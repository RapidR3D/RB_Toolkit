## <color=#FF8C00>AEI Reads & Notifications</color>  

## <color=#FF8C00>Overview</color>  

AEI (Automated Equipment Identification) reads verify your train consist using trackside scanners. Handling AEI reads correctly ensures your work order matches what you're actually moving.  

---

## <color=#FF8C00>What is AEI?</color>  

### <color=#20B2AA>Automated Equipment Identification</color>  

<color=#FF8C00>**Technology:**</color>  
- Trackside scanners read RFID tags on railcars
- Automatic capture of car initials and numbers
- Verifies train consist against work order
- Detects discrepancies

<color=#FF8C00>**Locations:**</color>  
- Outbound yard exits
- Inbound yard entrances
- Key mileposts en route
- Interchange points

<color=#FF8C00>**Purpose:**</color>  
- Confirm you have the cars on your work order
- Detect cars NOT on your work order
- Identify missing cars from work order
- Verify car sequence

---

## <color=#FF8C00>Types of AEI Reads</color>  

### <color=#20B2AA>Outbound AEI Read</color>  
<color=#FF8C00>**When:**</color> Departing origin yard  
<color=#FF8C00>**Purpose:**</color> Verify you're leaving with correct cars  
<color=#FF8C00>**Handle:**</color> BEFORE reporting work at any other locations  

### <color=#20B2AA>Inbound AEI Read</color>  
<color=#FF8C00>**When:**</color> Arriving at destination yard  
<color=#FF8C00>**Purpose:**</color> Verify what you're bringing in  
<color=#FF8C00>**Handle:**</color> BEFORE reporting Set Out at destination  

### <color=#20B2AA>En Route AEI Read</color>  
<color=#FF8C00>**When:**</color> Passing trackside scanners during journey  
<color=#FF8C00>**Purpose:**</color> Monitor train consist during movement  
<color=#FF8C00>**Handle:**</color> Review for major discrepancies  

---

## <color=#FF8C00>AEI Notification</color>  

### <color=#20B2AA>Alert Indicators</color>  

<color=#FF8C00>**Notification Bell:**</color>  
🔔 (2)  
AEI Reads (2)  
Number shows unread AEI notifications  

<color=#FF8C00>**Notification List:**</color>  
AEI Received at 11/30 07:53  
AEI Read: 923 4144 Verified  

AEI Received at 11/29 15:42  
AEI Read: 922 2103 Discrepancies  

---

## <color=#FF8C00>Accessing AEI Reads</color>  

### <color=#20B2AA>Method 1: From Notification Bell</color>  
1. Tap **notification bell** (🔔)  
2. Select **AEI Reads** notification  
3. AEI Read Selection screen opens  

### <color=#20B2AA>Method 2: From Menu</color>  
1. Tap **Menu** (☰)  
2. Select **AEI Reads**  
3. Shows all AEI reads for this work order  

---

## <color=#FF8C00>AEI Read Selection Screen</color>  

### <color=#20B2AA>Three Tabs (Work Left to Right)</color>  

#### Tab 1: AEI Errors
<color=#FF8C00>**Purpose:**</color> Cars with mismatches between AEI and work order  
<color=#FF8C00>**Action Required:**</color> Report or Exception each car  

#### Tab 2: AEI Add Cars
<color=#FF8C00>**Purpose:**</color> Cars scanned by AEI but NOT on your work order  
<color=#FF8C00>**Action Required:**</color> Add Work for each car  

#### Tab 3: All Cars (AEI Standing Order)
<color=#FF8C00>**Purpose:**</color> Complete verified consist after resolving errors/adds  
<color=#FF8C00>**Action Required:**</color> Accept AEI Standing Order  

---

## <color=#FF8C00>Handling AEI Errors</color>  

### <color=#20B2AA>Error Types</color>  

#### Missing Car
<color=#FF8C00>**Problem:**</color> Car on work order but NOT scanned by AEI  
<color=#FF8C00>**Possible Causes:**</color>  
- Car left behind at origin
- Car on different track than expected
- Bad AEI tag
- Car already moved by another crew

