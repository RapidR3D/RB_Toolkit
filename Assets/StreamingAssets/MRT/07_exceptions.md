# <color=#FFD700>Exception Codes & Reasons</color>  

## <color=#FF8C00>Overview</color>  

Exception codes communicate **why** planned work could not be completed. Choosing the correct exception reason is critical for:  
- Accurate CSD (Customer Switch Data) scoring
- Proper customer billing
- Operational metrics
- Future planning

---

## <color=#FF8C00>Exception Code Categories</color>  

### <color=#20B2AA>Work Instruction Exception Codes</color>  

| Code | Description | When to Use |  
|------|-------------|-------------|  
| **CD** | Conductor Distributable | Work delegated to conductor |  
| **LD** | Placed on Lead | Car placed on lead track temporarily |  
| **NI** | Not in Industry | Car not found at expected location |  
| **NP** | Not Performed | Work not completed |  
| **OS** | Off Spot | Car moved from assigned spot |  
| **PD** | Placed Different Track/Spot | Car spotted at alternate location |  
| **RD** | Reject Dirty | Car rejected due to cleanliness |  
| **RM** | Reject Mechanical | Car rejected due to mechanical defect |  
| **RO** | Reject Other | Car rejected for other reason |  
| **SO** | Set Out Other than Instructed | Car left at different location |  

### <color=#20B2AA>Special Work Instructions</color>  

| Code | Description | When to Use |  
|------|-------------|-------------|  
| **DI** | Delivered Interchange | Car delivered to another railroad |  
| **IP** | Intra Plant Switch | Car moved within customer facility |  
| **LC** | Locomotives and EOTS | Power/equipment movement |  
| **PK** | Pick Up | Car picked up from station |  
| **PL** | Place | Car placed at customer |  
| **SO** | Set Out | Car left at station |  
| **WI** | Weigh On Industry Scales | Car weighed at customer |  

---

## <color=#FF8C00>Reason Code Categories</color>  

### <color=#20B2AA>Railroad Reason Codes ⚠️</color>  
<color=#FF8C00>**These COUNT AGAINST CSD as "Misses"**</color>  
| Code | Description | Impact on CSD |  
|------|-------------|---------------|  
| **BI** | Bad Ordered - On Interchange Track | Miss |  
| **BO** | Bad Ordered | Miss |  
| **CX** | CSX Inability | Miss |  
| **DR** | Derailed Car | Miss |  
| **DW** | Dispatcher/Windows | Miss |  
| **EF** | Engine Failure | Miss |  
| **FL** | Foreign Line | Miss |  
| **HD** | No Hazardous Doc/Placards | Miss |  
| **IC** | Delivered Interchange | Miss |  
| **IL** | Improperly Loaded/Overloaded | Miss |  
| **NA** | Not Available at Station | Miss |  
| **NO** | Not Ordered | Miss |  
| **OT** | Out of Time | Miss |  
| **PI** | Placed in Industry | Miss |  
| **PR** | Temporarily Placed Different Industry | Miss |  
| **RE** | Railroad Error | Miss |  
| **RN** | Railroad Reason - No Re-spot | Miss |  
| **RP** | Rail Partner Inability | Miss |  
| **RR** | Railroad Reason - Re-spot | Miss |  
| **RT** | Track or Interchange Track Full | Miss |  
| **SI** | Customer Scales Inoperative | Miss |  
| **SP** | Swap Power/EOT's | Miss |  
| **SS** | Customer Siding Safety Issue | Miss |  
| **TN** | Tonnage | Miss |  
| **TX** | Track Condition - Railroad | Miss |  

### <color=#20B2AA>Customer Reason Codes ✅</color>  
<color=#FF8C00>**These DO NOT COUNT AGAINST CSD**</color>  
| Code | Description | May Result In |  
|------|-------------|---------------|  
| **AP** | Empty Appropriated for Loading | No CSD impact |  
| **BD** | Customer Blue Flag/Derail | Customer charge |  
| **CD** | Reject Mechanical - Customer Damage | No CSD impact |  
| **CI** | Customer Not Accessible | Customer charge |  
| **LN** | Load/Unload Not Complete | No CSD impact |  
| **OB** | Customer Obstruction | Customer charge |  
| **RA** | Customer Request on Arrival | No CSD impact |  
| **RQ** | Customer Request | No CSD impact |  
| **TC** | Track Condition - Customer | Customer charge |  
| **TF** | Customer Track Full | No CSD impact |  

---

## <color=#FF8C00>Valid Exception Code + Reason Code Combinations</color>  

### <color=#20B2AA>DI (Deliver Interchange)</color>  

<color=#FF8C00>**Valid Exception Codes:**</color> SO, NI  

<color=#FF8C00>**Valid Reason Codes:**</color>  
- BO, IC, OT, PI, PR, RE, RP, RR, RT

<color=#FF8C00>**Example:**</color>  

Exception: SO (Set Out Other)  
Reason: IC (Delivered Interchange)  
Explanation: Car was delivered to interchange instead of customer  


---

