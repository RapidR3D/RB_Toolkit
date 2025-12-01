# Work Instruction Codes Reference

## All Work Instruction Codes

| Code | Description | Category | Use When |
|------|-------------|----------|----------|
| **DI** | Deliver Interchange | Interchange | Taking cars from CSX to another railroad's track |
| **IP** | Intra Plant Switch | Customer | Moving cars within customer facility |
| **LC** | Locomotives and EOTS | Equipment | Picking up or setting out power and end devices |
| **PK** | Pick Up | Station | Adding cars to train from CSX yard/station |
| **PL** | Place | Customer | Spotting cars at customer industry |
| **PU** | Pull | Customer | Removing cars from customer industry |
| **SO** | Set Out | Station | Leaving cars at CSX yard/station |
| **WI** | Weigh In Industry | Customer | Weighing cars on customer's scales |

---

## Work Instruction Pairs (FROM → TO)

Every car movement requires **TWO instructions**: where you GET the car (FROM) and where you LEAVE the car (TO).

### Common Movement Patterns

#### Station to Station
FROM: PK (Pick Up from origin station)
TO: SO (Set Out at destination station)

Example: Pick up from Atlanta yard, set out at Jacksonville yard

#### Station to Customer
FROM: PK (Pick Up from yard)
TO: PL (Place at customer)

Example: Pick up from yard, place at customer facility

#### Customer to Station
FROM: PU (Pull from customer)
TO: SO (Set Out at yard)

Example: Pull from customer, set out at yard

#### Customer to Customer
FROM: PU (Pull from first customer)
TO: PL (Place at second customer)

Example: Pull from Customer A, place at Customer B

#### Station to Interchange
FROM: PK (Pick Up from yard)
TO: DI (Deliver to other railroad)

Example: Pick up from CSX yard, deliver to Norfolk Southern

#### Interchange to Station
FROM: PK (Pick Up from other railroad)
TO: SO (Set Out at yard)

Example: Pick up from Union Pacific, set out at CSX yard

#### Interchange to Customer
FROM: PK (Pick Up from other railroad)
TO: PL (Place at customer)

Example: Pick up from BNSF interchange, place at customer

#### Within Customer (Intraplant)
FROM: IP (Intra Plant Switch)
TO: IP (stays at same customer)

Example: Move car from Track 1 to Track 3 within customer facility

---

## Detailed Work Instruction Definitions

### DI - Deliver Interchange

**Full Name:** Deliver Interchange

**Category:** Interchange Work

**Definition:** Taking cars from CSX network and delivering them to another railroad's designated track at an interchange point.

**When to Use:**
- Delivering cars to foreign railroads
- Handing off to shortlines
- Interchange transfers to rail partners

**Example Scenarios:**
- CSX car going to Norfolk Southern
- Delivering to regional shortline
- Transferring to Canadian railroad at border

**FROM Instructions that precede DI:**
- PK (Pick Up from Station)
- PU (Pull from Customer)

**Key Points:**
- Car leaves CSX possession
- Other railroad assumes responsibility
- Reported at time of physical transfer
- Requires proper paperwork/billing

---

### IP - Intra Plant Switch

**Full Name:** Intra Plant Switch

**Category:** Customer Work

**Definition:** Moving previously placed cars within a customer's facility. Cars remain at the same customer, just changing tracks/spots.

**When to Use:**
- Repositioning cars within customer
- Moving empties for loading
- Rearranging cars for customer access
- Switching between customer's tracks

**Example Scenarios:**
- Move car from Track 1 to Track 3 (same customer)
- Reposition empty for customer to load
- Clear customer track for inbound placement

**FROM and TO Instructions:**
- Both are IP (car stays at customer)

**Key Points:**
- Car never leaves customer facility
- FROM customer = TO customer
- Customer-requested repositioning
- May be on SPT or added work

---

### LC - Locomotives and EOTS

**Full Name:** Locomotives and End-of-Train Devices

**Category:** Equipment

