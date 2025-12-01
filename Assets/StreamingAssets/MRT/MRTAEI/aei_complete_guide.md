# MRT AEI Guide - Accept an AEI Read in MRT Work Order

**Complete Reference Guide**

---

## Table of Contents

1. [Overview & Access](#overview--access)
2. [AEI Error Cars](#aei-error-cars)
3. [AEI Added Cars](#aei-added-cars)
4. [Accept AEI Standing Order](#accept-aei-standing-order)
5. [Correct AEI Placeholder Cars](#correct-aei-placeholder-cars)

---

## Overview & Access

### Introduction

This guide provides step-by-step instructions for processing Automated Equipment Identification (AEI) reads in the Mobile Rail Tool Work Order system.

### Access the Read

#### Method 1: Alert Bell
Use the **alert bell** icon to access the AEI Read.

#### Method 2: Menu Icon
Use the **menu icon** (≡) to access the AEI Read.

### When There Are No Cars to Handle

If **AEI Errors** and **Add Cars** both show zero:

1. Navigate to **All Cars** tab
2. Tap **ACCEPT AEI STANDING ORDER**

---

## AEI Scan Overview

The AEI Read Selection screen shows three tabs that must be processed in order:

### Tab Navigation Order

**Step 1:** AEI Errors
- Process error cars first
- Report or Exception all AEI Error Cars

**Step 2:** AEI Add Cars
- Process added cars second
- Handle all AEI Add cars

**Step 3:** All Cars
- Accept standing order last
- Only after Steps 1 and 2 are complete

### Notification Display

AEI reads appear in the **Notifications** panel:

AEI    Received at 12/28   09:56
AEI Read: 469 2342 Verified

### Steps to Process and Accept an AEI Read

To begin, select the AEI Read you want to use:

1. **Process AEI Error cars**
2. **Process AEI Add cars**
3. **Accept AEI Read**

### Important Notes

#### Car Status Indicators

**Origin of Car:**
- Highlighted cars show where the car originated
- Destination point of car is also highlighted

**Completion Status:**
- **Car is present by the AEI reader** and is waiting to be completed
- **Car either needs to be completed at destination point** or exception coded if it never existed on the train

### Screen Layout

The AEI Read Selection screen displays:

#### Header Information
- Mobile Rail Tool
- Train: (Train ID)
- WO# (Work Order Number)
- AEI Read Selection

#### Tab Structure
- **ALL AEI READS** (navigation)
- **CANCEL** (exit button)
- **REJECT AEI READ** (rejection option)

#### Three Processing Tabs
1. AEI Errors (with count)
2. AEI Add Cars (with count)
3. All Cars (with count)

#### Data Columns
- **AEI Standing Seq** - AEI sequence number
- **WO Seq Order** - Work order sequence
- **Car** - Car initial and number
- **Load/Empty** - L or E status
- **From Instruction** - Origin instruction
- **Reported Time** - When reported
- **To Instruction** - Destination instruction
- **TOC/Requestor Name** - Contact information
- **Info** - Status information

---

## AEI Error Cars

### Definition

**AEI Error Cars:** Cars on work order but not currently in train.

### Processing AEI Error Cars

Navigate to the **AEI Errors** tab to view cars with discrepancies.

### Selection Options

#### Select In Work Order

When enabled, click to skip or unskip adding a car:

- **Select In Work Order cars** and pont the pickup or pull
- **Select AEI Missing cars** and report the end point or exception them

### Error Car Status Indicators

#### Highlighted Cars

Cars highlighted in the **AEI Add Cars** column indicate:

- **Highlighted cars** are labeled as **added** to add work to train
- Cars need to be added via the **Add Work** function

### AEI Error Car Display

The screen shows detailed information for each error car:

#### Column Headers
- AEI Standing Seq
- WO Seq Order
- Car
- Load/Empty
- From Instruction
- Reported Time
- To Instruction
- TOC/Requestor Name
- Info

#### Example Error Cars

**In Work Order Status:**
- Car shows on work order
- Needs pickup or pull reported
- Highlighted for origin/destination

**AEI Missing Status:**
- Car expected but not scanned
- Verify if car actually present
- Report or exception as needed

### Actions for Error Cars

#### Option 1: Report Cars in Work Order

For cars that **ARE** on your train:
1. Select the car(s)
2. Tap the appropriate instruction button
3. Report the work

#### Option 2: Exception Missing Cars

For cars that are **NOT** on your train:
1. Select the car(s)
2. Tap exception
3. Choose appropriate exception code and reason

### Special Status Messages

#### In Work Order
- Car is on the work order
- Needs to be completed or exceptioned

#### AEI Missing
- Car was expected but not scanned by AEI
- Verify if car is actually present
- Report or exception as appropriate

### Car Position Information

- **Destination Point of Car** - Shows where the car is headed
- **Origin of Car** - Shows where the car came from

### Processing Notes

- **Click to add work** for cars in train but not on work order
- **Status buttons** available for L/E changes
- **ENTER LC CARS** option for locomotive and equipment entry

### Best Practices

#### Before Reporting
- ✅ Visually verify car presence in train
- ✅ Check car numbers carefully
- ✅ Confirm car position if needed

#### When Exceptioning
- ✅ Choose most accurate exception code
- ✅ Verify car truly missing from train
- ✅ Document reason clearly

#### For Add Work
- ✅ Ensure proper FROM and TO instructions
- ✅ Verify car location
- ✅ Complete add work process before accepting standing order

---

## AEI Added Cars

### Definition

**AEI Added Cars:** Cars on your train but not on your work order.

### Processing Steps

Navigate to the **AEI Add Cars** tab.

### Actions Required

#### Add Work (From/To)

For cars that should be on your train:

1. Select the **AEI Added Cars**
2. Set **LE** (Load/Empty) status if needed
3. Add work with proper **FROM** and **TO** instructions

### AEI OK Cars

#### Definition
**AEI OK Cars:** Cars on your train AND on your work order.

#### Status
Once all cars show **AEI OK**, you can accept the AEI Scan.

### Add Work Process

#### Step 1: Select Car
Tap and select the car that needs to be added.

#### Step 2: Set Initial Number
1. Tap **Set Initial Number**
2. A pop-up box will open

#### Step 3: Enter Car Details

┌─────────────────────────────────────┐
│ Please enter new car details:       │
│                                     │
│ ENTER CAR INITIAL & NUMBER          │
│ [                                ]  │
│                                     │
│         [Submit]                    │
└─────────────────────────────────────┘

#### Step 4: Input Information
1. Enter the **car initial**, **space**, and the **car number**
2. Click **Submit**

#### Step 5: Set Load/Empty Status
Then, indicate the **Load/Empty** status using the **Set Loaded** or **Set Empty** button.

#### Step 6: Add to Work Order
If there is no car, or you're unsure of the car type, select the car and tap the **Skip/Unskip Car** button.

### Scenario Example

#### Situation
Two cars show missing but the conductor verified they are on the train.

#### Actions

1. Check the **Add Cars** tab for **AEI Placeholder cars**
2. There is one car (position 72)
3. Tap and select **the car** that is there
4. Tap **Set Initial Number**
5. A pop-up box will open
6. Input the railcar that is present in that spot
7. Enter: **car initial**, **space**, and **car number**
8. Tap **Submit**

### Status Information

#### Info Column Values

**AEI Added**
- Car scanned by AEI
- Not on work order
- Needs to be added

**In Work Order** (after adding)
- Car successfully added
- Now part of work order
- Ready for processing

### Important Notes

#### Add Work Requirements
When adding cars, you must provide:
- ✅ Car initial and number
- ✅ Load/Empty (L/E) status
- ✅ FROM instruction (where you got it)
- ✅ TO instruction (where you're taking it)

#### Skip/Unskip Option
Use **Skip/Unskip Car** when:
- No car is present at that position
- Unsure of car type
- Need to bypass placeholder

### Best Practices

#### Before Adding Work
- ✅ Visually verify car is in train
- ✅ Confirm car initial and number
- ✅ Check load/empty status
- ✅ Know where car came from (FROM)
- ✅ Know where car is going (TO)

#### During Add Work
- ✅ Enter car details accurately
- ✅ Use space between initial and number
- ✅ Set correct L/E status
- ✅ Choose proper work instructions

#### After Adding
- ✅ Verify car shows "In Work Order"
- ✅ Confirm car appears in proper sequence
- ✅ Check that all add cars processed

---

## Accept AEI Standing Order

### Overview

The final step in processing an AEI Read is accepting the AEI Standing Order.

### When to Accept

#### Prerequisites

✅ **All AEI Errors resolved**
- AEI Errors tab shows: **(0)**
- All error cars reported or exceptioned

✅ **All Add Cars processed**
- AEI Add Cars tab shows: **(0)**
- All added cars have work instructions

✅ **All Cars show AEI OK**
- Every car displays "AEI OK" status
- Train consist matches work order

### Accept Process

Navigate to the **All Cars** tab to view the complete verified consist.

### All Cars Display

#### Tab Counts
- **AEI Errors (0)**
- **AEI Add Cars (0)**
- **All Cars (with total count)**

#### Verified Car List

All cars should display with:
- AEI sequence number
- Work order sequence
- Car initial and number
- Load/Empty status
- From instruction
- Reported time
- To instruction
- **Info: AEI OK**

### Accept AEI Standing Order Button

Click **Accept AEI Standing Order** button.

### What Happens When You Accept

#### System Actions

1. **Updates Train Standing Order**
   - Adjusts car sequence based on AEI scan
   - Matches physical train to work order

2. **Updates Set Out (SO) on Device**
   - Modifies destination set out information
   - Reflects actual train consist

3. **Matches AEI Reader Results**
   - Confirms work order reflects how train passed the AEI reader
   - Synchronizes system with reality

### Critical Timing

#### When to Accept AEI Read

**Outbound AEI (Origin):**
- Accept on your read **BEFORE** completing the Set Out on the work order
- Process immediately after departing origin
- Must be complete before reporting any customer or station work

**Inbound AEI (Destination):**
- Accept **BEFORE** reporting Set Out at destination
- Process as soon as you receive the read
- Final verification before completing work order

### Confirmation

After accepting, the system will:
- ✅ Update work order with verified consist
- ✅ Adjust car sequence to match AEI scan
- ✅ Clear the AEI notification
- ✅ Enable continued work order processing

### Post-Acceptance

#### Next Steps

**After Outbound AEI:**
1. Continue to customers/stations
2. Report work as performed
3. Handle any new notifications

**After Inbound AEI:**
1. Proceed to destination Set Out tile
2. Report Set Out work
3. Complete locomotives
4. Logout of work order

### Important Notes

#### AEI Standing Order Updates

The Accept function:
- **Does NOT create new cars** - only verifies existing
- **Does NOT remove cars** - only adjusts sequence
- **Does synchronize** work order with physical train
- **Does update** train standing order automatically

#### Work Order Impact

Accepting the AEI Standing Order:
- ✅ Confirms your consist is accurate
- ✅ Prevents discrepancies at destination
- ✅ Ensures proper set out processing
- ✅ Maintains system integrity

### Troubleshooting

#### Cannot Accept Standing Order

**Problem:** Accept button not working or grayed out

**Solution:**
1. Verify **AEI Errors (0)** - must show zero
2. Verify **AEI Add Cars (0)** - must show zero
3. Check that all cars show **AEI OK** status
4. If issues persist, call MRT Helpdesk

#### Cars Still Show Errors

**Problem:** Some cars don't show "AEI OK"

**Solution:**
1. Return to **AEI Errors** tab
2. Process remaining error cars
3. Report or exception each one
4. Return to **All Cars** tab
5. Verify all show AEI OK
6. Then accept standing order

#### Add Cars Not Processed

**Problem:** AEI Add Cars count not zero

**Solution:**
1. Return to **AEI Add Cars** tab
2. Add work for each car OR
3. Skip/unskip cars not present
4. Verify count shows (0)
5. Return to **All Cars** tab
6. Accept standing order

### Best Practices

#### Before Accepting
- ✅ Double-check both error and add car tabs show (0)
- ✅ Verify every car shows "AEI OK"
- ✅ Review train sequence matches reality
- ✅ Confirm all work instructions correct

#### After Accepting
- ✅ Notification bell should clear AEI alert
- ✅ Work order updates with new sequence
- ✅ Can now proceed with remaining work
- ✅ Train standing order reflects AEI scan

#### General Tips
- ✅ Process AEI reads immediately upon receipt
- ✅ Don't delay - affects subsequent work
- ✅ Verify physically before reporting
- ✅ Call helpdesk if uncertain

---

## Correct AEI Placeholder Cars

### Overview

AEI Placeholder Cars are temporary entries created when the AEI system cannot read a car's identification tag. These must be corrected with actual car information.

### What Are Placeholder Cars?

#### Definition

**Placeholder Car:** An entry in the AEI Add Cars column marked with **AEI ##** prefix.

#### Why They Exist

Placeholder cars appear when:
- AEI tag is damaged or missing
- AEI reader malfunction
- Car passed too quickly for accurate scan
- Environmental interference with RFID signal

#### Identifying Placeholders

Look for entries like:
Car: AEI ##7166A
Info: AEI Added

The **AEI ##** prefix indicates a placeholder.

### When to Check for Placeholders

#### Scenario Trigger

**If the Add Work button is disabled**, check for AEI placeholder cars.

#### How to Check

Navigate to the **AEI Add Cars** column and look for:
- Cars marked **AEI ##**
- Entries with fake car numbers
- Highlighted placeholder entries

### Correction Process

#### Step 1: Identify Placeholder Cars

These cars **did not pick up the AEI tag** and have **fake car numbers**.

#### Step 2: Highlight Correct Car

Highlight the car and tap **Set Initial/Number**.

#### Step 3: Enter Correct Information

┌─────────────────────────────────────┐
│ Please enter new car details:       │
│                                     │
│ ENTER CAR INITIAL & NUMBER          │
│ [                                ]  │
│                                     │
│         [Submit]                    │
└─────────────────────────────────────┘

1. Supply the **correct car number**
2. Click **Submit**

#### Step 4: Set Load/Empty Status

Then, indicate the **Load/Empty** status using:
- **Set Loaded** button, OR
- **Set Empty** button

#### Step 5: Handle Missing/Unknown Cars

If there is no car, or you're unsure of the car type:
1. Select the car
2. Tap the **Skip/Unskip Car** button

### Detailed Example Scenario

#### Situation

Two cars show missing but the conductor verified they are on the train.

#### Investigation Steps

1. **Check the Add Cars tab** for AEI Placeholder cars
2. **Confirm:** There is one car (position 72)
3. The placeholder shows as: `AEI ##7166A`

#### Correction Steps

1. Tap and select **the car** at position 72
2. Tap **Set Initial Number**
3. A pop-up box will open
4. Input the railcar present in that spot:
   - Car initial
   - Space
   - Car number
   - Example: `CSXT 2797`
5. Tap **Submit**
6. Set the Load/Empty status:
   - If loaded: Tap **Set Loaded**
   - If empty: Tap **Set Empty**
7. The placeholder is now replaced with actual car information

### Common Placeholder Scenarios

#### Scenario 1: Readable Car in Position

**Situation:** Placeholder exists, actual car present and readable

**Action:**
1. Visually identify car
2. Set Initial Number with correct car info
3. Set Load/Empty status
4. Add work instructions (FROM/TO)

#### Scenario 2: No Car in Position

**Situation:** Placeholder exists but position is empty

**Action:**
1. Select the placeholder
2. Tap **Skip/Unskip Car**
3. Placeholder removed from consideration
4. Continue processing other cars

#### Scenario 3: Unknown Car Type

**Situation:** Car present but cannot determine car number

**Action:**
1. Stop and physically verify
2. Walk to car location if safe
3. Read car marking directly
4. If cannot verify, tap **Skip/Unskip Car**
5. Report to MRT Helpdesk

#### Scenario 4: Multiple Placeholders

**Situation:** Several placeholder cars in Add Cars list

**Action:**
1. Process each placeholder individually
2. Verify physical position of each
3. Correct placeholders in sequence order
4. Skip any that cannot be verified
5. Do not guess - accuracy is critical

### Add Work Button Status

#### When Add Work is Disabled

The **Add Work** button becomes disabled when:
- AEI placeholder cars exist in the system
- System requires placeholder correction first
- Cannot add new work until placeholders resolved

#### Enabling Add Work Button

To re-enable the Add Work button:
1. Correct all placeholder cars OR
2. Skip/unskip all placeholders
3. Verify AEI Add Cars count reduces
4. Add Work button becomes active again

### Load/Empty Status

#### Set Loaded

Use **Set Loaded** when:
- Car contains freight
- Visual inspection confirms loaded
- Car sits low on trucks (loaded position)

#### Set Empty

Use **Set Empty** when:
- Car has no freight
- Visual inspection confirms empty
- Car sits high on trucks (empty position)

#### Cannot Determine

If Load/Empty status uncertain:
1. Do not guess
2. Tap **Skip/Unskip Car**
3. Call MRT Helpdesk for guidance
4. Verify with conductor/yardmaster

### Best Practices

#### Verification
- ✅ Always visually verify car before correcting placeholder
- ✅ Read car markings directly when possible
- ✅ Confirm sequence position matches reality
- ✅ Double-check car initial and number entry

#### Data Entry
- ✅ Use space between initial and number (CSXT 2797)
- ✅ Enter exactly as marked on car
- ✅ Verify spelling of railroad initials
- ✅ Confirm number is complete

#### When Uncertain
- ✅ Use Skip/Unskip rather than guessing
- ✅ Call MRT Helpdesk for assistance
- ✅ Document uncertainty
- ✅ Coordinate with conductor for verification

#### Safety
- ✅ Only approach cars if safe to do so
- ✅ Do not enter between cars
- ✅ Follow all safety protocols
- ✅ Never guess if unable to verify safely

### Troubleshooting

#### Cannot Find Physical Car

**Problem:** Placeholder exists but cannot locate actual car

**Solution:**
1. Verify train position and sequence
2. Count cars from known reference point
3. Check for cars in unexpected positions
4. If truly missing, tap Skip/Unskip Car
5. Report discrepancy to MRT Helpdesk

#### Multiple Placeholders for Same Position

**Problem:** Two placeholders seem to indicate same car

**Solution:**
1. Process first placeholder with correct info
2. Skip second placeholder
3. Verify Add Cars count decreases appropriately
4. If confusion persists, call MRT Helpdesk

#### Cannot Submit Car Information

**Problem:** Submit button not working after entering car info

**Solution:**
1. Verify format: INITIAL SPACE NUMBER
2. Check for special characters
3. Ensure all fields completed
4. Try re-entering information
5. Call MRT Helpdesk if persists

#### Add Work Still Disabled After Corrections

**Problem:** Add Work button remains disabled after fixing placeholders

**Solution:**
1. Verify all placeholders corrected or skipped
2. Check AEI Add Cars count
3. Refresh screen by backing out and re-entering
4. Restart MRT app if needed
5. Call MRT Helpdesk

---

## Summary

### Complete AEI Processing Workflow

1. **Receive AEI notification**
2. **Access via alert bell or menu**
3. **Process AEI Error Cars** (Tab 1)
   - Report cars in work order
   - Exception missing cars
4. **Process AEI Add Cars** (Tab 2)
   - Add work for unexpected cars
   - Correct placeholder cars
   - Skip/unskip as needed
5. **Verify All Cars show AEI OK** (Tab 3)
6. **Accept AEI Standing Order**
7. **Continue with work order**

### Critical Reminders

- ✅ Process AEI reads immediately
- ✅ Complete all three tabs in order
- ✅ Verify all cars show "AEI OK" before accepting
- ✅ Accept before continuing with work order activities
- ✅ Call MRT Helpdesk if uncertain

---

## Support

### MRT Helpdesk

📞 **Phone: 800-243-7743 option #4**

**Call for:**
- AEI processing questions
- Cannot accept standing order
- Placeholder car issues
- Error or add car problems
- System errors
- Any AEI-related concerns

**Have ready:**
- Train ID and Work Order number
- AEI scan location and time
- Specific car numbers involved
- What you've tried
- Any error messages

---

## Document Information

**Title:** MRT AEI Guide - Accept an AEI Read in MRT Work Order

**Purpose:** Step-by-step guide for processing AEI reads

**Audience:** CSX Transportation & Engineering employees

**Support:** MRT Helpdesk 800-243-7743 option #4

---

*End of AEI Guide*