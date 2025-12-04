# Add Work & New Work

## Overview

**Add Work** and **New Work** allow you to handle unplanned car movements that weren't on your original work order.

---

## Add Work vs. New Work

### Add Work
**Definition:** You initiate the addition of work
**Use when:** You need to move cars not on your work order
**Process:** Crew-initiated, manual input

**Examples:**
- Empty pulls from customer (not pre-planned)
- Bad order cars
- Cars found at wrong location
- Emergency moves

### New Work
**Definition:** System sends you additional work
**Use when:** Dispatched new assignments during your shift
**Process:** System-initiated, sent via notification

**Examples:**
- New customer orders received
- Work reassigned from another crew
- Updated plans from dispatcher
- Additional interchange cars

---

## ADD WORK

### Accessing Add Work

**Method 1: From Home Screen**
1. Tap **ADD WORK** button (bottom of screen)

**Method 2: From Menu**
1. Tap Menu (☰)
2. Select **Add Work**

**Method 3: From Customer Tile**
1. Some customer tiles show **ADD WORK** button

---

## Add Work Process

### Step 1: Select FROM Instruction

**Available Options:**
- **PK** (Pick Up from Station)
- **PU** (Pull from Customer)
- **IP** (Intra Plant Switch)
- **OS** (Off Spot)
- **LC** (Pick Up Loco/EOT)
- **WI** (Weigh In Industry)
- **TU** (Turn)

**Choose the instruction that describes where you GOT the car from**

---

### Step 2: Select TO Instruction

**Available Options:**
- **SO** (Station Set Out)
- **DI** (Deliver Interchange)
- **PL** (Place at Customer)

**Choose the instruction that describes where you're TAKING the car to**

---

### Step 3: Select Cars

#### For Customer Add Work (PU from Customer)

**Display Shows:**
- Customer inventory (cars currently at customer)
- Track/Spot location
- Car initial and number
- Load/Empty status
- Commodity
- HAZ indicator

**Selection Options:**
- **TRACK** filter - View by specific track
- **CAR INITIAL** filter - Search by reporting mark
- **LOAD/EMPTY** filter - Filter by L or E status
- **CAR TYPE** filter - Filter by AAR type
- **CLASS CODE** filter - Filter by commodity class

**Search Function:**
- **SEARCH CAR INITIAL/NUMBER** - Direct search

#### For Station Add Work (PK from Station)

**Display Shows:**
- Yard inventory
- Track location
- All available cars at station

**Additional Filters:**
- Filter by track
- Filter by car type
- Search specific car

---

### Step 4: Select FROM Track/Location

**For Customer:**
- System shows customer track/spot numbers
- Select where car currently is
- Example: 000010 (spot number)

**For Station:**
- Select yard track
- Example: W23, R01

---

### Step 5: Set Destination Details

#### Selecting Destination Station

**If TO instruction is SO (Set Out):**

1. List of stations displays:
CityState        Milepost
BIRMINGHAM AL    000389
TALLADEGA AL     ANJ910

2. Options shown:
   - **Origin - YOU ARE HERE**
   - **Destination**
   - **Add Station After** (intermediate stops)

3. Scroll to find your station
4. Tap to select
5. Tap **ADD SELECTED STATION**

#### Selecting Destination Customer

**If TO instruction is PL (Place):**

1. Select station/milepost first
2. Customer list appears:

Station SX 820 (AUBURNDALE FL)
- SX 820 9726 COMMERCIAL WAREHOUSE #1
- SX 820 9732 ROADMASTER
- SX 820 9735 QUALITY LIQUID FEEDS INC

3. Tap customer
4. Tap **UPDATE**

#### Selecting Interchange Railroad

**If TO instruction is DI (Deliver):**

1. Junction/railroad list appears
2. Select receiving railroad
3. Tap **UPDATE**

---

### Step 6: Add Cars to Work Order

