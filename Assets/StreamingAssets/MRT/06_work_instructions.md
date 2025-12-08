# <color=#FFD700>Work Instructions & Terminology</color>  

## <color=#FF8C00>Understanding Begin Point and End Point</color>  

### <color=#20B2AA>Core Concept</color>  
Every railcar movement has <color=#FF8C00>**TWO linked instructions:**</color>  

```  
Begin Point (FROM) ──────> End Point (TO)  
Where you GET the car    Where you LEAVE the car  
```  

### <color=#20B2AA>Begin Point = From Instruction</color>  
- **Where you got the car from**
- Couple up to it
- Add it to the train
- Origin of movement

### <color=#20B2AA>End Point = To Instruction</color>  
- **Where you take the car to**
- Uncouple from it
- Leave it at destination
- Final location

---

## <color=#FF8C00>Two-Letter Abbreviation System</color>  

All work is reported using 2-letter codes for the type of work performed.  

### <color=#20B2AA>⚠️ Critical Rule for Add Work</color>  
When inputting Add Work on MRT, you **MUST** input BOTH:  
1. **FROM instruction** (where you got the car)  
2. **TO instruction** (where you expect to leave it)  

---

## <color=#FF8C00>CSX Station Work (Yards/Terminals)</color>  

### <color=#20B2AA>PK - Pickup</color>  
<color=#FF8C00>**Definition:**</color> Add car to train to depart with from station  
<color=#FF8C00>**Use When:**</color> Taking cars from yard to move elsewhere  
<color=#FF8C00>**Example:**</color> PK from AY 856 (Winston FL yard)  

```  
FROM: PK (Pickup from Station)  
TO: Various (SO, PL, DI)  
```  

### <color=#20B2AA>SO - Set Out</color>  
<color=#FF8C00>**Definition:**</color> Leave car at station  
<color=#FF8C00>**Use When:**</color> Dropping cars in yard for others to handle  
<color=#FF8C00>**Example:**</color> SO to SX 820 (Auburndale FL yard)  

```  
FROM: Various (PK, PU, DI)  
TO: SO (Set Out at Station)  
```  

### <color=#20B2AA>LC - Locomotives & EOT</color>  
<color=#FF8C00>**Definition:**</color> Pickup equipment (Locomotives and EOTS)  
<color=#FF8C00>**Use When:**</color> Adding power or end-of-train devices  
<color=#FF8C00>**Special:**</color> Shows in separate destination tile of Work Order  

```  
FROM: LC (Pickup Loco/EOT)  
TO: LC (Drop Loco/EOT)  
```  

---

## <color=#FF8C00>Customer Work (Industry)</color>  

### <color=#20B2AA>PU - Pull</color>  
<color=#FF8C00>**Definition:**</color> Remove car from customer industry, take it out  
<color=#FF8C00>**Use When:**</color> Picking up cars from inside customer facility  
<color=#FF8C00>**Example:**</color> PU from SX 820 9726 (Commercial Warehouse)  

```  
FROM: PU (Pull from Customer)  
TO: SO, PL (to another customer), DI  
```  

### <color=#20B2AA>PL - Place</color>  
<color=#FF8C00>**Definition:**</color> Spot car into customer industry  
<color=#FF8C00>**Use When:**</color> Delivering cars to customer's track/spot  
<color=#FF8C00>**Example:**</color> PL at SX 820 9731 (Quality Liquid Feeds)  

```  
FROM: PK, PU, DI  
TO: PL (Place at Customer)  
```  

### <color=#20B2AA>IP - Intraplant Switch</color>  
<color=#FF8C00>**Definition:**</color> Move previously placed cars within customer facility  
<color=#FF8C00>**Use When:**</color> Rearranging cars inside customer's tracks  
<color=#FF8C00>**Special:**</color> Car stays within customer, doesn't leave facility  

```  
FROM: IP (Intra Plant Switch)  
TO: IP (stays at same customer)  
```  

---

## <color=#FF8C00>Interchange Work</color>  

### <color=#20B2AA>DI - Deliver Interchange</color>  
<color=#FF8C00>**Definition:**</color> Take cars from CSX to another railroad's designated track  
<color=#FF8C00>**Use When:**</color> Handing off cars to foreign railroads/shortlines  
<color=#FF8C00>**Example:**</color> DI to Norfolk Southern at interchange point  

```  
FROM: PK, PU  
TO: DI (Deliver Interchange)  
```  

### <color=#20B2AA>PK - Pickup Interchange</color>  
<color=#FF8C00>**Definition:**</color> Receive cars from another railroad's track to bring online to CSX  
<color=#FF8C00>**Use When:**</color> Taking cars from foreign railroad into CSX system  
<color=#FF8C00>**Example:**</color> PK from Canadian National interchange  

```  
FROM: PK (Pickup from Interchange)  
TO: SO, PL, DI  
```  

---

## <color=#FF8C00>Common Work Instruction Combinations</color>  

### <color=#20B2AA>Moving Cars Between Stations</color>  
```  
FROM: PK (Pickup from Station A)  
TO: SO (Set Out at Station B)  
```  

