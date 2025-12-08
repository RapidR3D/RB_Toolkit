# <color=#FFD700>Load/Empty Status Codes Reference</color>  

## <color=#FF8C00>Overview</color>  

Load/Empty (L/E) status identifies whether a railcar is carrying freight or is empty. This information is critical for billing, routing, and operational planning.  

---

## <color=#FF8C00>Status Code Definitions</color>  

### <color=#20B2AA>Loaded Status Codes</color>  

#### L - Loaded
<color=#FF8C00>**Definition:**</color> Standard loaded railcar carrying revenue freight  

<color=#FF8C00>**Characteristics:**</color>  
- Contains customer commodity
- Generating freight revenue
- Has active waybill/billing
- Normal loaded operations

<color=#FF8C00>**Examples:**</color>  
- Tank car with chemicals
- Boxcar with manufactured goods
- Hopper with coal
- Flatcar with lumber

<color=#FF8C00>**When to Use:**</color>  
- Standard loaded car movements
- Customer has loaded the car
- Car carrying revenue freight

---

#### M - Company Material
<color=#FF8C00>**Definition:**</color> CSX-owned loads or company material  

<color=#FF8C00>**Characteristics:**</color>  
- Not customer revenue freight
- CSX internal movements
- Company materials or supplies
- Special handling

<color=#FF8C00>**Examples:**</color>  
- Rail carrying ties for CSX
- MOW (Maintenance of Way) materials
- CSX equipment or supplies
- Internal company shipments

<color=#FF8C00>**When to Use:**</color>  
- System assigns this status
- CSX materials being transported
- Non-revenue company loads

<color=#FF8C00>**Note:**</color> You cannot input "M" status in MRT - system controlled  

---

#### N - Nobill
<color=#FF8C00>**Definition:**</color> Loaded car with no billing information in CSX systems, or unknown L/E status  

<color=#FF8C00>**Characteristics:**</color>  
- Car is loaded (or appears loaded)
- No waybill in system
- Billing information missing/unknown
- Status uncertain

<color=#FF8C00>**Examples:**</color>  
- Customer loaded but hasn't submitted billing
- Loaded car with missing paperwork
- Status unknown from foreign railroad
- Billing not yet processed

<color=#FF8C00>**When to Use:**</color>  
- System assigns this status
- Indicates billing issue needs resolution

<color=#FF8C00>**⚠️ CRITICAL COMPANY DIRECTIVE:**</color>  
<color=#FF8C00>**LEAVE NOBILLS AT THE CUSTOMER UNTIL THEY ARE BILLED!**</color>  
<color=#FF8C00>**Nobill Rules:**</color>  
1. <color=#FF8C00>**Loaded NOBILL Pulls:**</color>  
   - ❌ DO NOT add work them
   - ✅ Must be on your work order, OR
   - ✅ Must come through MRT New Work
   - Wait for proper billing

2. <color=#FF8C00>**Empty Nobill Pulls:**</color>  
   - ✅ OK to add work and pull
   - Can remove empty nobills as needed

3. <color=#FF8C00>**Status Changes:**</color>  
   - You may need to change L/E status if car changes
   - Change N→E if car actually empty
   - Change N→L if car gets properly billed

<color=#FF8C00>**Note:**</color> You cannot input "N" status in MRT - system controlled  

---

### <color=#20B2AA>Empty Status Codes</color>  

#### E - Empty
<color=#FF8C00>**Definition:**</color> Standard empty railcar not carrying freight  

<color=#FF8C00>**Characteristics:**</color>  
- No freight loaded
- Available for loading
- Normal empty operations
- Standard empty movement

<color=#FF8C00>**Examples:**</color>  
- Empty hopper ready for loading
- Empty tank car after unloading
- Empty boxcar returning to customer
- Empty flatcar repositioning

<color=#FF8C00>**When to Use:**</color>  
- Car has been unloaded
- Empty car for positioning
- Available for customer loading

---

#### F - Revenue Empty
<color=#FF8C00>**Definition:**</color> Empty car generating revenue (special movement)  

