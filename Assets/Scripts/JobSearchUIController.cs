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

    // Data
    private List<SectionItem> allSectionItems = new List<SectionItem>();
    private List<SectionItem> currentSectionItems = new List<SectionItem>();
    private string currentSearchTerm = "";
    private int currentMatchIndex = -1;
    private int totalMatches = 0;

    private const string ActiveMatchColor = "#4CAF5066";
    private const string InactiveMatchColor = "#FFFF0080";

    private enum ItemType { Text, Image, MainframeGuide }

    private class SectionItem
    {
        public string DisplayName;
        public string FileKey;
        public ItemType Type;
        public JobData GuideData; // For Mainframe Guides
    }

    private void OnEnable()
    {
        if (uiDocument == null) uiDocument = GetComponent<UIDocument>();
        if (jobDataLoader == null) jobDataLoader = FindFirstObjectByType<JobDataLoader>();
        if (easterEggManager == null) easterEggManager = GetComponent<EasterEggManager>();
        if (easterEggManager == null) easterEggManager = gameObject.AddComponent<EasterEggManager>();

        // Setup Audio
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
        
        clickSound = Resources.Load<AudioClip>("click");
        if (clickSound == null) Debug.LogWarning("Could not load 'click.ogg' from Resources.");

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

        searchField = root.Q<TextField>("SearchField");
        if (searchField != null)
        {
            // Play sound on input change
            searchField.RegisterCallback<ChangeEvent<string>>(evt => PlayClickSound());
            
            // Add click sound when typing
            searchField.RegisterCallback<KeyDownEvent>(evt => PlayClickSound());
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
                        }
                    }
                }
            };
            sectionList.itemsSource = currentSectionItems;
            sectionList.selectionChanged += OnSectionSelected;
            // Play sound on selection
            sectionList.selectionChanged += (items) => PlayClickSound();
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

        Debug.Log("JobSearchUIController initialized.");
    }

    private void OnDisable()
    {
        if (searchButton != null)
            searchButton.clicked -= OnSearchClicked;

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
        bool isPayroll = docType == "payroll";
        bool isHelp = docType == "help";
        bool isMRT = docType == "mrt";
        bool isMRTAEI = docType == "mrt_aei";
        bool isYES = docType == "yes";
        bool isDirectAccess = docType == "direct_access";
        bool isMiscellaneous = docType == "miscellaneous";

        // Show/Hide Content Search Field
        if (searchControlsContainer != null)
        {
            if (isMainframe || isTEGuide || isCrewLife || isPayroll || isMRT || isMRTAEI || isYES || isDirectAccess || isMiscellaneous)
            {
                Debug.Log($"Showing Search Controls for docType: {docType}");
                searchControlsContainer.style.display = DisplayStyle.Flex;
                if (contentSearchField != null)
                {
                    contentSearchField.value = ""; // Reset search
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
            }
        }
        else if (contentSearchField != null)
        {
            // Fallback if container not found (e.g. old UXML)
            if (isMainframe || isTEGuide || isCrewLife || isPayroll || isMRT || isMRTAEI || isYES || isDirectAccess || isMiscellaneous)
            {
                contentSearchField.style.display = DisplayStyle.Flex;
                contentSearchField.value = "";
                currentSearchTerm = "";
            }
            else
            {
                contentSearchField.style.display = DisplayStyle.None;
            }
        }
        else
        {
            Debug.LogError("ContentSearchField is null in OnJobLoaded!");
        }

        // Set Header
        if (isMainframe)
        {
            if (jobTitle != null) jobTitle.text = job.title;
            if (jobSubtitle != null) jobSubtitle.text = $"{job.systemName} v{job.version}";
        }
        else if (isTEGuide || isCrewLife || isPayroll || isHelp || isMRT || isMRTAEI || isYES || isDirectAccess || isMiscellaneous)
        {
            if (jobTitle != null) jobTitle.text = job.title;
            if (jobSubtitle != null) jobSubtitle.text = $"{job.category} v{job.version}";
        }
        else
        {
            // Standard Job Header
            if (jobTitle != null) jobTitle.text = $"{job.jobNumber} - {job.jobName}";
            if (jobSubtitle != null) jobSubtitle.text = $"{job.craft} | {job.onduty} | {job.location}";
        }

        // Populate List
        allSectionItems.Clear();

        if (isMainframe || isMRT || isMRTAEI || isYES || isDirectAccess || isMiscellaneous)
        {
            // Add Mainframe/MRT/YES/DA/Misc specific sections
            allSectionItems.Add(new SectionItem { DisplayName = "**Summary**", Type = ItemType.MainframeGuide, GuideData = job });
            
            // Also add any standard sections/tables defined in the JSON for Mainframe
            if (job.sections != null)
            {
                foreach (var section in job.sections)
                {
                    // Skip adding "Summary" again if it's already handled by the hardcoded item above
                    if (section.label.Equals("Summary", StringComparison.OrdinalIgnoreCase))
                        continue;

                    allSectionItems.Add(new SectionItem { DisplayName = section.label, FileKey = section.file, Type = ItemType.Text });
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
                    // Check if the file is a CSV (Table) or MD (Text)
                    ItemType type = section.file.EndsWith(".csv", StringComparison.OrdinalIgnoreCase) ? ItemType.Text : ItemType.Text;
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
            if (job.procedures != null)
            {
                foreach (var proc in job.procedures)
                {
                    allSectionItems.Add(new SectionItem { DisplayName = proc.name, FileKey = proc.file, Type = ItemType.Text });
                }
            }

            // Add Images
            if (job.images != null)
            {
                foreach (var img in job.images)
                {
                    allSectionItems.Add(new SectionItem { DisplayName = img.name, FileKey = img.file, Type = ItemType.Image });
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
        
        // Automatically refresh the current view if a section is selected
        if (sectionList.selectedIndex >= 0)
        {
            // Re-trigger selection logic to update highlighting
            OnSectionSelected(new List<object> { sectionList.selectedItem });
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
                    img.style.unityBackgroundScaleMode = ScaleMode.ScaleToFit;
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
        else
        {
            // Handle Text Content
            string content = "";
            string fileKey = item.FileKey;

            // Check if it's a nested job (JSON file)
            if (fileKey.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            {
                string currentFolder = jobDataLoader.JobFolder;
                string directory = System.IO.Path.GetDirectoryName(fileKey);
                string fullFolderPath = System.IO.Path.Combine(currentFolder, directory);
                
                jobDataLoader.LoadJobFromInputField(fullFolderPath);
                return;
            }
            
            content = GetFileContent(fileKey);
            if (content == null) content = "Content not found.";

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
            }
            else
            {
                var label = new Label(content);
                label.AddToClassList("detail-content");
                detailView.Add(label);
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
            sb.AppendLine($"# Summary");
            sb.AppendLine(guide.summary);
            sb.AppendLine();
        }

        // Access Steps
        if (guide.accessSteps != null && guide.accessSteps.Count > 0)
        {
            sb.AppendLine($"# Access Steps");
            for (int i = 0; i < guide.accessSteps.Count; i++)
            {
                sb.AppendLine($"{i + 1}. {guide.accessSteps[i]}");
            }
            sb.AppendLine();
        }

        // Usage Tips
        if (guide.usageTips != null && guide.usageTips.Count > 0)
        {
            sb.AppendLine($"# Usage Tips");
            foreach (var tip in guide.usageTips)
            {
                sb.AppendLine($"- {tip}");
            }
            sb.AppendLine();
        }

        // Links
        if (guide.links != null && guide.links.Count > 0)
        {
            sb.AppendLine($"# Links");
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
        fullImage.transform.scale = Vector3.one;
        fullImage.transform.position = Vector3.zero;
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
        fullImage.transform.scale = Vector3.one * currentZoom;
    }

    private void ZoomOut()
    {
        if (fullImage == null) return;
        currentZoom = Mathf.Max(currentZoom - 0.5f, 1f); // Min zoom 1x
        if (currentZoom == 1f)
        {
            fullImage.transform.position = Vector3.zero; // Reset position if zoomed out completely
        }
        fullImage.transform.scale = Vector3.one * currentZoom;
    }

    private void OnPointerDown(PointerDownEvent evt)
    {
        if (currentZoom > 1f)
        {
            isPanning = true;
            panStart = evt.position;
            imageStartPos = fullImage.transform.position;
            fullImage.CapturePointer(evt.pointerId);
            evt.StopPropagation();
        }
    }

    private void OnPointerMove(PointerMoveEvent evt)
    {
        if (isPanning && fullImage.HasPointerCapture(evt.pointerId))
        {
            Vector2 delta = (Vector2)evt.position - panStart;
            fullImage.transform.position = imageStartPos + (Vector3)delta;
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
}
