## AEI Reads & Notifications

## Overview

AEI (Automated Equipment Identification) reads verify your train consist using trackside scanners. Handling AEI reads correctly ensures your work order matches what you're actually moving.

---

## What is AEI?

### Automated Equipment Identification

**Technology:**
- Trackside scanners read RFID tags on railcars
- Automatic capture of car initials and numbers
- Verifies train consist against work order
- Detects discrepancies

**Locations:**
- Outbound yard exits
- Inbound yard entrances
- Key mileposts en route
- Interchange points

**Purpose:**
- Confirm you have the cars on your work order
- Detect cars NOT on your work order
- Identify missing cars from work order
- Verify car sequence

---

## Types of AEI Reads

### Outbound AEI Read
**When:** Departing origin yard
**Purpose:** Verify you're leaving with correct cars
**Handle:** BEFORE reporting work at any other locations

### Inbound AEI Read
**When:** Arriving at destination yard
**Purpose:** Verify what you're bringing in
**Handle:** BEFORE reporting Set Out at destination

### En Route AEI Read
**When:** Passing trackside scanners during journey
**Purpose:** Monitor train consist during movement
**Handle:** Review for major discrepancies

---

## AEI Notification

### Alert Indicators

**Notification Bell:**
🔔 (2)
AEI Reads (2)
Number shows unread AEI notifications

**Notification List:**
AEI Received at 11/30 07:53
AEI Read: 923 4144 Verified

AEI Received at 11/29 15:42
AEI Read: 922 2103 Discrepancies

---

## Accessing AEI Reads

### Method 1: From Notification Bell
1. Tap **notification bell** (🔔)
2. Select **AEI Reads** notification
3. AEI Read Selection screen opens

### Method 2: From Menu
1. Tap **Menu** (☰)
2. Select **AEI Reads**
3. Shows all AEI reads for this work order

---

## AEI Read Selection Screen

### Three Tabs (Work Left to Right)

#### Tab 1: AEI Errors
**Purpose:** Cars with mismatches between AEI and work order
**Action Required:** Report or Exception each car

#### Tab 2: AEI Add Cars
**Purpose:** Cars scanned by AEI but NOT on your work order
**Action Required:** Add Work for each car

#### Tab 3: All Cars (AEI Standing Order)
**Purpose:** Complete verified consist after resolving errors/adds
**Action Required:** Accept AEI Standing Order

---

## Handling AEI Errors

### Error Types

#### Missing Car
**Problem:** Car on work order but NOT scanned by AEI
**Possible Causes:**
- Car left behind at origin
- Car on different track than expected
- Bad AEI tag
- Car already moved by another crew

#### Wrong Position
**Problem:** Car scanned but in wrong sequence
**Possible Causes:**
- Cars coupled in different order
- Misread during switching
- Train standing order not followed

#### Wrong Information
**Problem:** Car data doesn't match work order
**Possible Causes:**
- Wrong car number entered
- Car swapped for another
- Data entry error in work order

---

### AEI Errors Tab Display

**Shows:**

AEI Errors (3)

Seq  WO   Car         L/E  From           Reported  To          TOC/Req  Info
     Seq                   Instruction    Time      Instruction  Name
002  002  CSXT 7674   L    PICK UP FROM   10/17     SET OUT AT           AEI OK
               S 229        18:07          S 156
003  ---  MWCX 4802   L    ---            ---       ---                  ERROR
004  005  CRDX 10137  L    PICK UP FROM   10/17     DI AT                AEI OK
                            S 249          16:56     SAB ACW


**Status Indicators:**
- **AEI OK** - Car verified
- **ERROR** - Car missing or wrong
- **---** - No work order sequence (added car)

---

### Resolving AEI Errors

#### Option 1: Report the Car
**Use when:** Car is actually with you, AEI missed it

**Process:**
1. Select the error car
2. Verify car is physically present
3. Tap **REPORT CAR**
4. Enter actual position in train
5. Confirm

#### Option 2: Exception the Car
**Use when:** Car is NOT with you, was left behind

**Process:**
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

## Handling AEI Add Cars

### Add Cars Tab Display

**Shows:**
AEI Add Cars (2)

