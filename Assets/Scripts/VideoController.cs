using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UIElements;
using System.IO;
using System;

[RequireComponent(typeof(VideoPlayer), typeof(AudioSource))]
public class VideoController : MonoBehaviour
{
    public static VideoController Instance;

    private VideoPlayer videoPlayer;
    private AudioSource audioSource;
    private RenderTexture renderTexture;

    // UI Toolkit Elements
    private VisualElement videoContainer;
    private Image videoScreen;
    private Button closeButton;
    private Button playButton;
    private Button pauseButton;
    private Slider seekSlider;
    private UIDocument uiDocument;

    private bool isDraggingSlider = false;
    public event Action OnClose;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        videoPlayer = GetComponent<VideoPlayer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Call this method from your main UI controller after the UIDocument is ready.
    public void Initialize(UIDocument doc)
    {
        this.uiDocument = doc;
        var root = uiDocument.rootVisualElement;

        Debug.Log("VideoController: Initializing with UI Toolkit root.");

        videoContainer = root.Q<VisualElement>("VideoPlayerContainer");
        videoScreen = root.Q<Image>("VideoScreen");
        closeButton = root.Q<Button>("VideoCloseButton");
        playButton = root.Q<Button>("VideoPlayButton");
        pauseButton = root.Q<Button>("VideoPauseButton");
        seekSlider = root.Q<Slider>("VideoSeekSlider");

        if (videoContainer == null || videoScreen == null || closeButton == null)
        {
            Debug.LogError("VideoController: Could not find all required video UI elements in the UXML! Make sure 'VideoPlayerContainer', 'VideoScreen', and 'VideoCloseButton' exist.");
            return;
        }
        
        Debug.Log("VideoController: All UI Toolkit elements found successfully.");

        if (playButton != null) playButton.clicked += () => {
             if (!videoPlayer.isPlaying) videoPlayer.Play();
        };
        
        if (pauseButton != null) pauseButton.clicked += () => {
             if (videoPlayer.isPlaying) videoPlayer.Pause();
        };

        if (seekSlider != null) {
            seekSlider.RegisterValueChangedCallback(evt => {
                // This callback is triggered by user interaction (since we use SetValueWithoutNotify in Update)
                if (videoPlayer.frameCount > 0) {
                    videoPlayer.time = evt.newValue * videoPlayer.length;
                }
            });
            
            seekSlider.RegisterCallback<PointerDownEvent>(e => {
                isDraggingSlider = true;
                seekSlider.CapturePointer(e.pointerId);
            });
            
            seekSlider.RegisterCallback<PointerUpEvent>(e => {
                isDraggingSlider = false;
                seekSlider.ReleasePointer(e.pointerId);
            });
            
            seekSlider.RegisterCallback<PointerCancelEvent>(e => {
                isDraggingSlider = false;
                seekSlider.ReleasePointer(e.pointerId);
            });
        }

        videoPlayer.playOnAwake = false;
        videoPlayer.source = VideoSource.Url;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.SetTargetAudioSource(0, audioSource);
        videoPlayer.renderMode = VideoRenderMode.RenderTexture;

        if (renderTexture == null || !renderTexture.IsCreated())
        {
            renderTexture = new RenderTexture(1920, 1080, 24);
        }
        videoPlayer.targetTexture = renderTexture;
        
        videoScreen.image = renderTexture;

        // Rotate video screen 270 degrees to fix orientation
        videoScreen.style.rotate = new Rotate(new Angle(270, AngleUnit.Degree));

        closeButton.clicked -= StopVideo;
        closeButton.clicked += StopVideo;
        
        // Avoid duplicate event subscriptions for VideoPlayer
        videoPlayer.errorReceived -= OnVideoError;
        videoPlayer.errorReceived += OnVideoError;
        
        videoPlayer.prepareCompleted -= OnVideoPrepared;
        videoPlayer.prepareCompleted += OnVideoPrepared;

        videoContainer.style.display = DisplayStyle.None;
    }

    private void OnVideoError(VideoPlayer source, string message)
    {
        Debug.LogError("VideoPlayer Error: " + message);
    }

    public void PlayVideo(string relativePath)
    {
        if (videoContainer == null || videoPlayer == null)
        {
            Debug.LogError("VideoController is not properly initialized. Was Initialize() called from the main UI controller?");
            return;
        }

        string videoPath = Path.Combine(Application.streamingAssetsPath, relativePath).Replace("\\", "/");

        #if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            // On mobile, the path from StreamingAssets is used directly by VideoPlayer
        #else
            videoPath = "file://" + videoPath;
        #endif

        videoPlayer.url = videoPath;
        Debug.Log("VideoController: Attempting to play video from URL: " + videoPlayer.url);

        videoContainer.style.display = DisplayStyle.Flex;
        Debug.Log("VideoController: Preparing video...");
        videoPlayer.Prepare();
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        Debug.Log("VideoController: Video prepared. Playing now.");
        source.Play();
    }

    public void StopVideo()
    {
        if (videoPlayer != null && videoPlayer.isPlaying)
        {
            videoPlayer.Stop();
        }
        if (videoContainer != null)
        {
            videoContainer.style.display = DisplayStyle.None;
        }
        OnClose?.Invoke();
    }

    void Update()
    {
        if (videoPlayer != null && videoPlayer.isPlaying && !isDraggingSlider && seekSlider != null)
        {
             if (videoPlayer.length > 0)
                seekSlider.SetValueWithoutNotify((float)(videoPlayer.time / videoPlayer.length));
        }
    }

    void OnDestroy()
    {
        if (renderTexture != null)
        {
            renderTexture.Release();
        }
    }
}
