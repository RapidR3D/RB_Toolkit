using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Builds the file list from the JobDataLoader and job.json ordering
public class FileBrowserController : MonoBehaviour
{
    public JobDataLoader Loader;
    public RectTransform ContentParent; // hook to ScrollView Content
    public GameObject FileRowPrefab; // FileRow prefab (Button + TMP)
    public TMP_InputField SearchInput; // optional

    void Start()
    {
        if (Loader == null)
        {
            Debug.LogError("[FileBrowserController] Loader not assigned.");
            return;
        }
        // subscribe so I build when data loads
        Loader.JobLoaded += OnJobLoaded;

        // if it's already loaded, build immediately
        if (Loader.LoadedFiles != null && Loader.LoadedFiles.Count > 0)
            BuildList();
    }

    void OnDestroy()
    {
        if (Loader != null) Loader.JobLoaded -= OnJobLoaded;
    }

    void OnJobLoaded(JobData job, Dictionary<string, string> files)
    {
        BuildList();
    }

    public void BuildList()
    {
        Debug.Log($"[FileBrowserController] BuildList() called — LoadedFiles count: {Loader.LoadedFiles.Count}");

#if UNITY_EDITOR
        // To prevent inspector errors, deselect game objects before destroying them.
        bool selectionWasCleared = false;
        if (UnityEditor.Selection.activeGameObject != null)
        {
            foreach (Transform child in ContentParent)
            {
                if (UnityEditor.Selection.activeGameObject == child.gameObject)
                {
                    UnityEditor.Selection.activeGameObject = null;
                    selectionWasCleared = true;
                    break; // Exit loop once we've cleared selection
                }
            }
        }
        if (selectionWasCleared)
        {
            Debug.Log("Selection cleared to avoid inspector errors on object destruction.");
        }
#endif

        // In the editor, use DestroyImmediate to prevent inspector errors if a child object is selected.
        // At runtime, Destroy is sufficient and preferred.
#if UNITY_EDITOR
        // We need to copy the children to a temporary list because DestroyImmediate modifies the collection.
        var children = new List<GameObject>();
        foreach (Transform child in ContentParent)
        {
            children.Add(child.gameObject);
        }
        foreach (var child in children)
        {
            DestroyImmediate(child);
        }
#else
        // In the editor, use DestroyImmediate to prevent inspector errors if a child object is selected.
        // At runtime, Destroy is sufficient and preferred.
#if UNITY_EDITOR
        // We need to copy the children to a temporary list because DestroyImmediate modifies the collection.
        var children = new List<GameObject>();
        foreach (Transform child in ContentParent)
        {
            children.Add(child.gameObject);
        }
        foreach (var child in children)
        {
            DestroyImmediate(child);
        }
#else
        foreach (Transform t in ContentParent) Destroy(t.gameObject);
#endif
#endif

        // Prefer to order items by job metadata (sections, tables, procedures) if present
        var added = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase);

        if (Loader.LoadedJob != null)
        {
            if (Loader.LoadedJob.sections != null)
                foreach (var s in Loader.LoadedJob.sections)
                    AddRowFor(s.file, s.label, added);

            if (Loader.LoadedJob.tables != null)
                foreach (var t in Loader.LoadedJob.tables)
                    AddRowFor(t.file, t.name, added);

            if (Loader.LoadedJob.procedures != null)
                foreach (var p in Loader.LoadedJob.procedures)
                    AddRowFor(p.file, p.name, added);
        }

        // add any other files not referenced explicitly
        foreach (var kv in Loader.LoadedFiles)
        {
            if (added.Contains(kv.Key)) continue;
            var nameOnly = System.IO.Path.GetFileName(kv.Key);
            AddRowFor(kv.Key, nameOnly, added);
        }
    }

    void AddRowFor(string fileKey, string label, HashSet<string> added)
    {
        if (string.IsNullOrEmpty(fileKey)) return;
        if (added.Contains(fileKey)) return;

        var go = Instantiate(FileRowPrefab, ContentParent);
        var c = go.GetComponent<FileRowController>();
        if (c == null)
        {
            Debug.LogError("[FileBrowserController] FileRowPrefab missing FileRowController script.");
            return;
        }
        c.Setup(fileKey, label ?? System.IO.Path.GetFileName(fileKey));
        added.Add(fileKey);
        
        Debug.Log($"[FileBrowserController] Created row '{label}' — GameObject active: {go.activeInHierarchy}, Position: {go.transform.localPosition}");
    }
}