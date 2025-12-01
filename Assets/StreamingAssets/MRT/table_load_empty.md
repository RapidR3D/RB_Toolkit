# Load/Empty Status Codes Reference

## Overview

Load/Empty (L/E) status identifies whether a railcar is carrying freight or is empty. This information is critical for billing, routing, and operational planning.

---

## Status Code Definitions

### Loaded Status Codes

#### L - Loaded
**Definition:** Standard loaded railcar carrying revenue freight

**Characteristics:**
- Contains customer commodity
- Generating freight revenue
- Has active waybill/billing
- Normal loaded operations

**Examples:**
- Tank car with chemicals
- Boxcar with manufactured goods
- Hopper with coal
- Flatcar with lumber

**When to Use:**
- Standard loaded car movements
- Customer has loaded the car
- Car carrying revenue freight

---

#### M - Company Material
**Definition:** CSX-owned loads or company material

**Characteristics:**
- Not customer revenue freight
- CSX internal movements
- Company materials or supplies
- Special handling

**Examples:**
- Rail carrying ties for CSX
- MOW (Maintenance of Way) materials
- CSX equipment or supplies
- Internal company shipments

**When to Use:**
- System assigns this status
- CSX materials being transported
- Non-revenue company loads

**Note:** You cannot input "M" status in MRT - system controlled

---

#### N - Nobill
**Definition:** Loaded car with no billing information in CSX systems, or unknown L/E status

**Characteristics:**
- Car is loaded (or appears loaded)
- No waybill in system
- Billing information missing/unknown
- Status uncertain

**Examples:**
- Customer loaded but hasn't submitted billing
- Loaded car with missing paperwork
- Status unknown from foreign railroad
- Billing not yet processed

**When to Use:**
- System assigns this status
- Indicates billing issue needs resolution

**⚠️ CRITICAL COMPANY DIRECTIVE:**
**LEAVE NOBILLS AT THE CUSTOMER UNTIL THEY ARE BILLED!**

**Nobill Rules:**
1. **Loaded NOBILL Pulls:**
   - ❌ DO NOT add work them
   - ✅ Must be on your work order, OR
   - ✅ Must come through MRT New Work
   - Wait for proper billing

2. **Empty Nobill Pulls:**
   - ✅ OK to add work and pull
   - Can remove empty nobills as needed

3. **Status Changes:**
   - You may need to change L/E status if car changes
   - Change N→E if car actually empty
   - Change N→L if car gets properly billed

**Note:** You cannot input "N" status in MRT - system controlled

---

### Empty Status Codes

#### E - Empty
**Definition:** Standard empty railcar not carrying freight

**Characteristics:**
- No freight loaded
- Available for loading
- Normal empty operations
- Standard empty movement

**Examples:**
- Empty hopper ready for loading
- Empty tank car after unloading
- Empty boxcar returning to customer
- Empty flatcar repositioning

**When to Use:**
- Car has been unloaded
- Empty car for positioning
- Available for customer loading

---

#### F - Revenue Empty
**Definition:** Empty car generating revenue (special movement)

**Characteristics:**
- Empty but earning revenue
- Special empty movement contract
- Customer pays for empty move
- Unique billing arrangement

**Examples:**
- Customer-owned car returning empty
- Dedicated equipment repositioning
- Contracted empty movements
- Special customer agreements

**When to Use:**
- System assigns this status
- Special revenue empty movements
- Customer contracts for empty return

**Note:** You cannot input "F" status in MRT - system controlled

---

## MRT Input Rules

### What You CAN Input

In MRT, you can only input two status codes:

✅ **L** (Loaded)
✅ **E** (Empty)

### What You CANNOT Input

You cannot directly input these codes - they are system-controlled:

❌ **M** (Company Material) - System assigned
❌ **N** (Nobill) - System assigned  
❌ **F** (Revenue Empty) - System assigned

### What You CAN See

All status codes (L, E, M, N, F) will **display** to you in MRT, but you can only change between L and E.

---

## When to Change Status

### Change FROM Empty TO Loaded (E → L)

