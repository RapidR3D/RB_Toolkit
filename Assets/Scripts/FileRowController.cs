using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using UnityEngine.UIElements;

// Simple helper for FileRow prefab
public class FileRowController : MonoBehaviour
{
    public TMP_Text Label;
    public Button LoadButton;
    public string FileKey;

    // called to initialize the row
    public void Setup(string fileKey, string displayText)
    {
        FileKey = fileKey;
        if (Label != null) Label.text = displayText;
        if (LoadButton != null)
        {
            LoadButton.onClick.RemoveAllListeners();
            LoadButton.onClick.AddListener(() => UIManager.Instance.ShowFile(FileKey));
            LoadButton.onClick.AddListener(()=> Debug.Log($"FileRowController: clicked button for file '{FileKey}'"));
            
        }
    }
}