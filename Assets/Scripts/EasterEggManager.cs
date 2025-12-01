using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Networking;

public class EasterEggManager : MonoBehaviour
{
    public enum EasterEggType
    {
        StaticImage,
        Animation
    }

    [Serializable]
    public class EasterEgg
    {
        public string triggerWord;
        public EasterEggType type;
        
        [Tooltip("Drag a Texture here OR use the File Name field below.")]
        public Texture2D staticImage;
        
        [Tooltip("Path relative to StreamingAssets (e.g., 'EasEgg/railroaded.png').")]
        public string fileName;
        
        public List<Texture2D> animationFrames;
        public float frameRate = 12f;
        
        [Tooltip("Drag an AudioClip here OR use the Sound File Name field below.")]
        public AudioClip soundEffect;
        
        [Tooltip("Path relative to StreamingAssets (e.g., 'EasEgg/sound.wav').")]
        public string soundFileName;
        
        [Tooltip("If true, the easter egg will loop until closed. If false, it plays once (for animation) or shows for a duration.")]
        public bool loop = true;
        public float duration = 3f; // For static images or non-looping animations
    }

    [Header("Configuration")]
    public List<EasterEgg> easterEggs = new List<EasterEgg>();
    
    [Header("UI References")]
    public UIDocument uiDocument;
    
    private VisualElement root;
    private VisualElement easterEggContainer;
    private Image easterEggImage;
    private Button closeButton;
    
    private AudioSource audioSource;
    private Coroutine animationCoroutine;
    private Coroutine autoCloseCoroutine;

    // Cache loaded textures to avoid reloading from disk every time
    private Dictionary<string, Texture2D> loadedTextures = new Dictionary<string, Texture2D>();
    // Cache loaded audio clips
    private Dictionary<string, AudioClip> loadedAudioClips = new Dictionary<string, AudioClip>();

    private void OnEnable()
    {
        if (uiDocument == null) uiDocument = GetComponent<UIDocument>();
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
    }

    public void Initialize(VisualElement rootElement)
    {
        root = rootElement;
        easterEggContainer = root.Q<VisualElement>("EasterEggContainer");
        easterEggImage = root.Q<Image>("EasterEggImage");
        closeButton = root.Q<Button>("EasterEggCloseButton");

        if (closeButton != null)
        {
            closeButton.clicked += CloseEasterEgg;
        }
        
        if (easterEggContainer != null)
        {
            easterEggContainer.style.display = DisplayStyle.None;
            // Allow clicking anywhere to close
            easterEggContainer.RegisterCallback<ClickEvent>(evt => CloseEasterEgg());
        }
    }

    public bool TryTriggerEasterEgg(string input)
    {
        if (string.IsNullOrEmpty(input)) return false;

        var egg = easterEggs.Find(e => e.triggerWord.Equals(input, StringComparison.OrdinalIgnoreCase));
        if (egg != null)
        {
            PlayEasterEgg(egg);
            return true;
        }
        return false;
    }

    private void PlayEasterEgg(EasterEgg egg)
    {
        if (easterEggContainer == null || easterEggImage == null)
        {
            Debug.LogError("Easter Egg UI not initialized!");
            return;
        }

        // Stop any previous execution
        StopAllCoroutines();
        
        easterEggContainer.style.display = DisplayStyle.Flex;
        
        StartCoroutine(PlayEasterEggRoutine(egg));
    }

