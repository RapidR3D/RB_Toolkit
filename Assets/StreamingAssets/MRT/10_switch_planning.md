# <color=#FFD700>Switch Planning Tool (SPT)</color>  

## <color=#FF8C00>Overview</color>  

The Switch Planning Tool builds outbound trains and generates work orders. It applies planned customer and interchange work to create a complete operating plan for your train.  

---

## <color=#FF8C00>Getting Your SPT Report</color>  

### <color=#20B2AA>Method 1: Request from Crew Menu</color>  

Crew > 27 > 18  

Select your train and request printed SPT  

### <color=#20B2AA>Method 2: Obtain from Printer/Office</color>  
- Check printer for existing SPT reports
- Check counter or file cabinet
- Ask yardmaster for your SPT

### <color=#20B2AA>Method 3: Request from Device</color>  
If SPT has not yet generated:  
1. Login to SPT  
2. Tap **Request SPT**  
3. System generates and sends to printer  

### <color=#20B2AA>Supporting Documents</color>  
Also print any needed track lists:  

Crew > 27 > 06 > YSTL  


---

## <color=#FF8C00>SPT Report Components</color>  

### <color=#20B2AA>Header Information</color>  
- **Train ID** - Your train identifier
- **Origin** - Starting location and milepost
- **Turn** - Intermediate location (if applicable)
- **Destination** - Final location and milepost
- **Snapshot Status** - When plan was created
- **Work Order Status** - Current WO state

### <color=#20B2AA>Customer Sections</color>  
For each customer shows:  
- Customer name and code
- Total capacity
- Available capacity
- Planned places (to spot)
- Planned pulls (to remove)
- Cars available in yard for placement
- Car locations (track/spot)

### <color=#20B2AA>Station Sections</color>  
- Origin pickups
- Line of road pickups
- Destination set outs

### <color=#20B2AA>Interchange Sections</color>  
- Deliver to other railroads
- Receive from other railroads

---

## <color=#FF8C00>SPT Workflow Overview</color>  

### <color=#20B2AA>Step 1: Login to SPT</color>  
1. From Tool Selection, tap **Switch Planning Tool**  
2. Enter **Train ID**  
3. For yard jobs: Enter **Origin Milepost**  
4. Tap **Create Build** icon  

### <color=#20B2AA>Step 2: Request or Continue</color>  
<color=#FF8C00>**If SPT not yet generated:**</color>  
- Tap **REQUEST SPT**
- System creates SPT and sends to printer

<color=#FF8C00>**If SPT already exists:**</color>  
- Tap **CONTINUE** to use current SPT
- Tap **UPDATE SPT** to request a new version

### <color=#20B2AA>Step 3: Apply Work</color>  
For each tile (customer, interchange, station):  
1. Tap the **Planned** count  
2. Select cars to apply  
3. Set end instructions (TO)  
4. Add cars to build  

### <color=#20B2AA>Step 4: Add Equipment</color>  
1. Tap **Locomotive(s)** (+)  
2. Enter lead locomotive first  
3. Add additional power  
4. Tap **EOT(s)** (+)  
5. Enter EOT device number  

### <color=#20B2AA>Step 5: Adjust Train Standing Order</color>  
1. Review car sequence  
2. Use function buttons to reorder:  
   - HEAD, UP, DOWN, REAR, AFTER, REVERSE
3. Tap **UPDATE**  

### <color=#20B2AA>Step 6: Handle Service Exceptions</color>  
If you **cannot take** planned cars:  
1. Select the customer/junction  
2. Tap **SERVICE EXCEPTION**  
3. Choose Full or Partial  
4. Select exception reason  
5. Tap **SEND**  

### <color=#20B2AA>Step 7: Select Printer</color>  
Choose where work order will print  
(if prompted)  

### <color=#20B2AA>Step 8: Submit</color>  
1. Tap **SEND**  
2. Confirmation pop-up appears  
3. Tap **OK**  
4. Work order prints  

---

## <color=#FF8C00>Applying Customer Work</color>  

### <color=#20B2AA>Customer Tile Display</color>  

SX 820 9726 COMMERCIAL WAREHOUSE #1  
Planned: 4        Applied: 0  
Total Capacity: 330  
Available Capacity: 328  


### <color=#20B2AA>Step-by-Step: Applying Customer Cars</color>  

#### 1. Tap the Customer Tile
Select the customer showing **Planned** work  

#### 2. Review Available Cars
System shows:  
- Cars in yard available for this customer
- From Station (where car currently is)
- From Track/Spot (exact location)
- Car initial and number
- HAZ status
- Load/Empty status
- Commodity
- Class code

