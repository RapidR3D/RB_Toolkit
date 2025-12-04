# Completing Work Orders

## Overview

Properly completing and closing out work orders is critical for accurate reporting, CSD scoring, and system data integrity. This section covers the final steps of work order completion.

---

## Completion Checklist

### Before Logging Out

-  All customer tiles show **100% Complete**
-  All station tiles show **100% Complete**
-  All interchange tiles show **100% Complete**
-  Locomotives reported
-  EOT reported
-  Notification bell clear (no unread alerts)
-  No pending AEI reads
-  Train Order shows **COMPLETED 100%**

---

## Reporting Set Out at Destination

### Final Station Work

When you arrive at your destination yard:

#### Step 1: Handle Inbound AEI Read
**Before reporting set out:**
1. Tap notification bell or Menu → AEI Reads
2. Work through tabs left to right:
   - **AEI Errors** - Report or exception missing cars
   - **AEI Add Cars** - Add Work unexpected cars
   - **All Cars** - Accept AEI Standing Order
3. Only proceed to Set Out after handling AEI

#### Step 2: Access Destination Tile
1. Scroll to destination station tile
2. Tap **SO** (Set Out) instruction
3. Set Out screen appears with all cars

#### Step 3: Set Track and Spot
1. Select all cars (or specific cut)
2. Tap **SET TRACK AND SPOT**
3. System shows:
   - **To Track** (select track from dropdown)
   - **Track Adjust** (organize within track)

#### Step 4: Select Track
1. Tap arrow next to **To Track**
2. Dropdown shows yard tracks:
   - W14, W15, W16, W17, W18, W19, W20, etc.
3. Select destination track
4. Tap track selector

#### Step 5: Position Cars in Track
**Options:**
- **HEAD** - Place at front of track
- **REAR** - Place at back of track
- **AFTER** - Select existing car, place after it

**Function Buttons:**
- UP - Move selected car(s) up one position
- DOWN - Move selected car(s) down one position
- REVERSE - Flip order of selected cars
- REMOVE - Remove from this cut

#### Step 6: Tap UPDATE
System assigns all cars to selected track and position

#### Step 7: Verify Track Assignment
All cars now show **To Track/Spot** column filled:
PRSX 449      W23 001
CSXT 915036   W23 002
CPDX 214008   W23 003

#### Step 8: Tap COMPLETE ALL CARS
System applies current timestamp to all cars in the cut

---

## Multiple Cuts in Destination

### When Setting Out to Multiple Tracks

If your train has cars for different tracks:

#### Method 1: Complete One Cut at a Time
1. Select cars for Track W23
2. SET TRACK AND SPOT → W23
3. COMPLETE SELECTED CARS → Enter time
4. Select cars for Track W25
5. SET TRACK AND SPOT → W25
6. COMPLETE SELECTED CARS → Enter time (1 minute later)

#### Method 2: Set All Tracks First, Then Complete
1. Select first cut → SET TRACK → W23 → UPDATE
2. Select second cut → SET TRACK → W25 → UPDATE
3. Select third cut → SET TRACK → W27 → UPDATE
4. Then COMPLETE ALL CARS (or complete each cut separately)

### ⚠️ Critical Time Rule for Set Outs

**Set Outs need at least 1 minute apart per cut!**

**Example:**
Cut 1 to W23: 17:00
Cut 2 to W25: 17:01
Cut 3 to W27: 17:02

**Why:** System tracks each cut as separate movement for inventory management.

---

## Reporting Locomotives

### After All Cars Are Set Out

#### Step 1: Tap Locomotives Tab
Switch from "Set Out (10)" to "Locomotives (2)"

#### Step 2: Verify Equipment Listed
CSXT 4555    L  D
CSXE 41852   L  M

#### Step 3: Tap COMPLETE ALL CARS
System applies timestamp to locomotive report

#### Step 4: Verify Completion
Both locomotives show **Reported Time** in green

---

## Final Verification

### Swipe to Check All Tiles

#### Scroll Through Entire Work Order
Swipe left/right to view all tiles:
- Origin
- Line of Road stations
- All customers
- All interchanges
- Destination

#### Each Tile Should Show
[Customer Name]
PU: 100%  (or grey/completed)
PL: 100%  (or grey/completed)
IP: 100%  (or grey/completed)

#### Train Order Display
At bottom of screen:
Train Order
COMPLETED 100%

---

## Logging Out of Work Order

### ⚠️ CRITICAL STEP

**You MUST logout to post data down to the system!**

### Logout Process

#### Step 1: Tap Menu Icon
Three horizontal lines (☰) in top corner

