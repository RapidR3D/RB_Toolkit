# Exception Codes & Reasons

## Overview

Exception codes communicate **why** planned work could not be completed. Choosing the correct exception reason is critical for:
- Accurate CSD (Customer Switch Data) scoring
- Proper customer billing
- Operational metrics
- Future planning

---

## Exception Code Categories

### Work Instruction Exception Codes

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

### Special Work Instructions

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

## Reason Code Categories

### Railroad Reason Codes ⚠️
**These COUNT AGAINST CSD as "Misses"**

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

### Customer Reason Codes ✅
**These DO NOT COUNT AGAINST CSD**

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

## Valid Exception Code + Reason Code Combinations

### DI (Deliver Interchange)

**Valid Exception Codes:** SO, NI

**Valid Reason Codes:**
- BO, IC, OT, PI, PR, RE, RP, RR, RT

**Example:**

Exception: SO (Set Out Other)
Reason: IC (Delivered Interchange)
Explanation: Car was delivered to interchange instead of customer


---

### IP (Intra Plant Switch)

**Valid Exception Codes:** NP

**Valid Reason Codes:**
- BD, BO, CI, CX, DW, EF, OB, OT, RA, RQ, RR, SS, TC, TX

**Example:**

Exception: NP (Not Performed)
Reason: CI (Customer Not Accessible)
Explanation: Could not perform intraplant due to customer blue flag


---

### LC (Locomotives/EOT)

**Valid Exception Codes:** SO, NI

**Valid Reason Codes:**
- BO, CX, DW, EF, FL, IC, RR, TX

**Example:**

Exception: SO (Set Out Other)
Reason: EF (Engine Failure)
Explanation: Power set out due to mechanical failure


---

### PK (Pick Up from Station)

**Valid Exception Codes:** NP, NT

**Valid Reason Codes:**
- BI, BO, CX, DR, DW, EF, FL, IL, NA, OT, RP, RQ, RR, SS, TC, TF, TN, TX

**Example:**

Exception: NP (Not Performed)
Reason: NA (Not Available at Station)
Explanation: Cars had not arrived at yard yet


---

### PL (Place at Customer)

**Valid Exception Codes:** PD, SO, NI, NP

#### Using PD (Placed Different Track/Spot)
**Valid Reason Codes:**
- BD, CI, CX, DW, EF, FL, OB, RA, RN, RQ, RR, SS, TC, TX

**Example:**

Exception: PD (Placed Different)
Reason: TF (Track Full)
Explanation: Primary spot full, placed on alternate track


#### Using SO (Set Out Other)
**Valid Reason Codes:**
- BD, BO, CI, CX, DW, EF, FL, IC, NO, OB, OT, PI, RA, RR, SS, TC, TX

**Example:**

Exception: SO (Set Out Other)
Reason: OT (Out of Time)
Explanation: Could not reach customer before hours of service, set out at yard


#### Using NI (Not In)
**Valid Reason Codes:**
- BO, CX, DW, EF, FL, IC, OT, PI, RR, TX

#### Using NP (Not Performed)
**Valid Reason Codes:**
- AP, BD, BO, CI, CX, DW, EF, FL, HD, IL, LN, OB, OT, RA, RQ, RR, SS, TC, TN, TX

**Special Reject Codes (A-N):**
- A through N codes for specific reject reasons
- B1, B2, B3, B4 for braking issues

---

### PU (Pull from Customer)

**Valid Exception Codes:** NP, NI, RD, RM, RO

#### Using NP (Not Performed)
**Valid Reason Codes:**
- BD, BO, CI, CX, DW, EF, IL, LN, OB, OT, RA, RQ, RR, SS, TC, TX

**Example:**

Exception: NP (Not Performed)
Reason: LN (Load/Unload Not Complete)
Explanation: Customer still loading car, not ready for pickup


#### Using NI (Not In Industry)
**Valid Reason Codes:**
- BD, CI, CX, DW, EF, OB, RA, RN, RQ, RR, SS, TC, TX

#### Using RD (Reject Dirty)
**Valid Reason Codes:**
- (Customer rejected car due to cleanliness)

#### Using RM (Reject Mechanical)
**Valid Reason Codes:**
- (Customer rejected car due to mechanical defect)

