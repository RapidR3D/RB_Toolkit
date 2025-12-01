# Correct AEI Placeholder Cars

## Overview

AEI Placeholder Cars are temporary entries created when the AEI system cannot read a car's identification tag. These must be corrected with actual car information.

---

## What Are Placeholder Cars?

### Definition

**Placeholder Car:** An entry in the AEI Add Cars column marked as **AEI** in the **Add Cars** column.

### Why They Exist

Placeholder cars appear when:
- AEI tag is damaged or missing
- AEI reader malfunction
- Car passed too quickly for accurate scan
- Environmental interference with RFID signal

### Identifying Placeholders

Look for entries like:
Car: AEI ##7166A
Info: AEI Added

The **AEI ##** prefix indicates a placeholder.

---

## When to Check for Placeholders

### Scenario Trigger

**If the Add Work button is disabled**, check for AEI placeholder cars.

### How to Check

Navigate to the **AEI Add Cars** column and look for:
- Cars marked **AEI** 
- Entries with fake car numbers
- Highlighted placeholder entries

---

## Correction Process

### Step 1: Identify Placeholder Cars

These cars **did not pick up the AEI tag** and have **fake car numbers**.

### Step 2: Highlight Correct Car

Highlight the car and tap **Set Initial/Number**.

### Step 3: Enter Correct Information

**Pop-up: "Please enter new car details:"**

┌─────────────────────────────────────┐
│ Please enter new car details:       │
│                                     │
│ ENTER CAR INITIAL & NUMBER          │
│ [                                ]  │
│                                     │
│         [Submit]                    │
└─────────────────────────────────────┘

1. To supply the **correct car number**
2. Click **Submit**

### Step 4: Set Load/Empty Status

Then, indicate the **Load/Empty** status using:
- **Set Loaded** button, OR
- **Set Empty** button

### Step 5: Handle Missing/Unknown Cars

If there is no car, or you're unsure of the car type:
1. Select the car
2. Tap the **Skip/Unskip Car** button

---

## Detailed Example Scenario

### Situation

Two cars show missing but the conductor verified they are on the train.

### Investigation Steps

1. **Check the Add Cars tab** for AEI Placeholder cars
2. **Confirm:** There is one car (position 72)
3. The placeholder shows as: `AEI ##7166A`

### Correction Steps

**Step 1:** Tap and select **the car** that is there (position 72)

**Step 2:** Tap **Set Initial Number**

**Step 3:** A pop-up box will open

**Step 4:** Input the railcar that is present in that spot by entering:
- Car initial
- Space
- Car number

**Example:** `CSXT 2797`

**Step 5:** Tap **Submit**

**Step 6:** Set the Load/Empty status:
- If loaded: Tap **Set Loaded**
- If empty: Tap **Set Empty**

**Step 7:** The placeholder is now replaced with actual car information

---

## Screen Display Example

### Before Correction

AEI Add Cars (4)

Seq   Car             Load/Empty   From Instruction   To Instruction   Info
072   AEI ##7166A     (unknown)                                       AEI Added

### During Correction

┌──────────────────────────────────────┐
│ Please enter new car details:        │
│                                      │
│ ENTER CAR INITIAL & NUMBER           │
│ [CSXT 2797                        ]  │
│                                      │
│          [Submit]                    │
└──────────────────────────────────────┘

### After Correction


AEI Add Cars (3)

Seq   Car          Load/Empty   From Instruction   To Instruction   Info
072   CSXT 2797    L           (to be set)        (to be set)     In Work Order

---

## Common Placeholder Scenarios

### Scenario 1: Readable Car in Position

**Situation:** Placeholder exists, actual car present and readable

**Action:**
1. Visually identify car
2. Set Initial Number with correct car info
3. Set Load/Empty status
4. Add work instructions (FROM/TO)

---

### Scenario 2: No Car in Position

**Situation:** Placeholder exists but position is empty

**Action:**
1. Select the placeholder
2. Tap **Skip/Unskip Car**
3. Placeholder removed from consideration
4. Continue processing other cars

---

### Scenario 3: Unknown Car Type

**Situation:** Car present but cannot determine car number

**Action:**
1. Stop and physically verify
2. Walk to car location if safe
3. Read car marking directly
4. If cannot verify, tap **Skip/Unskip Car**
5. Report to MRT Helpdesk