1. Review selected cars
2. Verify FROM and TO instructions are correct
3. Tap **ADD SELECTED CARS** or **ACCEPT SELECTED CARS**
4. Cars added to your work order

---

### Step 7: Report the Add Work

After adding cars to work order:

1. Locate the tile with added work
2. Report work as normal:
   - Complete cars when work performed
   - Input accurate timestamps
   - Exception if necessary

---

## Add Work from Customer Inventory

### Detailed Example: Pulling Empty from Customer

**Scenario:** Customer releases empty car not on your work order

**Step 1:** Tap **ADD WORK**

**Step 2:** Select **PU** (Pull from Customer)

**Step 3:** Customer list appears, select customer
BN 188 2315 APG POLYTECH LLC


**Step 4:** Customer inventory displays
Track/Spot  Car          L/E  Commodity  Class  Consignee  PS#
000010      MGRX 10802   L    3742217    01AP   SOUCONT    PS045215

**Filters Available:**
- TRACK
- CAR INITIAL
- LOAD/EMPTY
- CAR TYPE
- CLASS CODE

**Step 5:** Select the car(s) to pull

**Step 6:** Tap **ADD SELECTED CARS**

**Step 7:** Select **TO** instruction: **SO** (Set Out at Station)

**Step 8:** Select destination station from list

**Step 9:** Cars added to work order with:

FROM: PU (Pull from BN 188 2315)
TO: SO (Set Out at destination station)
**Step 10:** Report pull when performed:
- Tap PU instruction
- Complete selected cars
- Input actual time

---

## Add Station (Intermediate Stops)

### Purpose
Add a station between your current origin and destination for unplanned work.

### Process

**Step 1:** During Add Work, select TO: **SO**

**Step 2:** Station list shows three sections:
Origin - YOU ARE HERE
BIRMINGHAM AL    000389

Add Station After
[Adds between Birmingham & Talladega]
TALLADEGA AL     ANJ910

Adds between Talladega & Birmingham
[Adds after Talladega]

Destination
BIRMINGHAM AL    000389
**Step 3:** Choose:
- **Add Station After Origin** - Before your destination
- **Add between existing stations** - Mid-route stop
- System adds tile to work order

**Step 4:** Report work at that station when you arrive

---

## NEW WORK

### What is New Work?

New Work consists of additional assignments sent to your tablet **during your shift** by:
- Dispatchers
- Yardmasters
- Transportation Services
- System automated updates

---

## New Work Notifications

### Alert Indicators

**Notification Bell:**

🔔 (2)

Number shows unread New Work notifications

**Customer Tile:**

SX 820 9726 COMMERCIAL WAREHOUSE
PL: 4
NEW WORK (3 cars)

**Notification List:**

NEWWORK Received at 11/29 15:31
New Work: Number of cars on new work: 3

NEWWORK Received at 11/29 18:12
New Work: Number of cars on new work: 1

---

## Accessing New Work

### Method 1: From Notification Bell
1. Tap **notification bell** (🔔)
2. Select **New Work** notification
3. Review new work details

### Method 2: From Customer Tile
1. Locate tile showing **NEW WORK**
2. Tap **NEW WORK** button
3. Review cars assigned

---

## New Work Screen

### Display Information

**Grouped by Customer/Location:**

BN 188 2315 APG POLYTECH LLC

**Car Details:**
| Car | L/E | Commodity | From Instruction | To Instruction | Track/Spot | Accepted/Rejected |
|-----|-----|-----------|------------------|----------------|------------|-------------------|
| MGRX 10802 | L | 3742217 | PULL FROM BN 188 2315 | SET OUT AT BN 173 | | |
| MGRX 10734 | L | 3742217 | PULL FROM BN 188 2315 | SET OUT AT BN 173 | | |
| GPLX 74627 | L | 3742217 | PULL FROM BN 188 2315 | SET OUT AT BN 173 | | |

---

## Handling New Work

### Decision: Accept or Reject

