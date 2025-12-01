using UnityEngine;
using TMPro;
using UnityEngine.UI;
using MarkdownToUnity; 
using System.Collections.Generic;
using MarkdownToUnity.Runtime; 

public class FileDisplayController : MonoBehaviour
{
    [Header("Panels")]
    public GameObject MarkdownPanel;
    public MarkdownRenderer MarkdownRendererComponent;

    public GameObject ContactsPanel;
    public RectTransform ContactsContentParent;
    public GameObject ContactRowPrefab;

    [Header("Title")]
    public TextMeshProUGUI TitleTMP;

    private void Start() => Clear();

    public void Clear()
    {
        if (TitleTMP != null) TitleTMP.text = "";
        if (MarkdownPanel != null) MarkdownPanel.SetActive(false);
        if (ContactsPanel != null) ContactsPanel.SetActive(false);
    }

    public void DisplayMarkdown(string md, string key = "")
    {
        if (MarkdownPanel != null) MarkdownPanel.SetActive(true);
        if (ContactsPanel != null) ContactsPanel.SetActive(false);

        if (TitleTMP != null) TitleTMP.text = NiceName(key);
        
        if (MarkdownRendererComponent != null)
        {
            TextAsset mdAsset = new TextAsset(md);
            MarkdownRendererComponent.Render(mdAsset);
        }
        else
        {
            Debug.LogError("[FileDisplayController] MarkdownRendererComponent not assigned!");
        }
    }

    public void DisplayCsv(string csv, string key = "")
    {
        if (ContactsPanel != null) ContactsPanel.SetActive(true);
        if (MarkdownPanel != null) MarkdownPanel.SetActive(false);

        if (TitleTMP != null) TitleTMP.text = NiceName(key);

        // Clear old rows
        foreach (Transform t in ContactsContentParent)
            if (t != null) Destroy(t.gameObject);

        var rows = CSVParser.Parse(csv);
        foreach (var row in rows)
        {
            var go = Instantiate(ContactRowPrefab, ContactsContentParent, false);
            var ctrl = go.GetComponent<ContactRowController>();
            if (ctrl != null)
            {
                ctrl.Setup(
                    row.GetValueOrDefault("Category", ""),
                    row.GetValueOrDefault("Name", ""),
                    row.GetValueOrDefault("Phone", "")
                );
            }
        }
    }

    public void DisplayPlainText(string text)
    {
        // Fallback: Wrap plain text as a Markdown code block
        DisplayMarkdown("```\n" + text.EscapeForMarkdown() + "\n```");
    }

    private string NiceName(string key)
    {
        if (string.IsNullOrEmpty(key)) return "Document";

        string name = System.IO.Path.GetFileNameWithoutExtension(key);
        return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(
                   name.Replace("_", " ").Replace("-", " ")
               );
    }
}

// Tiny extension to safely escape text for the Markdown code blocks
public static class StringExtensions
{
    public static string EscapeForMarkdown(this string s)
    {
        if (string.IsNullOrEmpty(s)) return s;
        return s.Replace("`", "\\`").Replace("\\", "\\\\"); // Escape backticks and backslashes
    }
}

// ← ADDED: Fix for CSV row.GetValueOrDefault if my CSVParser doesn't have it
public static class DictionaryExtensions
{
    public static string GetValueOrDefault(this Dictionary<string, string> dict, string key, string defaultValue)
    {
        return dict.TryGetValue(key, out string val) ? val : defaultValue;
    }
}