### <color=#20B2AA>Serving a Customer</color>  
```  
FROM: PK (Pickup from Yard)  
TO: PL (Place at Customer)  
```  

### <color=#20B2AA>Pulling from Customer to Yard</color>  
```  
FROM: PU (Pull from Customer)  
TO: SO (Set Out at Yard)  
```  

### <color=#20B2AA>Customer-to-Customer Move</color>  
```  
FROM: PU (Pull from Customer A)  
TO: PL (Place at Customer B)  
```  

### <color=#20B2AA>Interchange Delivery</color>  
```  
FROM: PK (Pickup from Yard)  
TO: DI (Deliver to Foreign Railroad)  
```  

### <color=#20B2AA>Receiving Interchange</color>  
```  
FROM: PK (Pickup from Foreign Railroad)  
TO: SO (Set Out at Yard) or PL (Place at Customer)  
```  

---

## <color=#FF8C00>Critical Distinctions</color>  

### <color=#20B2AA>Station vs. Customer</color>  
| Aspect | Station (PK/SO) | Customer (PU/PL) |  
|--------|----------------|------------------|  
| Location | CSX yard/terminal | Industry/private track |  
| Inventory | CSX-controlled | Customer-controlled |  
| Billing | No customer charge | Customer billed |  
| CSD Impact | No | Yes |  

### <color=#20B2AA>⚠️ Common Mistake</color>  
<color=#FF8C00>**WRONG:**</color> Using PK (Pickup) when pulling from customer  
<color=#FF8C00>**RIGHT:**</color> Use PU (Pull) when at customer industry  

<color=#FF8C00>**WRONG:**</color> Using SO (Set Out) when placing at customer  
<color=#FF8C00>**RIGHT:**</color> Use PL (Place) when spotting for customer  

---

## <color=#FF8C00>Reporting Accuracy Requirements</color>  

### <color=#20B2AA>Why It Matters</color>  
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

### <color=#20B2AA>Current Problem</color>  
🚨 **We are not getting all customer place and pull events reported!**  

<color=#FF8C00>**Solution:**</color> Know the difference!  
- **Pickup from Station** ≠ **Pull from Customer**
- **Set Out at Station** ≠ **Place at Customer**

---

## <color=#FF8C00>Load/Empty Status</color>  

### <color=#20B2AA>Status Codes</color>  

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

## <color=#FF8C00>Load/Empty Rules in MRT</color>  

### <color=#20B2AA>What You Can Input</color>  
- ✅ **L** (Loaded)
- ✅ **E** (Empty)

### <color=#20B2AA>What You'll See (But Cannot Input)</color>  
- M, N, F (displayed but not selectable)

### <color=#20B2AA>When to Change Status</color>  
✅ <color=#FF8C00>**Change when:**</color>  
- Empty car becomes loaded
- Loaded car becomes empty
- Actual status differs from system

❌ <color=#FF8C00>**Leave "as is" when:**</color>  
- Status is already correct
- Shows M, N, or F (unless actual status changed)

---

## <color=#FF8C00>Special Directive: NOBILLS</color>  

### <color=#20B2AA>⚠️ Company Directive</color>  
<color=#FF8C00>**LEAVE NOBILLS AT THE CUSTOMER UNTIL THEY ARE BILLED!**</color>  
### <color=#20B2AA>Rules for Nobill Cars (N status)</color>  
1. <color=#FF8C00>**Loaded PULLS must:**</color>  
   - Be on your work order already, OR
   - Come through MRT New Work
   - ❌ **DO NOT** Add Work them manually

2. <color=#FF8C00>**Empty pulls from customer:**</color>  
   - ✅ OK to Add Work these

3. <color=#FF8C00>**You may need to:**</color>  
   - Change L/E status if car status changed
   - Wait for billing before pulling loaded nobills

---

## <color=#FF8C00>Quick Reference: When to Use Each Code</color>  

### <color=#20B2AA>I'm at a CSX Yard</color>  
- Taking cars with me → **PK** (Pickup)
- Leaving cars here → **SO** (Set Out)
- Adding locomotives/EOT → **LC**

### <color=#20B2AA>I'm at a Customer</color>  
- Removing cars → **PU** (Pull)
- Spotting cars → **PL** (Place)
- Moving cars within facility → **IP** (Intraplant)

### <color=#20B2AA>I'm at an Interchange</color>  
- Giving cars to another railroad → **DI** (Deliver)
- Receiving cars from another railroad → **PK** (Pickup)

---

## <color=#FF8C00>Helpdesk Reminder</color>  
<color=#FF8C00>**Cannot input work on MRT?**</color>  
📞 **Call 800-243-7743 option #4** to report work you cannot input in the application.  

<color=#FF8C00>**What to report:**</color>  
- Car initials and numbers
- Work instruction (PU, PL, etc.)
- Location/customer
- Time work was performed
- Reason you couldn't input it

The helpdesk will manually enter the work to ensure accurate reporting.  