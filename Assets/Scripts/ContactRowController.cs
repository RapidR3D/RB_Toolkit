using UnityEngine;
using TMPro;

// Simple controller for ContactRow prefab
public class ContactRowController : MonoBehaviour
{
    public TextMeshProUGUI CategoryTMP;
    public TextMeshProUGUI NameTMP;
    public TextMeshProUGUI PhoneTMP;

    public void Setup(string category, string name, string phone)
    {
        if (CategoryTMP != null) CategoryTMP.text = category;
        if (NameTMP != null) NameTMP.text = name;
        if (PhoneTMP != null) PhoneTMP.text = phone;
    }
}