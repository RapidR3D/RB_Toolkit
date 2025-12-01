using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JobViewerTMP : MonoBehaviour
{
    public JobDataLoader Loader;

    [Header("UI (TextMeshProUGUI)")]
    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI SummaryText;
    public TextMeshProUGUI ContactsText;

    [Tooltip("Name of the summary markdown file referenced in job.json (e.g., summary.md)")]
    public string SummaryFileName = "summary.md";

    [Tooltip("Name of the contacts CSV referenced in job.json (e.g., contacts.csv)")]
    public string ContactsFileName = "contacts.csv";

    void OnEnable()
    {
        if (Loader == null)
        {
            Debug.LogError("[JobViewerTMP] Loader reference is null. Assign the JobDataLoader in the inspector.");
            return;
        }

        // Subscribe to the loader's event so that I'm notified when it finishes
        Loader.JobLoaded += OnJobLoaded;

        // If the loader has already loaded data, bind immediately
        if (Loader.LoadedJob != null && Loader.LoadedFiles != null && Loader.LoadedFiles.Count > 0)
        {
            Debug.Log("[JobViewerTMP] Loader already has data, binding now.");
            Bind();
        }
        else
        {
            Debug.Log("[JobViewerTMP] Waiting for loader to finish (subscribed to JobLoaded).");
        }
    }

    void OnDisable()
    {
        if (Loader != null)
            Loader.JobLoaded -= OnJobLoaded;
    }

    void OnJobLoaded(JobData job, Dictionary<string, string> files)
    {
        Debug.Log("[JobViewerTMP] Received JobLoaded event, binding UI.");
        // Defensive: update local loader state if needed, then bind
        Bind();
    }

    void Bind()
    {
        var job = Loader.LoadedJob;
        if (job == null)
        {
            Debug.LogError("[JobViewerTMP] LoadedJob is null in Bind().");
            return;
        }

        Debug.Log($"[JobViewerTMP] Binding job {job.jobNumber} - {job.jobName}. LoadedFiles: {Loader.LoadedFiles.Count}");
        foreach (var k in Loader.LoadedFiles.Keys)
            Debug.Log($"[JobViewerTMP] Loaded file: {k}");

        // Title
        if (TitleText != null)
        {
            TitleText.text = $"{job.jobNumber} - {job.jobName}";
            ApplyAndResize(TitleText);
        }
        else Debug.LogWarning("[JobViewerTMP] TitleText not assigned.");

        // Summary (allow matching by filename suffix in case Loader stored path prefixes)
        if (SummaryText != null)
        {
            if (TryGetLoadedFile(SummaryFileName, out var summary))
            {
                SummaryText.text = summary;
            }
            else
            {
                SummaryText.text = "(summary not found)";
                Debug.LogWarning($"[JobViewerTMP] Summary file '{SummaryFileName}' not found in LoadedFiles.");
            }
            ApplyAndResize(SummaryText);
        }
        else Debug.LogWarning("[JobViewerTMP] SummaryText not assigned.");

        // Contacts
        if (ContactsText != null)
        {
            if (TryGetLoadedFile(ContactsFileName, out var csv))
            {
                var rows = CSVParser.Parse(csv);
                ContactsText.text = FormatContacts(rows);
            }
            else
            {
                ContactsText.text = "(contacts not found)";
                Debug.LogWarning($"[JobViewerTMP] Contacts file '{ContactsFileName}' not found in LoadedFiles.");
            }
            ApplyAndResize(ContactsText);
        }
        else Debug.LogWarning("[JobViewerTMP] ContactsText not assigned.");
    }

    bool TryGetLoadedFile(string filename, out string content)
    {
        // Direct lookup
        if (Loader.LoadedFiles.TryGetValue(filename, out content))
            return true;

        // Fallback: find any key that ends with the filename (case-insensitive)
        foreach (var kv in Loader.LoadedFiles)
        {
            if (kv.Key != null && kv.Key.ToLower().EndsWith(filename.ToLower()))
            {
                content = kv.Value;
                return true;
            }
        }
        content = null;
        return false;
    }

    string FormatContacts(List<Dictionary<string, string>> rows)
    {
        if (rows == null || rows.Count == 0) return "(no contacts)";
        var sb = new System.Text.StringBuilder();
        foreach (var row in rows)
        {
            row.TryGetValue("Category", out var category);
            row.TryGetValue("Name", out var name);
            row.TryGetValue("Phone", out var phone);
            sb.AppendLine($"{category} — {name} — {phone}");
        }
        return sb.ToString();
    }

    void ApplyAndResize(TextMeshProUGUI tmp)
    {
        if (tmp == null) return;
        // force TMP to generate geometry
        tmp.ForceMeshUpdate();

        // compute preferred height for current width
        float width = tmp.rectTransform.rect.width;
        if (width <= 0f)
        {
            // If width is zero (not laid out yet), try a default or skip sizing
            Debug.LogWarning("[JobViewerTMP] TMP rect width is zero; cannot compute preferred height yet.");
            return;
        }

        Vector2 pref = tmp.GetPreferredValues(tmp.text, width, 0f);
        tmp.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Mathf.Ceil(pref.y));

        // If inside a layout group, force it to rebuild immediately so changes are visible
        var parent = tmp.rectTransform.parent as RectTransform;
        if (parent != null)
            LayoutRebuilder.ForceRebuildLayoutImmediate(parent);
    }
}