#### Wrong Position
<color=#FF8C00>**Problem:**</color> Car scanned but in wrong sequence  
<color=#FF8C00>**Possible Causes:**</color>  
- Cars coupled in different order
- Misread during switching
- Train standing order not followed

#### Wrong Information
<color=#FF8C00>**Problem:**</color> Car data doesn't match work order  
<color=#FF8C00>**Possible Causes:**</color>  
- Wrong car number entered
- Car swapped for another
- Data entry error in work order

---

### <color=#20B2AA>AEI Errors Tab Display</color>  

<color=#FF8C00>**Shows:**</color>  

AEI Errors (3)  

Seq  WO   Car         L/E  From           Reported  To          TOC/Req  Info  
     Seq                   Instruction    Time      Instruction  Name  
002  002  CSXT 7674   L    PICK UP FROM   10/17     SET OUT AT           AEI OK  
               S 229        18:07          S 156  
003  ---  MWCX 4802   L    ---            ---       ---                  ERROR  
004  005  CRDX 10137  L    PICK UP FROM   10/17     DI AT                AEI OK  
                            S 249          16:56     SAB ACW  


<color=#FF8C00>**Status Indicators:**</color>  
- **AEI OK** - Car verified
- **ERROR** - Car missing or wrong
- **---** - No work order sequence (added car)

---

### <color=#20B2AA>Resolving AEI Errors</color>  

#### Option 1: Report the Car
<color=#FF8C00>**Use when:**</color> Car is actually with you, AEI missed it  

<color=#FF8C00>**Process:**</color>  
1. Select the error car  
2. Verify car is physically present  
3. Tap **REPORT CAR**  
4. Enter actual position in train  
5. Confirm  

#### Option 2: Exception the Car
<color=#FF8C00>**Use when:**</color> Car is NOT with you, was left behind  

<color=#FF8C00>**Process:**</color>  
1. Select the error car  
2. Tap **EXCEPTION CAR**  
3. Choose exception code:  
   - **NP** (Not Performed)
   - **NI** (Not In)
   - **SO** (Set Out Other)
4. Choose reason code:  
   - **NA** (Not Available at Station)
   - **BO** (Bad Ordered)
   - **RE** (Railroad Error)
   - etc.
5. Tap **SEND**  

---

## <color=#FF8C00>Handling AEI Add Cars</color>  

### <color=#20B2AA>Add Cars Tab Display</color>  

<color=#FF8C00>**Shows:**</color>  
AEI Add Cars (2)  

Seq  WO   Car         L/E  From           Reported  To          TOC/Req  
     Seq                   Instruction    Time      Instruction  Name  
---  ---  TILX 351506 E    ---            ---       ---          
---  ---  ROIX 57755  E    ---            ---       ---        

<color=#FF8C00>**Indicators:**</color>  
- **---** - No work order information (unexpected car)
- Need to add these cars to work order

---

### <color=#20B2AA>Resolving Add Cars</color>  

#### Option 1: Add Work
<color=#FF8C00>**Use when:**</color> Cars are actually with you and should be moved  

<color=#FF8C00>**Process:**</color>  
1. Select the add car(s)  
2. Tap **ADD WORK** or **ACCEPT CARS**  
3. System prompts for instructions:  
   - Where did you get car? (FROM)
   - Where are you taking it? (TO)
4. Select FROM instruction (PK, PU, etc.)  
5. Select TO instruction (SO, PL, DI)  
6. Choose destinations  
7. Tap **ACCEPT**  
8. Cars added to work order  

#### Option 2: Reject/Exception
<color=#FF8C00>**Use when:**</color> Cars should NOT be with you  

<color=#FF8C00>**Process:**</color>  
1. Contact dispatcher immediately  
2. Determine proper disposition  
3. May need to:  
   - Set out at nearest siding
   - Return to origin
   - Exception as wrong train
4. Report as directed  

---

## <color=#FF8C00>Accept AEI Standing Order</color>  

### <color=#20B2AA>Purpose</color>  
Final verification that your work order now matches your actual train consist after resolving all errors and add cars.  

### <color=#20B2AA>When to Accept</color>  
✅ <color=#FF8C00>**Only after:**</color>  
- All AEI Errors resolved (reported or exceptioned)
- All Add Cars handled (added or rejected)
- Tabs 1 and 2 both show **(0)**