**Definition:** Movement of locomotives and EOT devices (not revenue cars).

**When to Use:**
- Adding locomotives to train
- Setting out locomotives
- Picking up or dropping EOT devices
- Power swaps

**Example Scenarios:**
- Picking up lead locomotive at origin
- Setting out helper locomotive en route
- Dropping EOT at destination
- Swapping power due to failure

**Appears Separately:**
- Shows in its own tile/destination on work order
- Reported separately from revenue cars
- Always report at end of shift (destination)

**Key Points:**
- Lead locomotive entered first
- Space between initial and number
- Report when setting out power
- EOT reported with locomotives

---

### PK - Pick Up (from Station)

**Full Name:** Pick Up from Station

**Category:** Station Work

**Definition:** Adding cars to your train from a CSX yard or terminal to depart with them.

**When to Use:**
- Taking cars from origin yard
- Picking up en route at intermediate yard
- Taking cars from line of road station
- Receiving from interchange (onto CSX)

**Example Scenarios:**
- Pick up 20 cars from Atlanta yard
- Add 5 cars at intermediate terminal
- Receive 10 cars from Norfolk Southern interchange

**TO Instructions that follow PK:**
- SO (Set Out at another station)
- PL (Place at customer)
- DI (Deliver to interchange)

**Key Points:**
- CSX-controlled inventory
- Origin = CSX yard/station
- **NOT customer property**
- Station-to-station or station-to-customer

---

### PL - Place (at Customer)

**Full Name:** Place at Customer

**Category:** Customer Work

**Definition:** Spotting cars into a customer's industry or facility at a specific track/spot.

**When to Use:**
- Delivering loads to customer
- Spotting empties for customer loading
- Placing cars at customer's request
- Customer service deliveries

**Example Scenarios:**
- Place 4 loaded cars at chemical plant
- Spot 6 empties for customer to load
- Deliver coal to power plant

**FROM Instructions that precede PL:**
- PK (Pick Up from Station)
- PU (Pull from another customer)
- DI (Received from interchange)

**Key Points:**
- Customer-controlled inventory
- Generates customer billing
- Specific track/spot assignment
- Affects CSD (Customer Switch Data)
- Report at time of placement

---

### PU - Pull (from Customer)

**Full Name:** Pull from Customer

**Category:** Customer Work

**Definition:** Removing cars from a customer's industry or facility.

**When to Use:**
- Pulling loaded cars customer has released
- Removing empties after unloading
- Customer-requested removals
- Picking up from customer facility

**Example Scenarios:**
- Pull 3 loaded tank cars from refinery
- Remove 5 empties after customer unloaded
- Pull bad order car from customer

**TO Instructions that follow PU:**
- SO (Set Out at Station)
- PL (Place at another customer)
- DI (Deliver to interchange)

**Key Points:**
- Removes from customer inventory
- Generates customer billing
- **NOT the same as PK** (station pickup)
- Loaded pulls must be on work order or New Work
- OK to add work empty pulls

**Special Rule:**
- **DO NOT pull loaded NOBILLS** (N status)
- Loaded pulls should be pre-planned
- Empty pulls can be added work

---

### SO - Set Out (at Station)

**Full Name:** Set Out at Station

**Category:** Station Work

**Definition:** Leaving cars at a CSX yard or terminal for others to handle.

**When to Use:**
- Leaving cars at destination yard
- Setting out at intermediate terminal
- Dropping cars for another crew
- Leaving at classification yard

**Example Scenarios:**
- Set out 15 cars at destination yard
- Drop 8 cars at intermediate terminal for sorting
- Leave cars for local crew to handle

**FROM Instructions that precede SO:**
- PK (Pick Up from origin)
- PU (Pull from customer)
- DI (Received from interchange)

**Key Points:**
- CSX-controlled inventory
- Destination = CSX yard/station
- **NOT customer facility**
- May include track assignment

---

### WI - Weigh In Industry

