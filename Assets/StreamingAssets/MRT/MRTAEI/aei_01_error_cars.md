# (1) AEI Errors Cars

## Definition

**AEI Error Cars:** Cars on work order but not currently in train.

---

## Processing AEI Error Cars

### Step 1: Access AEI Errors Tab

Navigate to the **AEI Errors** tab to view cars with discrepancies.

---

## Selection Options

### Select In Work Order

When enabled, click to skip or unskip adding a car:

- **Select In Work Order cars** and pont the pickup or pull
- **Select AEI Missing cars** and report the end point or exception them

---

## Error Car Status Indicators

### Highlighted Cars

Cars highlighted in the **AEI Add Cars** column indicate:

- **Highlighted cars** are labeled as **added** to add work to train
- Cars need to be added via the **Add Work** function

---

## AEI Error Car Display

The screen shows:

### Column Headers
| AEI Standing Seq | WO Seq Order | Car | Load/Empty | From Instruction | Reported Time | To Instruction | TOC/Requestor Name | Info |
|------------------|--------------|-----|------------|------------------|---------------|----------------|-------------------|------|

### Example Error Cars

**Car 1:**
Seq: 001   WO: ADD
Car: WCXX 10040
L/E: (status)
From: PICK UP FROM CA 513
To: SET OUT AT CA 505
Info: In Work Order

**Car 2:**
Seq: 005   WO: ADD
Car: APPX 17009
L/E: F
From: PICK UP FROM CA 513
To: SET OUT AT CA 505
Info: In Work Order

**Car 3:**
Seq: N/A   WO: 003
Car: NAHX 580604
L/E: E
From: PICK UP FROM CA 505
Time: 04/07 08:35
To: DI AT CKVNS NS
Info: AEI Missing

**Car 4:**
Seq: N/A   WO: 004
Car: CR 569980
L/E: L
From: PICK UP FROM CA 505
Time: 04/07 08:35
To: DI AT CKVNS NS
Info: AEI Missing

---

## Actions for Error Cars

### Option 1: Report Cars in Work Order

For cars that **ARE** on your train:
1. Select the car(s)
2. Tap the appropriate instruction button
3. Report the work

### Option 2: Exception Missing Cars

For cars that are **NOT** on your train:
1. Select the car(s)
2. Tap exception
3. Choose appropriate exception code and reason

---

## Special Status Messages

### In Work Order
- Car is on the work order
- Needs to be completed or exceptioned

### AEI Missing
- Car was expected but not scanned by AEI
- Verify if car is actually present
- Report or exception as appropriate

---

## Car Position Information

### Destination Point of Car
Shows where the car is headed (highlighted in orange/yellow)

### Origin of Car
Shows where the car came from (may be highlighted)

---

## Processing Notes

- **Click to add work** for cars in train but not on work order
- **D, G, E buttons** available for status changes
- **ENTER LC CARS** option for locomotive and equipment entry
- **Step 2: Report all AEI Add Cars** follows after error car resolution

---

## Best Practices

### Before Reporting
- ✅ Visually verify car presence in train
- ✅ Check car numbers carefully
- ✅ Confirm car position if needed

### When Exceptioning
- ✅ Choose most accurate exception code
- ✅ Verify car truly missing from train
- ✅ Document reason clearly

### For Add Work
- ✅ Ensure proper FROM and TO instructions
- ✅ Verify car location
- ✅ Complete add work process before accepting standing order