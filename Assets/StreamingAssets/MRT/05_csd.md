# Customer Switch Data (CSD)

## Overview

Customer Switch Data (CSD) measures CSX's ability to complete planned customer work within defined service windows. This metric directly impacts customer satisfaction and CSX's service reliability.

---

## CSD Measurement Formula

```
              Completed Work (Makes)
CSD Score = ─────────────────────────────────
            Makes + Misses (Not Completed)
```

---

## Two Factors That Determine CSD Score

### Makes ✅
Place, pull, in-plant, and interchange delivery work on the snapshot that is:
- **Reported** in MRT
- **Completed** within the defined customer service window
- **Accurate** in time and location

### Misses ❌
Place, pull, in-plant, and interchange delivery work on the snapshot that:
- Is **NOT completed** within the defined customer service window
- Is **NOT completed** due to a Railroad Reason exception
- Has **incorrect or missing** reporting

---

## Two Kinds of Exceptions

### 1. Service Exception
**Definition:** Cars were NOT put on the work order, regardless of whether YES or MRT was used to create the work order.

**Types:**

#### Full Service Exception
- **None** of the planned cars were put on the work order
- Example: Customer had 5 planned places, crew applied 0

#### Partial Service Exception
- **Some** of the planned cars were put on the work order
- Example: Customer had 5 planned places, crew applied 3

**When to Use:**
- During SPT build when you cannot take planned cars
- Before departing origin

---

### 2. Work Order Exception
**Definition:** Car was applied during work order build but could not be completed by the crew using MRT.

**Characteristics:**
- Car **WAS** on the work order
- Crew attempted to perform work
- Work could not be completed for a specific reason

**When to Use:**
- During work order completion
- At the customer location
- When encountering obstacles to completing planned work

---

## CSD Exception Reasons

### Railroad Reason Exceptions
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

### Customer Reason Exceptions
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

## How to Improve CSD Score

### Before Departure (SPT)
1. ✅ **Apply ALL cars** you can realistically handle
2. ✅ **Input Service Exceptions** for cars you cannot take
3. ✅ **Use correct exception reasons** (Railroad vs Customer)
4. ✅ **Verify equipment** (locomotives, EOT) is correct

### During Work (MRT)
1. ✅ **Report work accurately** with correct times
2. ✅ **Complete planned work** within service windows
3. ✅ **Exception cars properly** when work cannot be performed
4. ✅ **Choose the right exception reason** (Railroad vs Customer)

### After Work (MRT)
1. ✅ **Complete ALL tiles** to 100%
2. ✅ **Logout properly** so data posts down
3. ✅ **Verify all work reported** before logging out

---

## Common CSD Mistakes to Avoid

### ❌ Mistake #1: Not Applying Planned Cars
**Problem:** Crew skips cars in SPT without inputting Service Exception
**Impact:** Full or Partial Service Exception = Miss
**Solution:** Always input Service Exceptions for cars you're not taking

### ❌ Mistake #2: Wrong Exception Reason
**Problem:** Using Railroad Reason when it's actually Customer Reason
**Impact:** Creates unnecessary Miss on CSD score
**Solution:** Choose the most accurate exception reason

### ❌ Mistake #3: Delayed Reporting
**Problem:** Reporting work hours after it was completed
**Impact:** May show as "late" or outside service window
**Solution:** Report work as real-time as possible

### ❌ Mistake #4: Not Logging Out
**Problem:** Work order never posts down to system
**Impact:** All work shows as incomplete = Multiple Misses
**Solution:** Always tap Menu → Logout when work is complete

### ❌ Mistake #5: Incorrect Work Instructions
**Problem:** Using PK (Pickup) instead of PU (Pull) from customer
**Impact:** Wrong inventory tracking, customer billing errors
**Solution:** Learn the difference between Station work and Customer work

---

## CSD Best Practices

### Planning Phase
- Review SPT carefully before building work order
- Verify customer capacities and available spots
- Communicate with Yardmaster about any concerns
- Input EACs (Estimated Arrival to Customer) accurately

### Execution Phase
- Follow the SPT plan as closely as possible
- Report work in real-time, not batch reporting
- Use correct timestamps (backdate when necessary)
- Handle AEI reads promptly

### Completion Phase
- Verify all tiles show 100% Complete
- Review notification bell for any missed alerts
- Logout properly from work order
- Check that pending data posts down

---

## Understanding the SPT Report

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

## CSD and YOU

### Why It Matters
- 🎯 Affects customer satisfaction and retention
- 📊 Impacts CSX's service reliability metrics
- 💰 Influences customer billing and contracts
- 🚂 Determines operational efficiency

### Your Role
As a T&E employee, you are the **final step** in the CSD process. Accurate and timely reporting in MRT ensures:
- Customers receive expected service
- CSX maintains high service scores
- Operations run smoothly
- Everyone's job is easier

**Remember:** The system is only as good as the data we put into it!