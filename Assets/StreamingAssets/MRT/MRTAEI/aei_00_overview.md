# <color=#FFD700>MRT AEI Guide - Accept an AEI Read in MRT Work Order</color>

## <color=#FF8C00>Overview</color>

This guide provides step-by-step instructions for processing Automated Equipment Identification (AEI) reads in the Mobile Rail Tool Work Order system.  

---

## <color=#FF8C00>Access the Read</color>

### <color=#20B2AA>Method 1: Alert Bell</color>
Use the **alert bell** icon to access the AEI Read.  

### <color=#20B2AA>Method 2: Menu Icon</color>
Use the **menu icon** (≡) to access the AEI Read.  

---

## <color=#FF8C00>When There Are No Cars to Handle</color>

If **AEI Errors** and **Add Cars** both show zero:  

1. Navigate to **All Cars** tab  
2. Tap **ACCEPT AEI STANDING ORDER**  

---

## <color=#FF8C00>AEI Scan Overview</color>

The AEI Read Selection screen shows three tabs that must be processed in order:  

### <color=#20B2AA>Tab Navigation Order</color>

<color=#FF8C00>**Step 1:**</color> AEI Errors (4)  
- Process error cars first
- Report or Exception all AEI Error Cars

<color=#FF8C00>**Step 2:**</color> AEI Add Cars (2)  
- Process added cars second
- Handle all AEI Add cars

<color=#FF8C00>**Step 3:**</color> All Cars (8)  
- Accept standing order last
- Only after Steps 1 and 2 are complete

---

## <color=#FF8C00>Notification Display</color>

AEI reads appear in the **Notifications** panel:  


AEI    Received at 12/28   09:56  
AEI Read: 469 2342 Verified  


---

## <color=#FF8C00>Steps to Process and Accept an AEI Read</color>

To begin, select the AEI Read you want to use:  

1. **Process AEI Error cars**  
2. **Process AEI Add cars**  
3. **Accept AEI Read**  

---

## <color=#FF8C00>Important Notes</color>

### <color=#20B2AA>Car Status Indicators</color>

<color=#FF8C00>**Origin of Car:**</color>  
- Highlighted cars show where the car originated
- Destination point of car is also highlighted

<color=#FF8C00>**Completion Status:**</color>  
- **Car is present by the AEI reader** and is waiting to be completed
- **Car either needs to be completed at destination point** or exception coded if it never existed on the train

---

## <color=#FF8C00>Screen Layout</color>

The AEI Read Selection screen displays:  

### <color=#20B2AA>Header Information</color>
- Mobile Rail Tool
- Train: H79605
- WO# 677846
- AEI Read Selection

### <color=#20B2AA>Tab Structure</color>
- **ALL AEI READS** (navigation)
- **CANCEL** (exit button)
- **REJECT AEI READ** (rejection option)

### <color=#20B2AA>Three Processing Tabs</color>
1. AEI Errors (with count)  
2. AEI Add Cars (with count)  
3. All Cars (with count)  

### <color=#20B2AA>Data Columns</color>
- **AEI Standing Seq** - AEI sequence number
- **WO Seq Order** - Work order sequence
- **Car** - Car initial and number
- **Load/Empty** - L or E status
- **From Instruction** - Origin instruction
- **Reported Time** - When reported
- **To Instruction** - Destination instruction
- **TOC/Requestor Name** - Contact information
- **Info** - Status information (AEI OK, In Work Order, AEI Missing, etc.)