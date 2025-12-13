using UnityEngine;
using TMPro;

public class EnableRichText : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI[] textComponents = FindObjectsByType<TextMeshProUGUI>(FindObjectsSortMode.None);
        foreach (TextMeshProUGUI component in textComponents)
        {
            component.richText = true;
        }
    }
}