**Accept:** You CAN handle this additional work
**Reject:** You CANNOT or will not perform this work

### Accepting New Work

**Step 1:** Review the new work cars

**Step 2:** Select cars you can handle
- Tap individual cars
- Use **SELECT/DESELECT ALL**
- Use **Select Range**

**Step 3:** Tap **ACCEPT SELECTED CARS**

**Step 4:** Cars added to your work order with:
- FROM instruction (where to get car)
- TO instruction (where to take car)
- Location details

**Step 5:** Report work when performed
- New cars appear in appropriate tiles
- Report like any other work

---

### Rejecting New Work

**Step 1:** Review the new work cars

**Step 2:** Select cars you CANNOT handle

**Step 3:** Tap **REJECT SELECTED CARS**

**Step 4:** System removes from your assignment

**Purpose of Rejecting:**
- Clears notification/message
- Informs system you won't perform work
- Allows reassignment to another crew

**When to Reject:**
- Out of time
- Wrong location
- Equipment constraints
- Safety concerns
- Received in error

---

## Text Notifications (Mail)

### Accessing Text Messages

**Notification Bell:**
🔔 
Text Messages (1)

**Message List:**
MESSAGE Received at 11/30 10:31
Do not pull GATX 32067 from Chemical Dynamics...

### Reading Text Messages

**Step 1:** Tap notification bell

**Step 2:** Select **Text Messages**

**Step 3:** Message details display:

Message Details:
Received at: 11/30 10:31

Do not pull GATX 32067 from Chemical Dynamics 
Plant City SX 823 9624. Car is still at 
industry/not loaded/not available for CSX to 
pull. I will exception this car for you off 
the work order today so the plant switch can 
be closed. You will need to log out and then 
log back into the work order. 

Call MRT Helpdesk at 800-243-7743 #4 if you 
have any questions. Thank you.

**Step 4:** Take appropriate action:
- Follow instructions in message
- **ACCEPT NOTIFICATION** (acknowledges message)
- **REJECT NOTIFICATION** (if not applicable)

### Purpose of Text Messages

- Specific instructions for your train
- Car-specific notices
- Work order modifications
- Safety alerts
- Operational updates

---

## Add Work Best Practices

### Before Adding Work

- ✅ Verify car is not already on your work order
- ✅ Confirm you have authority to move the car
- ✅ Check if it's a NOBILL (don't add loaded nobills)
- ✅ Verify proper FROM and TO instructions
- ✅ Ensure you can handle the car (hazmat, dimensional, etc.)

### While Adding Work

- ✅ Use correct work instructions (PU vs PK, PL vs SO)
- ✅ Select accurate car locations
- ✅ Verify L/E status is correct
- ✅ Double-check destination
- ✅ Input all required information

### After Adding Work

- ✅ Report work at time of performance
- ✅ Use accurate timestamps
- ✅ Exception properly if work cannot be completed
- ✅ Verify work posted to system

---

## New Work Best Practices

### Reviewing New Work

- ✅ Check notification bell regularly
- ✅ Review new work promptly
- ✅ Verify you're at correct location
- ✅ Assess if you can handle additional work
- ✅ Check for time constraints

### Accepting New Work

- ✅ Only accept what you can realistically complete
- ✅ Consider your hours of service
- ✅ Verify equipment can handle additional cars
- ✅ Check route for restrictions
- ✅ Confirm adequate time to complete

### Rejecting New Work

- ✅ Reject promptly so work can be reassigned
- ✅ Reject entire assignment if appropriate
- ✅ Contact dispatcher if clarification needed
- ✅ Don't accept then exception due to time

---

## Common Add Work Scenarios

### Scenario 1: Emergency Empty Pull

1. Customer calls: Empty available for pickup
2. Tap ADD WORK
3. Select PU (Pull from Customer)
4. Choose customer
5. Select empty car from inventory
6. Set TO: SO (Set Out at yard)
7. Select destination yard
8. Add to work order
9. Pull car when at customer
10. Report pull work with actual time

