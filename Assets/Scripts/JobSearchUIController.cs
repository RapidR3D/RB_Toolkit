using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UIElements;
using BrewedInk.MarkdownSupport;

public class JobSearchUIController : MonoBehaviour
{
    [Header("References")]
    public UIDocument uiDocument;
    public JobDataLoader jobDataLoader;
    public EasterEggManager easterEggManager;

    // UI Elements
    private TextField searchField;
    private Button searchButton;
    private VisualElement jobDetailsArea;
    private Label jobTitle;
    private Label jobSubtitle;
    private ListView sectionList;
    private ScrollView detailView;
    private TextField contentSearchField;
    
    // Search Navigation Elements
    private VisualElement searchControlsContainer;
    private Label matchCountLbl;
    private Button prevMatchBtn;
    private Button nextMatchBtn;

    // Full Screen UI Elements
    private VisualElement fullScreenContainer;
    private Image fullImage;
    private Button closeButton;
    private Button zoomInBtn;
    private Button zoomOutBtn;

    // Zoom/Pan State
    private float currentZoom = 1f;
    private bool isPanning = false;
    private Vector2 panStart;
    private Vector3 imageStartPos;

    // Audio
    private AudioSource audioSource;
    private AudioClip clickSound;

    // Fonts
    private Font _systemFont;

    // Data
    private List<SectionItem> allSectionItems = new List<SectionItem>();
    private List<SectionItem> currentSectionItems = new List<SectionItem>();
    private string currentSearchTerm = "";
    private int currentMatchIndex = -1;
    private int totalMatches = 0;
    private Stack<string> navigationHistory = new Stack<string>();

    private const string ActiveMatchColor = "#4CAF5066";
    private const string InactiveMatchColor = "#FFFF0080";

    private enum ItemType { Text, Image, Video, MainframeGuide }

    private class SectionItem
    {
        public string DisplayName;
        public string FileKey;
        public ItemType Type;
        public JobData GuideData; // For Mainframe Guides
    }

    // UI Elements
    private Button backButton;
    private Button homeButton;

    private void Start()
    {
        // Ensure VideoController is initialized. 
        // We do this in Start to ensure VideoController.Awake has run.
        if (VideoController.Instance != null)
        {
            VideoController.Instance.Initialize(uiDocument);
        }
        else
        {
            // Fallback: Try to find it if Instance is not set yet (unlikely in Start, but possible if disabled)
            var vc = FindFirstObjectByType<VideoController>();
            if (vc != null)
            {
                vc.Initialize(uiDocument);
            }
            else
            {
                Debug.LogError("VideoController not found in scene!");
            }
        }
    }