<color=#FF8C00>**Characteristics:**</color>  
- Empty but earning revenue
- Special empty movement contract
- Customer pays for empty move
- Unique billing arrangement

<color=#FF8C00>**Examples:**</color>  
- Customer-owned car returning empty
- Dedicated equipment repositioning
- Contracted empty movements
- Special customer agreements

<color=#FF8C00>**When to Use:**</color>  
- System assigns this status
- Special revenue empty movements
- Customer contracts for empty return

<color=#FF8C00>**Note:**</color> You cannot input "F" status in MRT - system controlled  

---

## <color=#FF8C00>MRT Input Rules</color>  

### <color=#20B2AA>What You CAN Input</color>  

In MRT, you can only input two status codes:  

✅ **L** (Loaded)  
✅ **E** (Empty)  

### <color=#20B2AA>What You CANNOT Input</color>  

You cannot directly input these codes - they are system-controlled:  

❌ **M** (Company Material) - System assigned  
❌ **N** (Nobill) - System assigned  
❌ **F** (Revenue Empty) - System assigned  

### <color=#20B2AA>What You CAN See</color>  

All status codes (L, E, M, N, F) will **display** to you in MRT, but you can only change between L and E.  

---

## <color=#FF8C00>When to Change Status</color>  

### <color=#20B2AA>Change FROM Empty TO Loaded (E → L)</color>  

<color=#FF8C00>**Scenario 1:**</color> Customer Loaded the Car  
Before: Car spotted empty for customer to load  
Status: E (Empty)  
Action: Customer fills car with commodity  
After: Change status to L (Loaded)  
When: When you pick up the now-loaded car  

<color=#FF8C00>**Scenario 2:**</color> Found Loaded Car Listed as Empty  
Before: System shows E (Empty)  
Reality: Car is actually loaded  
Action: Change to L (Loaded)  
When: When you discover the discrepancy  

---

### <color=#20B2AA>Change FROM Loaded TO Empty (L → E)</color>  

<color=#FF8C00>**Scenario 1:**</color> Customer Unloaded the Car  
Before: Car placed loaded for customer to unload  
Status: L (Loaded)  
Action: Customer empties car  
After: Change status to E (Empty)  
When: When you pick up the now-empty car  

<color=#FF8C00>**Scenario 2:**</color> Found Empty Car Listed as Loaded  
Before: System shows L (Loaded)  
Reality: Car is actually empty  
Action: Change to E (Empty)  
When: When you discover the discrepancy  

---

### <color=#20B2AA>Leave Status "As Is"</color>  

<color=#FF8C00>**When NOT to change:**</color>  
- ✅ Status already matches actual condition
- ✅ System shows M, N, or F and condition hasn't changed
- ✅ Car status is correct
- ✅ No change in loading/unloading occurred

<color=#FF8C00>**Special case - Nobills:**</color>  
- Car shows N status
- Car is still loaded without billing
- **Leave as N** until proper billing received
- **DO NOT pull** loaded nobills unless on work order

---

## <color=#FF8C00>Status Change Process in MRT</color>  

### <color=#20B2AA>Step 1: Identify Need to Change</color>  
- Car's actual condition differs from displayed status
- Customer has loaded or unloaded car
- Discovered incorrect status

### <color=#20B2AA>Step 2: Select the Car(s)</color>  
- In work order, select car(s) needing status change
- Can select multiple cars if same change needed

### <color=#20B2AA>Step 3: Use Status Button</color>  
- **SET EMPTY** - Changes selected car(s) to E
- **SET LOADED** - Changes selected car(s) to L

### <color=#20B2AA>Step 4: Verify Change</color>  
- Check that status updated correctly
- Proceed with reporting work

---

## <color=#FF8C00>Status and Billing Implications</color>  

### <color=#20B2AA>Loaded Cars (L, M, N)</color>  

<color=#FF8C00>**Customer Impact:**</color>  
- Customer may be charged for placement
- Loaded pulls generate revenue
- Billing based on loaded status
- Commodity rates apply

<color=#FF8C00>**Operational Impact:**</color>  
- Different handling requirements
- Hazmat considerations if applicable
- Weight considerations for tonnage
- Special movement restrictions may apply

