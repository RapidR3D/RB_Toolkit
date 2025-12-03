using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;



// Attach this to an empty GameObject. Set JobFolder to the folder name under StreamingAssets that contains job.json.
public class JobDataLoader : MonoBehaviour
{
    [Tooltip("Folder name under StreamingAssets that contains job.json and the referenced files (e.g., Y197)")]
    public string JobFolder = "Help";

    [Tooltip("job.json filename (relative to StreamingAssets/JobFolder)")]
    public string JobJsonFile = "job.json";

    [Tooltip("Auto-load on Start")]
    public bool LoadOnStart = true;

    public JobData LoadedJob;
    // Dictionary mapping filename -> content (markdown or csv raw text)
    public Dictionary<string, string> LoadedFiles = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

    // Event invoked when load completes (successful or not). Subscribers can bind when ready.
    public event Action<JobData, Dictionary<string, string>> JobLoaded;

    void Start()
    {
        if (LoadOnStart) StartCoroutine(LoadJobCoroutine());
    }

    public IEnumerator LoadJobCoroutine()
    {
        LoadedJob = null;
        LoadedFiles.Clear();

        string basePath = Path.Combine(Application.streamingAssetsPath, JobFolder);
        string jobJsonPath = Path.Combine(basePath, JobJsonFile);

        string jobJsonText = null;
        // streamingAssetsPath may require UnityWebRequest on some platforms (Android)
        string url = ToPathUrl(jobJsonPath);
        using (var uwr = UnityWebRequest.Get(url))
        {
            yield return uwr.SendWebRequest();
#if UNITY_2020_1_OR_NEWER
            if (uwr.result != UnityWebRequest.Result.Success)
#else
            if (uwr.isNetworkError || uwr.isHttpError)
#endif
            {
                Debug.LogError($"Failed to load job.json from {url}: {uwr.error}");
                // Fire event even on failure so listeners can react
                JobLoaded?.Invoke(null, LoadedFiles);
                yield break;
            }
            jobJsonText = uwr.downloadHandler.text;
        }

        try
        {
            LoadedJob = JsonUtility.FromJson<JobData>(jobJsonText);
            if (LoadedJob == null)
            {
                Debug.LogError("Failed to deserialize job.json (null). Check JSON format.");
                JobLoaded?.Invoke(null, LoadedFiles);
                yield break;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to parse job.json: {ex}");
            JobLoaded?.Invoke(null, LoadedFiles);
            yield break;
        }

        // Collect references to files from job object
        var referencedFiles = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

        if (LoadedJob.sections != null)
            foreach (var s in LoadedJob.sections) if (!string.IsNullOrEmpty(s.file)) referencedFiles.Add(s.file);

        if (LoadedJob.tables != null)
            foreach (var t in LoadedJob.tables) if (!string.IsNullOrEmpty(t.file)) referencedFiles.Add(t.file);

        if (LoadedJob.procedures != null)
            foreach (var p in LoadedJob.procedures) if (!string.IsNullOrEmpty(p.file)) referencedFiles.Add(p.file);

        if (LoadedJob.images != null)
            foreach (var img in LoadedJob.images) if (!string.IsNullOrEmpty(img.file)) referencedFiles.Add(img.file);

        // Also check for files in links (if they are local files, not URLs)
        if (LoadedJob.links != null)
            foreach (var link in LoadedJob.links) 
                if (!string.IsNullOrEmpty(link.file) && !link.file.StartsWith("http") && !link.file.StartsWith("www")) 
                    referencedFiles.Add(link.file);

        // Also attempt to load any other files in the folder (optional)
        foreach (var file in referencedFiles)
        {
            string fileUrl = GetUrlForFile(file);
            using (var uwr = UnityWebRequest.Get(fileUrl))
            {
                yield return uwr.SendWebRequest();
#if UNITY_2020_1_OR_NEWER
                if (uwr.result != UnityWebRequest.Result.Success)
#else
                if (uwr.isNetworkError || uwr.isHttpError)
#endif
                {
                    Debug.LogWarning($"Could not load referenced file {file} ({fileUrl}): {uwr.error}");
                    continue;
                }
                var content = uwr.downloadHandler.text;
                // Store using the original file key (may include subfolders)
                LoadedFiles[file] = content;
                // Also store using the filename-only key so lookups like "summary.md" succeed
                try
                {
                    var nameOnly = Path.GetFileName(file);
                    if (!string.IsNullOrEmpty(nameOnly) && !LoadedFiles.ContainsKey(nameOnly))
                        LoadedFiles[nameOnly] = content;
                }
                catch (Exception) { /* ignore Path issues */ }
            }
        }

        // Also add job.json content itself
        LoadedFiles[JobJsonFile] = jobJsonText;
        // And also add filename-only for job.json if different
        try
        {
            var jname = Path.GetFileName(JobJsonFile);
            if (!LoadedFiles.ContainsKey(jname))
                LoadedFiles[jname] = jobJsonText;
        }
        catch (Exception) { }

        Debug.Log($"Loaded job {LoadedJob.jobNumber} - {LoadedJob.jobName}. Files loaded: {LoadedFiles.Count}");
        foreach (var kvp in LoadedFiles)
        {
            Debug.Log($"Loaded File Key: {kvp.Key}");
        }

        // Notify subscribers that load finished (pass both job and files)
        JobLoaded?.Invoke(LoadedJob, LoadedFiles);

        // Optionally notify other logic via virtual method
        OnLoaded();
    }

    protected virtual void OnLoaded()
    {
        // This forces ANY FileBrowserController (or anything else) that might have missed the event to rebuild
        Debug.Log($"[JobDataLoader] OnLoaded() called - forcing UI refresh for {LoadedJob?.jobNumber}");
    
        // Find every FileBrowserController in the scene and force it to rebuild the list
        var browsers = FindObjectsOfType<FileBrowserController>();
        foreach (var browser in browsers)
        {
            browser.BuildList();
        }
    }

    public void LoadImage(string relativePath, Action<Texture2D> onSuccess)
    {
        StartCoroutine(LoadImageCoroutine(relativePath, onSuccess));
    }

    private IEnumerator LoadImageCoroutine(string relativePath, Action<Texture2D> onSuccess)
    {
        string url = GetUrlForFile(relativePath);

        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            yield return uwr.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
            if (uwr.result != UnityWebRequest.Result.Success)
#else
            if (uwr.isNetworkError || uwr.isHttpError)
#endif
            {
                Debug.LogError($"Failed to load image {url}: {uwr.error}");
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                onSuccess?.Invoke(texture);
            }
        }
    }

