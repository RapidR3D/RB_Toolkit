# <color=#FFD700>(1) AEI Errors Cars</color>  

## <color=#FF8C00>Definition</color>  

<color=#FF8C00>**AEI Error Cars:**</color> Cars on work order but not currently in train.  

---

## <color=#FF8C00>Processing AEI Error Cars</color>  

### <color=#20B2AA>Step 1: Access AEI Errors Tab</color>  

Navigate to the **AEI Errors** tab to view cars with discrepancies.  

---

## <color=#FF8C00>Selection Options</color>  

### <color=#20B2AA>Select In Work Order</color>  

When enabled, click to skip or unskip adding a car:  

- **Select In Work Order cars** and pont the pickup or pull
- **Select AEI Missing cars** and report the end point or exception them

---

## <color=#FF8C00>Error Car Status Indicators</color>  

### <color=#20B2AA>Highlighted Cars</color>  

Cars highlighted in the **AEI Add Cars** column indicate:  

- **Highlighted cars** are labeled as **added** to add work to train
- Cars need to be added via the **Add Work** function

---

## <color=#FF8C00>AEI Error Car Display</color>  

The screen shows:  

### <color=#20B2AA>Column Headers</color>  
| AEI Standing Seq | WO Seq Order | Car | Load/Empty | From Instruction | Reported Time | To Instruction | TOC/Requestor Name | Info |  
|------------------|--------------|-----|------------|------------------|---------------|----------------|-------------------|------|  

### <color=#20B2AA>Example Error Cars</color>  

<color=#FF8C00>**Car 1:**</color>  
Seq: 001   WO: ADD  
Car: WCXX 10040  
L/E: (status)  
From: PICK UP FROM CA 513  
To: SET OUT AT CA 505  
Info: In Work Order  

<color=#FF8C00>**Car 2:**</color>  
Seq: 005   WO: ADD  
Car: APPX 17009  
L/E: F  
From: PICK UP FROM CA 513  
To: SET OUT AT CA 505  
Info: In Work Order  

<color=#FF8C00>**Car 3:**</color>  
Seq: N/A   WO: 003  
Car: NAHX 580604  
L/E: E  
From: PICK UP FROM CA 505  
Time: 04/07 08:35  
To: DI AT CKVNS NS  
Info: AEI Missing  

<color=#FF8C00>**Car 4:**</color>  
Seq: N/A   WO: 004  
Car: CR 569980  
L/E: L  
From: PICK UP FROM CA 505  
Time: 04/07 08:35  
To: DI AT CKVNS NS  
Info: AEI Missing  

---

## <color=#FF8C00>Actions for Error Cars</color>  

### <color=#20B2AA>Option 1: Report Cars in Work Order</color>  

For cars that **ARE** on your train:  
1. Select the car(s)  
2. Tap the appropriate instruction button  
3. Report the work  

### <color=#20B2AA>Option 2: Exception Missing Cars</color>  

For cars that are **NOT** on your train:  
1. Select the car(s)  
2. Tap exception  
3. Choose appropriate exception code and reason  

---

## <color=#FF8C00>Special Status Messages</color>  

### <color=#20B2AA>In Work Order</color>  
- Car is on the work order
- Needs to be completed or exceptioned

### <color=#20B2AA>AEI Missing</color>  
- Car was expected but not scanned by AEI
- Verify if car is actually present
- Report or exception as appropriate

---

## <color=#FF8C00>Car Position Information</color>  

### <color=#20B2AA>Destination Point of Car</color>  
Shows where the car is headed (highlighted in orange/yellow)  

### <color=#20B2AA>Origin of Car</color>  
Shows where the car came from (may be highlighted)  

---

## <color=#FF8C00>Processing Notes</color>  

- **Click to add work** for cars in train but not on work order
- **D, G, E buttons** available for status changes
- **ENTER LC CARS** option for locomotive and equipment entry
- **Step 2: Report all AEI Add Cars** follows after error car resolution

---

## <color=#FF8C00>Best Practices</color>  

### <color=#20B2AA>Before Reporting</color>  
- ✅ Visually verify car presence in train
- ✅ Check car numbers carefully
- ✅ Confirm car position if needed

### <color=#20B2AA>When Exceptioning</color>  
- ✅ Choose most accurate exception code
- ✅ Verify car truly missing from train
- ✅ Document reason clearly

### <color=#20B2AA>For Add Work</color>  
- ✅ Ensure proper FROM and TO instructions
- ✅ Verify car location
- ✅ Complete add work process before accepting standing order