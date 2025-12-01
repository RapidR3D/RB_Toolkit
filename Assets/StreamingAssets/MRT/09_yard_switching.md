# Yard Switching Tool (YST)

## Overview

The Yard Switching Tool manages car movements **within** a yard. It handles both manual switch lists (crew-initiated) and automated switch lists (system-generated).

---

## Accessing YST

### Method 1: From Tool Selection Screen
1. Login to MRT
2. Tap **Yard Switching Tool**
3. Enter **Train ID**
4. Enter **Destination Milepost**
5. Tap **SEND**

### Method 2: From Active Work Order
1. While in Mobile Work Order
2. Tap **Menu** (☰)
3. Select **Yard Switching Tool**

---

## Manual Switchlists

Manual switchlists allow you to report car movements between tracks that you've already performed.

### Four Types of Manual Switchlists

#### 1. Track Adjust (To Track Side)
**Purpose:** Adjust car position within the same track
**Use when:** Reorganizing cars on a single track

#### 2. Single Track to Single Track
**Purpose:** Move cars from one track to another track
**Use when:** Standard yard switching operations

#### 3. Multiple Tracks to Single Track
**Purpose:** Gather cars from several tracks onto one track
**Use when:** Building cuts from multiple locations

#### 4. Single Track to Multiple Tracks
**Purpose:** Distribute cars from one track to several tracks
**Use when:** Breaking down inbound trains

---

## Manual Switchlist Workflow

### Step 1: Select Yard
1. Tap **Select Yard to be Switched**
2. Choose from available yards at your location
3. System shows **Primary Direction** (North, South, East, West)

### Step 2: Select From Track and To Track
1. Tap the **arrow** next to **From Track**
2. Select source track from dropdown list
3. Tap the **arrow** next to **To Track**
4. Select destination track from dropdown list

### Step 3: Select Cars to Move
**Options:**
- Tap individual cars
- Use **Select All** checkbox
- Use **Select Range** slider

**Important:** System remembers the **sequence** in which you select cars!

### Step 4: Choose Positioning
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

### Step 5: Adjust Sequence (Optional)
**Function Buttons** beside To Track:
- **HEAD** - Move selected cars to front
- **UP** - Move selected cars up one position
- **DOWN** - Move selected cars down one position
- **REAR** - Move selected cars to back
- **AFTER** - Place after selected car
- **REVERSE** - Flip order of selected cars

### Step 6: Send
1. Tap **SEND**
2. System processes the switch
3. Wait for confirmation

---

## Understanding Yard Primary Direction

Each yard has a **Primary Direction** for listing cars:

### North Primary Direction
- **HEAD** = North end of track
- **REAR** = South end of track
- List cars from **North to South**

### South Primary Direction
- **HEAD** = South end of track
- **REAR** = North end of track
- List cars from **South to North**

### East/West Primary Directions
- Same concept, different orientation
- **Know your yard's direction!**

---

## Verifying Manual Switches

### Completed Switch Lists Screen

After sending, check the **Completed Switch Lists** section:

| Yard | From Track | To Track | Switch# | Sent Time | # of Cars | Status |
|------|------------|----------|---------|-----------|-----------|--------|
| XXB023 | DSI | MAI | 001 | 13:27 | 7 | ✅ |
| XXB023 | MAI | WYE | 002 | 13:28 | 12 | ✅ |
| XXB023 | MAI | MAI | 003 | 14:02 | 70 | ✅ |
| XXB023 | AEI | MAI | 004 | 15:42 | 2 | ❌ |

### Status Indicators

#### ✅ Green Check
- Switch posted successfully
- Inventory updated
- No action needed

#### ❌ Red X
- Switch did **NOT** post
- **Action Required:** Re-input the switch
- If Red X persists, call MRT Helpdesk

### Refresh List
Tap **REFRESH LIST** to check for updated status icons.

### View Details
Tap any row to see:
- Exact cars switched
- From/To locations
- HAZ status
- Load/Empty status
- Commodities
- Final position in track

---

## Automated Switchlists

Automated switchlists are **system-generated** switching plans created by CSX's planning systems.

### Automated Switchlist Functions

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

### Sending Automated Lists
Once reviewed and adjusted:
1. Tap **SEND**
2. System processes the automated plan
3. Updates yard inventory
4. Generates confirmation

---

## Advanced YST Features

### Select All and Select Range
Available in YST for quick car selection.

### Set To Track
Quickly assign multiple cars to the same destination track.

### Report Defective Car (Bad Order)
1. While in YST, select the defective car
2. Tap **Report Defective Car**
3. Enter defect details
4. System marks car as Bad Order in inventory

