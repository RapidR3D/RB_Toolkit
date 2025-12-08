# <color=#FFD700>Work Instruction Codes Reference</color>  

## <color=#FF8C00>All Work Instruction Codes</color>  

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

## <color=#FF8C00>Work Instruction Pairs (FROM → TO)</color>  

Every car movement requires **TWO instructions**: where you GET the car (FROM) and where you LEAVE the car (TO).  

### <color=#20B2AA>Common Movement Patterns</color>  

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

## <color=#FF8C00>Detailed Work Instruction Definitions</color>  

### <color=#20B2AA>DI - Deliver Interchange</color>  

<color=#FF8C00>**Full Name:**</color> Deliver Interchange  

<color=#FF8C00>**Category:**</color> Interchange Work  

<color=#FF8C00>**Definition:**</color> Taking cars from CSX network and delivering them to another railroad's designated track at an interchange point.  

<color=#FF8C00>**When to Use:**</color>  
- Delivering cars to foreign railroads
- Handing off to shortlines
- Interchange transfers to rail partners

<color=#FF8C00>**Example Scenarios:**</color>  
- CSX car going to Norfolk Southern
- Delivering to regional shortline
- Transferring to Canadian railroad at border

<color=#FF8C00>**FROM Instructions that precede DI:**</color>  
- PK (Pick Up from Station)
- PU (Pull from Customer)

<color=#FF8C00>**Key Points:**</color>  
- Car leaves CSX possession
- Other railroad assumes responsibility
- Reported at time of physical transfer
- Requires proper paperwork/billing

---

### <color=#20B2AA>IP - Intra Plant Switch</color>  

<color=#FF8C00>**Full Name:**</color> Intra Plant Switch  

<color=#FF8C00>**Category:**</color> Customer Work  

<color=#FF8C00>**Definition:**</color> Moving previously placed cars within a customer's facility. Cars remain at the same customer, just changing tracks/spots.  

<color=#FF8C00>**When to Use:**</color>  
- Repositioning cars within customer
- Moving empties for loading
- Rearranging cars for customer access
- Switching between customer's tracks

<color=#FF8C00>**Example Scenarios:**</color>  
- Move car from Track 1 to Track 3 (same customer)
- Reposition empty for customer to load
- Clear customer track for inbound placement

<color=#FF8C00>**FROM and TO Instructions:**</color>  
- Both are IP (car stays at customer)

<color=#FF8C00>**Key Points:**</color>  
- Car never leaves customer facility
- FROM customer = TO customer
- Customer-requested repositioning
- May be on SPT or added work

---

### <color=#20B2AA>LC - Locomotives and EOTS</color>  

<color=#FF8C00>**Full Name:**</color> Locomotives and End-of-Train Devices  

<color=#FF8C00>**Category:**</color> Equipment  

<color=#FF8C00>**Definition:**</color> Movement of locomotives and EOT devices (not revenue cars).  

<color=#FF8C00>**When to Use:**</color>  
- Adding locomotives to train
- Setting out locomotives
- Picking up or dropping EOT devices
- Power swaps

<color=#FF8C00>**Example Scenarios:**</color>  
- Picking up lead locomotive at origin
- Setting out helper locomotive en route
- Dropping EOT at destination
- Swapping power due to failure

<color=#FF8C00>**Appears Separately:**</color>  
- Shows in its own tile/destination on work order
- Reported separately from revenue cars
- Always report at end of shift (destination)

<color=#FF8C00>**Key Points:**</color>  
- Lead locomotive entered first
- Space between initial and number
- Report when setting out power
- EOT reported with locomotives

---

### <color=#20B2AA>PK - Pick Up (from Station)</color>  

<color=#FF8C00>**Full Name:**</color> Pick Up from Station  

<color=#FF8C00>**Category:**</color> Station Work  

<color=#FF8C00>**Definition:**</color> Adding cars to your train from a CSX yard or terminal to depart with them.  

<color=#FF8C00>**When to Use:**</color>  
- Taking cars from origin yard
- Picking up en route at intermediate yard
- Taking cars from line of road station
- Receiving from interchange (onto CSX)

<color=#FF8C00>**Example Scenarios:**</color>  
- Pick up 20 cars from Atlanta yard
- Add 5 cars at intermediate terminal
- Receive 10 cars from Norfolk Southern interchange

