# Mobile Work Order Completion

## Overview

The Mobile Work Order tool is used to complete and report all train movements, customer service, and station work. This is where the actual work gets reported in real-time.

---

## MRT Work Order Workflow (16 Steps)

### 1. Retrieve Work Order and Documents
- Get printed work order from printer
- Verify train ID and work order number match
- Review all planned work

### 2. Login to Mobile Work Order
- From Tool Selection, tap **Mobile Work Order**
- System shows dashboard with current work orders

### 3. Download Work Order
- Search for your work order (Train ID or WO#)
- Select from Current or Incomplete work orders
- Work order downloads with all tiles

### 4. Add/Change Service Equipment
- Input locomotives (lead first)
- Input EOT devices
- Tap **SEND**

### 5. Select Cars for Departure (Origin Pickup)
- Review cars available for pickup
- Select all cars you're taking
- Tap **SEND**

### 6. Adjust Train Standing Order
- Verify car sequence is correct
- Use function buttons to reorder if needed
- Tap **SEND**

### 7. Input EACs (Estimated Arrival to Customer)
- For each customer, tap clock icon
- Set estimated arrival date/time
- Tap **SEND**

### 8. Input Departure Time
- Enter time you actually left origin
- Use scroll arrows to set date/time
- Tap checkmark to confirm

### 9. Depart Origin
**If no cars selected for departure:**
- Go to Origin Pickup tile
- Report cars as you leave the yard

### 10. Take MRT Device With You
- Put tablet in **sleep mode** (press power button once)
- Keep tablet accessible on train
- Do NOT power down

### 11. Review Outbound AEI Read
- Handle any added or missing cars
- Accept or exception cars
- Complete BEFORE reporting work at other locations

### 12. Report Work in Real-Time
- At each location, report work as performed
- Complete customer tiles (places, pulls, intraplants)
- Complete station tiles (pickups, set outs)
- Complete interchange tiles (deliver, receive)

### 13. Check Alert Bell
- Tap notification bell regularly
- Review AEI Reads
- Check New Work
- Read Text Messages (Mail)

### 14. Review Inbound AEI Read
Handle discrepancies in this order:
1. **Error/Missing cars** - Report or exception
2. **Add Work cars** - Accept or reject
3. **Accept AEI Standing Order** - Final verification

Complete BEFORE reporting Set Out at destination

### 15. Report All Work
Continue until:
- All tiles are **grey**
- Display shows **COMPLETED 100%**
- Exception: If train is being recrewed

### 16. Logout
- Tap Menu (☰)
- Tap **Logout**
- Confirms pending data posts down

---

## Accessing Mobile Work Order

### From Dashboard

**Current Work Order:**

070729 (677637)
[Tap to select]


**Incomplete Work Orders:**

070727 (677666) - 75% Complete
[Tap to login and continue reporting]


**Search Box:**

Enter Train ID/WO#: _______
[For non-yard jobs, leave milepost blank]


---

## Origin Service Equipment

### Adding Locomotives

**Format Requirements:**
- Space between initial and number
- Lead locomotive entered first
- Example: CSXT 4555

**Process:**
1. Tap **(+)** next to Locomotive(s)
2. Enter locomotive number
3. Tap to confirm
4. Repeat for additional units
5. Tap **SEND** when all entered

### Adding EOT Devices

**Format Requirements:**
- Space between initial and number
- Example: CSXE 41852

**Process:**
1. Tap **(+)** next to EOT(s)
2. Enter EOT number
3. Tap to confirm
4. Tap **SEND**

### Removing Equipment
- Tap **trash bin icon** (🗑️) next to equipment
- Confirms removal
- Re-add if removed in error

---

## Origin Pickup

### Selecting Cars for Departure

**View Options:**
- **Add Cars** tab - Shows yard inventory available
- **Origin Pickup** tab - Shows cars already selected

**Selection Methods:**
- Tap individual cars
- Use **SELECT/DESELECT ALL**
- Use **Select Range** slider
- Search by car initial/number

### Origin Pickup Screen

**Available Functions:**
- **EXCEPTION CARS** - Mark cars you cannot take
- **SET END INSTRUCTIONS** - Change destination if needed
- **SET EMPTY** - Change load status to empty
- **SET LOADED** - Change load status to loaded
- **MARK A/N** - Mark as A or N status
- **MARK BUFFER CAR** - Designate buffer car

**Information Displayed:**
| Column | Information |
|--------|-------------|
| Seq | Sequence number |
| HAZ | Hazmat indicator |
| Car | Car initial and number |
| Load/Empty | L or E status |
| Car Type | AAR car type code |
| Commodity | What's being shipped |
| From Instruction | Where car came from |
| Exception | Any exception code |

### Completing Origin Pickup

**Step 1:** Select all cars for departure

11 of 11 Selected


**Step 2:** Tap **SEND**

**Step 3:** Origin Pickup tile updates:

PK: 11  [COMPLETED]
03/30 09:25


---

## Train Standing Order (Work Order)

### Purpose
Verify and adjust the final sequence of cars in your train.

### Display Information

Seq  HAZ  Car         Load/Empty  Car Type  Commodity  From Instruction  To Instruction
001       CSXT 4555   L           D                    PICK UP FROM      LOCOMOTIVES
002       ARMN 933003 L           R         2036190    PICK UP FROM      PLACE AT
003       CYDX 220    L           H         1421965    PICK UP FROM      PLACE AT


### Function Buttons
| Button | Function |
|--------|----------|
| **HEAD** | Move to front of train |
| **UP** | Move up one position |
| **DOWN** | Move down one position |
| **REAR** | Move to rear of train |
| **AFTER** | Place after selected car |
| **REVERSE** | Reverse order of selection |

### Adjustment Process
1. Select car(s) to move (tap checkbox)
2. Tap appropriate function button
3. Verify new position
4. Repeat as needed
5. Tap **SEND**

---

## Estimated Arrival to Customer (EAC)

### Purpose
Notify customers when to expect your arrival for service.

### EAC Screen Display

Customer Name               Type  IIDS Key    Scheduled   Est Arrival  EAC Sent
COMMERCIAL WAREHOUSE #1     Cust  SX820 9726  4 PL                    
COMMERCIAL WAREHOUSE #2     Cust  SX820 9732  1 PU                    
QUALITY LIQUID FEEDS INC    Cust  SX820 9731  2 PL                    


### Setting EAC

**Step 1:** Tap **clock icon** for each customer

**Step 2:** Adjust date/time using scroll arrows

Mar 2017
  30
10:30


**Step 3:** Tap **checkmark icon** to confirm

**Step 4:** Verify EAC appears in column

Est Arrival: 03/30 10:30


**Step 5:** Tap **SEND** to transmit all EACs

### EAC Status Indicators
- **Blank** - Not yet entered
- **Time shown** - Entered but not sent
- **EAC Sent** - Successfully transmitted to customer
- **EAC cannot be sent** - Customer not configured for EAC

### Alternative EAC Access
1. **From Customer Tile** - Tap "EDIT EAC" button
2. **From Menu** - Tap Menu → EAC Review

---

## Origin Departure Time

### When to Input
After all origin work is complete and ready to depart.

### Process

**Step 1:** System prompts for departure time

ENTER TIME FOR ORIGIN DEPARTURE


**Step 2:** Use scroll arrows to set actual departure time

Mar 2017
  30
09:25


**Step 3:** Tap **checkmark icon**

**Step 4:** Departure time shows on Origin tile

ORIGIN
03/30 09:25


---

## Understanding the Work Order Tiles

### Tile Components

**Header:**
- Location name and milepost
- Station/Customer/Interchange designation

**Work Instructions:**
- **PK** - Pickup (with count)
- **SO** - Set Out (with count)
- **PL** - Place (with count)
- **PU** - Pull (with count)
- **DI** - Deliver Interchange (with count)
- **IP** - Intraplant Switch (with count)

**Status Indicators:**
- Completion percentage (0%, 50%, 100%)
- Reported time
- EAC time (for customers)
- NEW WORK notification

**Action Buttons:**
- **STATION INFO / CUSTOMER INFO** - View details
- **EDIT EAC** - Modify arrival estimate
- **NEW WORK** - View/accept new assignments

---

## Reporting Customer Work

### Customer Tile Example

SX 820 9726 COMMERCIAL WAREHOUSING INC
PL: 4     03/30 10:35
EAC: 03/30 10:30


### Completing Place Work

**Step 1:** Tap the **PL** instruction

**Step 2:** Review cars to place

4 of 4 Selected
Car         Load/Empty  Car Type  Commodity  HAZ  TOC/Requestor
ARMN 933003 L           R         2036190         
CYDX 220    L           H         1421965         
AEX 11238   L           K         1421965         
KGLX 91122  L           H         1421965         


**Step 3:** Handle any exceptions
- If car cannot be placed, select it
- Tap **EXCEPTION CARS**
- Choose exception code and reason

**Step 4:** Complete all cars OR selected cars

**Option A: Complete All Cars at Once**
- Tap **COMPLETE ALL CARS**
- Uses current timestamp for all cars

**Option B: Complete Selected Cars**
- Select specific car(s)
- Tap **COMPLETE SELECTED CARS**
- Allows backdating or specific time entry

**Step 5:** Enter time if prompted

ENTER TIME TO REPORT WORK
LAST REPORTED CAR WAS AT: 03/30 09:25
TIME MUST BE GREATER THAN 03/30 09:31


**Step 6:** Verify completion

Car         Reported Time  To Track/Spot  Exception
ARMN 933003 03/30 10:35    
CYDX 220    03/30 10:35    
AEX 11238   03/30 10:35    
KGLX 91122  03/30 10:35    


### Completing Pull Work

**Same process as Place, but:**
- Cars are being removed from customer
- May need to change L/E status
- From Instruction shows PU (Pull from Customer)
- To Instruction shows where cars are going (SO, PL, DI)

### Completing Intraplant Work

**Process:**
- Select cars being moved within customer facility
- Cars stay at same customer (FROM and TO are same customer)
- Report time of intraplant movement
- No track/spot change typically needed

---

## Reporting Station Work

### Station Set Out

**Step 1:** Tap **SO** (Set Out) instruction on destination tile

**Step 2:** Review cars to set out

10 of 10 Selected
Car         Load/Empty  Car Type  Commodity  Reported Time  To Track/Spot


**Step 3:** Tap **SET TRACK AND SPOT**

**Step 4:** Select To Track

**Method 1: Using Track Adjust**
- Select specific track from dropdown
- Tap HEAD or REAR
- Or select "After car" and tap AFTER
- Use function buttons to adjust

**Method 2: Using Select Filter**
- Choose To Track from dropdown (W23, W25, etc.)
- All selected cars assigned to that track
- Tap HEAD or REAR

**Step 5:** Position cars on track

**Using HEAD:**

To Track: W23
Position: HEAD (north end)
Seq  Car
001  PRSX 449
002  CSXT 915036
003  CPDX 214008


**Using REAR:**

To Track: W23
Position: REAR (south end)
Seq  Car
...  (existing cars)
025  PRSX 449
026  CSXT 915036
027  CPDX 214008


**Using AFTER:**
1. Select the "behind car" on track first
2. Tap **AFTER**
3. New cars insert after that car

**Step 6:** Tap **UPDATE**

**Step 7:** Tap **COMPLETE ALL CARS**

**Step 8:** Enter time

Set Out completed: 03/30 17:00


**Important:** Use different times for each cut per yard
- Set Outs need at least 1 minute apart
- Example: 17:00, 17:01, 17:02, etc.

---

## Reporting Locomotives

### When to Report
After all other work is complete at destination.

### Process

**Step 1:** From Set Out screen, tap **Locomotives** tab

**Step 2:** System shows equipment

0 of 2 Selected
Car         Load/Empty  Car Type
CSXT 4555   L           D
CSXE 41852  L           M


**Step 3:** Tap **COMPLETE ALL CARS**

**Step 4:** Enter time

Locomotives reported: 03/30 17:04


**Step 5:** Verify completion

Car         Reported Time  To Track/Spot
CSXT 4555   03/30 17:04    
CSXE 41852  03/30 17:04    


---

## Work Order Completion Indicators

### Train Order Progress Bar

Train Order  COMPLETED 15%
Train Order  COMPLETED 50%
Train Order  COMPLETED 82%
Train Order  COMPLETED 100%


### Tile Color Progression
1. **White** - Not started (0%)
2. **Blue** - In progress (1-99%)
3. **Green** - Partially complete (some instructions done)
4. **Grey** - Fully complete (100%)

### Completion Goal
All tiles must show:
- Grey color
- 100% percentage
- All instructions reported

Example:

SX 820 9726 CUSTOMER
PL: 4   03/30 10:35  [Grey tile]
PU: 2   03/30 10:40  [Grey tile]


---

## Best Practices for Work Order Completion

### Timing
- ✅ Report work **as real-time as possible**
- ✅ Backdate when necessary (with actual time)
- ✅ Separate cuts by at least 1 minute
- ❌ Don't batch-report at end of shift

### Accuracy
- ✅ Verify car initials and numbers
- ✅ Use correct work instructions (PU vs PK, PL vs SO)
- ✅ Input actual times, not estimated
- ✅ Double-check track and spot numbers

### Exceptions
- ✅ Exception cars at time of occurrence
- ✅ Choose most accurate exception reason
- ✅ Use customer reasons when appropriate
- ❌ Don't default to one exception for everything

### Completion
- ✅ Complete all tiles before logging out
- ✅ Report locomotives last
- ✅ Verify 100% completion
- ✅ Logout properly (Menu → Logout)

---

## Common Work Order Scenarios

### Scenario 1: Simple Place and Depart

1. Login to work order
2. Add equipment
3. Select origin pickup cars
4. Input EACs
5. Enter departure time
6. Travel to customer
7. Report place work
8. Continue to destination
9. Report set out
10. Report locomotives
11. Logout


### Scenario 2: Multiple Customer Stops

1. Complete origin procedures
2. At Customer A: Report places
3. At Customer B: Report pulls
4. At Customer C: Report places and pulls
5. Review AEI read
6. At destination: Report set out
7. Report locomotives
8. Logout


### Scenario 3: Exception Handling

1. Arrive at customer
2. Customer track full - cannot place 2 of 4 cars
3. Place 2 cars successfully (Complete Selected)
4. Select 2 cars that couldn't be placed
5. Tap EXCEPTION CARS
6. Choose: SO (Set Out Other), TF (Track Full)
7. Continue to destination with 2 cars
8. Report set out of 2 excepted cars
9. Complete remaining work
10. Logout


---

## Troubleshooting Work Order Issues

### Cannot Find Work Order
**Problem:** Work order not showing on dashboard
**Solution:**
1. Verify Train ID or WO# is correct
2. Check if it's under Incomplete Work Orders
3. Try searching with just Train ID
4. For yard jobs, verify milepost is correct
5. Call MRT Helpdesk if still not found

### Car Not in Work Order
**Problem:** Need to move a car not on your WO
**Solution:**
1. Use **ADD WORK** function
2. Input FROM and TO instructions
3. Report immediately
4. Or call MRT Helpdesk to add

### Wrong End Instruction
**Problem:** Car shows wrong destination
**Solution:**
1. Select the car
2. Tap **SET END INSTRUCTIONS**
3. Choose correct destination
4. Tap UPDATE
5. Continue with work order

### Reported Wrong Time
**Problem:** Entered incorrect timestamp
**Solution:**
1. Tap Menu → **Undo Last Reporting**
2. Works for 4 minutes after reporting
3. Re-report with correct time
4. If beyond 4 minutes, call MRT Helpdesk

---

## Work Order Quick Reference

| Task | Action |
|------|--------|
| Add equipment | Tap (+) next to Locomotives/EOT |
| Select origin cars | Origin Pickup → Select All → SEND |
| Adjust car order | Train Standing Order → Use function buttons |
| Set EAC | Tap clock icon → Set time → SEND |
| Report customer work | Tap instruction → Complete cars |
| Set track/spot | SET TRACK AND SPOT → Choose track → Position |
| Exception a car | Select car → EXCEPTION CARS → Choose reason |
| Report locomotives | Tap Locomotives tab → Complete All |
| Undo reporting | Menu → Undo Last Reporting |
| Check completion | Verify all tiles grey, 100% complete |
| Logout | Menu → Logout |

---

## Need Help?

📞 **MRT Helpdesk: 800-243-7743 option #4**

**Call for:**
- Work order not found
- Cannot report work
- Exception code questions
- Incorrect reporting (beyond 4-min undo window)
- System errors
- Work not posting down

**Have ready:**
- Train ID and Work Order number
- Location/milepost
- Specific cars involved
- What you were trying to do
- Any error messages