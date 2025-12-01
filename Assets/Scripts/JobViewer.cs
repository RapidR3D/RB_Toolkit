using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Simple UI binder using TextMeshPro. Drop this on a GameObject, assign the loader, and hook TMP UI fields to display content.
public class JobViewer : MonoBehaviour
{
    public JobDataLoader Loader;

    [Header("UI (TextMeshPro)")]
    public TMP_Text TitleText;
    public TMP_Text SummaryText;
    public TMP_Text ContactsText;

    [Tooltip("Name of the summary markdown file referenced in job.json (e.g., summary.md)")]
    public string SummaryFileName = "summary.md";

    [Tooltip("Name of the contacts CSV referenced in job.json (e.g., contacts.csv)")]
    public string ContactsFileName = "contacts.csv";

    void OnEnable()
    {
        if (Loader == null)
        {
            Debug.LogError("JobViewer requires a JobDataLoader reference.");
            return;
        }
        // If already loaded, bind immediately
        if (Loader.LoadedJob != null)
            Bind();
        else
            // Start a small polling coroutine to wait for the loader to finish
            Loader.StartCoroutine(WaitAndBind());
    }

    System.Collections.IEnumerator WaitAndBind()
    {
        // Wait until the loader has data or timeout
        float timeout = 5f;
        float t = 0f;
        while (Loader.LoadedJob == null && t < timeout)
        {
            t += Time.deltaTime;
            yield return null;
        }
        if (Loader.LoadedJob == null)
        {
            Debug.LogWarning("JobViewer: loader did not finish in time.");
            yield break;
        }
        Bind();
    }

    void Bind()
    {
        var job = Loader.LoadedJob;
        if (TitleText != null)
            TitleText.text = $"{job.jobNumber} - {job.jobName}";

        // Summary file content (Markdown). For now display raw Markdown.
        if (SummaryText != null)
        {
            if (Loader.LoadedFiles.TryGetValue(SummaryFileName, out var summary))
                SummaryText.text = summary;
            else
                SummaryText.text = "(summary not found)";
        }

        if (ContactsText != null)
        {
            if (Loader.LoadedFiles.TryGetValue(ContactsFileName, out var csv))
            {
                var rows = CSVParser.Parse(csv);
                ContactsText.text = FormatContacts(rows);
            }
            else
            {
                ContactsText.text = "(contacts not found)";
            }
        }
    }

    string FormatContacts(List<Dictionary<string, string>> rows)
    {
        if (rows == null || rows.Count == 0) return "(no contacts)";
        var sb = new System.Text.StringBuilder();
        foreach (var row in rows)
        {
            // Try to print Category, Name, Phone if present
            row.TryGetValue("Category", out var category);
            row.TryGetValue("Name", out var name);
            row.TryGetValue("Phone", out var phone);
            // Use simple spacing; TextMeshPro will render tabs/spacing consistently.
            sb.AppendLine($"{category}\t{name}\t{phone}");
        }
        return sb.ToString();
    }
}