---

### Scenario 4: Multiple Placeholders

**Situation:** Several placeholder cars in Add Cars list

**Action:**
1. Process each placeholder individually
2. Verify physical position of each
3. Correct placeholders in sequence order
4. Skip any that cannot be verified
5. Do not guess - accuracy is critical

---

## Add Work Button Status

### When Add Work is Disabled

The **Add Work** button becomes disabled when:
- AEI placeholder cars exist in the system
- System requires placeholder correction first
- Cannot add new work until placeholders resolved

### Enabling Add Work Button

To re-enable the Add Work button:
1. Correct all placeholder cars OR
2. Skip/unskip all placeholders
3. Verify AEI Add Cars count reduces
4. Add Work button becomes active again

---

## Load/Empty Status

### Set Loaded

Use **Set Loaded** when:
- Car contains freight
- Visual inspection confirms loaded
- Car sits low on trucks (loaded position)

### Set Empty

Use **Set Empty** when:
- Car has no freight
- Visual inspection confirms empty
- Car sits high on trucks (empty position)

### Cannot Determine

If Load/Empty status uncertain:
1. Do not guess
2. Tap **Skip/Unskip Car**
3. Call MRT Helpdesk for guidance
4. Verify with conductor/yardmaster

---

## Best Practices

### Verification
- ✅ Always visually verify car before correcting placeholder
- ✅ Read car markings directly when possible
- ✅ Confirm sequence position matches reality
- ✅ Double-check car initial and number entry

### Data Entry
- ✅ Use space between initial and number (CSXT 2797)
- ✅ Enter exactly as marked on car
- ✅ Verify spelling of railroad initials
- ✅ Confirm number is complete

### When Uncertain
- ✅ Use Skip/Unskip rather than guessing
- ✅ Call MRT Helpdesk for assistance
- ✅ Document uncertainty
- ✅ Coordinate with conductor for verification

### Safety
- ✅ Only approach cars if safe to do so
- ✅ Do not enter between cars
- ✅ Follow all safety protocols
- ✅ Never guess if unable to verify safely

---

## Troubleshooting

### Cannot Find Physical Car

**Problem:** Placeholder exists but cannot locate actual car

**Solution:**
1. Verify train position and sequence
2. Count cars from known reference point
3. Check for cars in unexpected positions
4. If truly missing, tap Skip/Unskip Car
5. Report discrepancy to MRT Helpdesk

---

### Multiple Placeholders for Same Position

**Problem:** Two placeholders seem to indicate same car

**Solution:**
1. Process first placeholder with correct info
2. Skip second placeholder
3. Verify Add Cars count decreases appropriately
4. If confusion persists, call MRT Helpdesk

---

### Cannot Submit Car Information

**Problem:** Submit button not working after entering car info

**Solution:**
1. Verify format: INITIAL SPACE NUMBER
2. Check for special characters
3. Ensure all fields completed
4. Try re-entering information
5. Call MRT Helpdesk if persists

---

### Add Work Still Disabled After Corrections

**Problem:** Add Work button remains disabled after fixing placeholders

**Solution:**
1. Verify all placeholders corrected or skipped
2. Check AEI Add Cars count
3. Refresh screen by backing out and re-entering
4. Restart MRT app if needed
5. Call MRT Helpdesk

---

## Summary Checklist

### Placeholder Correction Process

- [ ] Identify placeholder cars (AEI ## prefix)
- [ ] Verify physical car presence
- [ ] Tap Set Initial Number
- [ ] Enter correct car initial and number
- [ ] Click Submit
- [ ] Set Load/Empty status
- [ ] Or use Skip/Unskip if car absent/unknown
- [ ] Verify correction appears in list
- [ ] Repeat for all placeholders
- [ ] Confirm Add Work button re-enabled
- [ ] Continue with normal AEI processing

---

## Need Help?

📞 **MRT Helpdesk: 800-243-7743 option #4**

**Call for:**
- Cannot identify placeholder car
- Multiple placeholders in same position
- Add Work button remains disabled
- Uncertain about car information
- Safety concerns accessing cars
- System not accepting corrections

**Have ready:**
- Train ID and Work Order number
- AEI scan location and time
- Placeholder car numbers
- Position in train consist
- What you've tried