### Scenario 2: Bad Order Discovery

1. Find bad order car at customer
2. Tap ADD WORK
3. Select PU (Pull from Customer)
4. Choose customer
5. Select bad order car
6. Set TO: SO (Set Out at yard)
7. Select yard with repair track
8. Add to work order
9. Pull car
10. Report with BO exception code

### Scenario 3: Found Car at Wrong Location

1. Find car at location, not on work order
2. Verify with dispatcher
3. Tap ADD WORK
4. Select PK (Pickup from Station) or PU (Pull from Customer)
5. Select car from inventory
6. Set TO instruction
7. Select destination
8. Add to work order
9. Move car to correct location
10. Report work

---

## Common New Work Scenarios

### Scenario 1: Customer Releases Load

1. Notification bell shows NEW WORK
2. Tap notification
3. Review: Customer has 2 loaded pulls
4. Verify you can handle (not out of time)
5. Select both cars
6. Tap ACCEPT SELECTED CARS
7. Cars added to customer PU tile
8. At customer, pull the loads
9. Report pulls with actual time

### Scenario 2: Reassigned Interchange

1. Notification: 3 cars for interchange delivery
2. Review New Work
3. Verify destination railroad
4. Assess time to complete
5. Accept all 3 cars
6. Cars added to DI tile
7. Deliver to interchange
8. Report DI work

### Scenario 3: Cannot Handle New Work

1. Notification: 5 new cars for distant customer
2. Review: Would exceed hours of service
3. Select all 5 cars
4. Tap REJECT SELECTED CARS
5. System clears assignment
6. Work reassigned to another crew
7. Notification cleared

---

## Troubleshooting Add Work & New Work

### Cannot Find Car in Inventory
**Problem:** Car expected but not showing
**Solution:**
1. Verify correct customer/station selected
2. Use SEARCH CAR function
3. Check if car already on another work order
4. Refresh inventory
5. Contact yardmaster to verify car location
6. Call MRT Helpdesk if still not found

### Wrong Destination Added
**Problem:** Added car with incorrect TO instruction
**Solution:**
1. Before reporting: Can remove and re-add
2. After reporting: Call MRT Helpdesk to correct
3. May need to add corrective movement

### New Work Not Showing
**Problem:** Notified of new work but can't find it
**Solution:**
1. Check notification bell
2. Look for NEW WORK on customer tiles
3. Logout and login to refresh
4. Call MRT Helpdesk if still missing

### Accepted New Work by Mistake
**Problem:** Accepted work you cannot handle
**Solution:**
1. Immediately exception the cars
2. Use appropriate exception code/reason
3. Contact dispatcher
4. Call MRT Helpdesk if needed

---

## Add Work & New Work Quick Reference

| Task | Action |
|------|--------|
| Start Add Work | Tap ADD WORK button |
| Select work type | Choose FROM instruction (PU, PK, etc.) |
| Choose destination | Select TO instruction (SO, PL, DI) |
| Find car | Use SEARCH or filters |
| Add to work order | ADD SELECTED CARS |
| Check for new work | Tap notification bell regularly |
| Review new work | Tap NEW WORK notification or button |
| Accept new work | Select cars → ACCEPT SELECTED CARS |
| Reject new work | Select cars → REJECT SELECTED CARS |
| Read text messages | Notification bell → Text Messages |
| Acknowledge message | ACCEPT NOTIFICATION |

---

## Need Help?

📞 **MRT Helpdesk: 800-243-7743 option #4**

**Call for:**
- Cannot add work for specific car
- New work not appearing
- Questions about accepting/rejecting
- Add work posting issues
- Text message clarifications
- Work order discrepancies after adding work

**Have ready:**
- Train ID and Work Order number
- Car initial and number
- Customer or station involved
- What you're trying to do
- Any error messages