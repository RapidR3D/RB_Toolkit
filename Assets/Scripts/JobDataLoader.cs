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

    private JobManifest _manifest;

    void Start()
    {
        StartCoroutine(LoadManifestAndJob());
    }

    private IEnumerator LoadManifestAndJob()
    {
        // Load Manifest
        string manifestPath = Path.Combine(Application.streamingAssetsPath, "job_manifest.json");
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        manifestPath = manifestPath.Replace("\\", "/");
#endif
        string url = ToPathUrl(manifestPath);
        
        using (var uwr = UnityWebRequest.Get(url))
        {
            yield return uwr.SendWebRequest();
            if (uwr.result == UnityWebRequest.Result.Success)
            {
                try
                {
                    _manifest = JsonUtility.FromJson<JobManifest>(uwr.downloadHandler.text);
                    Debug.Log($"Loaded Job Manifest with {_manifest.directories.Count} entries.");
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Failed to parse job_manifest.json: {ex}");
                }
            }
            else
            {
                Debug.LogWarning($"Could not load job_manifest.json: {uwr.error}. Case-insensitive fallback will be disabled.");
            }
        }

        if (LoadOnStart) StartCoroutine(LoadJobCoroutine());
    }

    public IEnumerator LoadJobCoroutine()
    {
        LoadedJob = null;
        LoadedFiles.Clear();

        // Use manual path construction to ensure forward slashes on all platforms, especially Android
        string basePath = CombinePathUrl(Application.streamingAssetsPath, JobFolder);
        string jobJsonPath = CombinePathUrl(basePath, JobJsonFile);

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
        StartCoroutine(RefreshBrowsersCoroutine());
    }

    private IEnumerator RefreshBrowsersCoroutine()
    {
        // Wait for the end of the frame to allow the inspector to update
        yield return new WaitForEndOfFrame();

        var browsers = FindObjectsOfType<FileBrowserController>();
        foreach (var browser in browsers)
        {
            if (browser != null) // Check if the browser object is still valid
            {
                browser.BuildList();
            }
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
            fullPath = CombinePathUrl(Application.streamingAssetsPath, relativePath);
        }
        else
        {
            // Handle nested folders in JobFolder (e.g. CREWLIFE/CLAIMS)
            fullPath = CombinePathUrl(Application.streamingAssetsPath, JobFolder, relativePath);
        }
        
        return ToPathUrl(fullPath);
    }

    // Helper to combine paths with forward slashes, safe for Android jar:file:// paths
    private string CombinePathUrl(params string[] parts)
    {
        if (parts == null || parts.Length == 0) return "";
        
        string result = parts[0].Replace("\\", "/");
        
        for (int i = 1; i < parts.Length; i++)
        {
            string p = parts[i];
            if (string.IsNullOrEmpty(p)) continue;
            
            p = p.Replace("\\", "/");
            
            // Ensure separator
            if (!result.EndsWith("/")) result += "/";
            
            // Remove leading slash from part to avoid double slash
            if (p.StartsWith("/")) p = p.Substring(1);
            
            result += p;
        }
        
        return result;
    }

    string ToPathUrl(string path)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // On Android, streamingAssetsPath is inside the APK, use "jar:file://" + path
        // However, if path already starts with jar:file://, we don't need to add it.
        // Application.streamingAssetsPath usually includes it, but let's be safe.
        if (!path.StartsWith("jar:file://"))
        {
             // If it starts with file://, replace it? No, jar:file:// expects a path inside apk.
             // But we are constructing paths from Application.streamingAssetsPath which HAS it.
             // So usually we just return path.
             return path;
        }
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
        if (upperInput == "TE" || upperInput == "T&E" || upperInput == "TRAIN AND ENGINE" || upperInput == "TRAIN & ENGINE" || upperInput == "TE_GUIDE")
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
        else if (upperInput == "DA" || upperInput == "DIRECT ACCESS" || upperInput == "DIRECT" || upperInput == "ACCESS" || upperInput == "DIRECTACCESS")
        {
            JobFolder = "DirectAccess";
        }
        else if (upperInput == "MISC" || upperInput == "MISCELLANEOUS")
        {
            JobFolder = "Miscellaneous";
        }
        else if (upperInput == "OTR" || upperInput == "OVER THE ROAD" || upperInput == "ROAD" || upperInput == "AWAY" || upperInput == "OUT OF TOWN" || upperInput == "OVER" || upperInput == "ROAD TRAIN")
        {
            JobFolder = "Miscellaneous/OverTheRoad";
        }
        else if (upperInput == "OVERTHEROAD")
        {
            JobFolder = "Miscellaneous/OverTheRoad";
        }
        else if (upperInput == "UNION" || upperInput == "UN" || upperInput == "UNI" || upperInput == "UNIO" || upperInput == "SMART")
        {
            JobFolder = "Miscellaneous/Union";
        }
        else
        {
            // Try to resolve using manifest first (Case-Insensitive Lookup)
            bool foundInManifest = false;
            if (_manifest != null && _manifest.directories != null)
            {
                // Normalize input slashes
                string normalizedInput = input.Replace("\\", "/");
                
                // Try exact match first
                foreach (var dir in _manifest.directories)
                {
                    if (dir.Equals(normalizedInput, StringComparison.OrdinalIgnoreCase))
                    {
                        JobFolder = dir; // Use the correct casing from manifest
                        foundInManifest = true;
                        break;
                    }
                }
                
                // If not found, and input doesn't have slashes, maybe it's a root folder?
                if (!foundInManifest && !normalizedInput.Contains("/"))
                {
                    foreach (var dir in _manifest.directories)
                    {
                        // Check if the directory name matches the input
                        // But manifest contains relative paths like "Miscellaneous/OverTheRoad"
                        // If input is "OverTheRoad", we might want to match?
                        // But usually input is the full relative path OR a root folder.
                        
                        // If input is "y199p", and manifest has "Y199P", it matches.
                        if (dir.Equals(normalizedInput, StringComparison.OrdinalIgnoreCase))
                        {
                            JobFolder = dir;
                            foundInManifest = true;
                            break;
                        }
                    }
                }
            }

            if (!foundInManifest)
            {
                // Fallback to old logic if manifest not loaded or not found
                if (input.Contains("/") || input.Contains("\\"))
                {
                    JobFolder = input;
                }
                else
                {
                    if (upperInput.StartsWith("Y"))
                    {
                        JobFolder = upperInput;
                    }
                    else
                    {
                        JobFolder = upperInput;
                    }
                }
            }
        }
        StartCoroutine(LoadJobCoroutine());
    }
}
