using UnityEngine;

/// <summary>
/// Small starter script for mobile builds. Attach to an initial GameObject in my main scene.
/// Detects platform and shows a simple message. Expand for touch controls, orientation, input, etc.
/// </summary>
public class MobileStarter : MonoBehaviour
{
    void Awake()
    {
        Debug.Log($"Platform: {Application.platform}");
        Debug.Log($"Unity Version: {Application.unityVersion}");
        SetupQualityAndOrientation();
    }

    void SetupQualityAndOrientation()
    {
        // Example: lock to portrait for phones by default
        Screen.orientation = ScreenOrientation.Portrait;
        // Reduce target frame rate on mobile to save battery (adjust as needed)
        Application.targetFrameRate = 60;
        // Example quality setting
        QualitySettings.vSyncCount = 0;
    }

    void Update()
    {
        // Simple example handling first touch
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log($"Touch at {t.position}");
            }
        }
    }
}