**Full Name:** Weigh On Industry Scales

**Category:** Customer Work (Special)

**Definition:** Weighing cars on customer's scales for billing or certification purposes.

**When to Use:**
- Customer requires certified weight
- Billing based on actual weight
- Special weight verification needed
- Customer scale operations

**Example Scenarios:**
- Weigh coal cars for tonnage billing
- Certify grain car weights
- Verify load weights for customer

**Key Points:**
- Limited use
- Specific customer agreements
- May be part of placement process
- Documentation required

---

## Critical Distinctions

### Station Work vs. Customer Work

| Aspect | Station (PK/SO) | Customer (PU/PL) |
|--------|----------------|------------------|
| **Location** | CSX yard/terminal | Customer industry/facility |
| **Control** | CSX-controlled | Customer-controlled |
| **Inventory** | CSX inventory | Customer inventory |
| **Billing** | No customer charge | Customer is billed |
| **CSD Impact** | None | Yes - affects score |
| **Accessibility** | CSX access | Customer hours/access |

### Common Mistakes to Avoid

❌ **WRONG:** Using PK when pulling from customer
✅ **RIGHT:** Use PU when at customer industry

❌ **WRONG:** Using SO when placing at customer
✅ **RIGHT:** Use PL when spotting for customer

❌ **WRONG:** Using PL when setting out at yard
✅ **RIGHT:** Use SO when leaving at CSX station

---

## Add Work Requirements

When adding work in MRT, you **MUST input BOTH instructions:**

### Required Pair
1. **FROM Instruction** - Where you got the car
2. **TO Instruction** - Where you're taking it

### Example Add Work
Car: TILX 334912
FROM: PU (Pull from SX 820 9726 Commercial Warehouse)
TO: SO (Set Out at AY 856 Winston FL yard)

**Cannot input:**
- ❌ Only FROM instruction
- ❌ Only TO instruction
- ✅ Must have both FROM and TO

---

## Work Instruction Quick Reference

### I'm at a CSX Yard
- **Taking cars with me** → PK (Pickup)
- **Leaving cars here** → SO (Set Out)
- **Adding power/EOT** → LC

### I'm at a Customer
- **Removing cars** → PU (Pull)
- **Spotting cars** → PL (Place)
- **Moving within facility** → IP (Intraplant)

### I'm at an Interchange
- **Giving cars to another railroad** → DI (Deliver)
- **Receiving cars from another railroad** → PK (Pickup)

---

## Reporting Tips

### Station Work (PK/SO)
- Report when physically taking or leaving cars
- Include track assignment for SO
- May include multiple cuts on different tracks
- Separate cuts by at least 1 minute

### Customer Work (PU/PL)
- Report at time of service
- Include specific track/spot if known
- Customer may request specific timing
- Affects customer billing - be accurate
- Impacts CSD score - report timely

### Interchange Work (DI)
- Report at time of physical transfer
- Ensure proper documentation
- Other railroad assumes responsibility
- Verify receiving railroad correct

### Equipment (LC)
- Report locomotives at destination
- Always report EOT with locomotives
- Last item to complete on work order
- Lead locomotive listed first

---

## Need Help?

### Unsure Which Code to Use?

📞 **MRT Helpdesk: 800-243-7743 option #4**

**Provide:**
- Where you are (customer, yard, interchange)
- What you're doing (taking, leaving, moving)
- Where the car came from
- Where the car is going

The helpdesk will guide you to the correct work instruction codes.

---

## Summary Table

| Code | Location Type | Action | Billing | CSD Impact |
|------|--------------|--------|---------|-----------|
| PK | Station | Take | No | No |
| SO | Station | Leave | No | No |
| PU | Customer | Remove | Yes | Yes |
| PL | Customer | Spot | Yes | Yes |
| IP | Customer | Reposition | Yes | Yes |
| DI | Interchange | Deliver | No | Varies |
| LC | Any | Equipment | No | No |
| WI | Customer | Weigh | Special | Special |