**Scenario 1:** Customer Loaded the Car
Before: Car spotted empty for customer to load
Status: E (Empty)
Action: Customer fills car with commodity
After: Change status to L (Loaded)
When: When you pick up the now-loaded car

**Scenario 2:** Found Loaded Car Listed as Empty
Before: System shows E (Empty)
Reality: Car is actually loaded
Action: Change to L (Loaded)
When: When you discover the discrepancy

---

### Change FROM Loaded TO Empty (L → E)

**Scenario 1:** Customer Unloaded the Car
Before: Car placed loaded for customer to unload
Status: L (Loaded)
Action: Customer empties car
After: Change status to E (Empty)
When: When you pick up the now-empty car

**Scenario 2:** Found Empty Car Listed as Loaded
Before: System shows L (Loaded)
Reality: Car is actually empty
Action: Change to E (Empty)
When: When you discover the discrepancy

---

### Leave Status "As Is"

**When NOT to change:**
- ✅ Status already matches actual condition
- ✅ System shows M, N, or F and condition hasn't changed
- ✅ Car status is correct
- ✅ No change in loading/unloading occurred

**Special case - Nobills:**
- Car shows N status
- Car is still loaded without billing
- **Leave as N** until proper billing received
- **DO NOT pull** loaded nobills unless on work order

---

## Status Change Process in MRT

### Step 1: Identify Need to Change
- Car's actual condition differs from displayed status
- Customer has loaded or unloaded car
- Discovered incorrect status

### Step 2: Select the Car(s)
- In work order, select car(s) needing status change
- Can select multiple cars if same change needed

### Step 3: Use Status Button
- **SET EMPTY** - Changes selected car(s) to E
- **SET LOADED** - Changes selected car(s) to L

### Step 4: Verify Change
- Check that status updated correctly
- Proceed with reporting work

---

## Status and Billing Implications

### Loaded Cars (L, M, N)

**Customer Impact:**
- Customer may be charged for placement
- Loaded pulls generate revenue
- Billing based on loaded status
- Commodity rates apply

**Operational Impact:**
- Different handling requirements
- Hazmat considerations if applicable
- Weight considerations for tonnage
- Special movement restrictions may apply

---

### Empty Cars (E, F)

**Customer Impact:**
- Different billing rates for empties
- Customer may request empty positioning
- Empty storage charges may apply
- Return empties for loading

**Operational Impact:**
- Lighter weight for tonnage
- Fewer restrictions generally
- Available for loading
- Can be repositioned more easily

---

## Special Nobill Handling

### Understanding Nobills

**Why N Status Exists:**
- Billing not yet in system
- Paperwork delayed or missing
- New customer setup incomplete
- Foreign road billing pending
- Load/Empty status uncertain

### The Problem with Nobills

If crews pull loaded nobills before billing:
- Customer not charged properly
- Revenue lost
- Billing disputes arise
- Inventory tracking problems
- Customer service window issues

### The Solution

**COMPANY DIRECTIVE:**
**LEAVE NOBILLS AT THE CUSTOMER UNTIL THEY ARE BILLED!**

**What This Means:**
1. **Loaded NOBILL at customer:**
   - DO NOT pull unless directed
   - Wait for billing to post
   - Car will appear on work order when billed
   - May come through New Work once billed

2. **Empty NOBILL at customer:**
   - OK to pull if needed
   - Can add work empty pulls
   - Less critical than loaded

3. **If loaded NOBILL on your work order:**
   - Then it's OK to pull
   - Billing has been addressed
   - Pull and report normally

4. **If loaded NOBILL in New Work:**
   - Then it's OK to pull
   - Has been specifically assigned
   - Accept and report normally

---

## Status Verification

### Before Reporting Customer Pulls

**Checklist:**
- [ ] Visually verify car is loaded or empty
- [ ] Check displayed L/E status matches reality
- [ ] Change status if needed before reporting
- [ ] For loaded cars, verify not a Nobill
- [ ] For Nobills, verify it's on work order or New Work

### Before Reporting Customer Places

**Checklist:**
- [ ] Verify L/E status correct for what customer expects
- [ ] Loaded cars have proper billing
- [ ] Empty cars show E status
- [ ] Customer requested this specific car

---

## Common Status Scenarios