---

### SO (Set Out at Station)

**Valid Exception Codes:** NP, PD

**Valid Reason Codes:**
- BO, CX, DW, EF, FL, IC, OT, PI, RR, TX

**Example:**

Exception: NP (Not Performed)
Reason: TX (Track Condition - Railroad)
Explanation: Yard track out of service, could not set out


---

### WI (Weigh In Industry)

**Valid Exception Codes:** NP

**Valid Reason Codes:**
- (Limited use, specific to weighing operations)

---

## How to Choose the Right Exception

### Step 1: Determine Exception Type
**Ask yourself:** "What happened to the car?"
- ✅ Work not done at all → **NP** (Not Performed)
- ✅ Car put somewhere else → **SO** (Set Out Other) or **PD** (Placed Different)
- ✅ Car not where expected → **NI** (Not In)
- ✅ Car rejected → **RD, RM, RO**

### Step 2: Determine Reason Category
**Ask yourself:** "Whose responsibility is this?"
- 🔴 Railroad's fault → Use **Railroad Reason** (counts as Miss)
- 🟢 Customer's fault → Use **Customer Reason** (no CSD impact)

### Step 3: Choose Specific Reason
Pick the **most accurate** reason from the valid options.

---

## Common Exception Scenarios

### Scenario 1: Customer Track Full

Work Instruction: PL (Place at Customer)
Exception Code: SO (Set Out Other)
Reason Code: TF (Customer Track Full)
Result: Left car at yard, customer reason, no CSD impact


### Scenario 2: Out of Time

Work Instruction: PL (Place at Customer)
Exception Code: SO (Set Out Other)
Reason Code: OT (Out of Time)
Result: Left car at yard, railroad reason, COUNTS AS MISS


### Scenario 3: Customer Blue Flag Up

Work Instruction: PU (Pull from Customer)
Exception Code: NP (Not Performed)
Reason Code: BD (Customer Blue Flag/Derail)
Result: Could not pull, customer reason, no CSD impact, may charge customer


### Scenario 4: Bad Ordered Car

Work Instruction: PL (Place at Customer)
Exception Code: SO (Set Out Other)
Reason Code: BO (Bad Ordered)
Result: Car mechanically defective, railroad reason, COUNTS AS MISS


### Scenario 5: Placed on Alternate Track

Work Instruction: PL at Track 1
Exception Code: PD (Placed Different Track/Spot)
Reason Code: RA (Customer Request on Arrival)
Result: Customer asked for different spot, customer reason, no CSD impact


---

## Exception Best Practices

### ✅ DO
- Choose the most accurate exception reason
- Use customer reasons when it's truly the customer's responsibility
- Document specific details in notes when available
- Input exceptions at time of occurrence

### ❌ DON'T
- Default to one exception reason for everything
- Use railroad reasons when customer is responsible
- Guess at exception reasons
- Delay exception input until end of shift

---

## Special Notes

### Customer Charges
Some customer reason codes **may result in a charge to the customer:**
- BD (Customer Blue Flag/Derail)
- OB (Customer Obstruction)
- TC (Track Condition - Customer)

These still don't count against CSD, but the customer may be billed for delays they caused.

### Changing End Points via Exception

You **CAN** change the destination of a car using exceptions:

**To show a car DI exception as SO IC:**

Original: DI (Deliver Interchange)
Exception: SO (Set Out Other)
Reason: IC (Delivered Interchange)
Result: Car set out at yard instead of interchange


**To show a car PL exception as SO PI:**

Original: PL (Place at Customer)
Exception: SO (Set Out Other)
Reason: PI (Placed in Industry)
Result: Car placed inside different customer facility


---

## Quick Exception Reference

### Cannot Complete Customer Work

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

### Car Not Where Expected

| Situation | Exception | Reason |
|-----------|-----------|--------|
| Not at station | NP | NA |
| Not in industry | NI | RN |
| Already moved | NI | PI |

---

## Need Help?

If you're unsure which exception to use:

📞 **Call MRT Helpdesk: 800-243-7743 option #4**

Provide:
- What you were trying to do
- What prevented you from doing it
- Whose responsibility the issue was

The helpdesk will guide you to the correct exception code and reason.