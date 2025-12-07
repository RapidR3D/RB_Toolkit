using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class FixFileCasing
{
    [MenuItem("Tools/Fix File Casing")]
    public static void Fix()
    {
        string streamingAssetsPath = Application.streamingAssetsPath;
        string[] jobFiles = Directory.GetFiles(streamingAssetsPath, "job.json", SearchOption.AllDirectories);
        
        int fixedCount = 0;

        foreach (string jobFile in jobFiles)
        {
            string jobDir = Path.GetDirectoryName(jobFile);
            string jsonContent = File.ReadAllText(jobFile);
            
            JobData jobData = null;
            try
            {
                jobData = JsonUtility.FromJson<JobData>(jsonContent);
            }
            catch
            {
                Debug.LogError($"Failed to parse {jobFile}");
                continue;
            }

            if (jobData == null) continue;

            var filesToCheck = new List<string>();
            
            if (jobData.sections != null)
                foreach (var s in jobData.sections) if (!string.IsNullOrEmpty(s.file)) filesToCheck.Add(s.file);
            
            if (jobData.tables != null)
                foreach (var t in jobData.tables) if (!string.IsNullOrEmpty(t.file)) filesToCheck.Add(t.file);
                
            if (jobData.procedures != null)
                foreach (var p in jobData.procedures) if (!string.IsNullOrEmpty(p.file)) filesToCheck.Add(p.file);

            foreach (string relativePath in filesToCheck)
            {
                // Skip URLs
                if (relativePath.StartsWith("http")) continue;
                
                // Skip Shared files (assuming they are correct or handled separately)
                // Actually, we should check them too, but renaming Shared files might affect other jobs.
                // Let's focus on local files first (not starting with Shared/)
                if (relativePath.StartsWith("Shared/") || relativePath.StartsWith("Shared\\")) continue;
                if (relativePath.StartsWith("SharedDocs/") || relativePath.StartsWith("SharedDocs\\")) continue;

                string expectedPath = Path.Combine(jobDir, relativePath);
                string expectedFileName = Path.GetFileName(expectedPath);
                string dirPath = Path.GetDirectoryName(expectedPath);

                if (!Directory.Exists(dirPath)) continue;

                // Get actual files in the directory
                string[] actualFiles = Directory.GetFiles(dirPath);
                
                bool exactMatchFound = false;
                string caseMismatchFile = null;

                foreach (string actualFile in actualFiles)
                {
                    string actualFileName = Path.GetFileName(actualFile);
                    
                    if (actualFileName.Equals(expectedFileName, System.StringComparison.Ordinal))
                    {
                        exactMatchFound = true;
                        break;
                    }
                    
                    if (actualFileName.Equals(expectedFileName, System.StringComparison.OrdinalIgnoreCase))
                    {
                        caseMismatchFile = actualFile;
                    }
                }

                if (!exactMatchFound && caseMismatchFile != null)
                {
                    // Rename caseMismatchFile to expectedPath
                    Debug.Log($"Renaming {caseMismatchFile} to {expectedPath}");
                    
                    // On Windows, you can't rename to same name with different case directly sometimes.
                    // Move to temp then back.
                    string tempPath = caseMismatchFile + ".tmp";
                    File.Move(caseMismatchFile, tempPath);
                    File.Move(tempPath, expectedPath);
                    
                    fixedCount++;
                }
            }
        }
        
        AssetDatabase.Refresh();
        Debug.Log($"Fixed casing for {fixedCount} files.");
    }
}
