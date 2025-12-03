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
        
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        // Ensure forward slashes on Android and iOS
        jobJsonPath = jobJsonPath.Replace("\\", "/");
#endif

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
        // Check if the path starts with "SharedDocs/" or "SharedDocs\" (case-insensitive)
        else if (relativePath.StartsWith("SharedDocs/", StringComparison.OrdinalIgnoreCase) || 
                 relativePath.StartsWith("SharedDocs\\", StringComparison.OrdinalIgnoreCase))
        {
            // On Android, we need to be careful with Path.Combine if the path already contains separators
            // relativePath might be "SharedDocs/filename.md"
            // Application.streamingAssetsPath on Android is "jar:file://.../assets"
            
            // If we use Path.Combine, it might use backslashes on Windows editor which is fine,
            // but on Android we want forward slashes.
            
            // Let's construct the path manually to ensure forward slashes for Android/iOS consistency
            // relativePath is expected to be like "SharedDocs/file.md"
            
            // Remove any leading slash/backslash just in case
            string cleanRelativePath = relativePath.TrimStart('/', '\\');
            
            fullPath = Path.Combine(Application.streamingAssetsPath, cleanRelativePath);
        }
        else
        {
            // Handle nested folders in JobFolder (e.g. CREWLIFE/CLAIMS)
            // If JobFolder contains slashes, Path.Combine might fail on Android if not handled carefully
            // But usually Path.Combine(base, nested, file) works if base is clean.
            
            // However, if relativePath itself contains slashes (e.g. "SubFolder/file.md"), 
            // we need to ensure separators are correct.
            
            fullPath = Path.Combine(Application.streamingAssetsPath, JobFolder, relativePath);
        }
        
        // Fix for Android: Ensure no backslashes in the final path if it's a URL
        // Path.Combine might introduce backslashes on Windows Editor, which is fine,
        // but on Android device, we want forward slashes for the jar:file:// URL.
        // The ToPathUrl method handles the prefix, but let's ensure the path part is clean.
        
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        fullPath = fullPath.Replace("\\", "/");
#endif
        
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
        // If the path contains slashes, it's likely a nested path (e.g. CrewLife/Claims)
        // We should NOT uppercase the whole thing because folder names on Android are case-sensitive.
        // However, we still want to support case-insensitive shortcuts for the root part.
        
        string input = jobFolder.Trim();
        string upperInput = input.ToUpper();
        
        // Special handling for shortcuts (Root Level)
        if (upperInput == "TE" || upperInput == "T&E" || upperInput == "TRAIN AND ENGINE" || upperInput == "TRAIN & ENGINE")
        {
            JobFolder = "TE_Guide";
        }
        else if (upperInput == "HELP")
        {
            JobFolder = "Help";
        }
        else if (upperInput == "PAYROLL" || upperInput == "PAYROLL_INFO" || upperInput == "PAY ROLL" || upperInput == "PAYROLL INFO" || upperInput == "PAY" || upperInput == "FUCKIN MONEY" || upperInput == "MONEY" || upperInput == "FUCKING MONEY")
        {
            JobFolder = "Payroll_Info";
        }
        else if (upperInput == "MAINFRAME" || upperInput == "MAIN FRAME" || upperInput == "MAIN" || upperInput == "FRAME" || upperInput == "MF")
        {
            JobFolder = "Mainframe";
        }
        else if (upperInput == "CREWLIFE" || upperInput == "CREW LIFE" || upperInput == "CREW" || upperInput == "LIFE" || upperInput == "CL")
        {
            JobFolder = "CrewLife";
        }
        else if (upperInput == "MRT" || upperInput == "MOBILE RAIL TOOL" || upperInput == "RAIL TOOL" || upperInput == "RAIL")
        {
            JobFolder = "MRT";
        }
        else if (upperInput == "YES" || upperInput == "YARD ENTERPRISE SYSTEM" || upperInput == "YARD" || upperInput == "SYSTEM")
        {
            JobFolder = "YES";
        }
        else if (upperInput == "DA" || upperInput == "DIRECT ACCESS" || upperInput == "DIRECT" || upperInput == "ACCESS")
        {
            JobFolder = "DirectAccess";
        }
        else if (upperInput == "MISC" || upperInput == "MISCELLANEOUS")
        {
            JobFolder = "Miscellaneous";
        }
        else if (upperInput == "OTR" || upperInput == "OVER THE ROAD" || upperInput == "ROAD" || upperInput == "AWAY" || upperInput == "OUT OF TOWN" || upperInput == "OVER" || upperInput == "ROAD TRAIN")
        {
            JobFolder = "OverTheRoad";
        }
        else if (upperInput == "UNION" || upperInput == "UN" || upperInput == "UNI" || upperInput == "UNIO" || upperInput == "SMART")
        {
            JobFolder = "Union";
        }
        else
        {
            // If it's not a shortcut, use the input as is (preserving case for nested paths)
            // But if it's a simple root folder like "y197", we might want to uppercase it if that's the convention
            // The convention seems to be that Job IDs (Y197) are uppercase, but folders like CrewLife are CamelCase.
            
            // If it contains a slash, assume it's a constructed path from the UI and trust its casing.
            if (input.Contains("/") || input.Contains("\\"))
            {
                JobFolder = input;
            }
            else
            {
                // If it's a single word, try to be smart.
                // If it looks like a Job ID (starts with Y), uppercase it.
                if (upperInput.StartsWith("Y"))
                {
                    JobFolder = upperInput;
                }
                else
                {
                    // For other single words, we might need to check if they exist or just use as is.
                    // Previously we uppercased everything.
                    // If we uppercase "CrewLife", it becomes "CREWLIFE", which fails.
                    // But "CrewLife" is handled by the shortcut above.
                    
                    // If the user types "Claims" directly (if that's supported), we might have an issue.
                    // But usually they type "Y197" or "CrewLife".
                    
                    // Let's default to preserving case if it's not a known shortcut/pattern.
                    // But wait, if they type "y197", we want "Y197".
                    // If they type "crewlife", we want "CrewLife" (handled above).
                    
                    // If they type "SomeFolder", we probably want "SomeFolder".
                    
                    // Let's stick to: if it has a slash, trust it. If not, uppercase it (legacy behavior for Job IDs).
                    JobFolder = upperInput;
                }
            }
        }
        StartCoroutine(LoadJobCoroutine());
    }
}
