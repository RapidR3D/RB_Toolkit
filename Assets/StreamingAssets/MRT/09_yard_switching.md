# <color=#FFD700>Yard Switching Tool (YST)</color>  

## <color=#FF8C00>Overview</color>  

The Yard Switching Tool manages car movements **within** a yard. It handles both manual switch lists (crew-initiated) and automated switch lists (system-generated).  

---

## <color=#FF8C00>Accessing YST</color>  

### <color=#20B2AA>Method 1: From Tool Selection Screen</color>  
1. Login to MRT  
2. Tap **Yard Switching Tool**  
3. Enter **Train ID**  
4. Enter **Destination Milepost**  
5. Tap **SEND**  

### <color=#20B2AA>Method 2: From Active Work Order</color>  
1. While in Mobile Work Order  
2. Tap **Menu** (☰)  
3. Select **Yard Switching Tool**  

---

## <color=#FF8C00>Manual Switchlists</color>  

Manual switchlists allow you to report car movements between tracks that you've already performed.  

### <color=#20B2AA>Four Types of Manual Switchlists</color>  

#### 1. Track Adjust (To Track Side)
<color=#FF8C00>**Purpose:**</color> Adjust car position within the same track  
<color=#FF8C00>**Use when:**</color> Reorganizing cars on a single track  

#### 2. Single Track to Single Track
<color=#FF8C00>**Purpose:**</color> Move cars from one track to another track  
<color=#FF8C00>**Use when:**</color> Standard yard switching operations  

#### 3. Multiple Tracks to Single Track
<color=#FF8C00>**Purpose:**</color> Gather cars from several tracks onto one track  
<color=#FF8C00>**Use when:**</color> Building cuts from multiple locations  

#### 4. Single Track to Multiple Tracks
<color=#FF8C00>**Purpose:**</color> Distribute cars from one track to several tracks  
<color=#FF8C00>**Use when:**</color> Breaking down inbound trains  

---

## <color=#FF8C00>Manual Switchlist Workflow</color>  

### <color=#20B2AA>Step 1: Select Yard</color>  
1. Tap **Select Yard to be Switched**  
2. Choose from available yards at your location  
3. System shows **Primary Direction** (North, South, East, West)  

### <color=#20B2AA>Step 2: Select From Track and To Track</color>  
1. Tap the **arrow** next to **From Track**  
2. Select source track from dropdown list  
3. Tap the **arrow** next to **To Track**  
4. Select destination track from dropdown list  

### <color=#20B2AA>Step 3: Select Cars to Move</color>  
<color=#FF8C00>**Options:**</color>  
- Tap individual cars
- Use **Select All** checkbox
- Use **Select Range** slider

<color=#FF8C00>**Important:**</color> System remembers the **sequence** in which you select cars!  

### <color=#20B2AA>Step 4: Choose Positioning</color>  
Three options for where cars go in the To Track:  

#### HEAD
- Places cars at the **head** (front) of To Track
- Use when: Adding to north/south end

#### REAR
- Places cars at the **rear** (back) of To Track
- Use when: Adding to opposite end

#### AFTER
1. Select the **"behind car"** in To Track first  
2. Then tap **AFTER** button  
3. Places selected cars **after** that car  
4. Use when: Inserting into middle of track  

### <color=#20B2AA>Step 5: Adjust Sequence (Optional)</color>  
**Function Buttons** beside To Track:  
- **HEAD** - Move selected cars to front
- **UP** - Move selected cars up one position
- **DOWN** - Move selected cars down one position
- **REAR** - Move selected cars to back
- **AFTER** - Place after selected car
- **REVERSE** - Flip order of selected cars

### <color=#20B2AA>Step 6: Send</color>  
1. Tap **SEND**  
2. System processes the switch  
3. Wait for confirmation  

---

## <color=#FF8C00>Understanding Yard Primary Direction</color>  

Each yard has a **Primary Direction** for listing cars:  

### <color=#20B2AA>North Primary Direction</color>  
- **HEAD** = North end of track
- **REAR** = South end of track
- List cars from **North to South**

### <color=#20B2AA>South Primary Direction</color>  
- **HEAD** = South end of track
- **REAR** = North end of track
- List cars from **South to North**

### <color=#20B2AA>East/West Primary Directions</color>  
- Same concept, different orientation
- **Know your yard's direction!**

---

## <color=#FF8C00>Verifying Manual Switches</color>  

### <color=#20B2AA>Completed Switch Lists Screen</color>  

After sending, check the **Completed Switch Lists** section:  

