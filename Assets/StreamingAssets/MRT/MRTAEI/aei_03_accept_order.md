# (3) Accept AEI Scan

## Overview

The final step in processing an AEI Read is accepting the AEI Standing Order.

---

## When to Accept

### Prerequisites

✅ **All AEI Errors resolved**
- AEI Errors tab shows: **(0)**
- All error cars reported or exceptioned

✅ **All Add Cars processed**
- AEI Add Cars tab shows: **(0)**
- All added cars have work instructions

✅ **All Cars show AEI OK**
- Every car displays "AEI OK" status
- Train consist matches work order

---

## Accept Process

### Step 1: Navigate to All Cars Tab

Click the **All Cars** tab to view the complete verified consist.

---

## All Cars Display

### Screen Header

Mobile Rail Tool   Train: H79605   WO# 677846   AEI Read Selection


### Tab Structure
- **ALL AEI READS**
- **CANCEL**
- **REJECT AEI READ**

### Tab Counts
- **AEI Errors (0)**
- **AEI Add Cars (0)**
- **All Cars (6)**

---

## Verified Car List

### Column Headers
| AEI Standing Seq | WO Seq Order | Car | Load/Empty | From Instruction | Reported Time | To Instruction | TOC/Requestor Name | Info |
|------------------|--------------|-----|------------|------------------|---------------|----------------|-------------------|------|

### Example Complete List

**Car 1:**
001   001   CSXT 2797   L   PICK UP FROM CA 505   04/07 08:35   LOCOMOTIVES AT CA 505   AEI OK

**Car 2:**
002   004   MWCX 481361   E   PULL FROM CA 511 B104   04/07 12:19   SET OUT AT CA 505   AEI OK

**Car 3:**
003   003   MWCX 481426   E   PULL FROM CA 511 B104   04/07 12:19   SET OUT AT CA 505   AEI OK

---

## Accept AEI Standing Order Button

### Step 2: Click Accept

Click **Accept AEI Standing Order** button.

---

## What Happens When You Accept

### System Actions

1. **Updates Train Standing Order**
   - Adjusts car sequence based on AEI scan
   - Matches physical train to work order

2. **Updates Set Out (SO) on Device**
   - Modifies destination set out information
   - Reflects actual train consist

3. **Matches AEI Reader Results**
   - Confirms work order reflects how train passed the AEI reader
   - Synchronizes system with reality

---

## Critical Timing

### When to Accept AEI Read

**Outbound AEI (Origin):**
- Accept on your read **BEFORE** completing the Set Out on the work order
- Process immediately after departing origin
- Must be complete before reporting any customer or station work

**Inbound AEI (Destination):**
- Accept **BEFORE** reporting Set Out at destination
- Process as soon as you receive the read
- Final verification before completing work order

---

## Confirmation

After accepting, the system will:
- ✅ Update work order with verified consist
- ✅ Adjust car sequence to match AEI scan
- ✅ Clear the AEI notification
- ✅ Enable continued work order processing

---

## Post-Acceptance

### Next Steps

**After Outbound AEI:**
1. Continue to customers/stations
2. Report work as performed
3. Handle any new notifications

**After Inbound AEI:**
1. Proceed to destination Set Out tile
2. Report Set Out work
3. Complete locomotives
4. Logout of work order

---

## Important Notes

### AEI Standing Order Updates

The Accept function:
- **Does NOT create new cars** - only verifies existing
- **Does NOT remove cars** - only adjusts sequence
- **Does synchronize** work order with physical train
- **Does update** train standing order automatically

### Work Order Impact

Accepting the AEI Standing Order:
- ✅ Confirms your consist is accurate
- ✅ Prevents discrepancies at destination
- ✅ Ensures proper set out processing
- ✅ Maintains system integrity

---

## Troubleshooting

### Cannot Accept Standing Order

**Problem:** Accept button not working or grayed out

**Solution:**
1. Verify **AEI Errors (0)** - must show zero
2. Verify **AEI Add Cars (0)** - must show zero
3. Check that all cars show **AEI OK** status
4. If issues persist, call MRT Helpdesk

---

### Cars Still Show Errors

**Problem:** Some cars don't show "AEI OK"

**Solution:**
1. Return to **AEI Errors** tab
2. Process remaining error cars
3. Report or exception each one
4. Return to **All Cars** tab
5. Verify all show AEI OK
6. Then accept standing order

---

### Add Cars Not Processed

**Problem:** AEI Add Cars count not zero

**Solution:**
1. Return to **AEI Add Cars** tab
2. Add work for each car OR
3. Skip/unskip cars not present
4. Verify count shows (0)
5. Return to **All Cars** tab
6. Accept standing order

---

## Best Practices

### Before Accepting
- ✅ Double-check both error and add car tabs show (0)
- ✅ Verify every car shows "AEI OK"
- ✅ Review train sequence matches reality
- ✅ Confirm all work instructions correct

### After Accepting
- ✅ Notification bell should clear AEI alert
- ✅ Work order updates with new sequence
- ✅ Can now proceed with remaining work
- ✅ Train standing order reflects AEI scan

### General Tips
- ✅ Process AEI reads immediately upon receipt
- ✅ Don't delay - affects subsequent work
- ✅ Verify physically before reporting
- ✅ Call helpdesk if uncertain

---

## Summary

The **Accept AEI Standing Order** is the final confirmation that:

1. Your work order matches your actual train
2. All discrepancies have been resolved
3. The system reflects reality
4. You can continue with work order completion

**This step is mandatory before proceeding with destination set out or further work order activities.**