---

### <color=#20B2AA>Empty Cars (E, F)</color>  

<color=#FF8C00>**Customer Impact:**</color>  
- Different billing rates for empties
- Customer may request empty positioning
- Empty storage charges may apply
- Return empties for loading

<color=#FF8C00>**Operational Impact:**</color>  
- Lighter weight for tonnage
- Fewer restrictions generally
- Available for loading
- Can be repositioned more easily

---

## <color=#FF8C00>Special Nobill Handling</color>  

### <color=#20B2AA>Understanding Nobills</color>  

<color=#FF8C00>**Why N Status Exists:**</color>  
- Billing not yet in system
- Paperwork delayed or missing
- New customer setup incomplete
- Foreign road billing pending
- Load/Empty status uncertain

### <color=#20B2AA>The Problem with Nobills</color>  

If crews pull loaded nobills before billing:  
- Customer not charged properly
- Revenue lost
- Billing disputes arise
- Inventory tracking problems
- Customer service window issues

### <color=#20B2AA>The Solution</color>  

<color=#FF8C00>**COMPANY DIRECTIVE:**</color>  
<color=#FF8C00>**LEAVE NOBILLS AT THE CUSTOMER UNTIL THEY ARE BILLED!**</color>  
<color=#FF8C00>**What This Means:**</color>  
1. <color=#FF8C00>**Loaded NOBILL at customer:**</color>  
   - DO NOT pull unless directed
   - Wait for billing to post
   - Car will appear on work order when billed
   - May come through New Work once billed

2. <color=#FF8C00>**Empty NOBILL at customer:**</color>  
   - OK to pull if needed
   - Can add work empty pulls
   - Less critical than loaded

3. <color=#FF8C00>**If loaded NOBILL on your work order:**</color>  
   - Then it's OK to pull
   - Billing has been addressed
   - Pull and report normally

4. <color=#FF8C00>**If loaded NOBILL in New Work:**</color>  
   - Then it's OK to pull
   - Has been specifically assigned
   - Accept and report normally

---

## <color=#FF8C00>Status Verification</color>  

### <color=#20B2AA>Before Reporting Customer Pulls</color>  

<color=#FF8C00>**Checklist:**</color>  
- [ ] Visually verify car is loaded or empty
- [ ] Check displayed L/E status matches reality
- [ ] Change status if needed before reporting
- [ ] For loaded cars, verify not a Nobill
- [ ] For Nobills, verify it's on work order or New Work

### <color=#20B2AA>Before Reporting Customer Places</color>  

<color=#FF8C00>**Checklist:**</color>  
- [ ] Verify L/E status correct for what customer expects
- [ ] Loaded cars have proper billing
- [ ] Empty cars show E status
- [ ] Customer requested this specific car

---

## <color=#FF8C00>Common Status Scenarios</color>  

### <color=#20B2AA>Scenario 1: Empty Car Placed, Now Loading</color>  

<color=#FF8C00>**Initial:**</color>  
Car: TILX 334912  
Status: E (Empty)  
Action: Placed at customer for loading  

<color=#FF8C00>**Later That Day:**</color>  
Customer has loaded the car  
Status still shows: E (Empty)  
Correct Action: Change to L (Loaded) when pulling  

---

### <color=#20B2AA>Scenario 2: Loaded Car Placed, Now Empty</color>  

<color=#FF8C00>**Initial:**</color>  
Car: UTLX 920035  
Status: L (Loaded)  
Action: Placed at customer for unloading  

<color=#FF8C00>**Next Day:**</color>  
Customer has unloaded the car  
Status still shows: L (Loaded)  
Correct Action: Change to E (Empty) when pulling  


---

### <color=#20B2AA>Scenario 3: Found Nobill at Customer</color>  

<color=#FF8C00>**Discovery:**</color>  
Car: ACFX 75577  
Status: N (Nobill)  
Location: At customer facility  
Work Order: Car NOT on your work order  

<color=#FF8C00>**Correct Action:**</color>  
1. DO NOT pull the car  
2. Leave at customer  
3. Report to MRT Helpdesk if customer requests removal  
4. Wait for billing to post  
5. Will appear on future work order when billed  