| Yard | From Track | To Track | Switch# | Sent Time | # of Cars | Status |  
|------|------------|----------|---------|-----------|-----------|--------|  
| XXB023 | DSI | MAI | 001 | 13:27 | 7 | ✅ |  
| XXB023 | MAI | WYE | 002 | 13:28 | 12 | ✅ |  
| XXB023 | MAI | MAI | 003 | 14:02 | 70 | ✅ |  
| XXB023 | AEI | MAI | 004 | 15:42 | 2 | ❌ |  

### <color=#20B2AA>Status Indicators</color>  

#### ✅ Green Check
- Switch posted successfully
- Inventory updated
- No action needed

#### ❌ Red X
- Switch did **NOT** post
- <color=#FF8C00>**Action Required:**</color> Re-input the switch
- If Red X persists, call MRT Helpdesk

### <color=#20B2AA>Refresh List</color>  
Tap **REFRESH LIST** to check for updated status icons.  

### <color=#20B2AA>View Details</color>  
Tap any row to see:  
- Exact cars switched
- From/To locations
- HAZ status
- Load/Empty status
- Commodities
- Final position in track

---

## <color=#FF8C00>Automated Switchlists</color>  

Automated switchlists are **system-generated** switching plans created by CSX's planning systems.  

### <color=#20B2AA>Automated Switchlist Functions</color>  

#### View
- Review the automated switch plan
- See which cars to move
- Check from/to tracks
- Verify quantities

#### Request
- Request a new automated switchlist
- Use when: No current list available
- System generates based on yard inventory

#### Update List
- **Refresh** the current automated list
- Use when: New cars have arrived
- Use when: Track locations have changed
- Sends updated version to printer

#### Refresh List
- Updates the display
- Checks for new automated lists
- Verifies current list status

#### Remove List
- Deletes the current automated list
- Use when: List is no longer valid
- Use when: Replacing with manual operations

#### Print and Save
- Generates paper copy
- Saves electronic version
- Use for reference during switching

### <color=#20B2AA>Sending Automated Lists</color>  
Once reviewed and adjusted:  
1. Tap **SEND**  
2. System processes the automated plan  
3. Updates yard inventory  
4. Generates confirmation  

---

## <color=#FF8C00>Advanced YST Features</color>  

### <color=#20B2AA>Select All and Select Range</color>  
Available in YST for quick car selection.  

### <color=#20B2AA>Set To Track</color>  
Quickly assign multiple cars to the same destination track.  

### <color=#20B2AA>Report Defective Car (Bad Order)</color>  
1. While in YST, select the defective car  
2. Tap **Report Defective Car**  
3. Enter defect details  
4. System marks car as Bad Order in inventory  

### <color=#20B2AA>Track Adjust</color>  
Special function for:  
- Reorganizing cars on same track
- Correcting car sequence
- Updating positions without moving tracks

---

## <color=#FF8C00>Manual Switchlist: Step-by-Step Example</color>  

### <color=#20B2AA>Scenario</color>  
Move 3 cars from Track W02 to Track W23, place at HEAD.  

### <color=#20B2AA>Steps</color>  
<color=#FF8C00>**1. Select Yard**</color>  
Yard: XXB023 FAIRBURN GA  
Primary Direction: North  
<color=#FF8C00>**2. Select Tracks**</color>  
From Track: W02 (tap arrow, select from list)  
To Track: W23 (tap arrow, select from list)  
<color=#FF8C00>**3. Select Cars**</color>  
Cars on W02:  
☐ CYDX 220  
☐ AEX 11238  
☐ KGLX 91122  
☐ CPDX 214008  

Select first 3 cars (or tap "Select Range")  
<color=#FF8C00>**4. Choose Position**</color>  
Tap: HEAD (to place at north end of W23)  
<color=#FF8C00>**5. Verify Sequence in To Track**</color>  
To Track W23 will show:  
001 CYDX 220  
002 AEX 11238  
003 KGLX 91122  
(existing cars follow)  
<color=#FF8C00>**6. Send**</color>  
Tap: SEND  
<color=#FF8C00>**7. Verify**</color>  
Tap: REFRESH LIST  
Check for green check ✅  


---

## <color=#FF8C00>Common YST Scenarios</color>  

### <color=#20B2AA>Scenario 1: Building a Cut for Departure</color>  

Purpose: Gather cars from multiple tracks onto departure track  

From Tracks: W02, W07, W19  
To Track: W01 (departure track)  
Method: Multiple manual switches, use REAR to build in order  
Result: All cars staged on W01 ready to depart  


### <color=#20B2AA>Scenario 2: Breaking Down an Arrival</color>  

Purpose: Distribute inbound cars to classification tracks  

From Track: W01 (receiving track)  
To Tracks: W10, W15, W20, W25 (by destination)  
Method: Multiple manual switches, selecting cars by destination  
Result: Cars sorted to proper classification tracks  


