using System;
using System.Collections.Generic;

[Serializable]
public class JobTableRef
{
    public string name;
    public string file;
}

[Serializable]
public class JobSection
{
    public string label;
    public string file;
}

[Serializable]
public class JobProcedure
{
    public string name;
    public string file;
}

[Serializable]
public class JobImage
{
    public string name;
    public string file;
}

[Serializable]
public class JobData
{
    // Standard Job Fields
    public string jobNumber;
    public string jobName;
    public string craft;
    public string onduty;
    public string yardCode;
    public string subdivisionCode;
    public string serviceType;
    public string location;
    public string radioChannels;
    public List<string> equipment;
    public List<JobSection> sections;
    public List<JobTableRef> tables;
    public List<JobProcedure> procedures;
    public List<JobImage> images;

    // Mainframe Guide Fields (Optional)
    public string docType; // "mainframe", "system_guide", "te_guide", "crewlife"
    public string title;
    public string systemName;
    public string category; // For T&E and CrewLife
    public string version;
    public string summary;
    public List<string> accessSteps;
    public List<string> usageTips;
    public List<JobTableRef> links; // Reusing JobTableRef for links (name=title, file=url)
    public List<string> keywords;

    // Color Customization (Optional)
    public string titleColor;
    public string categoryColor;
    public string summaryColor;
}