---

### <color=#20B2AA>Scenario 4: Nobill Appears as New Work</color>  

<color=#FF8C00>**Notification:**</color>  
NEW WORK: GATX 32067  
Status: N (Nobill) → may have changed to L  
Location: Customer facility  
Action: Pull requested  

<color=#FF8C00>**Correct Action:**</color>  
1. Check status - may now show L (billed)  
2. Accept the New Work  
3. Pull the car  
4. Report normally  
5. Has been specifically assigned/cleared  

---

## <color=#FF8C00>Status Quick Reference</color>  

| Code | Name | Can Input? | Meaning | Action Required |  
|------|------|-----------|---------|-----------------|  
| **L** | Loaded | ✅ Yes | Car has freight | Normal handling |  
| **E** | Empty | ✅ Yes | Car is empty | Normal handling |  
| **M** | Company Material | ❌ No | CSX-owned loads | Leave as-is |  
| **N** | Nobill | ❌ No | No billing / Unknown | DO NOT pull loaded |  
| **F** | Revenue Empty | ❌ No | Special empty | Leave as-is |  

---

## <color=#FF8C00>Status Change Quick Reference</color>  

| Current Status | Actual Condition | Change To | When |  
|----------------|------------------|-----------|------|  
| E | Customer loaded it | L | When pulling |  
| L | Customer unloaded it | E | When pulling |  
| N | Now properly billed | L | System will change |  
| N | Actually empty | E | If you verify it's empty |  
| M | Any change | - | Call MRT Helpdesk |  
| F | Any change | - | Call MRT Helpdesk |  

---

## <color=#FF8C00>Troubleshooting Status Issues</color>  

### <color=#20B2AA>Problem: Can't Change Status</color>  

<color=#FF8C00>**Solution:**</color>  
1. Verify you're using SET EMPTY or SET LOADED buttons  
2. Confirm car is selected  
3. Check you're not trying to change M, N, or F  
4. Call MRT Helpdesk if issues persist  

---

### <color=#20B2AA>Problem: System Changed Status Back</color>  

<color=#FF8C00>**Solution:**</color>  
1. System may have overridden your change  
2. Verify actual car condition  
3. Re-apply correct status  
4. If persists, call MRT Helpdesk  
5. May indicate data conflict  

---

### <color=#20B2AA>Problem: Nobill Won't Clear</color>  

<color=#FF8C00>**Solution:**</color>  
1. DO NOT force pull the car  
2. Contact customer about billing  
3. Report to MRT Helpdesk  
4. Car may need billing department involvement  
5. Wait for proper billing to post  

---

### <color=#20B2AA>Problem: Don't Know if Car is Loaded</color>  

<color=#FF8C00>**Solution:**</color>  
1. Visually inspect the car if possible  
2. Check car ride height (loaded sits lower)  
3. Ask customer if accessible  
4. Check original placement records  
5. If uncertain, leave status as-is and call MRT Helpdesk  

---

## <color=#FF8C00>Best Practices</color>  

### <color=#20B2AA>✅ DO</color>  

- Visually verify L/E status before reporting
- Change status when you KNOW it changed
- Leave nobills at customer until billed
- Report status changes immediately
- Use SET EMPTY/SET LOADED buttons properly

### <color=#20B2AA>❌ DON'T</color>  

- Guess at status if uncertain
- Pull loaded nobills without authorization
- Change M, N, or F status codes manually
- Ignore status discrepancies
- Assume status hasn't changed

---

## <color=#FF8C00>Need Help?</color>  

📞 **MRT Helpdesk: 800-243-7743 option #4**  

<color=#FF8C00>**Call for:**</color>  
- Uncertain about car status
- Nobill handling questions
- Status won't change in MRT
- Found loaded car marked empty (or vice versa)
- Customer requesting pull of nobill
- System overriding your status changes

<color=#FF8C00>**Have ready:**</color>  
- Car initial and number
- Current displayed status
- Actual condition of car
- Customer name and location
- What you're trying to do