### Scenario 1: Empty Car Placed, Now Loading

**Initial:**
Car: TILX 334912
Status: E (Empty)
Action: Placed at customer for loading

**Later That Day:**
Customer has loaded the car
Status still shows: E (Empty)
Correct Action: Change to L (Loaded) when pulling

---

### Scenario 2: Loaded Car Placed, Now Empty

**Initial:**
Car: UTLX 920035
Status: L (Loaded)
Action: Placed at customer for unloading

**Next Day:**
Customer has unloaded the car
Status still shows: L (Loaded)
Correct Action: Change to E (Empty) when pulling


---

### Scenario 3: Found Nobill at Customer

**Discovery:**
Car: ACFX 75577
Status: N (Nobill)
Location: At customer facility
Work Order: Car NOT on your work order

**Correct Action:**
1. DO NOT pull the car
2. Leave at customer
3. Report to MRT Helpdesk if customer requests removal
4. Wait for billing to post
5. Will appear on future work order when billed

---

### Scenario 4: Nobill Appears as New Work

**Notification:**
NEW WORK: GATX 32067
Status: N (Nobill) → may have changed to L
Location: Customer facility
Action: Pull requested

**Correct Action:**
1. Check status - may now show L (billed)
2. Accept the New Work
3. Pull the car
4. Report normally
5. Has been specifically assigned/cleared

---

## Status Quick Reference

| Code | Name | Can Input? | Meaning | Action Required |
|------|------|-----------|---------|-----------------|
| **L** | Loaded | ✅ Yes | Car has freight | Normal handling |
| **E** | Empty | ✅ Yes | Car is empty | Normal handling |
| **M** | Company Material | ❌ No | CSX-owned loads | Leave as-is |
| **N** | Nobill | ❌ No | No billing / Unknown | DO NOT pull loaded |
| **F** | Revenue Empty | ❌ No | Special empty | Leave as-is |

---

## Status Change Quick Reference

| Current Status | Actual Condition | Change To | When |
|----------------|------------------|-----------|------|
| E | Customer loaded it | L | When pulling |
| L | Customer unloaded it | E | When pulling |
| N | Now properly billed | L | System will change |
| N | Actually empty | E | If you verify it's empty |
| M | Any change | - | Call MRT Helpdesk |
| F | Any change | - | Call MRT Helpdesk |

---

## Troubleshooting Status Issues

### Problem: Can't Change Status

**Solution:**
1. Verify you're using SET EMPTY or SET LOADED buttons
2. Confirm car is selected
3. Check you're not trying to change M, N, or F
4. Call MRT Helpdesk if issues persist

---

### Problem: System Changed Status Back

**Solution:**
1. System may have overridden your change
2. Verify actual car condition
3. Re-apply correct status
4. If persists, call MRT Helpdesk
5. May indicate data conflict

---

### Problem: Nobill Won't Clear

**Solution:**
1. DO NOT force pull the car
2. Contact customer about billing
3. Report to MRT Helpdesk
4. Car may need billing department involvement
5. Wait for proper billing to post

---

### Problem: Don't Know if Car is Loaded

**Solution:**
1. Visually inspect the car if possible
2. Check car ride height (loaded sits lower)
3. Ask customer if accessible
4. Check original placement records
5. If uncertain, leave status as-is and call MRT Helpdesk

---

## Best Practices

### ✅ DO

- Visually verify L/E status before reporting
- Change status when you KNOW it changed
- Leave nobills at customer until billed
- Report status changes immediately
- Use SET EMPTY/SET LOADED buttons properly

### ❌ DON'T

- Guess at status if uncertain
- Pull loaded nobills without authorization
- Change M, N, or F status codes manually
- Ignore status discrepancies
- Assume status hasn't changed

---

## Need Help?

📞 **MRT Helpdesk: 800-243-7743 option #4**

**Call for:**
- Uncertain about car status
- Nobill handling questions
- Status won't change in MRT
- Found loaded car marked empty (or vice versa)
- Customer requesting pull of nobill
- System overriding your status changes

**Have ready:**
- Car initial and number
- Current displayed status
- Actual condition of car
- Customer name and location
- What you're trying to do