### <color=#20B2AA>All Cars Tab Display</color>  

<color=#FF8C00>**Shows:**</color>  
All Cars (8)  

Seq  WO   Car         L/E  From           Reported  To          TOC/Req  Status  
     Seq                   Instruction    Time      Instruction  Name  
001  001  CSXT 7674   L    PICK UP FROM   10/17     SET OUT AT           AEI OK  
                            S 229          18:07     S 156  
002  002  MWCX 4802   L    PICK UP FROM   10/17     DI AT                AEI OK  
                            S 249          16:56     SAB ACW  


<color=#FF8C00>**All cars show:**</color> AEI OK  

---

### <color=#20B2AA>Accepting Standing Order</color>  

<color=#FF8C00>**Step 1:**</color> Verify all cars show **AEI OK**  

<color=#FF8C00>**Step 2:**</color> Verify error count: **AEI Errors (0)**  

<color=#FF8C00>**Step 3:**</color> Verify add count: **AEI Add Cars (0)**  

<color=#FF8C00>**Step 4:**</color> Tap **ACCEPT AEI STANDING ORDER**  

<color=#FF8C00>**Step 5:**</color> System updates work order with verified consist  

<color=#FF8C00>**Result:**</color>  
- Work order now matches physical train
- Can proceed with reporting work at other locations
- Train standing order updated

---

## <color=#FF8C00>Critical AEI Rules</color>  

### <color=#20B2AA>⚠️ Outbound AEI Read</color>  
<color=#FF8C00>**MUST handle BEFORE reporting work at customers/interchanges**</color>  
<color=#FF8C00>**Workflow:**</color>  
1. Depart origin  
2. Pass outbound AEI scanner  
3. Receive AEI notification  
4. **STOP** - Handle AEI read completely  
5. **THEN** proceed to report customer work  

<color=#FF8C00>**Why:**</color> Ensures you're moving correct cars to customers  

### <color=#20B2AA>⚠️ Inbound AEI Read</color>  
<color=#FF8C00>**MUST handle BEFORE reporting Set Out at destination**</color>  
<color=#FF8C00>**Workflow:**</color>  
1. Arrive at destination yard  
2. Pass inbound AEI scanner  
3. Receive AEI notification  
4. **STOP** - Handle AEI read completely  
5. **THEN** report Set Out work  

<color=#FF8C00>**Why:**</color> Ensures destination yard gets accurate inventory  

---

## <color=#FF8C00>AEI Read Workflow (Step-by-Step)</color>  

### <color=#20B2AA>Outbound AEI Processing</color>  

<color=#FF8C00>**Step 1:**</color> Depart origin  
Origin Pickup: COMPLETED  
Departure Time: 03/30 09:25  

<color=#FF8C00>**Step 2:**</color> Receive notification  
🔔 AEI Reads (1)  
AEI Received at 03/30 09:28  

<color=#FF8C00>**Step 3:**</color> Tap notification bell → AEI Reads  

<color=#FF8C00>**Step 4:**</color> Check AEI Errors tab  
AEI Errors (2)  

<color=#FF8C00>**Step 5:**</color> Resolve each error:  
- Report if car is present
- Exception if car left behind

<color=#FF8C00>**Step 6:**</color> Check AEI Add Cars tab  
AEI Add Cars (1)  


<color=#FF8C00>**Step 7:**</color> Add Work for unexpected car:  
- Input FROM instruction
- Input TO instruction
- Accept car

<color=#FF8C00>**Step 8:**</color> Verify both tabs show (0)  
AEI Errors (0)  
AEI Add Cars (0)  

<color=#FF8C00>**Step 9:**</color> Go to All Cars tab  

<color=#FF8C00>**Step 10:**</color> Tap **ACCEPT AEI STANDING ORDER**  

<color=#FF8C00>**Step 11:**</color> Confirmation received  

<color=#FF8C00>**Step 12:**</color> NOW proceed to report customer work  

---

### <color=#20B2AA>Inbound AEI Processing</color>  

<color=#FF8C00>**Step 1:**</color> Approach destination yard  
Train Order: 82% Complete  
Last work: Customer places/pulls completed  

