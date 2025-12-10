using UnityEngine;
using TMPro;

public class EnableRichText : MonoBehaviour
{
    void Start()
    {
        TextMeshProUGUI[] textComponents = FindObjectsOfType<TextMeshProUGUI>();
        foreach (TextMeshProUGUI component in textComponents)
        {
            component.richText = true;
        }
    }
}