    private void OnEnable()
    {
        Debug.Log("JobSearchUIController: OnEnable called.");
        if (uiDocument == null) uiDocument = GetComponent<UIDocument>();
        if (jobDataLoader == null) 
        {
            jobDataLoader = FindFirstObjectByType<JobDataLoader>();
            if (jobDataLoader == null) Debug.LogError("JobSearchUIController: JobDataLoader not found!");
            else Debug.Log("JobSearchUIController: JobDataLoader found.");
        }
        if (easterEggManager == null) easterEggManager = GetComponent<EasterEggManager>();
        if (easterEggManager == null) easterEggManager = gameObject.AddComponent<EasterEggManager>();

        // Setup Audio
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
        
        clickSound = Resources.Load<AudioClip>("click");
        if (clickSound == null) Debug.LogWarning("Could not load 'click.ogg' from Resources.");

        // Load System Font for Mobile
        LoadSystemFont();

        if (uiDocument == null)
        {
            Debug.LogError("UIDocument component not found!");
            return;
        }

        var root = uiDocument.rootVisualElement;
        if (root == null)
        {
            Debug.LogError("Root VisualElement is null!");
            return;
        }

        // Register link click handler for UMarkdown
        UMarkdown.OnLinkClick += HandleLinkClick;

        searchField = root.Q<TextField>("SearchField");
        if (searchField != null)
        {
            // Play sound on input change
            searchField.RegisterCallback<ChangeEvent<string>>(evt => PlayClickSound());
            
            // Add click sound when typing
            searchField.RegisterCallback<KeyDownEvent>(evt => PlayClickSound());
        }

        backButton = root.Q<Button>("BackButton");
        if (backButton != null)
        {
            backButton.clicked += OnBackClicked;
            backButton.style.display = DisplayStyle.None; // Hide initially
        }

        homeButton = root.Q<Button>("HomeButton");
        if (homeButton != null)
        {
            homeButton.clicked += OnHomeClicked;
            homeButton.style.display = DisplayStyle.None; // Hide initially
        }

        searchButton = root.Q<Button>("SearchButton");
        jobDetailsArea = root.Q<VisualElement>("JobDetailsArea");
        jobTitle = root.Q<Label>("JobTitle");
        jobSubtitle = root.Q<Label>("JobSubtitle");
        sectionList = root.Q<ListView>("SectionList");
        detailView = root.Q<ScrollView>("DetailView");
        
        contentSearchField = root.Q<TextField>("ContentSearchField");
        searchControlsContainer = root.Q<VisualElement>("SearchControlsContainer");
        matchCountLbl = root.Q<Label>("MatchCountLabel");
        prevMatchBtn = root.Q<Button>("PrevMatchButton");
        nextMatchBtn = root.Q<Button>("NextMatchButton");

        if (contentSearchField != null)
        {
            contentSearchField.RegisterCallback<ChangeEvent<string>>(evt => 
            {
                OnContentSearchChanged(evt.newValue);
                PlayClickSound(); // Play sound on change
            });
            
            // Also play sound on focus to give feedback
            contentSearchField.RegisterCallback<FocusInEvent>(evt => PlayClickSound());

            // Also try KeyDownEvent as a backup for some platforms/keyboards
            contentSearchField.RegisterCallback<KeyDownEvent>(evt => 
            {
                PlayClickSound();
                HandleSearchNavigation(evt);
            });
            
            Debug.Log("ContentSearchField found and registered.");
        }
        else
        {
            Debug.LogError("ContentSearchField NOT found in UXML!");
        }
        
        if (prevMatchBtn != null) prevMatchBtn.clicked += OnPrevMatch;
        if (nextMatchBtn != null) nextMatchBtn.clicked += OnNextMatch;

        // Full Screen Elements
        fullScreenContainer = root.Q<VisualElement>("FullScreenContainer");
        fullImage = root.Q<Image>("FullImage");
        closeButton = root.Q<Button>("CloseButton");
        zoomInBtn = root.Q<Button>("ZoomInButton");
        zoomOutBtn = root.Q<Button>("ZoomOutButton");

        if (searchButton != null)
        {
            searchButton.clicked += OnSearchClicked;
        }

        if (closeButton != null) closeButton.clicked += CloseFullScreen;
        if (zoomInBtn != null) zoomInBtn.clicked += ZoomIn;
        if (zoomOutBtn != null) zoomOutBtn.clicked += ZoomOut;

        // Setup Pan Logic
        if (fullImage != null)
        {
            fullImage.RegisterCallback<PointerDownEvent>(OnPointerDown);
            fullImage.RegisterCallback<PointerMoveEvent>(OnPointerMove);
            fullImage.RegisterCallback<PointerUpEvent>(OnPointerUp);
            fullImage.RegisterCallback<PointerCancelEvent>(OnPointerCancel);
        }
        else
        {
            Debug.LogError("Search Button not found in UXML!");
        }

        if (jobDataLoader != null)
            jobDataLoader.JobLoaded += OnJobLoaded;

        // Setup ListView
        if (sectionList != null)
        {
            sectionList.virtualizationMethod = CollectionVirtualizationMethod.DynamicHeight; 
            sectionList.makeItem = () => new Label();
            sectionList.bindItem = (element, index) =>
            {
                var label = element as Label;
                if (index >= 0 && index < currentSectionItems.Count)
                {
                    var item = currentSectionItems[index];
                    string text = item.DisplayName;
                    
                    // Reset classes
                    label.ClearClassList();
                    
                    if (text != null)
                    {
                        text = text.Trim(); // Remove any accidental whitespace
                        
                        // Check if the text contains ** (even if wrapped in HTML tags like <b>**Text**</b>)
                        // OR if it is exactly "Overview" or "Summary" (case-insensitive)
                        if (text.Contains("**") || 
                            text.Equals("Overview", StringComparison.OrdinalIgnoreCase) || 
                            text.Equals("Summary", StringComparison.OrdinalIgnoreCase))
                        {
                            // Clean the text: remove **, <b>, </b>, <i>, </i>, etc.
                            string cleanText = text.Replace("**", "")
                                                   .Replace("<b>", "").Replace("</b>", "")
                                                   .Replace("<i>", "").Replace("</i>", "")
                                                   .Trim();
                            
                            label.text = cleanText;
                            label.AddToClassList("list-item-section-header");
                        }
                        else
                        {
                            label.text = text;
                            label.AddToClassList("list-item-label");

                            // Check for sub-category (nested job)
                            if (item.FileKey != null && item.FileKey.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                            {
                                label.AddToClassList("list-item-subcategory");
                            }
                        }
                    }
                }
            };
            sectionList.itemsSource = currentSectionItems;
            sectionList.selectionChanged += OnSectionSelected;
            // Play sound on selection
            sectionList.selectionChanged += (items) => PlayClickSound();

            // Add PointerDown callback for stylus/touch support
            sectionList.RegisterCallback<PointerDownEvent>(evt => {
                // Check if the pointer type is Pen (Stylus) or Touch
                if (evt.pointerType == UnityEngine.UIElements.PointerType.pen || evt.pointerType == UnityEngine.UIElements.PointerType.touch)
                {
                    // Find the index of the item under the pointer
                    // We need to find the visual element that was clicked and map it back to an index
                    var target = evt.target as VisualElement;
                    
                    // Traverse up to find the Label which is our item
                    while (target != null && !(target is Label))
                    {
                        target = target.parent;
                    }

                    if (target is Label label)
                    {
                        // This is a bit hacky but effective: find the index of this label in the list
                        // Note: This relies on the fact that ListView recycles items, so we can't just use IndexOf on children
                        // However, for simple selection, we can rely on the built-in selection logic which usually handles this.
                        // If built-in selection fails for stylus, we might need to manually trigger it.
                        
                        // For now, let's ensure the ScrollView inside ListView handles the event
                        // Usually Unity handles this, but sometimes explicit focus helps
                        sectionList.Focus();
                    }
                }
            });
        }
        else
        {
            Debug.LogError("Section List not found in UXML!");
        }
        
        // Hide details initially
        if (jobDetailsArea != null)
            jobDetailsArea.style.display = DisplayStyle.None;
            
        if (easterEggManager != null)
        {
            easterEggManager.Initialize(root);
        }

        // Try to initialize VideoController if it's already ready (e.g. re-enabling)
        if (VideoController.Instance != null)
        {
            VideoController.Instance.Initialize(uiDocument);
            VideoController.Instance.OnClose -= OnVideoClosed;
            VideoController.Instance.OnClose += OnVideoClosed;
        }

        Debug.Log("JobSearchUIController initialized.");
    }

    private void OnVideoClosed()
    {
        if (sectionList != null)
        {
            sectionList.ClearSelection();
        }
    }

    private void OnDisable()
    {
        // Unregister link click handler
        UMarkdown.OnLinkClick -= HandleLinkClick;

        if (searchButton != null)
            searchButton.clicked -= OnSearchClicked;

        if (backButton != null)
            backButton.clicked -= OnBackClicked;

        if (homeButton != null)
            homeButton.clicked -= OnHomeClicked;

        if (jobDataLoader != null)
            jobDataLoader.JobLoaded -= OnJobLoaded;
            
        if (sectionList != null)
            sectionList.selectionChanged -= OnSectionSelected;

        if (closeButton != null) closeButton.clicked -= CloseFullScreen;
        if (zoomInBtn != null) zoomInBtn.clicked -= ZoomIn;
        if (zoomOutBtn != null) zoomOutBtn.clicked -= ZoomOut;
        
        if (prevMatchBtn != null) prevMatchBtn.clicked -= OnPrevMatch;
        if (nextMatchBtn != null) nextMatchBtn.clicked -= OnNextMatch;
        
        if (fullImage != null)
        {
            fullImage.UnregisterCallback<PointerDownEvent>(OnPointerDown);
            fullImage.UnregisterCallback<PointerMoveEvent>(OnPointerMove);
            fullImage.UnregisterCallback<PointerUpEvent>(OnPointerUp);
            fullImage.UnregisterCallback<PointerCancelEvent>(OnPointerCancel);
        }
    }

    private void OnSearchClicked()
    {
        if (searchField != null && !string.IsNullOrEmpty(searchField.value))
        {
            string jobId = searchField.value;
            
            // Check for Easter Egg first
            if (easterEggManager != null && easterEggManager.TryTriggerEasterEgg(jobId))
            {
                Debug.Log($"Easter Egg triggered for: {jobId}");
                // Hide keyboard after triggering easter egg
                if (TouchScreenKeyboard.isSupported)
                {
                    // Force hide keyboard by opening and immediately closing/deactivating
                    var kb = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
                    kb.active = false;
                }
                // Also blur the field to hide soft keyboard on some platforms
                searchField.Blur();
                return;
            }

            Debug.Log($"Searching for job: {jobId}");
            
            // Clear history on new search
            navigationHistory.Clear();
            UpdateBackButtonState();
            
            jobDataLoader.LoadJobFromInputField(jobId);
            
            // Hide keyboard after loading job
            if (TouchScreenKeyboard.isSupported)
            {
                // Force hide keyboard by opening and immediately closing/deactivating
                // This is a known workaround for some Unity versions where hideInput=true is ignored
                var kb = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
                kb.active = false;
            }
            // Also blur the field to hide soft keyboard on some platforms
            searchField.Blur();
        }
    }

    private void OnJobLoaded(JobData job, Dictionary<string, string> files)
    {
        if (job == null)
        {
            Debug.LogError("Job failed to load.");
            // Optionally show an error message in UI
            if (jobDetailsArea != null) jobDetailsArea.style.display = DisplayStyle.None;
            return;
        }

        // Show details area
        if (jobDetailsArea != null) jobDetailsArea.style.display = DisplayStyle.Flex;

        // Determine Document Type
        string docType = job.docType?.ToLower() ?? "job";
        bool isMainframe = docType == "mainframe" || docType == "system_guide";
        bool isTEGuide = docType == "te_guide";
        bool isCrewLife = docType == "crewlife";
        bool isClaims = docType == "claims";
        bool isPayroll = docType == "payroll";
        bool isHelp = docType == "help";
        bool isMRT = docType == "mrt";
        bool isMRTAEI = docType == "mrt_aei";
        bool isYES = docType == "yes";
        bool isDirectAccess = docType == "direct_access";
        bool isMiscellaneous = docType == "miscellaneous";
        bool isOverTheRoad = docType == "over_the_road";
        bool isUnion = docType == "union";
        bool isPayrollClaims = docType == "payroll_claims";
        

        // Show/Hide Home Button
        if (homeButton != null)
        {
            homeButton.style.display = isHelp ? DisplayStyle.None : DisplayStyle.Flex;
        }

        // Show/Hide Content Search Field
        if (searchControlsContainer != null)
        {
            if (isMainframe || isTEGuide || isCrewLife || isPayroll || isMRT || isMRTAEI || isYES || isDirectAccess || isMiscellaneous || isOverTheRoad || isUnion || isClaims || isPayrollClaims)
            {
                Debug.Log($"Showing Search Controls for docType: {docType}");
                searchControlsContainer.style.display = DisplayStyle.Flex;
                if (contentSearchField != null)
                {
                    // Only reset search if we are NOT navigating back/forward in history
                    // Actually, for now, let's always reset search when loading a new job to avoid "hanging" state
                    // This fixes the bug where switching categories with a search term active causes issues
                    contentSearchField.value = ""; 
                    currentSearchTerm = "";
                }
                
                // Reset match count UI
                if (matchCountLbl != null) matchCountLbl.text = "0/0";
                currentMatchIndex = -1;
                totalMatches = 0;
            }
            else
            {
                Debug.Log($"Hiding Search Controls for docType: {docType}");
                searchControlsContainer.style.display = DisplayStyle.None;
                // Also clear search term if we are hiding the controls
                currentSearchTerm = "";
                if (contentSearchField != null) contentSearchField.value = "";
            }
        }
        else if (contentSearchField != null)
        {
            // Fallback if container not found (e.g. old UXML)
            if (isMainframe || isTEGuide || isCrewLife || isPayroll || isMRT || isMRTAEI || isYES || isDirectAccess || isMiscellaneous || isOverTheRoad || isUnion || isClaims || isPayrollClaims)
            {
                contentSearchField.style.display = DisplayStyle.Flex;
                contentSearchField.value = "";
                currentSearchTerm = "";
            }
            else
            {
                contentSearchField.style.display = DisplayStyle.None;
                currentSearchTerm = "";
                contentSearchField.value = "";
            }
        }
        else
        {
            Debug.LogError("ContentSearchField is null in OnJobLoaded!");
        }

        // Set Header
        if (isMainframe)
        {
            if (jobTitle != null) 
            {
                jobTitle.text = job.title;
                ApplyColor(jobTitle, job.titleColor);
            }
            if (jobSubtitle != null) 
            {
                jobSubtitle.text = $"{job.systemName} v{job.version}";
                ApplyColor(jobSubtitle, job.categoryColor);
            }
        }
        else if (isTEGuide || isCrewLife || isPayroll || isHelp || isMRT || isMRTAEI || isYES || isDirectAccess || isMiscellaneous || isOverTheRoad || isUnion || isClaims || isPayrollClaims)
        {
            if (jobTitle != null) 
            {
                jobTitle.text = job.title;
                ApplyColor(jobTitle, job.titleColor);
            }
            if (jobSubtitle != null) 
            {
                jobSubtitle.text = $"{job.category} v{job.version}";
                ApplyColor(jobSubtitle, job.categoryColor);
            }
        }
        else
        {
            // Standard Job Header
            if (jobTitle != null) 
            {
                jobTitle.text = $"{job.jobNumber} - {job.jobName}";
                ApplyColor(jobTitle, job.titleColor);
            }
            if (jobSubtitle != null) 
            {
                jobSubtitle.text = $"{job.craft} | {job.onduty} | {job.location}";
                ApplyColor(jobSubtitle, job.categoryColor);
            }
        }
        
        // Apply Summary Color if available (for Mainframe/Category guides)
        if (job.summaryColor != null)
        {
            // We don't have a direct reference to the summary label here as it's generated in RenderMainframeGuide
            // But we can store it for later use
        }

        // Populate List
        allSectionItems.Clear();
        
        if (isMainframe || isMRT || isMRTAEI || isYES || isDirectAccess || isMiscellaneous || isOverTheRoad || isUnion || isClaims || isPayrollClaims)
        {
            // Add Mainframe/MRT/YES/DA/Misc/OTR/Union specific sections
            allSectionItems.Add(new SectionItem { DisplayName = "**Summary**", Type = ItemType.MainframeGuide, GuideData = job });
    
            // Also add any standard sections/tables defined in the JSON for Mainframe
            if (job.sections != null)
            {
                foreach (var section in job.sections)
                { 
                    // Skip adding "Summary" again if it's already handled by the hardcoded item above
                    if (section.label.Equals("Summary", StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Check if it's a video
                    ItemType type; 
                    if (section.file.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase))
                    {
                      type = ItemType.Video;
                    }
                    else
                    {
                        type = ItemType.Text;
                    }

                    allSectionItems.Add(new SectionItem { DisplayName = section.label, FileKey = section.file, Type = type });
                }
            }

            if (job.tables != null)
            {
                foreach (var table in job.tables) 
                {
                    allSectionItems.Add(new SectionItem { DisplayName = table.name, FileKey = table.file, Type = ItemType.Text });
                }
            }
        }
        else
        {
            // Add Standard Sections (Works for Jobs, T&E, CrewLife, and Payroll)
            if (job.sections != null)
            {
                foreach (var section in job.sections) 
                {
                    ItemType type; 
                    if (section.file.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase))
                    {
                        type = ItemType. Video;
                    }
                    else
                    {
                        // Default to Text for .md, .csv, etc.
                        type = ItemType.Text;
                    }
                    allSectionItems.Add(new SectionItem { DisplayName = section.label, FileKey = section.file, Type = type });
                }
            }

            // Add Tables (Explicit tables list)
            if (job.tables != null)
            {
                foreach (var table in job.tables) 
                {
                    allSectionItems.Add(new SectionItem { DisplayName = table.name, FileKey = table.file, Type = ItemType.Text });
                }
            }

            // Add Procedures
            if (job. procedures != null)
            {
                foreach (var proc in job. procedures)
                {
                    allSectionItems.Add(new SectionItem { DisplayName = proc. name, FileKey = proc.file, Type = ItemType.Text });
                }
            }

            // Add Images
            if (job.images != null)
            {
                foreach (var img in job.images)
                {
                    allSectionItems.Add(new SectionItem { DisplayName = img.name, FileKey = img. file, Type = ItemType.Image });
                }
            }
        }

        // Initial Filter (Show All)
        FilterSectionList("");
        
        // Select first item if available
        if (currentSectionItems.Count > 0)
        {
            // Force selection change to ensure the detail view updates immediately
            sectionList.ClearSelection();
            sectionList.selectedIndex = 0;
        }
    }

    private void OnContentSearchChanged(string searchText)
    {
        // Capture the currently selected item before filtering
        var previouslySelectedItem = sectionList.selectedItem as SectionItem;

        currentSearchTerm = searchText;
        FilterSectionList(searchText);
        
        // If user hits enter (newline in text), hide keyboard
        if (searchText.Contains("\n"))
        {
            if (TouchScreenKeyboard.isSupported)
            {
                TouchScreenKeyboard.hideInput = true;
            }
            contentSearchField.Blur();
            // Remove the newline from the search term
            contentSearchField.value = searchText.Replace("\n", "");
        }
        
        // Try to restore selection if the item is still in the filtered list
        if (previouslySelectedItem != null && currentSectionItems.Contains(previouslySelectedItem))
        {
            int newIndex = currentSectionItems.IndexOf(previouslySelectedItem);
            sectionList.selectedIndex = newIndex;
            
            // Force update detail view to show highlights
            OnSectionSelected(new List<object> { previouslySelectedItem });
        }
        else if (sectionList.selectedIndex >= 0)
        {
            // If selection was preserved by ListView (unlikely but possible), update view
            OnSectionSelected(new List<object> { sectionList.selectedItem });
        }
        else if (currentSectionItems.Count > 0)
        {
            // Optional: If selection was lost, maybe select the first item?
            // For now, let's just leave it unselected to avoid jumping around too much while typing,
            // unless the user explicitly wants that behavior.
            // But we should clear the detail view if nothing is selected?
            // Actually, RenderDetailView handles null item by doing nothing, so the old content stays.
            // This might be confusing. Let's clear it if nothing is selected.
            // detailView.Clear(); // Maybe?
        }
    }

    private void FilterSectionList(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
        {
            currentSectionItems = new List<SectionItem>(allSectionItems);
        }
        else
        {
            currentSectionItems = new List<SectionItem>();
            
            foreach (var item in allSectionItems)
            {
                bool match = false;

                // 1. Check Display Name
                if (item.DisplayName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    match = true;
                }
                else 
                {
                    string content = null;
                    
                    if (item.Type == ItemType.Text && !string.IsNullOrEmpty(item.FileKey))
                    {
                        content = GetFileContent(item.FileKey);
                        // Handle CSV content generation if needed for search
                        if (item.FileKey.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(content))
                        {
                             content = CsvToMarkdownTable(content);
                        }
                    }
                    else if (item.Type == ItemType.MainframeGuide && item.GuideData != null)
                    {
                        content = GenerateMainframeContent(item.GuideData);
                    }

                    if (!string.IsNullOrEmpty(content))
                    {
                        // Use GetValidMatches to ensure we only match visible text
                        if (GetValidMatches(content, searchText).Count > 0)
                        {
                            match = true;
                        }
                    }
                }

                if (match)
                {
                    currentSectionItems.Add(item);
                }
            }
        }

        sectionList.itemsSource = currentSectionItems;
        sectionList.RefreshItems();
        sectionList.ScrollToItem(0);
    }

    private string GetFileContent(string fileKey)
    {
        if (jobDataLoader.LoadedFiles.ContainsKey(fileKey))
        {
            return jobDataLoader.LoadedFiles[fileKey];
        }
        
        var fileName = System.IO.Path.GetFileName(fileKey);
        if (jobDataLoader.LoadedFiles.ContainsKey(fileName))
        {
            return jobDataLoader.LoadedFiles[fileName];
        }

        return null;
    }

    private void OnSectionSelected(IEnumerable<object> selectedItems)
    {
        RenderDetailView(true);
    }

    private void RenderDetailView(bool resetMatches)
    {
        var item = sectionList.selectedItem as SectionItem;
        if (item == null || detailView == null) return;

        detailView.Clear();
        if (resetMatches)
        {
            detailView.scrollOffset = Vector2.zero;
            currentMatchIndex = -1;
            totalMatches = 0;
            UpdateMatchCountUI();
        }

        if (item.Type == ItemType.MainframeGuide)
        {
            RenderMainframeGuide(item.GuideData, resetMatches);
        }
        else if (item.Type == ItemType.Image)
        {
            // Handle Image Loading
            jobDataLoader.LoadImage(item.FileKey, (texture) =>
            {
                if (texture != null)
                {
                    var img = new Image();
                    img.image = texture;
                    img.style.flexGrow = 1;
                    img.style.backgroundSize = new BackgroundSize(BackgroundSizeType.Contain);
                    img.style.minHeight = 500; // Ensure it has some height
                    
                    // Add click handler to open full screen
                    img.RegisterCallback<ClickEvent>(evt => OpenFullScreen(texture));
                    
                    detailView.Add(img);
                }
                else
                {
                    var label = new Label("Failed to load image.");
                    label.AddToClassList("detail-content");
                    detailView.Add(label);
                }
            });
        }
        else if (item.Type == ItemType.Video)
        {
            Debug.Log($"Play video requested for file: {item.FileKey}");
            // Handle Video Playback
            if (VideoController.Instance != null)
            {
                VideoController.Instance.PlayVideo(item.FileKey);
            }
            else
            {
                var label = new Label("Video Player not available.");
                label.AddToClassList("detail-content");
                detailView.Add(label);
            }
        }
        else
        {
            // Handle Text Content
            string content = "";
            string fileKey = item.FileKey;

            // Check if it's a nested job (JSON file)
            if (fileKey.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            {
                string currentFolder = jobDataLoader.JobFolder;
                
                // Push current folder to history
                navigationHistory.Push(currentFolder);
                UpdateBackButtonState();

                // fileKey is relative to the current job folder, e.g. "MRTAEI/job.json"
                // We want to extract the directory part, e.g. "MRTAEI"
                string directory = System.IO.Path.GetDirectoryName(fileKey);
                
                // If directory is empty (fileKey is just "job.json"), it means reload current folder?
                // But usually it's "SubFolder/job.json".
                
                string fullFolderPath;
                if (string.IsNullOrEmpty(directory))
                {
                    // If fileKey is just "job.json", we are reloading the same folder?
                    // Or maybe it's a sibling?
                    // Let's assume it's relative to current folder.
                    fullFolderPath = currentFolder;
                }
                else
                {
                    // Check if currentFolder already ends with the directory we are trying to append
                    // This prevents recursive duplication like "MRT/MRTAEI/MRTAEI"
                    // Normalize separators for comparison
                    string normalizedCurrent = currentFolder.Replace("\\", "/").TrimEnd('/');
                    string normalizedDir = directory.Replace("\\", "/").TrimEnd('/');
                    
                    if (normalizedCurrent.EndsWith("/" + normalizedDir, StringComparison.OrdinalIgnoreCase) || 
                        normalizedCurrent.Equals(normalizedDir, StringComparison.OrdinalIgnoreCase))
                    {
                        // If we are already in "MRT/MRTAEI" and trying to go to "MRTAEI", just stay here?
                        // Or maybe the fileKey is relative to the PARENT?
                        // No, fileKey comes from the JSON which is relative to the JSON file location.
                        
                        // If we are in MRT (root), fileKey is "MRTAEI/job.json".
                        // fullFolderPath becomes "MRT/MRTAEI". Correct.
                        
                        // If we are in MRT/MRTAEI, and we click a link... wait, subcategories don't usually link to themselves.
                        // But if they did, or if there's a loop.
                        
                        // The issue reported is "MRT/MRTAEI/MRTAEI/job.json".
                        // This implies currentFolder was "MRT/MRTAEI" and we appended "MRTAEI" again.
                        // This happens if the user is IN the subcategory and clicks the link again?
                        // OR if the search term filtering somehow messes up the context.
                        
                        // If we are in "MRT", currentFolder="MRT". Link="MRTAEI/job.json". Result="MRT/MRTAEI". Correct.
                        // If we are in "MRT/MRTAEI", currentFolder="MRT/MRTAEI".
                        // If the list item "MRTAEI/job.json" is still visible (e.g. from the parent list?), that's the problem.
                        // When we load a subcategory, we usually load a NEW job.json which has its OWN sections.
                        // The parent's sections (including the link to the subcategory) should disappear.
                        
                        // UNLESS the subcategory's job.json ALSO has a link to itself or a child with the same name?
                        // Let's check MRT/MRTAEI/job.json content if possible.
                        // But assuming standard structure, maybe the "Back" navigation didn't clear something?
                        
                        // Wait, the error log says: "Failed to load .../MRT/MRTAEI/MRTAEI/job.json"
                        // This means `currentFolder` was `MRT/MRTAEI` and `directory` was `MRTAEI`.
                        // This implies `fileKey` was `MRTAEI/job.json`.
                        // Why would `MRT/MRTAEI/job.json` contain a link to `MRTAEI/job.json`?
                        // It shouldn't. It should contain sections for that subcategory.
                        
                        // HYPOTHESIS: When we filter with a search term, we might be showing items from the PREVIOUS job 
                        // if `allSectionItems` wasn't cleared or updated correctly?
                        // `OnJobLoaded` clears `allSectionItems`.
                        
                        // HYPOTHESIS 2: The user is in "MRT", types a search term.
                        // The list filters to show "MRTAEI" (the subcategory link).
                        // User clicks it. `RenderDetailView` runs.
                        // It calculates path "MRT/MRTAEI". Loads it.
                        // `OnJobLoaded` runs for "MRT/MRTAEI".
                        // It clears `allSectionItems` and populates it with MRTAEI's content.
                        // BUT `currentSearchTerm` is NOT cleared (before my previous fix).
                        // So `FilterSectionList` runs immediately with the OLD search term.
                        // If the old search term matches something in the NEW list, it shows it.
                        
                        // But if the user clicks the subcategory again?
                        // The error happens "when you have a keyword ... and switch to a subcategory".
                        // Maybe the click event fires twice? Or the UI doesn't update fast enough?
                        
                        // Let's look at the path construction again.
                        // If `currentFolder` is "MRT/MRTAEI", and we append `directory` "MRTAEI", we get the error.
                        // This means `fileKey` is "MRTAEI/job.json".
                        // This means the item clicked was the one from the PARENT list ("MRT").
                        // But `jobDataLoader.JobFolder` should have been updated to "MRT/MRTAEI" *after* the load starts?
                        // No, `JobFolder` is updated in `LoadJobFromInputField` BEFORE starting the coroutine.
                        
                        // Sequence:
                        // 1. User in "MRT". `JobFolder` = "MRT". List shows "MRTAEI/job.json".
                        // 2. User clicks "MRTAEI".
                        // 3. `RenderDetailView` runs.
                        // 4. `currentFolder` = "MRT". `directory` = "MRTAEI".
                        // 5. `fullFolderPath` = "MRT/MRTAEI".
                        // 6. `navigationHistory.Push("MRT")`.
                        // 7. `jobDataLoader.LoadJobFromInputField("MRT/MRTAEI")`.
                        //    - Sets `JobFolder` = "MRT/MRTAEI".
                        //    - Starts Coroutine.
                        
                        // If `RenderDetailView` runs AGAIN for the SAME item before the new job loads?
                        // 1. `RenderDetailView` runs again.
                        // 2. `currentFolder` is now "MRT/MRTAEI" (updated in step 7 above).
                        // 3. Item is still "MRTAEI/job.json" (list hasn't refreshed yet).
                        // 4. `directory` = "MRTAEI".
                        // 5. `fullFolderPath` = "MRT/MRTAEI/MRTAEI". -> ERROR!
                        
                        // FIX: We need to prevent re-entrance or check if we are already loading?
                        // Or simply check if `currentFolder` already contains the target directory?
                        
                        // If `currentFolder` ends with `directory`, we shouldn't append it again?
                        // But what if we have `Folder/Sub/Sub`?
                        
                        // Better fix: Use the `navigationHistory` to determine the "base" folder for the current view?
                        // No, that's complex.
                        
                        // Simple fix: If `currentFolder` already ends with `directory`, assume we double-clicked or are re-processing.
                        // But we need to be careful about legitimate sibling folders with same names (unlikely here).
                        
                        // Let's implement the check.
                         if (normalizedCurrent.EndsWith("/" + normalizedDir, StringComparison.OrdinalIgnoreCase))
                         {
                             // We are likely re-processing the same click while JobFolder has already updated.
                             // Use currentFolder as is.
                             fullFolderPath = currentFolder;
                         }
                         else
                         {
                             fullFolderPath = System.IO.Path.Combine(currentFolder, directory);
                         }
                    }
                    else
                    {
                        fullFolderPath = System.IO.Path.Combine(currentFolder, directory);
                    }
                }

                fullFolderPath = fullFolderPath.Replace("\\", "/");
                
                // Resolve any relative paths (like ..) before loading
                fullFolderPath = ResolvePath(fullFolderPath);
                
                // Prevent reloading if we are already there (simple debounce)
                if (fullFolderPath.Equals(jobDataLoader.JobFolder.Replace("\\", "/"), StringComparison.OrdinalIgnoreCase))
                {
                    Debug.Log("Ignoring duplicate load request for: " + fullFolderPath);
                    return;
                }
                
                jobDataLoader.LoadJobFromInputField(fullFolderPath);
                return;
            }
            
            content = GetFileContent(fileKey);
            if (content == null)
            {
                // For videos, content will be null because they are not pre-loaded as text.
                // This is expected, so we don't show a "Content not found" message.
                if (!fileKey.EndsWith(".mp4", StringComparison.OrdinalIgnoreCase))
                {
                    content = "Content not found.";
                }
                else
                {
                    content = ""; // Set to empty for videos
                }
            }

            // Highlight Search Term and Count Matches
            if (!string.IsNullOrEmpty(currentSearchTerm))
            {
                if (!fileKey.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                {
                    var matches = GetValidMatches(content, currentSearchTerm);
                    
                    if (resetMatches)
                    {
                        totalMatches = matches.Count;
                        if (totalMatches > 0)
                        {
                            currentMatchIndex = 0; // Start at first match
                        }
                        UpdateMatchCountUI();
                    }
                    
                    content = HighlightText(content, matches, currentMatchIndex);
                }
            }

            // Render content
            if (fileKey.EndsWith(".md", StringComparison.OrdinalIgnoreCase))
            {
                var mdElement = UMarkdown.Parse(content, UMarkdownContext.Runtime());
                detailView.Add(mdElement);
                ApplyTableStyles(mdElement);
                ApplyMobileFonts(mdElement);
            }
            else if (fileKey.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
            {
                // Re-fetch raw content for CSV to avoid corruption
                string rawContent = GetFileContent(fileKey);
                string mdTableRaw = CsvToMarkdownTable(rawContent);
                
                if (!string.IsNullOrEmpty(currentSearchTerm))
                {
                    var matches = GetValidMatches(mdTableRaw, currentSearchTerm);

                    if (resetMatches)
                    {
                        // Count matches in the generated table string
                        totalMatches = matches.Count;
                        if (totalMatches > 0)
                        {
                            currentMatchIndex = 0;
                        }
                        UpdateMatchCountUI();
                    }
                    
                    mdTableRaw = HighlightText(mdTableRaw, matches, currentMatchIndex);
                }

                var mdElement = UMarkdown.Parse(mdTableRaw, UMarkdownContext.Runtime());
                detailView.Add(mdElement);
                ApplyTableStyles(mdElement);
                ApplyMobileFonts(mdElement);
            }
            else
            {
                var label = new Label(content);
                label.AddToClassList("detail-content");
                detailView.Add(label);
                ApplyMobileFonts(label);
            }
        }
        
        // Auto-scroll to match if we have matches
        if (totalMatches > 0)
        {
            // Use ExecuteLater to give the layout system time to process the new content
            // Increased delay to ensure complex layouts (like tables) are fully calculated
            detailView.schedule.Execute(() => ScrollToMatch()).ExecuteLater(100);
        }
    }

    private string ResolvePath(string path)
    {
        // Normalize separators
        path = path.Replace("\\", "/");
        
        var parts = new List<string>();
        var segments = path.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var segment in segments)
        {
            if (segment == "..")
            {
                if (parts.Count > 0)
                    parts.RemoveAt(parts.Count - 1);
            }
            else if (segment != ".")
            {
                parts.Add(segment);
            }
        }

        return string.Join("/", parts);
    }

    private List<Match> GetValidMatches(string text, string term)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(term)) return new List<Match>();

        var allMatches = Regex.Matches(text, Regex.Escape(term), RegexOptions.IgnoreCase).Cast<Match>().ToList();
        var validMatches = new List<Match>();
        
        var unsafeRanges = new List<(int start, int end)>();
        
        // 1. Markdown Links: [text](url) - capture group 1 (url)
        foreach (Match m in Regex.Matches(text, @"\[[^\]]*\]\(([^)]*)\)"))
        {
            if (m.Groups.Count > 1)
            {
                Group g = m.Groups[1];
                unsafeRanges.Add((g.Index, g.Index + g.Length));
            }
        }

        // 2. HTML Tags: <tag> - capture whole match
        foreach (Match m in Regex.Matches(text, @"<[^>]*>"))
        {
            unsafeRanges.Add((m.Index, m.Index + m.Length));
        }

        // 3. Headers: # Header - capture whole match
        foreach (Match m in Regex.Matches(text, @"^#+ .*$", RegexOptions.Multiline))
        {
            unsafeRanges.Add((m.Index, m.Index + m.Length));
        }

        // 4. Bold: **text** - capture whole match
        // Note: This is greedy, might match **bold** normal **bold**.
        // Use non-greedy .*?
        foreach (Match m in Regex.Matches(text, @"\*\*.*?\*\*"))
        {
            unsafeRanges.Add((m.Index, m.Index + m.Length));
        }
        
        foreach (var m in allMatches)
        {
            bool isUnsafe = false;
            foreach (var range in unsafeRanges)
            {
                if (m.Index >= range.start && m.Index < range.end)
                {
                    isUnsafe = true;
                    break;
                }
            }
            
            if (!isUnsafe)
            {
                validMatches.Add(m);
            }
        }
        
        return validMatches;
    }

    private string HighlightText(string text, List<Match> matches, int activeIndex)
    {
        if (string.IsNullOrEmpty(text) || matches == null || matches.Count == 0) return text;
        
        StringBuilder sb = new StringBuilder();
        int lastIndex = 0;
        
        for (int i = 0; i < matches.Count; i++)
        {
            Match m = matches[i];
            
            // Append text before match
            sb.Append(text.Substring(lastIndex, m.Index - lastIndex));
            
            // Append highlighted match
            string color = (i == activeIndex) ? ActiveMatchColor : InactiveMatchColor;
            sb.Append($"<mark={color}><b>{m.Value}</b></mark>");
            
            lastIndex = m.Index + m.Length;
        }
        
        // Append remaining text
        sb.Append(text.Substring(lastIndex));
        
        return sb.ToString();
    }

    private string GenerateMainframeContent(JobData guide)
    {
        var sb = new StringBuilder();

        // Summary
        if (!string.IsNullOrEmpty(guide.summary))
        {
            // If summaryColor is defined, apply it to the header? 
            // Or maybe the user wants the summary TEXT to be colored?
            // "where things like Summary are rendered in the gold color" implies the header "Summary".
            // But we already have a global rule for # Header -> Gold.
            // However, if the user wants to override it via JSON, we can do that.
            
            // Actually, the user said: "I'd like to have the same color formatting that is being applied to the specific job folder .json files where things like Summary are rendered in the gold color"
            // In specific jobs (like Y290), "Summary" is a section label in the list.
            // In Category files (like MRT), "Summary" is part of the generated content from `guide.summary`.
            
            // The generated content uses markdown headers: `# Summary`.
            // My previous script `FormatAllMarkdownFilesExtended` formatted ALL .md files on disk.
            // BUT `GenerateMainframeContent` generates markdown in memory! It doesn't read from a file.
            // So the global formatting script didn't touch this generated content.
            
            // We need to apply the same formatting rules here in code.
            
            sb.AppendLine($"# <color=#FFD700>Summary</color>");
            sb.AppendLine("==========="); // Add separator line for consistency
            
            if (!string.IsNullOrEmpty(guide.summaryColor))
            {
                sb.AppendLine($"<color={guide.summaryColor}>{guide.summary}</color>");
            }
            else
            {
                // Ensure summary starts on a new line if it doesn't already
                // The previous AppendLine("===========") adds a newline, so it should be fine.
                // But if the summary text itself starts with something that looks like it belongs to the previous line?
                // Markdown usually handles this.
                // However, if the user sees "Claims" on the same line as "==========", it means the newline after "==========" is missing or ignored.
                // Let's add an extra newline before the summary content just to be safe.
                
                sb.AppendLine(); 
                sb.AppendLine(guide.summary);
            }
            sb.AppendLine();
        }

        // Access Steps
        if (guide.accessSteps != null && guide.accessSteps.Count > 0)
        {
            sb.AppendLine($"# <color=#FFD700>Access Steps</color>");
            sb.AppendLine("===========");
            for (int i = 0; i < guide.accessSteps.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {guide.accessSteps[i]}");
            }
            sb.AppendLine();
        }

        // Usage Tips
        if (guide.usageTips != null && guide.usageTips.Count > 0)
        {
            sb.AppendLine($"# <color=#FFD700>Usage Tips</color>");
            sb.AppendLine("===========");
            foreach (var tip in guide.usageTips)
            {
                sb.AppendLine($"- {tip}");
            }
            sb.AppendLine();
        }

        // Links
        if (guide.links != null && guide.links.Count > 0)
        {
            sb.AppendLine($"# <color=#FFD700>Links</color>");
            sb.AppendLine("===========");
            foreach (var link in guide.links)
            {
                sb.AppendLine($"- [{link.name}]({link.file})");
            }
        }

        return sb.ToString();
    }

    private void RenderMainframeGuide(JobData guide, bool resetMatches)
    {
        string content = GenerateMainframeContent(guide);
        if (!string.IsNullOrEmpty(currentSearchTerm))
        {
            var matches = GetValidMatches(content, currentSearchTerm);

            if (resetMatches)
            {
                totalMatches = matches.Count;
                if (totalMatches > 0)
                {
                    currentMatchIndex = 0;
                }
                UpdateMatchCountUI();
            }
            
            content = HighlightText(content, matches, currentMatchIndex);
        }

        var mdElement = UMarkdown.Parse(content, UMarkdownContext.Runtime());
        detailView.Add(mdElement);
        ApplyTableStyles(mdElement);
        ApplyMobileFonts(mdElement);
    }
    
    private void UpdateMatchCountUI()
    {
        if (matchCountLbl != null)
        {
            if (totalMatches > 0)
            {
                matchCountLbl.text = $"{currentMatchIndex + 1}/{totalMatches}";
            }
            else
            {
                matchCountLbl.text = "0/0";
            }
        }
    }
    
    private void OnPrevMatch()
    {
        if (totalMatches > 0)
        {
            currentMatchIndex--;
            if (currentMatchIndex < 0) currentMatchIndex = totalMatches - 1;
            UpdateMatchCountUI();
            PlayClickSound();
            RenderDetailView(false); // Re-render to update highlight
        }
    }
    
    private void OnNextMatch()
    {
        if (totalMatches > 0)
        {
            currentMatchIndex++;
            if (currentMatchIndex >= totalMatches) currentMatchIndex = 0;
            UpdateMatchCountUI();
            PlayClickSound();
            RenderDetailView(false); // Re-render to update highlight
        }
    }

    private void ScrollToMatch()
    {
        if (detailView == null || string.IsNullOrEmpty(currentSearchTerm)) return;

        var labels = detailView.Query<Label>().ToList();

        foreach (var label in labels)
        {
            // Instead of counting matches again (which can be inaccurate if markdown consumes some text),
            // we look for the specific active color tag that HighlightText applied.
            if (label.text.Contains(ActiveMatchColor))
            {
                // Found the label containing the active match!
                
                // Ensure layout is ready
                if (float.IsNaN(label.worldBound.y) || float.IsNaN(detailView.worldBound.y) || detailView.layout.height == 0)
                {
                    // Layout not ready, schedule for next frame
                    detailView.schedule.Execute(() => ScrollToMatch());
                    return;
                }

                // Use contentContainer for more accurate relative position
                float relativeY = label.worldBound.y - detailView.contentContainer.worldBound.y;
                
                // Center it
                float targetScroll = relativeY - (detailView.layout.height / 2) + (label.layout.height / 2);
                
                detailView.scrollOffset = new Vector2(0, Mathf.Max(0, targetScroll));
                return;
            }
        }
    }

    private void ApplyTableStyles(VisualElement root)
    {
        // Find all elements with class "table-cell"
        root.Query(className: "table-cell").ForEach(cell => 
        {
            // Set style on the cell itself
            cell.style.fontSize = 28;
            cell.style.paddingLeft = 10;
            cell.style.paddingRight = 10;
            cell.style.paddingTop = 5;
            cell.style.paddingBottom = 5;

            // Also find any Labels inside the cell and force their size
            cell.Query<Label>().ForEach(label => 
            {
                label.style.fontSize = 28;
                label.style.whiteSpace = WhiteSpace.Normal; 
            });
        });
    }

    private string CsvToMarkdownTable(string csvContent)
    {
        var data = CSVParser.Parse(csvContent);
        if (data == null || data.Count == 0) return "No data found.";

        var sb = new StringBuilder();
        var headers = data[0].Keys.ToList();

        // Header row
        sb.Append("|");
        foreach (var h in headers) sb.Append($" {h} |");
        sb.AppendLine();

        // Separator row
        sb.Append("|");
        foreach (var h in headers) sb.Append(" --- |");
        sb.AppendLine();

        // Data rows
        foreach (var row in data)
        {
            sb.Append("|");
            foreach (var h in headers)
            {
                var val = row.ContainsKey(h) ? row[h] : "";
                sb.Append($" {val} |");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }

    // --- Full Screen Logic ---

    private void OpenFullScreen(Texture2D texture)
    {
        if (fullScreenContainer == null || fullImage == null) return;

        fullImage.image = texture;
        fullScreenContainer.style.display = DisplayStyle.Flex;
        
        // Reset Zoom/Pan
        currentZoom = 1f;
        fullImage.style.scale = new Scale(Vector3.one);
        fullImage.style.translate = new Translate(0, 0, 0);
    }

    private void CloseFullScreen()
    {
        if (fullScreenContainer != null)
            fullScreenContainer.style.display = DisplayStyle.None;
    }

    private void ZoomIn()
    {
        if (fullImage == null) return;
        currentZoom = Mathf.Min(currentZoom + 0.5f, 5f); // Max zoom 5x
        fullImage.style.scale = new Scale(Vector3.one * currentZoom);
    }

    private void ZoomOut()
    {
        if (fullImage == null) return;
        currentZoom = Mathf.Max(currentZoom - 0.5f, 1f); // Min zoom 1x
        if (currentZoom == 1f)
        {
            fullImage.style.translate = new Translate(0, 0, 0); // Reset position if zoomed out completely
        }
        fullImage.style.scale = new Scale(Vector3.one * currentZoom);
    }

    private void OnPointerDown(PointerDownEvent evt)
    {
        if (currentZoom > 1f)
        {
            isPanning = true;
            panStart = evt.position;
            imageStartPos = new Vector3(fullImage.resolvedStyle.translate.x, fullImage.resolvedStyle.translate.y, 0);
            fullImage.CapturePointer(evt.pointerId);
            evt.StopPropagation();
        }
    }

    private void OnPointerMove(PointerMoveEvent evt)
    {
        if (isPanning && fullImage.HasPointerCapture(evt.pointerId))
        {
            Vector2 delta = (Vector2)evt.position - panStart;
            fullImage.style.translate = new Translate(imageStartPos.x + delta.x, imageStartPos.y + delta.y, 0);
            evt.StopPropagation();
        }
    }

    private void OnPointerUp(PointerUpEvent evt)
    {
        if (isPanning)
        {
            isPanning = false;
            fullImage.ReleasePointer(evt.pointerId);
            evt.StopPropagation();
        }
    }

    private void OnPointerCancel(PointerCancelEvent evt)
    {
        if (isPanning)
        {
            isPanning = false;
            fullImage.ReleasePointer(evt.pointerId);
            evt.StopPropagation();
        }
    }

    private void PlayClickSound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    private void OnBackClicked()
    {
        if (navigationHistory.Count > 0)
        {
            string previousFolder = navigationHistory.Pop();
            UpdateBackButtonState();
            jobDataLoader.LoadJobFromInputField(previousFolder);
        }
    }

    private void OnHomeClicked()
    {
        // Clear history when going home
        navigationHistory.Clear();
        UpdateBackButtonState();
        
        // Load Help (Home)
        jobDataLoader.LoadJobFromInputField("Help");
    }

    private void UpdateBackButtonState()
    {
        if (backButton != null)
        {
            backButton.style.display = navigationHistory.Count > 0 ? DisplayStyle.Flex : DisplayStyle.None;
        }
    }

    private void HandleLinkClick(string url)
    {
        Debug.Log($"[JobSearchUIController] Link clicked: {url}");
        
        // Check if it's a job.json link
        if (url.EndsWith("job.json", StringComparison.OrdinalIgnoreCase))
        {
            // It's a navigation link to another category
            // We need to resolve the path relative to the current job folder if it's a relative path
            
            string targetPath = url;
            
            // If it starts with ../ it means go up one level from current folder
            // But JobDataLoader expects a path relative to StreamingAssets or a full path
            
            // Let's try to resolve it.
            // If current folder is "Help" and link is "../DirectAccess/job.json"
            // We want "DirectAccess"
            
            // If it's a relative path starting with .., we need to handle it manually
            if (targetPath.StartsWith("../"))
            {
                // Use ResolvePath to handle .. correctly
                string currentFolder = jobDataLoader.JobFolder;
                string fullPath = System.IO.Path.Combine(currentFolder, targetPath);
                fullPath = ResolvePath(fullPath);
                
                // Remove /job.json to get the folder name
                if (fullPath.EndsWith("/job.json", StringComparison.OrdinalIgnoreCase))
                {
                    fullPath = fullPath.Substring(0, fullPath.Length - 9);
                }
                
                // Push current folder to history
                navigationHistory.Push(jobDataLoader.JobFolder);
                UpdateBackButtonState();
                
                // Load the new job
                jobDataLoader.LoadJobFromInputField(fullPath);
            }
            // If it's a relative path starting with StreamingAssets (e.g. from Quick Links in Help/job.json)
            else if (targetPath.StartsWith("StreamingAssets", StringComparison.OrdinalIgnoreCase))
            {
                // The path is like "StreamingAssets\DirectAccess\job.json"
                // We need to extract "DirectAccess"
                
                // Normalize slashes
                targetPath = targetPath.Replace("\\", "/");
                
                // Remove StreamingAssets/
                if (targetPath.StartsWith("StreamingAssets/", StringComparison.OrdinalIgnoreCase))
                {
                    targetPath = targetPath.Substring(16);
                }
                
                // Remove /job.json
                if (targetPath.EndsWith("/job.json", StringComparison.OrdinalIgnoreCase))
                {
                    targetPath = targetPath.Substring(0, targetPath.Length - 9);
                }
                
                // Push current folder to history
                navigationHistory.Push(jobDataLoader.JobFolder);
                UpdateBackButtonState();
                
                // Load the new job
                jobDataLoader.LoadJobFromInputField(targetPath);
            }
            else
            {
                // It might be a direct path or relative to current folder
                // If it's just "job.json", it reloads current.
                // If it's "SubFolder/job.json", we treat it as nested.
                
                string currentFolder = jobDataLoader.JobFolder;
                string directory = System.IO.Path.GetDirectoryName(url);
                
                string fullFolderPath = System.IO.Path.Combine(currentFolder, directory);
                fullFolderPath = fullFolderPath.Replace("\\", "/");
                
                // Push current folder to history
                navigationHistory.Push(currentFolder);
                UpdateBackButtonState();
                
                jobDataLoader.LoadJobFromInputField(fullFolderPath);
            }
        }
        else
        {
            // Standard URL or other file type
            Application.OpenURL(url);
        }
    }

    private void HandleSearchNavigation(KeyDownEvent evt)
    {
        // Prioritize navigating matches if they exist
        if (totalMatches > 0)
        {
            if (evt.keyCode == KeyCode.DownArrow)
            {
                OnNextMatch();
                evt.StopPropagation();
                return;
            }
            else if (evt.keyCode == KeyCode.UpArrow)
            {
                OnPrevMatch();
                evt.StopPropagation();
                return;
            }
        }

        // Fallback to section navigation if no matches
        if (sectionList == null || currentSectionItems == null || currentSectionItems.Count == 0) return;

        if (evt.keyCode == KeyCode.DownArrow)
        {
            int newIndex = sectionList.selectedIndex + 1;
            if (newIndex < currentSectionItems.Count)
            {
                sectionList.selectedIndex = newIndex;
                sectionList.ScrollToItem(newIndex);
            }
            evt.StopPropagation();
        }
        else if (evt.keyCode == KeyCode.UpArrow)
        {
            int newIndex = sectionList.selectedIndex - 1;
            if (newIndex >= 0)
            {
                sectionList.selectedIndex = newIndex;
                sectionList.ScrollToItem(newIndex);
            }
            evt.StopPropagation();
        }
    }

    private void ApplyColor(Label label, string colorHex)
    {
        if (label == null) return;
        
        if (!string.IsNullOrEmpty(colorHex))
        {
            if (ColorUtility.TryParseHtmlString(colorHex, out Color color))
            {
                label.style.color = color;
            }
        }
        else
        {
            // Reset to default if no color specified (optional, or keep previous style)
            // label.style.color = StyleKeyword.Null; 
        }
    }

    private void LoadSystemFont()
    {
    }

    private void ApplyMobileFonts(VisualElement root)
    {
    }

    // Helper to apply mobile fonts to a specific label (used when creating labels manually)
    private void ApplyMobileFonts(Label label)
    {
    }
}