#### Step 2: Review Menu Options
Welcome [Your Name]
Undo last reporting
AEI Reads
Error Cars
EAC Review
Yard Switching Tool
Navigate to Tool Selection
Customer Insights
Send Client Logs
About
Logout ← Tap this

#### Step 3: Tap Logout
System processes and posts all pending data

#### Step 4: Verify Logout Complete
Screen returns to:
Login with Okta
[Button]

**When you see this screen, logout was successful!**

---

## What Happens When You Logout

### Data Posting
1. All reported work sends to CSX systems
2. Car movements update inventory
3. Customer billing records created
4. CSD metrics calculated
5. Train completion recorded

### If You DON'T Logout
❌ **Problems that occur:**
- Work order stays "open" in system
- Pending data doesn't post
- Locomotive section incomplete
- CSD shows all work as "misses"
- Next crew cannot access work order
- Inventory updates delayed

---

## Undo Last Reporting

### When to Use
If you made a mistake in your last reporting event (within 4 minutes).

### How to Access
1. Tap Menu (☰)
2. Tap **Undo last reporting**
3. System removes your last timestamp
4. Re-report with correct information

### Time Limit
**Undo is available for 4 minutes** after reporting, or until your next event (whichever comes first).

---

## About Screen: Final Check

### Before Logging Out

#### Verify MQTT Connection
1. Tap Menu (☰)
2. Tap **About**
3. Check critical fields:

