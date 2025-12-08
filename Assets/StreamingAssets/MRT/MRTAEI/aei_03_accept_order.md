# <color=#FFD700>(3) Accept AEI Scan</color>  

## <color=#FF8C00>Overview</color>  

The final step in processing an AEI Read is accepting the AEI Standing Order.  

---

## <color=#FF8C00>When to Accept</color>  

### <color=#20B2AA>Prerequisites</color>  

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

## <color=#FF8C00>Accept Process</color>  

### <color=#20B2AA>Step 1: Navigate to All Cars Tab</color>  

Click the **All Cars** tab to view the complete verified consist.  

---

## <color=#FF8C00>All Cars Display</color>  

### <color=#20B2AA>Screen Header</color>  

Mobile Rail Tool   Train: H79605   WO# 677846   AEI Read Selection  


### <color=#20B2AA>Tab Structure</color>  
- **ALL AEI READS**
- **CANCEL**
- **REJECT AEI READ**

### <color=#20B2AA>Tab Counts</color>  
- **AEI Errors (0)**
- **AEI Add Cars (0)**
- **All Cars (6)**

---

## <color=#FF8C00>Verified Car List</color>  

### <color=#20B2AA>Column Headers</color>  
| AEI Standing Seq | WO Seq Order | Car | Load/Empty | From Instruction | Reported Time | To Instruction | TOC/Requestor Name | Info |  
|------------------|--------------|-----|------------|------------------|---------------|----------------|-------------------|------|  

### <color=#20B2AA>Example Complete List</color>  

<color=#FF8C00>**Car 1:**</color>  
001   001   CSXT 2797   L   PICK UP FROM CA 505   04/07 08:35   LOCOMOTIVES AT CA 505   AEI OK  

<color=#FF8C00>**Car 2:**</color>  
002   004   MWCX 481361   E   PULL FROM CA 511 B104   04/07 12:19   SET OUT AT CA 505   AEI OK  

<color=#FF8C00>**Car 3:**</color>  
003   003   MWCX 481426   E   PULL FROM CA 511 B104   04/07 12:19   SET OUT AT CA 505   AEI OK  

---

## <color=#FF8C00>Accept AEI Standing Order Button</color>  

### <color=#20B2AA>Step 2: Click Accept</color>  

Click **Accept AEI Standing Order** button.  

---

## <color=#FF8C00>What Happens When You Accept</color>  

### <color=#20B2AA>System Actions</color>  

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

## <color=#FF8C00>Critical Timing</color>  

### <color=#20B2AA>When to Accept AEI Read</color>  

<color=#FF8C00>**Outbound AEI (Origin):**</color>  
- Accept on your read **BEFORE** completing the Set Out on the work order
- Process immediately after departing origin
- Must be complete before reporting any customer or station work

<color=#FF8C00>**Inbound AEI (Destination):**</color>  
- Accept **BEFORE** reporting Set Out at destination
- Process as soon as you receive the read
- Final verification before completing work order

---

## <color=#FF8C00>Confirmation</color>  

After accepting, the system will:  
- ✅ Update work order with verified consist
- ✅ Adjust car sequence to match AEI scan
- ✅ Clear the AEI notification
- ✅ Enable continued work order processing

---

## <color=#FF8C00>Post-Acceptance</color>  

### <color=#20B2AA>Next Steps</color>  

<color=#FF8C00>**After Outbound AEI:**</color>  
1. Continue to customers/stations  
2. Report work as performed  
3. Handle any new notifications  

<color=#FF8C00>**After Inbound AEI:**</color>  
1. Proceed to destination Set Out tile  
2. Report Set Out work  
3. Complete locomotives  
4. Logout of work order  

---

## <color=#FF8C00>Important Notes</color>  

### <color=#20B2AA>AEI Standing Order Updates</color>  

The Accept function:  
- **Does NOT create new cars** - only verifies existing
- **Does NOT remove cars** - only adjusts sequence
- **Does synchronize** work order with physical train
- **Does update** train standing order automatically

### <color=#20B2AA>Work Order Impact</color>  

Accepting the AEI Standing Order:  
- ✅ Confirms your consist is accurate
- ✅ Prevents discrepancies at destination
- ✅ Ensures proper set out processing
- ✅ Maintains system integrity

---

## <color=#FF8C00>Troubleshooting</color>  

### <color=#20B2AA>Cannot Accept Standing Order</color>  

<color=#FF8C00>**Problem:**</color> Accept button not working or grayed out  

<color=#FF8C00>**Solution:**</color>  
1. Verify **AEI Errors (0)** - must show zero  
2. Verify **AEI Add Cars (0)** - must show zero  
3. Check that all cars show **AEI OK** status  
4. If issues persist, call MRT Helpdesk  

---

### <color=#20B2AA>Cars Still Show Errors</color>  

<color=#FF8C00>**Problem:**</color> Some cars don't show "AEI OK"  

<color=#FF8C00>**Solution:**</color>  
1. Return to **AEI Errors** tab  
2. Process remaining error cars  
3. Report or exception each one  
4. Return to **All Cars** tab  
5. Verify all show AEI OK  
6. Then accept standing order  

---

### <color=#20B2AA>Add Cars Not Processed</color>  

<color=#FF8C00>**Problem:**</color> AEI Add Cars count not zero  

<color=#FF8C00>**Solution:**</color>  
1. Return to **AEI Add Cars** tab  
2. Add work for each car OR  
3. Skip/unskip cars not present  
4. Verify count shows (0)  
5. Return to **All Cars** tab  
6. Accept standing order  

---

## <color=#FF8C00>Best Practices</color>  

### <color=#20B2AA>Before Accepting</color>  
- ✅ Double-check both error and add car tabs show (0)
- ✅ Verify every car shows "AEI OK"
- ✅ Review train sequence matches reality
- ✅ Confirm all work instructions correct

### <color=#20B2AA>After Accepting</color>  
- ✅ Notification bell should clear AEI alert
- ✅ Work order updates with new sequence
- ✅ Can now proceed with remaining work
- ✅ Train standing order reflects AEI scan

### <color=#20B2AA>General Tips</color>  
- ✅ Process AEI reads immediately upon receipt
- ✅ Don't delay - affects subsequent work
- ✅ Verify physically before reporting
- ✅ Call helpdesk if uncertain

---

## <color=#FF8C00>Summary</color>  

The **Accept AEI Standing Order** is the final confirmation that:  

1. Your work order matches your actual train  
2. All discrepancies have been resolved  
3. The system reflects reality  
4. You can continue with work order completion  
<color=#FF8C00>**This step is mandatory before proceeding with destination set out or further work order activities.**</color>  