<color=#FF8C00>**Step 2:**</color> Pass inbound AEI scanner  

<color=#FF8C00>**Step 3:**</color> Receive notification  
🔔 AEI Reads (1)  
AEI Received at 03/30 16:45  

<color=#FF8C00>**Step 4:**</color> Tap notification → AEI Reads  

<color=#FF8C00>**Step 5:**</color> Work through tabs:  
1. **AEI Errors** - Resolve discrepancies  
2. **AEI Add Cars** - Handle unexpected cars  
3. **All Cars** - Accept Standing Order  

<color=#FF8C00>**Step 6:**</color> After accepting AEI Standing Order:  
- Proceed to destination Set Out tile
- Report Set Out work
- Complete work order

---

## <color=#FF8C00>Common AEI Scenarios</color>  

### <color=#20B2AA>Scenario 1: Missing Car at Origin</color>  

AEI Error: Car ARMN 933003 not scanned  

Investigation:  
- Car was on work order
- You did not actually pick it up
- Car still at origin yard

Action:  
1. Select ARMN 933003 in AEI Errors  
2. Tap EXCEPTION CAR  
3. Choose: NP (Not Performed)  
4. Reason: NA (Not Available at Station)  
5. Continue with actual cars you have  

### <color=#20B2AA>Scenario 2: Extra Car Added</color>  
AEI Add Car: TILX 351506 scanned but not on WO  

Investigation:  
- Car was coupled to your cut
- Not on original work order
- Destined for same location

Action:  
1. Select TILX 351506 in Add Cars tab  
2. Tap ADD WORK  
3. FROM: PK (Pickup from origin)  
4. TO: SO (Set Out at destination)  
5. Accept car  
6. Report with rest of set out  

### <color=#20B2AA>Scenario 3: Wrong Car Position</color>  
AEI Error: CRDX 10137 in position 4, WO shows position 5  

Investigation:  
- Car is present
- Just coupled in different sequence
- No operational impact

Action:  
1. Select CRDX 10137  
2. Tap REPORT CAR  
3. Confirm actual position (4)  
4. System updates standing order  

### <color=#20B2AA>Scenario 4: Bad AEI Tag</color>  
AEI Error: Car UTLX 920035 missing from scan  

Investigation:  
- Car is physically present in train
- Verified car number visually
- AEI tag likely defective

Action:  
1. Select UTLX 920035  
2. Tap REPORT CAR  
3. Confirm car is present  
4. Enter actual position  
5. Note bad AEI tag to mechanical  

---

## <color=#FF8C00>AEI Best Practices</color>  

### <color=#20B2AA>Before Departing</color>  
- ✅ Verify all origin pickup cars selected
- ✅ Confirm train standing order
- ✅ Double-check equipment (locos, EOT)
- ✅ Be prepared to handle AEI read

### <color=#20B2AA>After AEI Scan</color>  
- ✅ Handle notification immediately
- ✅ Don't continue to customers until AEI resolved
- ✅ Resolve ALL errors before accepting standing order
- ✅ Verify all add cars before accepting
- ✅ Accept standing order only when tabs show (0), (0)

### <color=#20B2AA>Discrepancy Investigation</color>  
- ✅ Visually verify cars on train
- ✅ Check car numbers carefully
- ✅ Consult work order printout
- ✅ Contact yardmaster if uncertain
- ✅ Call MRT Helpdesk for guidance

### <color=#20B2AA>Documentation</color>  
- ✅ Report accurately what you have
- ✅ Exception what you don't have
- ✅ Use correct exception reasons
- ✅ Note defective AEI tags
- ✅ Communicate issues to next crew

---

## <color=#FF8C00>Troubleshooting AEI Issues</color>  

### <color=#20B2AA>AEI Read Doesn't Match Reality</color>  
<color=#FF8C00>**Problem:**</color> AEI shows cars you don't have, or missing cars you do have  

<color=#FF8C00>**Solution:**</color>  
1. Stop and visually verify your entire train  
2. Make list of actual cars you have  
3. Compare to work order and AEI  
4. Report/exception to match actual consist  
5. Call MRT Helpdesk if major discrepancies  