App Version: 2.0.6000 (or current)
MQTT Connected: Yes ← Must be YES
MQTT Subscribed: Yes ← Must be YES
MQTT Client: mrt_[number]
MQTT Subscription: MRT/[WO#], TRT/[WO#], TRT/[Train ID]

### If MQTT Shows "No"
**Problem:** Data may not be syncing properly

**Solution:**
1. Check cellular/WiFi signal
2. Move to area with better signal
3. Wait 30 seconds and recheck About screen
4. If still "No", call MRT Helpdesk before logging out

---

## Recrewing Procedures

### When Your Train Will Be Recrewed

#### Your Responsibilities
1. Complete all work up to your tie-up point
2. Report locomotives
3. Verify Train Order shows completion percentage
4. **Logout of the work order**
5. Inform relief crew of work order number

#### Relief Crew Process
1. Login to Mobile Work Order
2. Search for work order by Train ID or WO#
3. Download existing work order
4. Continue reporting remaining work
5. Complete and logout when finished

### ⚠️ Critical for Recrewing
**You MUST logout** even if train isn't complete!
- Allows relief crew to access work order
- Posts your completed work to system
- Prevents data loss

---

## End of Shift Procedures

### After Logging Out of MRT

#### Step 1: Close All Apps
1. Tap 3 vertical lines (bottom left of tablet)
2. View all open apps
3. Tap **Close All**
4. Frees up memory for next shift

#### Step 2: Restart Tablet
**Do NOT power down - RESTART instead!**

**How to Restart:**
1. Hold power button
2. Tap **Restart**
3. Confirm by tapping **Restart** again
4. Wait for tablet to fully restart

**Why Restart (not power down):**
- Allows overnight updates to install
- Clears memory and cache
- Optimizes performance
- Prevents update failures

#### Step 3: Place on Charger
- Plug in tablet overnight
- Ensure green charging light visible
- Ready for next shift fully charged

---

## Completion Verification

### How to Verify Work Posted

#### Method 1: Check Work Order Status
After logging out:
1. Wait 2-3 minutes
2. Login again to MRT
3. Search for your train ID
4. If work order doesn't appear in "Current" - it completed successfully
5. Check "Incomplete Work Orders" - should show 100% if recrewed

#### Method 2: Confirm with Yardmaster
- Yardmaster can verify completion in their systems
- All movements should show in yard inventory
- Customer work should reflect in CSD metrics

#### Method 3: No Error Calls
- If work posted correctly, you won't receive callback
- MRT Helpdesk monitors failed completions
- They'll contact you if data didn't post

---

## Common Completion Errors

### Error 1: Forgot to Logout
**Problem:** Work order still open in system

**Solution:**
1. Login to MRT again
2. Search for the work order
3. It will appear as "Current Work Order"
4. Tap Menu → Logout properly

### Error 2: MQTT Not Connected
**Problem:** Data didn't sync before logout

**Solution:**
1. Login to work order again
2. Check Menu → About → MQTT Connected: Yes
3. Wait in area with good signal
4. Logout again when connected

### Error 3: Tiles Not 100% Complete
**Problem:** Logged out with incomplete work

**Solution:**
1. Login to work order again
2. Complete remaining tiles
3. Verify Train Order shows 100%
4. Logout properly

### Error 4: Locomotives Not Reported
**Problem:** Most common completion error!

**Solution:**
1. Login to work order again
2. Go to destination station
3. Tap Locomotives tab
4. Tap COMPLETE ALL CARS
5. Verify reported
6. Logout

---

## Troubleshooting Completion Issues

### Cannot Logout - Button Greyed Out
**Cause:** Work order not complete or system processing

**Fix:**
1. Verify all tiles show completion
2. Wait 10 seconds
3. Try logout again
4. If persists, close MRT app and reopen
5. Try logout again

### "Pending Data" Message
**Cause:** System still syncing previous events

**Fix:**
1. Wait in area with good signal
2. Let system finish syncing (check notification bell)
3. When clear, try logout again

### Logged Out But Work Order Still Appears
**Cause:** Data didn't post properly

**Fix:**
1. Reopen work order
2. Check Menu → About → MQTT status
3. Verify all tiles complete
4. Logout again with strong signal

---

## Best Practices for Completion

### During Your Shift
- ✅ Report work in real-time, not batch at end
- ✅ Handle AEI reads as they occur
- ✅ Clear notification bell throughout shift
- ✅ Keep work order current (not hours behind)

### At Destination
- ✅ Handle inbound AEI BEFORE reporting set out
- ✅ Set tracks for all cars before completing
- ✅ Space out cut completion times (1 min apart)
- ✅ Report locomotives last
- ✅ Check MQTT connected before logout

### Before Logout
- ✅ Swipe through ALL tiles to verify 100%
- ✅ Check Train Order completion percentage
- ✅ Clear notification bell
- ✅ Verify MQTT connected in About
- ✅ Have strong cellular/WiFi signal

### After Logout
- ✅ Wait for "Login with Okta" screen
- ✅ Close all apps
- ✅ Restart tablet (not power down)
- ✅ Place on charger

---

## Completion Success Indicators

### ✅ You're Done When...
1. Train Order shows **COMPLETED 100%**
2. All tiles are **grey and complete**
3. Notification bell is **clear (0)**
4. Menu → About shows **MQTT: Yes/Yes**
5. You successfully **tapped Logout**
6. Screen shows **"Login with Okta"**

### ❌ You're NOT Done If...
1. Any tile shows **less than 100%**
2. Train Order shows **partial percentage**
3. Notification bell has **unread alerts**
4. MQTT shows **"No" for Connected**
5. Work order still appears as **"Current"**
6. You can still access the **work order screen**

---

## Quality Metrics Impacted by Completion

### Customer Switch Data (CSD)
- Incomplete work orders = Misses
- Late reporting = Service window failures
- Missing data = Billing errors

### Car Cycle Time
- Timely reporting = Accurate ETAs
- Batch reporting = Delayed updates
- No logout = Frozen inventory

### Operational Efficiency
- Clean completions = Smooth recrewing
- Proper logout = Next crew ready access
- Real-time data = Better planning

---

## Summary: The Perfect Completion

1. **Handle Inbound AEI** completely
2. **Report Set Out** with proper tracks and times
3. **Report Locomotives** with timestamp
4. **Verify All Tiles** show 100%
5. **Check Train Order** shows COMPLETED 100%
6. **Clear Notifications** (bell icon)
7. **Check MQTT Status** (About screen)
8. **Tap Logout** (Menu → Logout)
9. **Verify Logout Screen** appears
10. **Close Apps** and **Restart Tablet**

---

## Need Help?

📞 **MRT Helpdesk: 800-243-7743 option #4**

**Call if:**
- Cannot complete work order
- Logout button not working
- MQTT showing disconnected
- Data didn't post down
- Work order still appearing after logout
- Any completion errors

**Have ready:**
- Train ID
- Work Order number
- Current location
- Specific error messages
- Screenshot of About screen (if possible)

---

## Critical Reminders

### ⚠️ ALWAYS Logout
Even if recrewing or ending shift early - **LOGOUT IS MANDATORY**

### ⚠️ Report Locomotives
Most common missed step - **check the locomotive tab before logout**

### ⚠️ Handle AEI Reads
Complete AEI process **before reporting set out at destination**

### ⚠️ MQTT Must Be Connected
Check About screen - both Connected and Subscribed must show **YES**

### ⚠️ Restart, Don't Power Down
At end of shift: **Restart tablet** (not power off) for updates

---

**Congratulations on completing your work order!** 🎉

Thank you for accurate reporting and proper completion procedures. Your attention to detail ensures smooth operations and excellent customer service.