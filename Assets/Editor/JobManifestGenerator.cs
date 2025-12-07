using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class JobManifestGenerator
{
    [MenuItem("Tools/Generate Job Manifest")]
    public static void Generate()
    {
        string streamingAssetsPath = Application.streamingAssetsPath;
        var manifest = new JobManifest();
        
        // Get all job.json files
        string[] jobFiles = Directory.GetFiles(streamingAssetsPath, "job.json", SearchOption.AllDirectories);
        
        foreach (string file in jobFiles)
        {
            string dir = Path.GetDirectoryName(file);
            
            // Calculate relative path manually to be safe across Unity versions/platforms
            string relativeDir = dir.Substring(streamingAssetsPath.Length);
            
            // Trim leading slash/backslash
            relativeDir = relativeDir.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            
            // Normalize slashes to forward slash
            relativeDir = relativeDir.Replace("\\", "/");
            
            if (!string.IsNullOrEmpty(relativeDir))
            {
                manifest.directories.Add(relativeDir);
            }
        }
        
        string json = JsonUtility.ToJson(manifest, true);
        File.WriteAllText(Path.Combine(streamingAssetsPath, "job_manifest.json"), json);
        
        AssetDatabase.Refresh();
        Debug.Log($"Generated job_manifest.json with {manifest.directories.Count} entries.");
    }
}