### Track Adjust
Special function for:
- Reorganizing cars on same track
- Correcting car sequence
- Updating positions without moving tracks

---

## Manual Switchlist: Step-by-Step Example

### Scenario
Move 3 cars from Track W02 to Track W23, place at HEAD.

### Steps

**1. Select Yard**

Yard: XXB023 FAIRBURN GA
Primary Direction: North


**2. Select Tracks**

From Track: W02 (tap arrow, select from list)
To Track: W23 (tap arrow, select from list)


**3. Select Cars**

Cars on W02:
☐ CYDX 220
☐ AEX 11238
☐ KGLX 91122
☐ CPDX 214008

Select first 3 cars (or tap "Select Range")


**4. Choose Position**

Tap: HEAD (to place at north end of W23)


**5. Verify Sequence in To Track**

To Track W23 will show:
001 CYDX 220
002 AEX 11238
003 KGLX 91122
(existing cars follow)


**6. Send**

Tap: SEND


**7. Verify**

Tap: REFRESH LIST
Check for green check ✅


---

## Common YST Scenarios

### Scenario 1: Building a Cut for Departure

Purpose: Gather cars from multiple tracks onto departure track

From Tracks: W02, W07, W19
To Track: W01 (departure track)
Method: Multiple manual switches, use REAR to build in order
Result: All cars staged on W01 ready to depart


### Scenario 2: Breaking Down an Arrival

Purpose: Distribute inbound cars to classification tracks

From Track: W01 (receiving track)
To Tracks: W10, W15, W20, W25 (by destination)
Method: Multiple manual switches, selecting cars by destination
Result: Cars sorted to proper classification tracks


### Scenario 3: Repositioning for Customer Access

Purpose: Move cars blocking customer track

From Track: W12
To Track: W13 (temporary storage)
Method: Single track to single track
Position: AFTER existing cut
Result: W12 clear for customer access


### Scenario 4: Correcting Car Sequence

Purpose: Reorder cars on same track

From Track: W20
To Track: W20
Method: Track Adjust
Use: UP/DOWN buttons to resequence
Result: Cars in correct order for outbound


---

## YST Best Practices

### Before Switching
- ✅ Review automated lists if available
- ✅ Know your yard's primary direction
- ✅ Verify track capacity
- ✅ Check for track outages or restrictions
- ✅ Understand the final goal (building, sorting, storing)

### During Switching
- ✅ Select cars in the sequence you want
- ✅ Use Select Range for continuous cuts
- ✅ Verify To Track before sending
- ✅ Double-check HEAD vs. REAR placement
- ✅ Use AFTER for precise positioning

### After Switching
- ✅ Tap REFRESH LIST immediately
- ✅ Verify green check appears
- ✅ Re-input any Red X switches
- ✅ Update manual records if required
- ✅ Inform yardmaster of completed switches

---

## Troubleshooting YST

### Red X on Switch
**Problem:** Switch did not post to system
**Solution:**
1. Tap REFRESH LIST (wait 30 seconds)
2. If still Red X, re-input the entire switch
3. If persists, call MRT Helpdesk 800-243-7743 #4

### Cars Not Showing in Inventory
**Problem:** Expected cars not visible in From Track
**Solution:**
1. Verify you're in correct yard
2. Check milepost matches your location
3. Tap REFRESH on inventory
4. Verify cars haven't already been moved
5. Contact yardmaster to verify car location

### Wrong Primary Direction
**Problem:** Cars listing in unexpected order
**Solution:**
1. Check yard's Primary Direction at top of screen
2. Adjust your HEAD/REAR selection accordingly
3. North Primary: List North to South
4. South Primary: List South to North

### Cannot Select Car
**Problem:** Car not selectable in From Track list
**Solution:**
1. Check if car has restrictions (HAZ, dimensional, bad order)
2. Verify car isn't already on another crew's work order
3. Refresh inventory
4. Contact yardmaster if issue persists

---

## YST and Work Orders

### Relationship
- YST movements are **internal** to the yard
- Mobile Work Order handles **train movements** to/from yard
- Some cars may appear on **both**:
  - YST: To move within yard for staging
  - Work Order: To pick up and depart with

### Coordination
1. Use YST to **stage** cars for outbound trains
2. Use SPT to **build** the outbound train
3. Use Mobile Work Order to **report** pickup and departure

---

## Quick Reference: YST Functions

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

## Need Help?

📞 **MRT Helpdesk: 800-243-7743 option #4**

**Call for:**
- Persistent Red X on switches
- Cars not appearing in inventory
- Unable to complete switchlist
- System errors or crashes
- Questions about automated lists

**Have ready:**
- Your Train ID
- Yard milepost
- From/To tracks
- Number of cars involved
- Any error messages