### <color=#20B2AA>IP (Intra Plant Switch)</color>  

<color=#FF8C00>**Valid Exception Codes:**</color> NP  

<color=#FF8C00>**Valid Reason Codes:**</color>  
- BD, BO, CI, CX, DW, EF, OB, OT, RA, RQ, RR, SS, TC, TX

<color=#FF8C00>**Example:**</color>  

Exception: NP (Not Performed)  
Reason: CI (Customer Not Accessible)  
Explanation: Could not perform intraplant due to customer blue flag  


---

### <color=#20B2AA>LC (Locomotives/EOT)</color>  

<color=#FF8C00>**Valid Exception Codes:**</color> SO, NI  

<color=#FF8C00>**Valid Reason Codes:**</color>  
- BO, CX, DW, EF, FL, IC, RR, TX

<color=#FF8C00>**Example:**</color>  

Exception: SO (Set Out Other)  
Reason: EF (Engine Failure)  
Explanation: Power set out due to mechanical failure  


---

### <color=#20B2AA>PK (Pick Up from Station)</color>  

<color=#FF8C00>**Valid Exception Codes:**</color> NP, NT  

<color=#FF8C00>**Valid Reason Codes:**</color>  
- BI, BO, CX, DR, DW, EF, FL, IL, NA, OT, RP, RQ, RR, SS, TC, TF, TN, TX

<color=#FF8C00>**Example:**</color>  

Exception: NP (Not Performed)  
Reason: NA (Not Available at Station)  
Explanation: Cars had not arrived at yard yet  


---

### <color=#20B2AA>PL (Place at Customer)</color>  

<color=#FF8C00>**Valid Exception Codes:**</color> PD, SO, NI, NP  

#### Using PD (Placed Different Track/Spot)
<color=#FF8C00>**Valid Reason Codes:**</color>  
- BD, CI, CX, DW, EF, FL, OB, RA, RN, RQ, RR, SS, TC, TX

<color=#FF8C00>**Example:**</color>  

Exception: PD (Placed Different)  
Reason: TF (Track Full)  
Explanation: Primary spot full, placed on alternate track  


#### Using SO (Set Out Other)
<color=#FF8C00>**Valid Reason Codes:**</color>  
- BD, BO, CI, CX, DW, EF, FL, IC, NO, OB, OT, PI, RA, RR, SS, TC, TX

<color=#FF8C00>**Example:**</color>  

Exception: SO (Set Out Other)  
Reason: OT (Out of Time)  
Explanation: Could not reach customer before hours of service, set out at yard  


#### Using NI (Not In)
<color=#FF8C00>**Valid Reason Codes:**</color>  
- BO, CX, DW, EF, FL, IC, OT, PI, RR, TX

#### Using NP (Not Performed)
<color=#FF8C00>**Valid Reason Codes:**</color>  
- AP, BD, BO, CI, CX, DW, EF, FL, HD, IL, LN, OB, OT, RA, RQ, RR, SS, TC, TN, TX

<color=#FF8C00>**Special Reject Codes (A-N):**</color>  
- A through N codes for specific reject reasons
- B1, B2, B3, B4 for braking issues

---

### <color=#20B2AA>PU (Pull from Customer)</color>  

<color=#FF8C00>**Valid Exception Codes:**</color> NP, NI, RD, RM, RO  

#### Using NP (Not Performed)
<color=#FF8C00>**Valid Reason Codes:**</color>  
- BD, BO, CI, CX, DW, EF, IL, LN, OB, OT, RA, RQ, RR, SS, TC, TX

<color=#FF8C00>**Example:**</color>  

Exception: NP (Not Performed)  
Reason: LN (Load/Unload Not Complete)  
Explanation: Customer still loading car, not ready for pickup  


#### Using NI (Not In Industry)
<color=#FF8C00>**Valid Reason Codes:**</color>  
- BD, CI, CX, DW, EF, OB, RA, RN, RQ, RR, SS, TC, TX

#### Using RD (Reject Dirty)
<color=#FF8C00>**Valid Reason Codes:**</color>  
- (Customer rejected car due to cleanliness)

#### Using RM (Reject Mechanical)
<color=#FF8C00>**Valid Reason Codes:**</color>  
- (Customer rejected car due to mechanical defect)

---

### <color=#20B2AA>SO (Set Out at Station)</color>  

<color=#FF8C00>**Valid Exception Codes:**</color> NP, PD  

<color=#FF8C00>**Valid Reason Codes:**</color>  
- BO, CX, DW, EF, FL, IC, OT, PI, RR, TX

<color=#FF8C00>**Example:**</color>  

Exception: NP (Not Performed)  
Reason: TX (Track Condition - Railroad)  
Explanation: Yard track out of service, could not set out  


---

### <color=#20B2AA>WI (Weigh In Industry)</color>  

<color=#FF8C00>**Valid Exception Codes:**</color> NP  

<color=#FF8C00>**Valid Reason Codes:**</color>  
- (Limited use, specific to weighing operations)

---

