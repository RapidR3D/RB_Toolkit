# Exception Codes and Reasons Reference Table

## Work Instruction Exception Codes

| Exception Code | Description | When to Use |
|----------------|-------------|-------------|
| **CD** | Conductor Distributable | Work delegated to conductor for distribution |
| **LD** | Placed on Lead | Car temporarily placed on lead track |
| **NI** | Not in Industry | Car not found at expected location/industry |
| **NP** | Not Performed | Work could not be completed |
| **OS** | Off Spot | Car moved from its assigned spot |
| **PD** | Placed Different Track/Spot | Car spotted at alternate location than instructed |
| **RD** | Reject Dirty | Car rejected by customer due to cleanliness issues |
| **RM** | Reject Mechanical | Car rejected due to mechanical defect |
| **RO** | Reject Other | Car rejected for other reasons |
| **SO** | Set Out Other than Instructed | Car left at different location than planned |

---

## Railroad Reason Codes (Count Against CSD)

| Reason Code | Description | CSD Impact | Common Use |
|-------------|-------------|------------|------------|
| **BI** | Bad Ordered - On Interchange Track | Miss | Car defective at interchange |
| **BO** | Bad Ordered | Miss | Car mechanically defective |
| **CX** | CSX Inability | Miss | Railroad operational issue |
| **DR** | Derailed Car | Miss | Car derailed |
| **DW** | Dispatcher/Windows | Miss | Dispatcher restrictions/timing windows |
| **EF** | Engine Failure | Miss | Locomotive mechanical failure |
| **FL** | Foreign Line | Miss | Issue with foreign railroad |
| **HD** | No Hazardous Doc/Placards | Miss | Missing hazmat documentation |
| **IC** | Delivered Interchange | Miss | Car delivered to interchange instead |
| **IL** | Improperly Loaded/Overloaded | Miss | Load not secured or overweight |
| **NA** | Not Available at Station | Miss | Car not arrived at yard yet |
| **NO** | Not Ordered | Miss | Car not on planned work |
| **OT** | Out of Time | Miss | Crew hours of service limitation |
| **PI** | Placed in Industry | Miss | Car placed at different customer |
| **PR** | Temporarily Placed Different Industry | Miss | Car staged at alternate customer |
| **RE** | Railroad Error | Miss | CSX made a mistake |
| **RN** | Railroad Reason - No Re-spot | Miss | Railroad issue, no respot needed |
| **RP** | Rail Partner Inability | Miss | Foreign railroad/partner issue |
| **RQ** | Customer Request | No Impact | Customer requested change |
| **RR** | Railroad Reason - Re-spot | Miss | Railroad issue requiring respot |
| **RT** | Track or Interchange Track Full | Miss | Railroad track at capacity |
| **SI** | Customer Scales Inoperative | Miss | Weighing equipment not working |
| **SP** | Swap Power/EOT's | Miss | Equipment exchange required |
| **SS** | Customer Siding Safety Issue | Miss | Safety concern on customer track |
| **TN** | Tonnage | Miss | Train exceeds weight limits |
| **TX** | Track Condition - Railroad | Miss | CSX track needs repair |

---

## Customer Reason Codes (Do NOT Count Against CSD)

| Reason Code | Description | CSD Impact | May Charge Customer |
|-------------|-------------|------------|---------------------|
| **AP** | Empty Appropriated for Loading | No Impact | No |
| **BD** | Customer Blue Flag/Derail | No Impact | Yes |
| **CD** | Reject Mechanical - Customer Damage | No Impact | Possible |
| **CI** | Customer Not Accessible | No Impact | Yes |
| **LN** | Load/Unload Not Complete | No Impact | No |
| **OB** | Customer Obstruction | No Impact | Yes |
| **RA** | Customer Request on Arrival | No Impact | No |
| **RQ** | Customer Request | No Impact | No |
| **TC** | Track Condition - Customer | No Impact | Yes |
| **TF** | Customer Track Full | No Impact | No |

---

## Valid Exception and Reason Code Combinations

### DI (Deliver Interchange)

**Valid Exception Codes:** SO, NI