Seq  WO   Car         L/E  From           Reported  To          TOC/Req
     Seq                   Instruction    Time      Instruction  Name
---  ---  TILX 351506 E    ---            ---       ---          
---  ---  ROIX 57755  E    ---            ---       ---        

**Indicators:**
- **---** - No work order information (unexpected car)
- Need to add these cars to work order

---

### Resolving Add Cars

#### Option 1: Add Work
**Use when:** Cars are actually with you and should be moved

**Process:**
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
**Use when:** Cars should NOT be with you

**Process:**
1. Contact dispatcher immediately
2. Determine proper disposition
3. May need to:
   - Set out at nearest siding
   - Return to origin
   - Exception as wrong train
4. Report as directed

---

## Accept AEI Standing Order

### Purpose
Final verification that your work order now matches your actual train consist after resolving all errors and add cars.

### When to Accept
✅ **Only after:**
- All AEI Errors resolved (reported or exceptioned)
- All Add Cars handled (added or rejected)
- Tabs 1 and 2 both show **(0)**

### All Cars Tab Display

**Shows:**
All Cars (8)

Seq  WO   Car         L/E  From           Reported  To          TOC/Req  Status
     Seq                   Instruction    Time      Instruction  Name
001  001  CSXT 7674   L    PICK UP FROM   10/17     SET OUT AT           AEI OK
                            S 229          18:07     S 156
002  002  MWCX 4802   L    PICK UP FROM   10/17     DI AT                AEI OK
                            S 249          16:56     SAB ACW


**All cars show:** AEI OK

---

### Accepting Standing Order

**Step 1:** Verify all cars show **AEI OK**

**Step 2:** Verify error count: **AEI Errors (0)**

**Step 3:** Verify add count: **AEI Add Cars (0)**

**Step 4:** Tap **ACCEPT AEI STANDING ORDER**

**Step 5:** System updates work order with verified consist

**Result:**
- Work order now matches physical train
- Can proceed with reporting work at other locations
- Train standing order updated

---

## Critical AEI Rules

### ⚠️ Outbound AEI Read
**MUST handle BEFORE reporting work at customers/interchanges**

**Workflow:**
1. Depart origin
2. Pass outbound AEI scanner
3. Receive AEI notification
4. **STOP** - Handle AEI read completely
5. **THEN** proceed to report customer work

**Why:** Ensures you're moving correct cars to customers

### ⚠️ Inbound AEI Read
**MUST handle BEFORE reporting Set Out at destination**

**Workflow:**
1. Arrive at destination yard
2. Pass inbound AEI scanner
3. Receive AEI notification
4. **STOP** - Handle AEI read completely
5. **THEN** report Set Out work

**Why:** Ensures destination yard gets accurate inventory

---

## AEI Read Workflow (Step-by-Step)

### Outbound AEI Processing

**Step 1:** Depart origin
Origin Pickup: COMPLETED
Departure Time: 03/30 09:25

**Step 2:** Receive notification
🔔 AEI Reads (1)
AEI Received at 03/30 09:28

**Step 3:** Tap notification bell → AEI Reads

**Step 4:** Check AEI Errors tab
AEI Errors (2)

**Step 5:** Resolve each error:
- Report if car is present
- Exception if car left behind

**Step 6:** Check AEI Add Cars tab
AEI Add Cars (1)


**Step 7:** Add Work for unexpected car:
- Input FROM instruction
- Input TO instruction
- Accept car

**Step 8:** Verify both tabs show (0)
AEI Errors (0)
AEI Add Cars (0)

**Step 9:** Go to All Cars tab

**Step 10:** Tap **ACCEPT AEI STANDING ORDER**

**Step 11:** Confirmation received

**Step 12:** NOW proceed to report customer work

---

### Inbound AEI Processing

**Step 1:** Approach destination yard
Train Order: 82% Complete
Last work: Customer places/pulls completed

**Step 2:** Pass inbound AEI scanner

**Step 3:** Receive notification
🔔 AEI Reads (1)
AEI Received at 03/30 16:45

**Step 4:** Tap notification → AEI Reads

**Step 5:** Work through tabs:
1. **AEI Errors** - Resolve discrepancies
2. **AEI Add Cars** - Handle unexpected cars
3. **All Cars** - Accept Standing Order