<color=#FF8C00>**TO Instructions that follow PK:**</color>  
- SO (Set Out at another station)
- PL (Place at customer)
- DI (Deliver to interchange)

<color=#FF8C00>**Key Points:**</color>  
- CSX-controlled inventory
- Origin = CSX yard/station
- **NOT customer property**
- Station-to-station or station-to-customer

---

### <color=#20B2AA>PL - Place (at Customer)</color>  

<color=#FF8C00>**Full Name:**</color> Place at Customer  

<color=#FF8C00>**Category:**</color> Customer Work  

<color=#FF8C00>**Definition:**</color> Spotting cars into a customer's industry or facility at a specific track/spot.  

<color=#FF8C00>**When to Use:**</color>  
- Delivering loads to customer
- Spotting empties for customer loading
- Placing cars at customer's request
- Customer service deliveries

<color=#FF8C00>**Example Scenarios:**</color>  
- Place 4 loaded cars at chemical plant
- Spot 6 empties for customer to load
- Deliver coal to power plant

<color=#FF8C00>**FROM Instructions that precede PL:**</color>  
- PK (Pick Up from Station)
- PU (Pull from another customer)
- DI (Received from interchange)

<color=#FF8C00>**Key Points:**</color>  
- Customer-controlled inventory
- Generates customer billing
- Specific track/spot assignment
- Affects CSD (Customer Switch Data)
- Report at time of placement

---

### <color=#20B2AA>PU - Pull (from Customer)</color>  

<color=#FF8C00>**Full Name:**</color> Pull from Customer  

<color=#FF8C00>**Category:**</color> Customer Work  

<color=#FF8C00>**Definition:**</color> Removing cars from a customer's industry or facility.  

<color=#FF8C00>**When to Use:**</color>  
- Pulling loaded cars customer has released
- Removing empties after unloading
- Customer-requested removals
- Picking up from customer facility

<color=#FF8C00>**Example Scenarios:**</color>  
- Pull 3 loaded tank cars from refinery
- Remove 5 empties after customer unloaded
- Pull bad order car from customer

<color=#FF8C00>**TO Instructions that follow PU:**</color>  
- SO (Set Out at Station)
- PL (Place at another customer)
- DI (Deliver to interchange)

<color=#FF8C00>**Key Points:**</color>  
- Removes from customer inventory
- Generates customer billing
- **NOT the same as PK** (station pickup)
- Loaded pulls must be on work order or New Work
- OK to add work empty pulls

<color=#FF8C00>**Special Rule:**</color>  
- **DO NOT pull loaded NOBILLS** (N status)
- Loaded pulls should be pre-planned
- Empty pulls can be added work

---

### <color=#20B2AA>SO - Set Out (at Station)</color>  

<color=#FF8C00>**Full Name:**</color> Set Out at Station  

<color=#FF8C00>**Category:**</color> Station Work  

<color=#FF8C00>**Definition:**</color> Leaving cars at a CSX yard or terminal for others to handle.  

<color=#FF8C00>**When to Use:**</color>  
- Leaving cars at destination yard
- Setting out at intermediate terminal
- Dropping cars for another crew
- Leaving at classification yard

<color=#FF8C00>**Example Scenarios:**</color>  
- Set out 15 cars at destination yard
- Drop 8 cars at intermediate terminal for sorting
- Leave cars for local crew to handle

<color=#FF8C00>**FROM Instructions that precede SO:**</color>  
- PK (Pick Up from origin)
- PU (Pull from customer)
- DI (Received from interchange)

<color=#FF8C00>**Key Points:**</color>  
- CSX-controlled inventory
- Destination = CSX yard/station
- **NOT customer facility**
- May include track assignment

---

### <color=#20B2AA>WI - Weigh In Industry</color>  

<color=#FF8C00>**Full Name:**</color> Weigh On Industry Scales  

<color=#FF8C00>**Category:**</color> Customer Work (Special)  

<color=#FF8C00>**Definition:**</color> Weighing cars on customer's scales for billing or certification purposes.  

<color=#FF8C00>**When to Use:**</color>  
- Customer requires certified weight
- Billing based on actual weight
- Special weight verification needed
- Customer scale operations