    private IEnumerator PlayEasterEggRoutine(EasterEgg egg)
    {
        // Play Sound
        if (egg.soundEffect != null && audioSource != null)
        {
            audioSource.PlayOneShot(egg.soundEffect);
        }
        else if (!string.IsNullOrEmpty(egg.soundFileName) && audioSource != null)
        {
            // Start audio loading but don't wait for it to finish before showing image
            StartCoroutine(LoadAndPlayAudio(egg.soundFileName));
        }

        if (egg.type == EasterEggType.StaticImage)
        {
            Texture2D textureToDisplay = egg.staticImage;

            // If no direct reference, try loading from file
            if (textureToDisplay == null && !string.IsNullOrEmpty(egg.fileName))
            {
                yield return StartCoroutine(LoadTextureRoutine(egg.fileName, (tex) => textureToDisplay = tex));
            }

            if (textureToDisplay != null)
            {
                easterEggImage.image = textureToDisplay;
                if (!egg.loop)
                {
                    autoCloseCoroutine = StartCoroutine(AutoCloseRoutine(egg.duration));
                }
            }
            else
            {
                Debug.LogWarning($"Could not load image for easter egg: {egg.triggerWord}");
                CloseEasterEgg();
            }
        }
        else if (egg.type == EasterEggType.Animation)
        {
            animationCoroutine = StartCoroutine(PlayAnimationRoutine(egg));
        }
    }

    private IEnumerator LoadTextureRoutine(string relativePath, Action<Texture2D> onSuccess)
    {
        if (loadedTextures.ContainsKey(relativePath))
        {
            onSuccess?.Invoke(loadedTextures[relativePath]);
            yield break;
        }

        string fullPath = Path.Combine(Application.streamingAssetsPath, relativePath);
        string url = ToPathUrl(fullPath);

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
                onSuccess?.Invoke(null);
            }
            else
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(uwr);
                if (texture != null)
                {
                    loadedTextures[relativePath] = texture;
                    onSuccess?.Invoke(texture);
                }
            }
        }
    }

    private IEnumerator LoadAndPlayAudio(string relativePath)
    {
        if (loadedAudioClips.ContainsKey(relativePath))
        {
            audioSource.PlayOneShot(loadedAudioClips[relativePath]);
            yield break;
        }

        string fullPath = Path.Combine(Application.streamingAssetsPath, relativePath);
        string url = ToPathUrl(fullPath);

        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(url, AudioType.UNKNOWN))
        {
            yield return www.SendWebRequest();

#if UNITY_2020_1_OR_NEWER
            if (www.result != UnityWebRequest.Result.Success)
#else
            if (www.isNetworkError || www.isHttpError)
#endif
            {
                Debug.LogError($"Failed to load audio: {www.error} ({url})");
            }
            else
            {
                AudioClip clip = DownloadHandlerAudioClip.GetContent(www);
                if (clip != null)
                {
                    loadedAudioClips[relativePath] = clip;
                    audioSource.PlayOneShot(clip);
                }
                else
                {
                    Debug.LogError($"Downloaded audio content is null: {url}");
                }
            }
        }
    }

    string ToPathUrl(string path)
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        // On Android, streamingAssetsPath is inside the APK, use "jar:file://" + path
        return path;
#else
        // For other platforms (and editor), path prefixed with file:// works
        if (path.StartsWith("http://") || path.StartsWith("https://") || path.StartsWith("file://"))
            return path;
        return "file://" + path;
#endif
    }

    private IEnumerator PlayAnimationRoutine(EasterEgg egg)
    {
        if (egg.animationFrames == null || egg.animationFrames.Count == 0) yield break;

        float waitTime = 1f / egg.frameRate;
        int index = 0;

        while (true)
        {
            easterEggImage.image = egg.animationFrames[index];
            index++;

            if (index >= egg.animationFrames.Count)
            {
                if (egg.loop)
                {
                    index = 0;
                }
                else
                {
                    // Animation finished
                    yield return new WaitForSeconds(egg.duration); // Wait a bit after animation finishes
                    CloseEasterEgg();
                    yield break;
                }
            }

            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator AutoCloseRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        CloseEasterEgg();
    }

    private void CloseEasterEgg()
    {
        StopAllCoroutines();
        if (easterEggContainer != null)
        {
            easterEggContainer.style.display = DisplayStyle.None;
        }
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}