### <color=#20B2AA>Scenario 3: Repositioning for Customer Access</color>  

Purpose: Move cars blocking customer track  

From Track: W12  
To Track: W13 (temporary storage)  
Method: Single track to single track  
Position: AFTER existing cut  
Result: W12 clear for customer access  


### <color=#20B2AA>Scenario 4: Correcting Car Sequence</color>  

Purpose: Reorder cars on same track  

From Track: W20  
To Track: W20  
Method: Track Adjust  
Use: UP/DOWN buttons to resequence  
Result: Cars in correct order for outbound  


---

## <color=#FF8C00>YST Best Practices</color>  

### <color=#20B2AA>Before Switching</color>  
- ✅ Review automated lists if available
- ✅ Know your yard's primary direction
- ✅ Verify track capacity
- ✅ Check for track outages or restrictions
- ✅ Understand the final goal (building, sorting, storing)

### <color=#20B2AA>During Switching</color>  
- ✅ Select cars in the sequence you want
- ✅ Use Select Range for continuous cuts
- ✅ Verify To Track before sending
- ✅ Double-check HEAD vs. REAR placement
- ✅ Use AFTER for precise positioning

### <color=#20B2AA>After Switching</color>  
- ✅ Tap REFRESH LIST immediately
- ✅ Verify green check appears
- ✅ Re-input any Red X switches
- ✅ Update manual records if required
- ✅ Inform yardmaster of completed switches

---

## <color=#FF8C00>Troubleshooting YST</color>  

### <color=#20B2AA>Red X on Switch</color>  
<color=#FF8C00>**Problem:**</color> Switch did not post to system  
<color=#FF8C00>**Solution:**</color>  
1. Tap REFRESH LIST (wait 30 seconds)  
2. If still Red X, re-input the entire switch  
3. If persists, call MRT Helpdesk 800-243-7743 #4  

### <color=#20B2AA>Cars Not Showing in Inventory</color>  
<color=#FF8C00>**Problem:**</color> Expected cars not visible in From Track  
<color=#FF8C00>**Solution:**</color>  
1. Verify you're in correct yard  
2. Check milepost matches your location  
3. Tap REFRESH on inventory  
4. Verify cars haven't already been moved  
5. Contact yardmaster to verify car location  

### <color=#20B2AA>Wrong Primary Direction</color>  
<color=#FF8C00>**Problem:**</color> Cars listing in unexpected order  
<color=#FF8C00>**Solution:**</color>  
1. Check yard's Primary Direction at top of screen  
2. Adjust your HEAD/REAR selection accordingly  
3. North Primary: List North to South  
4. South Primary: List South to North  

### <color=#20B2AA>Cannot Select Car</color>  
<color=#FF8C00>**Problem:**</color> Car not selectable in From Track list  
<color=#FF8C00>**Solution:**</color>  
1. Check if car has restrictions (HAZ, dimensional, bad order)  
2. Verify car isn't already on another crew's work order  
3. Refresh inventory  
4. Contact yardmaster if issue persists  

---

## <color=#FF8C00>YST and Work Orders</color>  

### <color=#20B2AA>Relationship</color>  
- YST movements are **internal** to the yard
- Mobile Work Order handles **train movements** to/from yard
- Some cars may appear on **both**:
  - YST: To move within yard for staging
  - Work Order: To pick up and depart with

### <color=#20B2AA>Coordination</color>  
1. Use YST to **stage** cars for outbound trains  
2. Use SPT to **build** the outbound train  
3. Use Mobile Work Order to **report** pickup and departure  

---

## <color=#FF8C00>Quick Reference: YST Functions</color>  

| Function | Purpose | When to Use |  
|----------|---------|-------------|  
| Manual Switchlist | Report completed switches | After physically moving cars |  
| Automated Switchlist | View/execute system plan | When automated list generated |  
| Request Switchlist | Generate new automated list | No current list available |  
| Update List | Refresh automated list | New arrivals or changes |  
| Track Adjust | Reorder on same track | Sequence correction needed |  
| Report Defective Car | Mark car bad order | Mechanical defects found |  
| Print and Save | Generate paper copy | Reference during switching |  

---

## <color=#FF8C00>Need Help?</color>  

📞 **MRT Helpdesk: 800-243-7743 option #4**  

<color=#FF8C00>**Call for:**</color>  
- Persistent Red X on switches
- Cars not appearing in inventory
- Unable to complete switchlist
- System errors or crashes
- Questions about automated lists

<color=#FF8C00>**Have ready:**</color>  
- Your Train ID
- Yard milepost
- From/To tracks
- Number of cars involved
- Any error messages