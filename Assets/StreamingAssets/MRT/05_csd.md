# <color=#FFD700>Customer Switch Data (CSD)</color>  

## <color=#FF8C00>Overview</color>  

Customer Switch Data (CSD) measures CSX's ability to complete planned customer work within defined service windows. This metric directly impacts customer satisfaction and CSX's service reliability.  

---

## <color=#FF8C00>CSD Measurement Formula</color>  

```  
              Completed Work (Makes)  
CSD Score = ─────────────────────────────────  
            Makes + Misses (Not Completed)  
```  

---

## <color=#FF8C00>Two Factors That Determine CSD Score</color>  

### <color=#20B2AA>Makes ✅</color>  
Place, pull, in-plant, and interchange delivery work on the snapshot that is:  
- **Reported** in MRT
- **Completed** within the defined customer service window
- **Accurate** in time and location

### <color=#20B2AA>Misses ❌</color>  
Place, pull, in-plant, and interchange delivery work on the snapshot that:  
- Is **NOT completed** within the defined customer service window
- Is **NOT completed** due to a Railroad Reason exception
- Has **incorrect or missing** reporting

---

## <color=#FF8C00>Two Kinds of Exceptions</color>  

### <color=#20B2AA>1. Service Exception</color>  
<color=#FF8C00>**Definition:**</color> Cars were NOT put on the work order, regardless of whether YES or MRT was used to create the work order.  

<color=#FF8C00>**Types:**</color>  

#### Full Service Exception
- **None** of the planned cars were put on the work order
- Example: Customer had 5 planned places, crew applied 0

#### Partial Service Exception
- **Some** of the planned cars were put on the work order
- Example: Customer had 5 planned places, crew applied 3

<color=#FF8C00>**When to Use:**</color>  
- During SPT build when you cannot take planned cars
- Before departing origin

---

### <color=#20B2AA>2. Work Order Exception</color>  
<color=#FF8C00>**Definition:**</color> Car was applied during work order build but could not be completed by the crew using MRT.  

<color=#FF8C00>**Characteristics:**</color>  
- Car **WAS** on the work order
- Crew attempted to perform work
- Work could not be completed for a specific reason

<color=#FF8C00>**When to Use:**</color>  
- During work order completion
- At the customer location
- When encountering obstacles to completing planned work

---

## <color=#FF8C00>CSD Exception Reasons</color>  

### <color=#20B2AA>Railroad Reason Exceptions</color>  
These **count against** CSD score as "Misses":  

| Code | Description | Impact |  
|------|-------------|--------|  
| BO | Bad Ordered | Miss |  
| CX | CSX Inability | Miss |  
| DW | Dispatcher/Windows | Miss |  
| EF | Engine Failure | Miss |  
| TX | Track Condition - Railroad | Miss |  
| OT | Out of Time | Miss |  
| TN | Tonnage | Miss |  
| IC | Delivered Interchange | Miss |  
| RR | Railroad Reason - Re-spot | Miss |  

### <color=#20B2AA>Customer Reason Exceptions</color>  
These **do NOT count against** CSD score:  

| Code | Description | Impact |  
|------|-------------|--------|  
| BD | Customer Blue Flag/Derail | No Impact |  
| CI | Customer Not Accessible | No Impact |  
| OB | Customer Obstruction | No Impact |  
| TC | Track Condition - Customer | No Impact |  
| TF | Customer Track Full | No Impact |  
| RQ | Customer Request | No Impact |  
| LN | Load/Unload Not Complete | No Impact |  

---

## <color=#FF8C00>How to Improve CSD Score</color>  

### <color=#20B2AA>Before Departure (SPT)</color>  
1. ✅ **Apply ALL cars** you can realistically handle  
2. ✅ **Input Service Exceptions** for cars you cannot take  
3. ✅ **Use correct exception reasons** (Railroad vs Customer)  
4. ✅ **Verify equipment** (locomotives, EOT) is correct  

### <color=#20B2AA>During Work (MRT)</color>  
1. ✅ **Report work accurately** with correct times  
2. ✅ **Complete planned work** within service windows  
3. ✅ **Exception cars properly** when work cannot be performed  
4. ✅ **Choose the right exception reason** (Railroad vs Customer)  