#### 3. Select Cars
<color=#FF8C00>**Options:**</color>  
- Tap individual cars
- Tap **SELECT/DESELECT ALL**
- Use **Select Range** slider
- Use **SEARCH CAR** to find specific car

#### 4. Tap ADD SELECTED CARS
Selected cars move to **Applied Cars** tab  

#### 5. Verify Instructions
System automatically sets:  
- <color=#FF8C00>**FROM:**</color> PK (Pickup from yard station)
- <color=#FF8C00>**TO:**</color> PL (Place at customer)

#### 6. Tap NEXT
Cars are added to your train build  

#### 7. Verify Applied Count
Customer tile now shows:  

Planned: 4        Applied: 4  


---

## <color=#FF8C00>Applying Station Work</color>  

### <color=#20B2AA>Origin Pickup</color>  

#### 1. Tap the PK (Pickup) Instruction
On the Origin station tile  

#### 2. Select Filter Type
**SPT** - Shows only planned cars from SPT report  
**TRACK** - Shows all yard inventory by track  

#### Using SPT Filter
- Lists only cars on your SPT
- Pre-filtered for your train
- Recommended for standard operations

#### Using TRACK Filter
1. Tap **Select Filter** dropdown  
2. Choose **From Track** (R01, W02, W20, etc.)  
3. All cars on that track display  
4. Select cars you're taking  

#### 3. Select Cars
<color=#FF8C00>**Important:**</color> System remembers selection sequence!  
- First car selected → Position 1
- Second car selected → Position 2
- Third car selected → Position 3

This determines car order in your train.  

#### 4. Tap ADD SELECTED CARS
Cars move to **Applied Cars** tab  

#### 5. Set End Instructions
Select all cars (or specific cars) going to same destination:  
1. Tap **SET END INSTRUCTIONS**  
2. Choose destination:  
   - **SO** (Set Out at another station)
   - **PL** (Place at customer)
   - **DI** (Deliver Interchange)
3. Select specific station/customer/railroad  
4. Tap **UPDATE**  

#### 6. Tap NEXT
Cars added to build with proper FROM and TO instructions  

---

## <color=#FF8C00>Setting End Instructions</color>  

### <color=#20B2AA>The End Instruction Screen</color>  

When you tap **SET END INSTRUCTIONS**, you'll see:  


SO (Station Set Out)  
LD (Rapid Load)  
DI (Deliver Interchange)  
UL (Rapid Unload)  
PL (Place at Customer)  


### <color=#20B2AA>Choosing Set Out Station</color>  
If selecting **SO**:  
1. List of stations appears:  
   - A 821 VERTAGREEN FL
   - A 825 DAVENPORT FL
   - A 829 HAINES CITY FL
   - etc.
2. Select destination station  
3. Tap **UPDATE**  

### <color=#20B2AA>Choosing Place at Customer</color>  
If selecting **PL**:  
1. Select station first (SX 820 AUBURNDALE FL)  
2. List of customers at that station appears:  
   - SX 820 9726 COMMERCIAL WAREHOUSE #1
   - SX 820 9732 ROADMASTER
   - SX 820 9735 QUALITY LIQUID FEEDS INC
   - etc.
3. Select customer  
4. Tap **UPDATE**  

### <color=#20B2AA>Choosing Deliver Interchange</color>  
If selecting **DI**:  
1. List of railroads/junctions appears  
2. Select receiving railroad  
3. Tap **UPDATE**  

---

## <color=#FF8C00>Train Standing Order</color>  

### <color=#20B2AA>Purpose</color>  
Arranges the exact sequence of cars in your train from head to rear.  

### <color=#20B2AA>Initial Order</color>  
System places cars in this sequence:  
1. Locomotives (head end)  
2. Cars (in order you selected them)  
3. EOT (rear end)  

### <color=#20B2AA>Adjusting the Order</color>  

#### Function Buttons
| Button | Action |  
|--------|--------|  
| **HEAD** | Move selected car(s) to front |  
| **UP** | Move selected car(s) up one position |  
| **DOWN** | Move selected car(s) down one position |  
| **REAR** | Move selected car(s) to back |  
| **AFTER** | Place selected car(s) after another car |  
| **REVERSE** | Flip order of selected cars |  

#### Reordering Process
1. Select car(s) to move (tap checkbox)  
2. Tap function button  
3. Car(s) move to new position  
4. Repeat as needed  
5. Tap **UPDATE** when complete  

### <color=#20B2AA>Example Train Standing Order</color>  

