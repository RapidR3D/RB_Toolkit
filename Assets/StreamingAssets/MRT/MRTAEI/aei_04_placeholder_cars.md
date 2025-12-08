# <color=#FFD700>Correct AEI Placeholder Cars</color>  

## <color=#FF8C00>Overview</color>  

AEI Placeholder Cars are temporary entries created when the AEI system cannot read a car's identification tag. These must be corrected with actual car information.  

---

## <color=#FF8C00>What Are Placeholder Cars?</color>  

### <color=#20B2AA>Definition</color>  

<color=#FF8C00>**Placeholder Car:**</color> An entry in the AEI Add Cars column marked as **AEI** in the **Add Cars** column.  

### <color=#20B2AA>Why They Exist</color>  

Placeholder cars appear when:  
- AEI tag is damaged or missing
- AEI reader malfunction
- Car passed too quickly for accurate scan
- Environmental interference with RFID signal

### <color=#20B2AA>Identifying Placeholders</color>  

Look for entries like:  
Car: AEI ##7166A  
Info: AEI Added  

The **AEI ##** prefix indicates a placeholder.  

---

## <color=#FF8C00>When to Check for Placeholders</color>  

### <color=#20B2AA>Scenario Trigger</color>  

**If the Add Work button is disabled**, check for AEI placeholder cars.  

### <color=#20B2AA>How to Check</color>  

Navigate to the **AEI Add Cars** column and look for:  
- Cars marked **AEI** 
- Entries with fake car numbers
- Highlighted placeholder entries

---

## <color=#FF8C00>Correction Process</color>  

### <color=#20B2AA>Step 1: Identify Placeholder Cars</color>  

These cars **did not pick up the AEI tag** and have **fake car numbers**.  

### <color=#20B2AA>Step 2: Highlight Correct Car</color>  

Highlight the car and tap **Set Initial/Number**.  

### <color=#20B2AA>Step 3: Enter Correct Information</color>  
<color=#FF8C00>**Pop-up: "Please enter new car details:"**</color>  
┌─────────────────────────────────────┐  
│ Please enter new car details:       │  
│                                     │  
│ ENTER CAR INITIAL & NUMBER          │  
│                                     │  
│                                     │  
│         (Submit)                    │  
└─────────────────────────────────────┘  

1. To supply the **correct car number**  
2. Click **Submit**  

### <color=#20B2AA>Step 4: Set Load/Empty Status</color>  

Then, indicate the **Load/Empty** status using:  
- **Set Loaded** button, OR
- **Set Empty** button

### <color=#20B2AA>Step 5: Handle Missing/Unknown Cars</color>  

If there is no car, or you're unsure of the car type:  
1. Select the car  
2. Tap the **Skip/Unskip Car** button  

---

## <color=#FF8C00>Detailed Example Scenario</color>  

### <color=#20B2AA>Situation</color>  

Two cars show missing but the conductor verified they are on the train.  

### <color=#20B2AA>Investigation Steps</color>  

1. **Check the Add Cars tab** for AEI Placeholder cars  
2. <color=#FF8C00>**Confirm:**</color> There is one car (position 72)  
3. The placeholder shows as: AEI ##7166A  

### <color=#20B2AA>Correction Steps</color>  

<color=#FF8C00>**Step 1:**</color> Tap and select **the car** that is there (position 72)  

<color=#FF8C00>**Step 2:**</color> Tap **Set Initial Number**  

<color=#FF8C00>**Step 3:**</color> A pop-up box will open  

<color=#FF8C00>**Step 4:**</color> Input the railcar that is present in that spot by entering:  
- Car initial
- Space
- Car number

<color=#FF8C00>**Example:**</color> CSXT 2797  

<color=#FF8C00>**Step 5:**</color> Tap **Submit**  

<color=#FF8C00>**Step 6:**</color> Set the Load/Empty status:  
- If loaded: Tap **Set Loaded**
- If empty: Tap **Set Empty**

<color=#FF8C00>**Step 7:**</color> The placeholder is now replaced with actual car information  

---

## <color=#FF8C00>Screen Display Example</color>  

### <color=#20B2AA>Before Correction</color>  

AEI Add Cars (4)  

Seq   Car             Load/Empty   From Instruction   To Instruction   Info  
072   AEI ##7166A     (unknown)                                       AEI Added  

### <color=#20B2AA>During Correction</color>  

┌──────────────────────────────────────┐  
│ Please enter new car details:        │  
│                                      │  
│ ENTER CAR INITIAL & NUMBER           │  
│   CSXT 2797                          │  
│                                      │  
│           Submit                     │  
└──────────────────────────────────────┘  

### <color=#20B2AA>After Correction</color>  


AEI Add Cars (3)  

Seq   Car          Load/Empty   From Instruction   To Instruction   Info  
072   CSXT 2797    L           (to be set)        (to be set)     In Work Order  

---

## <color=#FF8C00>Common Placeholder Scenarios</color>  

### <color=#20B2AA>Scenario 1: Readable Car in Position</color>  

<color=#FF8C00>**Situation:**</color> Placeholder exists, actual car present and readable  

<color=#FF8C00>**Action:**</color>  
1. Visually identify car  
2. Set Initial Number with correct car info  
3. Set Load/Empty status  
4. Add work instructions (FROM/TO)  

---

### <color=#20B2AA>Scenario 2: No Car in Position</color>  

<color=#FF8C00>**Situation:**</color> Placeholder exists but position is empty  

<color=#FF8C00>**Action:**</color>  
1. Select the placeholder  
2. Tap **Skip/Unskip Car**  
3. Placeholder removed from consideration  
4. Continue processing other cars  

---

### <color=#20B2AA>Scenario 3: Unknown Car Type</color>  