### <color=#20B2AA>After Work (MRT)</color>  
1. ✅ **Complete ALL tiles** to 100%  
2. ✅ **Logout properly** so data posts down  
3. ✅ **Verify all work reported** before logging out  

---

## <color=#FF8C00>Common CSD Mistakes to Avoid</color>  

### <color=#20B2AA>❌ Mistake #1: Not Applying Planned Cars</color>  
<color=#FF8C00>**Problem:**</color> Crew skips cars in SPT without inputting Service Exception  
<color=#FF8C00>**Impact:**</color> Full or Partial Service Exception = Miss  
<color=#FF8C00>**Solution:**</color> Always input Service Exceptions for cars you're not taking  

### <color=#20B2AA>❌ Mistake #2: Wrong Exception Reason</color>  
<color=#FF8C00>**Problem:**</color> Using Railroad Reason when it's actually Customer Reason  
<color=#FF8C00>**Impact:**</color> Creates unnecessary Miss on CSD score  
<color=#FF8C00>**Solution:**</color> Choose the most accurate exception reason  

### <color=#20B2AA>❌ Mistake #3: Delayed Reporting</color>  
<color=#FF8C00>**Problem:**</color> Reporting work hours after it was completed  
<color=#FF8C00>**Impact:**</color> May show as "late" or outside service window  
<color=#FF8C00>**Solution:**</color> Report work as real-time as possible  

### <color=#20B2AA>❌ Mistake #4: Not Logging Out</color>  
<color=#FF8C00>**Problem:**</color> Work order never posts down to system  
<color=#FF8C00>**Impact:**</color> All work shows as incomplete = Multiple Misses  
<color=#FF8C00>**Solution:**</color> Always tap Menu → Logout when work is complete  

### <color=#20B2AA>❌ Mistake #5: Incorrect Work Instructions</color>  
<color=#FF8C00>**Problem:**</color> Using PK (Pickup) instead of PU (Pull) from customer  
<color=#FF8C00>**Impact:**</color> Wrong inventory tracking, customer billing errors  
<color=#FF8C00>**Solution:**</color> Learn the difference between Station work and Customer work  

---

## <color=#FF8C00>CSD Best Practices</color>  

### <color=#20B2AA>Planning Phase</color>  
- Review SPT carefully before building work order
- Verify customer capacities and available spots
- Communicate with Yardmaster about any concerns
- Input EACs (Estimated Arrival to Customer) accurately

### <color=#20B2AA>Execution Phase</color>  
- Follow the SPT plan as closely as possible
- Report work in real-time, not batch reporting
- Use correct timestamps (backdate when necessary)
- Handle AEI reads promptly

### <color=#20B2AA>Completion Phase</color>  
- Verify all tiles show 100% Complete
- Review notification bell for any missed alerts
- Logout properly from work order
- Check that pending data posts down

---

## <color=#FF8C00>Understanding the SPT Report</color>  

The Switch Planning Tool report (printout) shows:  

| Section | Information | Purpose |  
|---------|-------------|---------|  
| Train ID | Your train identifier | Reference |  
| Origin/Milepost | Starting location | Navigation |  
| Customer Capacity | Max cars customer can hold | Planning |  
| Available Capacity | Open spots at customer | Planning |  
| Planned Places | Cars to spot | Work list |  
| Planned Pulls | Cars to remove | Work list |  
| Track/Spot | Location in yard | Finding cars |  

---

## <color=#FF8C00>CSD and YOU</color>  

### <color=#20B2AA>Why It Matters</color>  
- 🎯 Affects customer satisfaction and retention
- 📊 Impacts CSX's service reliability metrics
- 💰 Influences customer billing and contracts
- 🚂 Determines operational efficiency

### <color=#20B2AA>Your Role</color>  
As a T&E employee, you are the **final step** in the CSD process. Accurate and timely reporting in MRT ensures:  
- Customers receive expected service
- CSX maintains high service scores
- Operations run smoothly
- Everyone's job is easier

<color=#FF8C00>**Remember:**</color> The system is only as good as the data we put into it!  