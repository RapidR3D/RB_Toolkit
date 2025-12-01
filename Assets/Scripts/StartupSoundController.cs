using UnityEngine;

public class StartupSoundController : MonoBehaviour
{
    private void Start()
    {
        AudioClip clip = Resources.Load<AudioClip>("TrainHorn");
        if (clip != null)
        {
            Vector3 pos = Camera.main != null ? Camera.main.transform.position : transform.position;
            AudioSource.PlayClipAtPoint(clip, pos);
        }
        else
        {
            Debug.LogWarning("TrainHorn.wav not found in Resources");
        }
    }
}