<color=#FF8C00>**Situation:**</color> Car present but cannot determine car number  

<color=#FF8C00>**Action:**</color>  
1. Stop and physically verify  
2. Walk to car location if safe  
3. Read car marking directly  
4. If cannot verify, tap **Skip/Unskip Car**  
5. Report to MRT Helpdesk  

---

### <color=#20B2AA>Scenario 4: Multiple Placeholders</color>  

<color=#FF8C00>**Situation:**</color> Several placeholder cars in Add Cars list  

<color=#FF8C00>**Action:**</color>  
1. Process each placeholder individually  
2. Verify physical position of each  
3. Correct placeholders in sequence order  
4. Skip any that cannot be verified  
5. Do not guess - accuracy is critical  

---

## <color=#FF8C00>Add Work Button Status</color>  

### <color=#20B2AA>When Add Work is Disabled</color>  

The **Add Work** button becomes disabled when:  
- AEI placeholder cars exist in the system
- System requires placeholder correction first
- Cannot add new work until placeholders resolved

### <color=#20B2AA>Enabling Add Work Button</color>  

To re-enable the Add Work button:  
1. Correct all placeholder cars OR  
2. Skip/unskip all placeholders  
3. Verify AEI Add Cars count reduces  
4. Add Work button becomes active again  

---

## <color=#FF8C00>Load/Empty Status</color>  

### <color=#20B2AA>Set Loaded</color>  

Use **Set Loaded** when:  
- Car contains freight
- Visual inspection confirms loaded
- Car sits low on trucks (loaded position)

### <color=#20B2AA>Set Empty</color>  

Use **Set Empty** when:  
- Car has no freight
- Visual inspection confirms empty
- Car sits high on trucks (empty position)

### <color=#20B2AA>Cannot Determine</color>  

If Load/Empty status uncertain:  
1. Do not guess  
2. Tap **Skip/Unskip Car**  
3. Call MRT Helpdesk for guidance  
4. Verify with conductor/yardmaster  

---

## <color=#FF8C00>Best Practices</color>  

### <color=#20B2AA>Verification</color>  
- ✅ Always visually verify car before correcting placeholder
- ✅ Read car markings directly when possible
- ✅ Confirm sequence position matches reality
- ✅ Double-check car initial and number entry

### <color=#20B2AA>Data Entry</color>  
- ✅ Use space between initial and number (CSXT 2797)
- ✅ Enter exactly as marked on car
- ✅ Verify spelling of railroad initials
- ✅ Confirm number is complete

### <color=#20B2AA>When Uncertain</color>  
- ✅ Use Skip/Unskip rather than guessing
- ✅ Call MRT Helpdesk for assistance
- ✅ Document uncertainty
- ✅ Coordinate with conductor for verification

### <color=#20B2AA>Safety</color>  
- ✅ Only approach cars if safe to do so
- ✅ Do not enter between cars
- ✅ Follow all safety protocols
- ✅ Never guess if unable to verify safely

---

## <color=#FF8C00>Troubleshooting</color>  

### <color=#20B2AA>Cannot Find Physical Car</color>  

<color=#FF8C00>**Problem:**</color> Placeholder exists but cannot locate actual car  

<color=#FF8C00>**Solution:**</color>  
1. Verify train position and sequence  
2. Count cars from known reference point  
3. Check for cars in unexpected positions  
4. If truly missing, tap Skip/Unskip Car  
5. Report discrepancy to MRT Helpdesk  

---

### <color=#20B2AA>Multiple Placeholders for Same Position</color>  

<color=#FF8C00>**Problem:**</color> Two placeholders seem to indicate same car  

<color=#FF8C00>**Solution:**</color>  
1. Process first placeholder with correct info  
2. Skip second placeholder  
3. Verify Add Cars count decreases appropriately  
4. If confusion persists, call MRT Helpdesk  

---

### <color=#20B2AA>Cannot Submit Car Information</color>  

<color=#FF8C00>**Problem:**</color> Submit button not working after entering car info  

<color=#FF8C00>**Solution:**</color>  
1. Verify format: INITIAL SPACE NUMBER  
2. Check for special characters  
3. Ensure all fields completed  
4. Try re-entering information  
5. Call MRT Helpdesk if persists  

---

### <color=#20B2AA>Add Work Still Disabled After Corrections</color>  

<color=#FF8C00>**Problem:**</color> Add Work button remains disabled after fixing placeholders  

<color=#FF8C00>**Solution:**</color>  
1. Verify all placeholders corrected or skipped  
2. Check AEI Add Cars count  
3. Refresh screen by backing out and re-entering  
4. Restart MRT app if needed  
5. Call MRT Helpdesk  

---

## <color=#FF8C00>Summary Checklist</color>  

### <color=#20B2AA>Placeholder Correction Process</color>  

-  Identify placeholder cars (AEI ## prefix)
-  Verify physical car presence
-  Tap Set Initial Number
-  Enter correct car initial and number
-  Click Submit
-  Set Load/Empty status
-  Or use Skip/Unskip if car absent/unknown
-  Verify correction appears in list
-  Repeat for all placeholders
-  Confirm Add Work button re-enabled
-  Continue with normal AEI processing

---

## <color=#FF8C00>Need Help?</color>  

📞 **MRT Helpdesk: 800-243-7743 option #4**  

<color=#FF8C00>**Call for:**</color>  
- Cannot identify placeholder car
- Multiple placeholders in same position
- Add Work button remains disabled
- Uncertain about car information
- Safety concerns accessing cars
- System not accepting corrections

<color=#FF8C00>**Have ready:**</color>  
- Train ID and Work Order number
- AEI scan location and time
- Placeholder car numbers
- Position in train consist
- What you've tried