<color=#FF8C00>**Example Scenarios:**</color>  
- Weigh coal cars for tonnage billing
- Certify grain car weights
- Verify load weights for customer

<color=#FF8C00>**Key Points:**</color>  
- Limited use
- Specific customer agreements
- May be part of placement process
- Documentation required

---

## <color=#FF8C00>Critical Distinctions</color>  

### <color=#20B2AA>Station Work vs. Customer Work</color>  

| Aspect | Station (PK/SO) | Customer (PU/PL) |  
|--------|----------------|------------------|  
| **Location** | CSX yard/terminal | Customer industry/facility |  
| **Control** | CSX-controlled | Customer-controlled |  
| **Inventory** | CSX inventory | Customer inventory |  
| **Billing** | No customer charge | Customer is billed |  
| **CSD Impact** | None | Yes - affects score |  
| **Accessibility** | CSX access | Customer hours/access |  

### <color=#20B2AA>Common Mistakes to Avoid</color>  

❌ <color=#FF8C00>**WRONG:**</color> Using PK when pulling from customer  
✅ <color=#FF8C00>**RIGHT:**</color> Use PU when at customer industry  

❌ <color=#FF8C00>**WRONG:**</color> Using SO when placing at customer  
✅ <color=#FF8C00>**RIGHT:**</color> Use PL when spotting for customer  

❌ <color=#FF8C00>**WRONG:**</color> Using PL when setting out at yard  
✅ <color=#FF8C00>**RIGHT:**</color> Use SO when leaving at CSX station  

---

## <color=#FF8C00>Add Work Requirements</color>  

When adding work in MRT, you <color=#FF8C00>**MUST input BOTH instructions:**</color>  

### <color=#20B2AA>Required Pair</color>  
1. **FROM Instruction** - Where you got the car  
2. **TO Instruction** - Where you're taking it  

### <color=#20B2AA>Example Add Work</color>  
Car: TILX 334912  
FROM: PU (Pull from SX 820 9726 Commercial Warehouse)  
TO: SO (Set Out at AY 856 Winston FL yard)  

<color=#FF8C00>**Cannot input:**</color>  
- ❌ Only FROM instruction
- ❌ Only TO instruction
- ✅ Must have both FROM and TO

---

## <color=#FF8C00>Work Instruction Quick Reference</color>  

### <color=#20B2AA>I'm at a CSX Yard</color>  
- **Taking cars with me** → PK (Pickup)
- **Leaving cars here** → SO (Set Out)
- **Adding power/EOT** → LC

### <color=#20B2AA>I'm at a Customer</color>  
- **Removing cars** → PU (Pull)
- **Spotting cars** → PL (Place)
- **Moving within facility** → IP (Intraplant)

### <color=#20B2AA>I'm at an Interchange</color>  
- **Giving cars to another railroad** → DI (Deliver)
- **Receiving cars from another railroad** → PK (Pickup)

---

## <color=#FF8C00>Reporting Tips</color>  

### <color=#20B2AA>Station Work (PK/SO)</color>  
- Report when physically taking or leaving cars
- Include track assignment for SO
- May include multiple cuts on different tracks
- Separate cuts by at least 1 minute

### <color=#20B2AA>Customer Work (PU/PL)</color>  
- Report at time of service
- Include specific track/spot if known
- Customer may request specific timing
- Affects customer billing - be accurate
- Impacts CSD score - report timely

### <color=#20B2AA>Interchange Work (DI)</color>  
- Report at time of physical transfer
- Ensure proper documentation
- Other railroad assumes responsibility
- Verify receiving railroad correct

### <color=#20B2AA>Equipment (LC)</color>  
- Report locomotives at destination
- Always report EOT with locomotives
- Last item to complete on work order
- Lead locomotive listed first

---

## <color=#FF8C00>Need Help?</color>  

### <color=#20B2AA>Unsure Which Code to Use?</color>  

📞 **MRT Helpdesk: 800-243-7743 option #4**  

<color=#FF8C00>**Provide:**</color>  
- Where you are (customer, yard, interchange)
- What you're doing (taking, leaving, moving)
- Where the car came from
- Where the car is going

The helpdesk will guide you to the correct work instruction codes.  

---

## <color=#FF8C00>Summary Table</color>  

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