Seq  Car          Load  Type  FROM           TO  
001  CSXT 4555    L     D     LOCO           LOCO  
002  ARMN 933003  L     R470  PK AY 856      PL SX 820 9726  
003  CYDX 220     L     H350  PK AY 856      PL SX 820 9726  
004  AEX 11238    L     K345  PK AY 856      PL SX 820 9726  
005  KGLX 91122   L     H350  PK AY 856      PL SX 820 9726  
006  CSXE 41852   L     M900  EOT            EOT  


---

## <color=#FF8C00>Service Exceptions in SPT</color>  

### <color=#20B2AA>When to Use</color>  
When you **cannot take** planned cars listed on the SPT.  

### <color=#20B2AA>Types of Service Exceptions</color>  

#### Full Service Exception
<color=#FF8C00>**Definition:**</color> Taking NONE of the planned cars  
<color=#FF8C00>**Example:**</color> Customer had 5 planned places, you applied 0  

#### Partial Service Exception
<color=#FF8C00>**Definition:**</color> Taking SOME of the planned cars  
<color=#FF8C00>**Example:**</color> Customer had 5 planned places, you applied 3  

### <color=#20B2AA>Service Exception Process</color>  

#### 1. Tap SERVICE EXCEPTION
On the customer or junction tile  

#### 2. System Shows

Customer: SX 820 9735 CERTAINTEED CORP  
Applied/Planned: 0 of 4 Cars Applied  
Exception: Full  

Select Service Exception Reason  


#### 3. Select Reason
Tap dropdown and choose:  
- **CX** (CSX Inability)
- **CI** (Customer Not Accessible)
- **TF** (Customer Track Full)
- **OT** (Out of Time)
- **NA** (Not Available at Station)
- etc.

#### 4. Tap SEND
Exception is recorded in the system  

---

## <color=#FF8C00>Adding Equipment</color>  

### <color=#20B2AA>Locomotives</color>  

#### Input Rules
1. Enter **lead locomotive first**  
2. Format: **Space** between initial and number  
   - ✅ Correct: CSXT 4555
   - ❌ Wrong: CSXT4555
3. Add additional power in order (head to rear)  

#### Process
1. Tap **(+)** next to Locomotive(s)  
2. Enter locomotive: CSXT 4555  
3. Tap **SEND**  
4. Repeat for additional units  
5. Tap trash bin icon (🗑️) to remove equipment  

### <color=#20B2AA>End-of-Train Devices (EOT)</color>  

#### Input Rules
1. Format: **Space** between initial and number  
   - ✅ Correct: CSXE 41852
   - ❌ Wrong: CSXE41852

#### Process
1. Tap **(+)** next to EOT(s)  
2. Enter EOT: CSXE 41852  
3. Tap **SEND**  
4. Tap trash bin icon (🗑️) to remove if needed  

---

## <color=#FF8C00>Printer Selection</color>  

### <color=#20B2AA>When Prompted</color>  
Some terminals require printer ID selection.  

### <color=#20B2AA>Process</color>  
1. List of available printers displays  
2. Select your terminal's printer  
3. Tap **OK**  
4. Work order routes to that printer  

### <color=#20B2AA>If Not Prompted</color>  
System uses default printer for your terminal.  

---

## <color=#FF8C00>SPT Confirmation</color>  

### <color=#20B2AA>Success Message</color>  

MOBILE RAIL TOOL ALERT  
Switch Planning build has been submitted  
successfully for train 070729  
[OK]  


### <color=#20B2AA>What Happens Next</color>  
1. **SPT build processes** in the system  
2. **Work order generates** with all applied work  
3. **Printed work order** outputs at selected printer  
4. **Ready to retrieve** and start Mobile Work Order  

---

## <color=#FF8C00>SPT Best Practices</color>  

### <color=#20B2AA>Before Building</color>  
- ✅ Review printed SPT report thoroughly
- ✅ Verify customer capacities
- ✅ Check for track restrictions
- ✅ Coordinate with yardmaster
- ✅ Know your locomotive consists
- ✅ Have EOT number ready

### <color=#20B2AA>During Build</color>  
- ✅ Apply ALL cars you can realistically handle
- ✅ Use Service Exceptions for cars you can't take
- ✅ Select cars in logical order (by destination, type, hazmat)
- ✅ Set all end instructions correctly
- ✅ Verify equipment entered correctly
- ✅ Review train standing order before submitting