## <color=#FF8C00>How to Choose the Right Exception</color>  

### <color=#20B2AA>Step 1: Determine Exception Type</color>  
<color=#FF8C00>**Ask yourself:**</color> "What happened to the car?"  
- ✅ Work not done at all → **NP** (Not Performed)
- ✅ Car put somewhere else → **SO** (Set Out Other) or **PD** (Placed Different)
- ✅ Car not where expected → **NI** (Not In)
- ✅ Car rejected → **RD, RM, RO**

### <color=#20B2AA>Step 2: Determine Reason Category</color>  
<color=#FF8C00>**Ask yourself:**</color> "Whose responsibility is this?"  
- 🔴 Railroad's fault → Use **Railroad Reason** (counts as Miss)
- 🟢 Customer's fault → Use **Customer Reason** (no CSD impact)

### <color=#20B2AA>Step 3: Choose Specific Reason</color>  
Pick the **most accurate** reason from the valid options.  

---

## <color=#FF8C00>Common Exception Scenarios</color>  

### <color=#20B2AA>Scenario 1: Customer Track Full</color>  

Work Instruction: PL (Place at Customer)  
Exception Code: SO (Set Out Other)  
Reason Code: TF (Customer Track Full)  
Result: Left car at yard, customer reason, no CSD impact  


### <color=#20B2AA>Scenario 2: Out of Time</color>  

Work Instruction: PL (Place at Customer)  
Exception Code: SO (Set Out Other)  
Reason Code: OT (Out of Time)  
Result: Left car at yard, railroad reason, COUNTS AS MISS  


### <color=#20B2AA>Scenario 3: Customer Blue Flag Up</color>  

Work Instruction: PU (Pull from Customer)  
Exception Code: NP (Not Performed)  
Reason Code: BD (Customer Blue Flag/Derail)  
Result: Could not pull, customer reason, no CSD impact, may charge customer  


### <color=#20B2AA>Scenario 4: Bad Ordered Car</color>  

Work Instruction: PL (Place at Customer)  
Exception Code: SO (Set Out Other)  
Reason Code: BO (Bad Ordered)  
Result: Car mechanically defective, railroad reason, COUNTS AS MISS  


### <color=#20B2AA>Scenario 5: Placed on Alternate Track</color>  

Work Instruction: PL at Track 1  
Exception Code: PD (Placed Different Track/Spot)  
Reason Code: RA (Customer Request on Arrival)  
Result: Customer asked for different spot, customer reason, no CSD impact  


---

## <color=#FF8C00>Exception Best Practices</color>  

### <color=#20B2AA>✅ DO</color>  
- Choose the most accurate exception reason
- Use customer reasons when it's truly the customer's responsibility
- Document specific details in notes when available
- Input exceptions at time of occurrence

### <color=#20B2AA>❌ DON'T</color>  
- Default to one exception reason for everything
- Use railroad reasons when customer is responsible
- Guess at exception reasons
- Delay exception input until end of shift

---

## <color=#FF8C00>Special Notes</color>  

### <color=#20B2AA>Customer Charges</color>  
Some customer reason codes <color=#FF8C00>**may result in a charge to the customer:**</color>  
- BD (Customer Blue Flag/Derail)
- OB (Customer Obstruction)
- TC (Track Condition - Customer)

These still don't count against CSD, but the customer may be billed for delays they caused.  

### <color=#20B2AA>Changing End Points via Exception</color>  

You **CAN** change the destination of a car using exceptions:  

<color=#FF8C00>**To show a car DI exception as SO IC:**</color>  

Original: DI (Deliver Interchange)  
Exception: SO (Set Out Other)  
Reason: IC (Delivered Interchange)  
Result: Car set out at yard instead of interchange  


<color=#FF8C00>**To show a car PL exception as SO PI:**</color>  

Original: PL (Place at Customer)  
Exception: SO (Set Out Other)  
Reason: PI (Placed in Industry)  
Result: Car placed inside different customer facility  


---

## <color=#FF8C00>Quick Exception Reference</color>  

### <color=#20B2AA>Cannot Complete Customer Work</color>  

| Situation | Exception | Reason |  
|-----------|-----------|--------|  
| Track full (customer) | SO | TF |  
| Track full (railroad) | SO | RT |  
| Customer not ready | NP | LN |  
| Blue flag up | NP | BD |  
| Out of time | SO | OT |  
| Bad ordered car | SO | BO |  
| Customer request | NP | RQ |  
| Track condition | NP | TC or TX |  

### <color=#20B2AA>Car Not Where Expected</color>  

| Situation | Exception | Reason |  
|-----------|-----------|--------|  
| Not at station | NP | NA |  
| Not in industry | NI | RN |  
| Already moved | NI | PI |  

---

## <color=#FF8C00>Need Help?</color>  

If you're unsure which exception to use:  

📞 **Call MRT Helpdesk: 800-243-7743 option #4**  

Provide:  
- What you were trying to do
- What prevented you from doing it
- Whose responsibility the issue was

The helpdesk will guide you to the correct exception code and reason.  