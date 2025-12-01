# Work Instructions & Terminology

## Understanding Begin Point and End Point

### Core Concept
Every railcar movement has **TWO linked instructions:**

```
Begin Point (FROM) ──────> End Point (TO)
Where you GET the car    Where you LEAVE the car
```

### Begin Point = From Instruction
- **Where you got the car from**
- Couple up to it
- Add it to the train
- Origin of movement

### End Point = To Instruction
- **Where you take the car to**
- Uncouple from it
- Leave it at destination
- Final location

---

## Two-Letter Abbreviation System

All work is reported using 2-letter codes for the type of work performed.

### ⚠️ Critical Rule for Add Work
When inputting Add Work on MRT, you **MUST** input BOTH:
1. **FROM instruction** (where you got the car)
2. **TO instruction** (where you expect to leave it)

---

## CSX Station Work (Yards/Terminals)

### PK - Pickup
**Definition:** Add car to train to depart with from station
**Use When:** Taking cars from yard to move elsewhere
**Example:** PK from AY 856 (Winston FL yard)

```
FROM: PK (Pickup from Station)
TO: Various (SO, PL, DI)
```

### SO - Set Out
**Definition:** Leave car at station
**Use When:** Dropping cars in yard for others to handle
**Example:** SO to SX 820 (Auburndale FL yard)

```
FROM: Various (PK, PU, DI)
TO: SO (Set Out at Station)
```

### LC - Locomotives & EOT
**Definition:** Pickup equipment (Locomotives and EOTS)
**Use When:** Adding power or end-of-train devices
**Special:** Shows in separate destination tile of Work Order

```
FROM: LC (Pickup Loco/EOT)
TO: LC (Drop Loco/EOT)
```

---

## Customer Work (Industry)

### PU - Pull
**Definition:** Remove car from customer industry, take it out
**Use When:** Picking up cars from inside customer facility
**Example:** PU from SX 820 9726 (Commercial Warehouse)

```
FROM: PU (Pull from Customer)
TO: SO, PL (to another customer), DI
```

### PL - Place
**Definition:** Spot car into customer industry
**Use When:** Delivering cars to customer's track/spot
**Example:** PL at SX 820 9731 (Quality Liquid Feeds)

```
FROM: PK, PU, DI
TO: PL (Place at Customer)
```

### IP - Intraplant Switch
**Definition:** Move previously placed cars within customer facility
**Use When:** Rearranging cars inside customer's tracks
**Special:** Car stays within customer, doesn't leave facility

```
FROM: IP (Intra Plant Switch)
TO: IP (stays at same customer)
```

---

## Interchange Work

### DI - Deliver Interchange
**Definition:** Take cars from CSX to another railroad's designated track
**Use When:** Handing off cars to foreign railroads/shortlines
**Example:** DI to Norfolk Southern at interchange point

```
FROM: PK, PU
TO: DI (Deliver Interchange)
```

### PK - Pickup Interchange
**Definition:** Receive cars from another railroad's track to bring online to CSX
**Use When:** Taking cars from foreign railroad into CSX system
**Example:** PK from Canadian National interchange

```
FROM: PK (Pickup from Interchange)
TO: SO, PL, DI
```

---

## Common Work Instruction Combinations

### Moving Cars Between Stations
```
FROM: PK (Pickup from Station A)
TO: SO (Set Out at Station B)
```

### Serving a Customer
```
FROM: PK (Pickup from Yard)
TO: PL (Place at Customer)
```

### Pulling from Customer to Yard
```
FROM: PU (Pull from Customer)
TO: SO (Set Out at Yard)
```

### Customer-to-Customer Move
```
FROM: PU (Pull from Customer A)
TO: PL (Place at Customer B)
```

### Interchange Delivery
```
FROM: PK (Pickup from Yard)
TO: DI (Deliver to Foreign Railroad)
```

### Receiving Interchange
```
FROM: PK (Pickup from Foreign Railroad)
TO: SO (Set Out at Yard) or PL (Place at Customer)
```

---

## Critical Distinctions

### Station vs. Customer
| Aspect | Station (PK/SO) | Customer (PU/PL) |
|--------|----------------|------------------|
| Location | CSX yard/terminal | Industry/private track |
| Inventory | CSX-controlled | Customer-controlled |
| Billing | No customer charge | Customer billed |
| CSD Impact | No | Yes |

### ⚠️ Common Mistake
**WRONG:** Using PK (Pickup) when pulling from customer
**RIGHT:** Use PU (Pull) when at customer industry

**WRONG:** Using SO (Set Out) when placing at customer
**RIGHT:** Use PL (Place) when spotting for customer

---

## Reporting Accuracy Requirements

### Why It Matters
Accurate work instruction reporting affects:

1. **Car Cycles**
   - Tracks car movement through network
   - Predicts arrival times

2. **Plant Switches**
   - Opens/closes customer work windows
   - Triggers next planned work

3. **Inventory Management**
   - Adds/removes cars from customer counts
   - Updates yard inventory

4. **Customer Billing**
   - Places and pulls generate charges
   - Incorrect reporting = billing errors

### Current Problem
🚨 **We are not getting all customer place and pull events reported!**

**Solution:** Know the difference!
- **Pickup from Station** ≠ **Pull from Customer**
- **Set Out at Station** ≠ **Place at Customer**

---

## Load/Empty Status

### Status Codes

#### Loads
| Code | Definition | When to Use |
|------|-----------|-------------|
| L | Loaded | Standard loaded car |
| M | Company Material | CSX-owned loads |
| N | Nobill | Loaded car with no billing |

#### Empties
| Code | Definition | When to Use |
|------|-----------|-------------|
| E | Empty | Standard empty car |
| F | Revenue Empty | Empty generating revenue |

---

## Load/Empty Rules in MRT

### What You Can Input
- ✅ **L** (Loaded)
- ✅ **E** (Empty)

### What You'll See (But Cannot Input)
- M, N, F (displayed but not selectable)

### When to Change Status
✅ **Change when:**
- Empty car becomes loaded
- Loaded car becomes empty
- Actual status differs from system

❌ **Leave "as is" when:**
- Status is already correct
- Shows M, N, or F (unless actual status changed)

---

## Special Directive: NOBILLS

### ⚠️ Company Directive
**LEAVE NOBILLS AT THE CUSTOMER UNTIL THEY ARE BILLED!**

### Rules for Nobill Cars (N status)
1. **Loaded PULLS must:**
   - Be on your work order already, OR
   - Come through MRT New Work
   - ❌ **DO NOT** Add Work them manually

2. **Empty pulls from customer:**
   - ✅ OK to Add Work these

3. **You may need to:**
   - Change L/E status if car status changed
   - Wait for billing before pulling loaded nobills

---

## Quick Reference: When to Use Each Code

### I'm at a CSX Yard
- Taking cars with me → **PK** (Pickup)
- Leaving cars here → **SO** (Set Out)
- Adding locomotives/EOT → **LC**

### I'm at a Customer
- Removing cars → **PU** (Pull)
- Spotting cars → **PL** (Place)
- Moving cars within facility → **IP** (Intraplant)

### I'm at an Interchange
- Giving cars to another railroad → **DI** (Deliver)
- Receiving cars from another railroad → **PK** (Pickup)

---

## Helpdesk Reminder

**Cannot input work on MRT?**

📞 **Call 800-243-7743 option #4** to report work you cannot input in the application.

**What to report:**
- Car initials and numbers
- Work instruction (PU, PL, etc.)
- Location/customer
- Time work was performed
- Reason you couldn't input it

The helpdesk will manually enter the work to ensure accurate reporting.