**Valid Reason Codes:**
- BO (Bad Ordered)
- IC (Delivered Interchange)
- OT (Out of Time)
- PI (Placed in Industry)
- PR (Temporarily Placed Different Industry)
- RE (Railroad Error)
- RP (Rail Partner Inability)
- RR (Railroad Reason - Re-spot)
- RT (Track or Interchange Track Full)

---

### IP (Intra Plant Switch)

**Valid Exception Codes:** NP

**Valid Reason Codes:**
- BD (Customer Blue Flag/Derail)
- BO (Bad Ordered)
- CI (Customer Not Accessible)
- CX (CSX Inability)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- OB (Customer Obstruction)
- OT (Out of Time)
- RA (Customer Request on Arrival)
- RQ (Customer Request)
- RR (Railroad Reason - Re-spot)
- SS (Customer Siding Safety Issue)
- TC (Track Condition - Customer)
- TX (Track Condition - Railroad)

---

### LC (Locomotives and EOTS)

**Valid Exception Codes:** SO, NI

**Valid Reason Codes:**
- BO (Bad Ordered)
- CX (CSX Inability)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- FL (Foreign Line)
- IC (Delivered Interchange)
- RR (Railroad Reason - Re-spot)
- TX (Track Condition - Railroad)

---

### PK (Pick Up from Station)

**Valid Exception Codes:** NP, NT

**Valid Reason Codes:**
- BI (Bad Ordered - On Interchange Track)
- BO (Bad Ordered)
- CX (CSX Inability)
- DR (Derailed Car)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- FL (Foreign Line)
- IL (Improperly Loaded/Overloaded)
- NA (Not Available at Station)
- OT (Out of Time)
- RP (Rail Partner Inability)
- RQ (Customer Request)
- RR (Railroad Reason - Re-spot)
- SS (Customer Siding Safety Issue)
- TC (Track Condition - Customer)
- TF (Customer Track Full)
- TN (Tonnage)
- TX (Track Condition - Railroad)

---

### PL (Place at Customer)

**Valid Exception Codes:** PD, SO, NI, NP

#### Exception: PD (Placed Different Track/Spot)
**Valid Reason Codes:**
- BD (Customer Blue Flag/Derail)
- CI (Customer Not Accessible)
- CX (CSX Inability)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- FL (Foreign Line)
- OB (Customer Obstruction)
- RA (Customer Request on Arrival)
- RN (Railroad Reason - No Re-spot)
- RQ (Customer Request)
- RR (Railroad Reason - Re-spot)
- SS (Customer Siding Safety Issue)
- TC (Track Condition - Customer)
- TX (Track Condition - Railroad)

#### Exception: SO (Set Out Other than Instructed)
**Valid Reason Codes:**
- BD (Customer Blue Flag/Derail)
- BO (Bad Ordered)
- CI (Customer Not Accessible)
- CX (CSX Inability)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- FL (Foreign Line)
- IC (Delivered Interchange)
- NO (Not Ordered)
- OB (Customer Obstruction)
- OT (Out of Time)
- PI (Placed in Industry)
- RA (Customer Request on Arrival)
- RR (Railroad Reason - Re-spot)
- SS (Customer Siding Safety Issue)
- TC (Track Condition - Customer)
- TX (Track Condition - Railroad)

#### Exception: NI (Not In Industry)
**Valid Reason Codes:**
- BO (Bad Ordered)
- CX (CSX Inability)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- FL (Foreign Line)
- IC (Delivered Interchange)
- OT (Out of Time)
- PI (Placed in Industry)
- RR (Railroad Reason - Re-spot)
- TX (Track Condition - Railroad)

#### Exception: NP (Not Performed)
**Valid Reason Codes:**
- AP (Empty Appropriated for Loading)
- BD (Customer Blue Flag/Derail)
- BO (Bad Ordered)
- CD (Reject Mechanical - Customer Damage)
- CI (Customer Not Accessible)
- CX (CSX Inability)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- FL (Foreign Line)
- HD (No Hazardous Doc/Placards)
- IL (Improperly Loaded/Overloaded)
- LN (Load/Unload Not Complete)
- OB (Customer Obstruction)
- OT (Out of Time)
- RA (Customer Request on Arrival)
- RQ (Customer Request)
- RR (Railroad Reason - Re-spot)
- SS (Customer Siding Safety Issue)
- TC (Track Condition - Customer)
- TN (Tonnage)
- TX (Track Condition - Railroad)
- **Plus Reject Codes A through N**
- **Plus Brake Codes B1, B2, B3, B4**

