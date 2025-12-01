using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public FileDisplayController Display;

    void Awake()
    {
        Instance = this;
    }

    public void ShowFile(string key)
    {
        var content = FindObjectOfType<JobDataLoader>().LoadedFiles;
        if (content.TryGetValue(key, out string text))
        {
            if (key.EndsWith(".md", System.StringComparison.OrdinalIgnoreCase))
                Display.DisplayMarkdown(text, key);
            else if (key.EndsWith(".csv", System.StringComparison.OrdinalIgnoreCase))
                Display.DisplayCsv(text, key);
            else
                Display.DisplayPlainText(text);
        }
    }
}