### <color=#20B2AA>Cannot Resolve AEI Errors</color>  
<color=#FF8C00>**Problem:**</color> Errors remain after attempting to resolve  

<color=#FF8C00>**Solution:**</color>  
1. Document specific issue  
2. Call MRT Helpdesk: 800-243-7743 #4  
3. Provide:  
   - Train ID and Work Order #
   - AEI location and time
   - Specific cars with errors
   - What you've tried
4. Helpdesk will assist resolution  

### <color=#20B2AA>Multiple AEI Reads Stacking Up</color>  
<color=#FF8C00>**Problem:**</color> Receiving multiple AEI notifications before resolving first  

<color=#FF8C00>**Solution:**</color>  
1. Handle them in chronological order  
2. Oldest first (outbound before inbound)  
3. Each AEI read must be fully resolved  
4. Accept each standing order before next  
5. Don't skip or ignore any AEI reads  

### <color=#20B2AA>Add Cars with Unknown Destination</color>  
<color=#FF8C00>**Problem:**</color> AEI shows cars you have but don't know where they go  

<color=#FF8C00>**Solution:**</color>  
1. Contact dispatcher immediately  
2. Provide car initials and numbers  
3. Dispatcher will check car routing  
4. Add work with correct destination once known  
5. Don't guess at destinations  

---

## <color=#FF8C00>Error Cars Function</color>  

### <color=#20B2AA>Accessing Error Cars</color>  
<color=#FF8C00>**From Menu:**</color>  
1. Tap Menu (☰)  
2. Select **Error Cars**  

### <color=#20B2AA>Purpose</color>  
Shows cars with unresolved issues:  
- Exception conflicts
- Reporting errors
- Missing information
- Data integrity problems

### <color=#20B2AA>Process</color>  
1. Review each error car  
2. Correct the issue:  
   - Re-report with correct data
   - Complete missing information
   - Resolve exception conflicts
3. Verify error clears  

---

## <color=#FF8C00>AEI Quick Reference</color>  

| Task | Action |  
|------|--------|  
| Check for AEI | Tap notification bell |  
| Open AEI Read | Tap AEI Reads notification |  
| Resolve errors | AEI Errors tab → Report or Exception each |  
| Handle add cars | Add Cars tab → Add Work for each |  
| Accept consist | All Cars tab → ACCEPT AEI STANDING ORDER |  
| View all AEIs | Menu → AEI Reads |  
| Check error cars | Menu → Error Cars |  

---

## <color=#FF8C00>AEI Notification Types</color>  

### <color=#20B2AA>Stop Train (0)</color>  
<color=#FF8C00>**Critical:**</color> Emergency stop order  
<color=#FF8C00>**Action:**</color> Stop immediately, contact dispatcher  

### <color=#20B2AA>AEI Reads (X)</color>  
<color=#FF8C00>**Priority:**</color> Handle before continuing  
<color=#FF8C00>**Action:**</color> Resolve all errors and add cars  

### <color=#20B2AA>TSO/Train Docs (X)</color>  
<color=#FF8C00>**Important:**</color> Updated train documents  
<color=#FF8C00>**Action:**</color> Download new documents when convenient  

### <color=#20B2AA>New Work (X)</color>  
<color=#FF8C00>**Operational:**</color> Additional work assigned  
<color=#FF8C00>**Action:**</color> Review and accept/reject  

### <color=#20B2AA>Text Messages (X)</color>  
<color=#FF8C00>**Informational:**</color> Direct communications  
<color=#FF8C00>**Action:**</color> Read and acknowledge  

---

## <color=#FF8C00>Need Help?</color>  

📞 **MRT Helpdesk: 800-243-7743 option #4**  

<color=#FF8C00>**Call for:**</color>  
- Cannot resolve AEI errors
- Major discrepancies between AEI and actual train
- Questions about reporting vs. exceptioning
- Add cars with unknown destination
- Multiple conflicting AEI reads
- AEI standing order won't accept

<color=#FF8C00>**Have ready:**</color>  
- Train ID and Work Order number
- AEI location and time
- Specific cars with issues
- What you've tried to resolve
- Visual verification of your actual train consist