---

### PU (Pull from Customer)

**Valid Exception Codes:** NP, NI, RD, RM, RO

#### Exception: NP (Not Performed)
**Valid Reason Codes:**
- BD (Customer Blue Flag/Derail)
- BO (Bad Ordered)
- CI (Customer Not Accessible)
- CX (CSX Inability)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- IL (Improperly Loaded/Overloaded)
- LN (Load/Unload Not Complete)
- OB (Customer Obstruction)
- OT (Out of Time)
- RA (Customer Request on Arrival)
- RQ (Customer Request)
- RR (Railroad Reason - Re-spot)
- SS (Customer Siding Safety Issue)
- TC (Track Condition - Customer)
- TX (Track Condition - Railroad)

#### Exception: NI (Not In Industry)
**Valid Reason Codes:**
- BD (Customer Blue Flag/Derail)
- CI (Customer Not Accessible)
- CX (CSX Inability)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- OB (Customer Obstruction)
- RA (Customer Request on Arrival)
- RN (Railroad Reason - No Re-spot)
- RQ (Customer Request)
- RR (Railroad Reason - Re-spot)
- SS (Customer Siding Safety Issue)
- TC (Track Condition - Customer)
- TX (Track Condition - Railroad)

#### Exception: RD (Reject Dirty)
Customer rejected car due to cleanliness issues

#### Exception: RM (Reject Mechanical)
Customer rejected car due to mechanical defect

#### Exception: RO (Reject Other)
Customer rejected car for other reasons

---

### SO (Set Out at Station)

**Valid Exception Codes:** NP, PD

**Valid Reason Codes:**
- BO (Bad Ordered)
- CX (CSX Inability)
- DW (Dispatcher/Windows)
- EF (Engine Failure)
- FL (Foreign Line)
- IC (Delivered Interchange)
- OT (Out of Time)
- PI (Placed in Industry)
- RR (Railroad Reason - Re-spot)
- TX (Track Condition - Railroad)

---

### WI (Weigh On Industry Scales)

**Valid Exception Codes:** NP

**Valid Reason Codes:** Limited use, specific to weighing operations

---

## Quick Exception Selection Guide

### Customer Track Full
Work Instruction: PL (Place at Customer)
Exception: SO (Set Out Other)
Reason: TF (Customer Track Full)
CSD Impact: No Miss (Customer reason)

### Out of Time
Work Instruction: PL (Place at Customer)
Exception: SO (Set Out Other)
Reason: OT (Out of Time)
CSD Impact: Miss (Railroad reason)

### Blue Flag Up
Work Instruction: PU (Pull from Customer)
Exception: NP (Not Performed)
Reason: BD (Customer Blue Flag/Derail)
CSD Impact: No Miss (Customer reason, may charge customer)

### Bad Ordered Car
Work Instruction: PL (Place at Customer)
Exception: SO (Set Out Other)
Reason: BO (Bad Ordered)
CSD Impact: Miss (Railroad reason)

### Customer Request Different Spot
Work Instruction: PL at Track 1
Exception: PD (Placed Different Track/Spot)
Reason: RA (Customer Request on Arrival)
CSD Impact: No Miss (Customer reason)

### Car Not Available
Work Instruction: PK (Pickup from Station)
Exception: NP (Not Performed)
Reason: NA (Not Available at Station)
CSD Impact: Miss (Railroad reason)

---

## Notes

- **Railroad Reasons** count against CSD as "Misses"
- **Customer Reasons** do not impact CSD scoring
- Some **Customer Reasons** may result in charges to the customer
- Always choose the **most accurate** exception reason
- When in doubt, call **MRT Helpdesk: 800-243-7743 option #4**