### <color=#20B2AA>After Building</color>  
- ✅ Wait for confirmation message
- ✅ Retrieve printed work order
- ✅ Verify all planned work applied correctly
- ✅ Check for any missing cars
- ✅ Proceed to Mobile Work Order

---

## <color=#FF8C00>Common SPT Scenarios</color>  

### <color=#20B2AA>Scenario 1: Standard Outbound Build</color>  

1. Review SPT report  
2. Login to SPT  
3. Apply all customer places from planned work  
4. Apply origin pickups using TRACK filter  
5. Set end instructions for each destination  
6. Add locomotives and EOT  
7. Review/adjust train standing order  
8. Submit build  
9. Retrieve work order  


### <color=#20B2AA>Scenario 2: Partial Service Exception</color>  

1. Customer has 5 planned places  
2. Only 3 cars available in yard  
3. Apply the 3 available cars  
4. Tap SERVICE EXCEPTION on customer  
5. Select "Partial" (3 of 5 applied)  
6. Choose reason: NA (Not Available at Station)  
7. Tap SEND  
8. Continue building rest of train  


### <color=#20B2AA>Scenario 3: Cannot Reach Customer</color>  

1. Customer has 4 planned places  
2. You know you'll run out of time before reaching them  
3. Do NOT apply any of the 4 cars  
4. Tap SERVICE EXCEPTION on customer  
5. Select "Full" (0 of 4 applied)  
6. Choose reason: OT (Out of Time)  
7. Tap SEND  
8. Continue with reachable customers  


### <color=#20B2AA>Scenario 4: Building from Multiple Tracks</color>  

1. Origin pickups scattered across W02, W07, W20  
2. Use TRACK filter in SPT  
3. Select track W02, apply cars in sequence  
4. Switch to track W07, apply next cars  
5. Switch to track W20, apply final cars  
6. Set end instructions for all cars  
7. Adjust train standing order to group by destination  
8. Submit build  


---

## <color=#FF8C00>Troubleshooting SPT</color>  

### <color=#20B2AA>Cannot Find Car on SPT</color>  
<color=#FF8C00>**Problem:**</color> Expected car not showing in planned work  
<color=#FF8C00>**Solution:**</color>  
1. Switch to TRACK filter view  
2. Search yard inventory directly  
3. Verify car hasn't already departed  
4. Check with yardmaster  
5. Add Work it manually if appropriate  

### <color=#20B2AA>Wrong End Instruction</color>  
<color=#FF8C00>**Problem:**</color> Car showing wrong destination  
<color=#FF8C00>**Solution:**</color>  
1. Go to Applied Cars tab  
2. Select the car(s)  
3. Tap SET END INSTRUCTIONS  
4. Choose correct destination  
5. Tap UPDATE  
6. Verify change before submitting  

### <color=#20B2AA>Submitted Wrong Build</color>  
<color=#FF8C00>**Problem:**</color> Build submitted with errors  
<color=#FF8C00>**Solution:**</color>  
1. Tap DELETE WO icon (trash bin)  
2. Confirms deletion  
3. Start over with CREATE BUILD  
4. Rebuild correctly  
5. Submit new build  

### <color=#20B2AA>Service Exception Not Accepted</color>  
<color=#FF8C00>**Problem:**</color> System rejects exception reason  
<color=#FF8C00>**Solution:**</color>  
1. Verify you chose valid reason for that customer type  
2. Check if Full vs Partial is correct  
3. Try different exception reason  
4. If persists, call MRT Helpdesk  

---

## <color=#FF8C00>SPT Quick Reference</color>  

| Task | Action |  
|------|--------|  
| Start new build | Tap CREATE BUILD |  
| Request new SPT | Tap REQUEST SPT |  
| Apply customer work | Tap customer tile → Planned |  
| Apply station work | Tap PK or SO instruction |  
| Set destination | SELECT END INSTRUCTIONS |  
| Add locomotives | Tap (+) next to Locomotive(s) |  
| Add EOT | Tap (+) next to EOT(s) |  
| Reorder cars | Use function buttons in Train Standing Order |  
| Input exception | Tap SERVICE EXCEPTION |  
| Delete build | Tap DELETE WO icon |  
| Submit build | Tap SEND |  

---

## <color=#FF8C00>Need Help?</color>  

📞 **MRT Helpdesk: 800-243-7743 option #4**  

<color=#FF8C00>**Call for:**</color>  
- SPT build errors
- Cannot apply planned work
- Service exception issues
- Equipment input problems
- Questions about car selection
- Work order didn't print

<color=#FF8C00>**Have ready:**</color>  
- Train ID
- Origin milepost
- SPT report (if available)
- Specific error messages