    string GetUrlForFile(string relativePath)
    {
        string fullPath;
        // Check if the path starts with "Shared/" or "Shared\" (case-insensitive)
        if (relativePath.StartsWith("Shared/", StringComparison.OrdinalIgnoreCase) || 
            relativePath.StartsWith("Shared\\", StringComparison.OrdinalIgnoreCase))
        {
            fullPath = Path.Combine(Application.streamingAssetsPath, relativePath);
        }
        else
        {
            fullPath = Path.Combine(Application.streamingAssetsPath, JobFolder, relativePath);
        }
        return ToPathUrl(fullPath);
    }

    string ToPathUrl(string path)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // On Android, streamingAssetsPath is inside the APK, use "jar:file://" + path
        return path;
#else
        // For other platforms (and editor), path prefixed with file:// works
        if (path.StartsWith("http://") || path.StartsWith("https://") || path.StartsWith("file://"))
            return path;
        return "file://" + path;
#endif
    }
    
    public void LoadJobFromInputField(string jobFolder)
    {
        // Convert input to uppercase to handle case-insensitivity (e.g., y197 -> Y197)
        string input = jobFolder.Trim().ToUpper();
        
        // Special handling for shortcuts
        if (input == "TE" || input == "T&E" || input == "TRAIN AND ENGINE" || input == "TRAIN & ENGINE")
        {
            JobFolder = "TE_Guide";
        }
        else if (input == "HELP")
        {
            JobFolder = "Help";
        }
        else if (input == "PAYROLL" || input == "PAYROLL_INFO" || input == "PAY ROLL" || input == "PAYROLL INFO")
        {
            JobFolder = "Payroll_Info";
        }
        else if (input == "MAINFRAME" || input == "MAIN FRAME")
        {
            JobFolder = "Mainframe";
        }
        else if (input == "CREWLIFE" || input == "CREW LIFE")
        {
            JobFolder = "CrewLife";
        }
        else if (input == "MRT" || input == "MOBILE RAIL TOOL")
        {
            JobFolder = "MRT";
        }
        else if (input == "YES" || input == "YARD ENTERPRISE SYSTEM")
        {
            JobFolder = "YES";
        }
        else if (input == "DA" || input == "DIRECT ACCESS")
        {
            JobFolder = "DirectAccess";
        }
        else if (input == "MISC" || input == "MISCELLANEOUS")
        {
            JobFolder = "Miscellaneous";
        }
        else
        {
            JobFolder = input;
        }
        StartCoroutine(LoadJobCoroutine());
    }
}