**Step 6:** After accepting AEI Standing Order:
- Proceed to destination Set Out tile
- Report Set Out work
- Complete work order

---

## Common AEI Scenarios

### Scenario 1: Missing Car at Origin

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

### Scenario 2: Extra Car Added
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

### Scenario 3: Wrong Car Position
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

### Scenario 4: Bad AEI Tag
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

## AEI Best Practices

### Before Departing
- ✅ Verify all origin pickup cars selected
- ✅ Confirm train standing order
- ✅ Double-check equipment (locos, EOT)
- ✅ Be prepared to handle AEI read

### After AEI Scan
- ✅ Handle notification immediately
- ✅ Don't continue to customers until AEI resolved
- ✅ Resolve ALL errors before accepting standing order
- ✅ Verify all add cars before accepting
- ✅ Accept standing order only when tabs show (0), (0)

### Discrepancy Investigation
- ✅ Visually verify cars on train
- ✅ Check car numbers carefully
- ✅ Consult work order printout
- ✅ Contact yardmaster if uncertain
- ✅ Call MRT Helpdesk for guidance

### Documentation
- ✅ Report accurately what you have
- ✅ Exception what you don't have
- ✅ Use correct exception reasons
- ✅ Note defective AEI tags
- ✅ Communicate issues to next crew

---

## Troubleshooting AEI Issues

### AEI Read Doesn't Match Reality
**Problem:** AEI shows cars you don't have, or missing cars you do have

**Solution:**
1. Stop and visually verify your entire train
2. Make list of actual cars you have
3. Compare to work order and AEI
4. Report/exception to match actual consist
5. Call MRT Helpdesk if major discrepancies

### Cannot Resolve AEI Errors
**Problem:** Errors remain after attempting to resolve

**Solution:**
1. Document specific issue
2. Call MRT Helpdesk: 800-243-7743 #4
3. Provide:
   - Train ID and Work Order #
   - AEI location and time
   - Specific cars with errors
   - What you've tried
4. Helpdesk will assist resolution

### Multiple AEI Reads Stacking Up
**Problem:** Receiving multiple AEI notifications before resolving first

**Solution:**
1. Handle them in chronological order
2. Oldest first (outbound before inbound)
3. Each AEI read must be fully resolved
4. Accept each standing order before next
5. Don't skip or ignore any AEI reads

### Add Cars with Unknown Destination
**Problem:** AEI shows cars you have but don't know where they go

**Solution:**
1. Contact dispatcher immediately
2. Provide car initials and numbers
3. Dispatcher will check car routing
4. Add work with correct destination once known
5. Don't guess at destinations

---

## Error Cars Function

### Accessing Error Cars
**From Menu:**
1. Tap Menu (☰)
2. Select **Error Cars**

### Purpose
Shows cars with unresolved issues:
- Exception conflicts
- Reporting errors
- Missing information
- Data integrity problems

### Process
1. Review each error car
2. Correct the issue:
   - Re-report with correct data
   - Complete missing information
   - Resolve exception conflicts
3. Verify error clears

---

## AEI Quick Reference

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

## AEI Notification Types

### Stop Train (0)
**Critical:** Emergency stop order
**Action:** Stop immediately, contact dispatcher

### AEI Reads (X)
**Priority:** Handle before continuing
**Action:** Resolve all errors and add cars

### TSO/Train Docs (X)
**Important:** Updated train documents
**Action:** Download new documents when convenient

### New Work (X)
**Operational:** Additional work assigned
**Action:** Review and accept/reject

### Text Messages (X)
**Informational:** Direct communications
**Action:** Read and acknowledge

---

## Need Help?

📞 **MRT Helpdesk: 800-243-7743 option #4**

**Call for:**
- Cannot resolve AEI errors
- Major discrepancies between AEI and actual train
- Questions about reporting vs. exceptioning
- Add cars with unknown destination
- Multiple conflicting AEI reads
- AEI standing order won't accept

**Have ready:**
- Train ID and Work Order number
- AEI location and time
- Specific cars with issues
- What you've tried to resolve
- Visual verification of your actual train consist