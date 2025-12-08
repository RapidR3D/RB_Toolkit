# <color=#FFD700>(2) AEI Added Cars</color>  

## <color=#FF8C00>Definition</color>  

<color=#FF8C00>**AEI Added Cars:**</color> Cars on your train but not on your work order.  

---

## <color=#FF8C00>Processing Steps</color>  

### <color=#20B2AA>Step 1: Select AEI Added Cars</color>  

Navigate to the **AEI Add Cars** tab.  

---

## <color=#FF8C00>Actions Required</color>  

### <color=#20B2AA>Option 1: Add Work (From/To)</color>  

For cars that should be on your train:  

1. Select the **AEI Added Cars**  
2. Set **LE** (Load/Empty) status if needed  
3. Add work with proper **FROM** and **TO** instructions  

---

## <color=#FF8C00>AEI OK Cars</color>  

### <color=#20B2AA>Definition</color>  
<color=#FF8C00>**AEI OK Cars:**</color> Cars on your train AND on your work order.  

### <color=#20B2AA>Status</color>  
Once all cars show **AEI OK**, you can accept the AEI Scan.  

---

## <color=#FF8C00>Example Display</color>  

### <color=#20B2AA>AEI Add Cars Tab</color>  

<color=#FF8C00>**Column Headers:**</color>  
| AEI Standing Seq | WO Seq Order | Car | Load/Empty | From Instruction | Reported Time | To Instruction | TOC/Requestor Name | Info |  
|------------------|--------------|-----|------------|------------------|---------------|----------------|-------------------|------|  

### <color=#20B2AA>Sample Added Car Entry</color>  


Seq: 001   WO: ADD  
Car: CSXT 2092  
L/E: L  
From: (to be set)  
To: (to be set)  
Info: AEI Added  


<color=#FF8C00>**Highlighted Row:**</color>  
Seq: U72   WO: ADD  
Car: AEI ##7166A  
Status: AEI Added (highlighted in green)  

---

## <color=#FF8C00>Add Work Process</color>  

### <color=#20B2AA>Step 1: Select Car</color>  
Tap and select the car that needs to be added.  

### <color=#20B2AA>Step 2: Set Initial Number</color>  
1. Tap **Set Initial Number**  
2. A pop-up box will open  

### <color=#20B2AA>Step 3: Enter Car Details</color>  
<color=#FF8C00>**Pop-up: "Please enter new car details:"**</color>  
┌─────────────────────────────────────┐  
│ Please enter new car details:       │  
│                                     │  
│ ENTER CAR INITIAL & NUMBER          │  
│                                     │  
│                                     │  
│           Submit                    │  
└─────────────────────────────────────┘  

### <color=#20B2AA>Step 4: Input Information</color>  
1. Enter the **car initial**, **space**, and the **car number**  
2. Click **Submit**  

### <color=#20B2AA>Step 5: Set Load/Empty Status</color>  
Then, indicate the **Load/Empty** status using the **Set Loaded** or **Set Empty** button.  

### <color=#20B2AA>Step 6: Add to Work Order</color>  
If there is no car, or you're unsure of the car type, select the car and tap the **Skip/Unskip Car** button.  

---

## <color=#FF8C00>Scenario Example</color>  

### <color=#20B2AA>Situation</color>  
Two cars show missing but the conductor verified they are on the train.  

<color=#FF8C00>**Actions:**</color>  

1. Check the **Add Cars** tab for **AEI Placeholder cars**  
2. There is one car (position 72)  
3. Tap and select **the car** that is there  
4. Tap **Set Initial Number**  
5. A pop-up box will open  
6. Input the railcar that is present in that spot by entering the **car initial**, **space**, and the **car number**  
7. Then, tap **Submit**  

---

## <color=#FF8C00>Status Information</color>  

### <color=#20B2AA>Info Column Values</color>  
<color=#FF8C00>**AEI Added**</color>  
- Car scanned by AEI
- Not on work order
- Needs to be added

**In Work Order** (after adding)  
- Car successfully added
- Now part of work order
- Ready for processing

---

## <color=#FF8C00>Important Notes</color>  

### <color=#20B2AA>Add Work Requirements</color>  
When adding cars, you must provide:  
- ✅ Car initial and number
- ✅ Load/Empty (L/E) status
- ✅ FROM instruction (where you got it)
- ✅ TO instruction (where you're taking it)

### <color=#20B2AA>Skip/Unskip Option</color>  
Use **Skip/Unskip Car** when:  
- No car is present at that position
- Unsure of car type
- Need to bypass placeholder

---

## <color=#FF8C00>Best Practices</color>  

### <color=#20B2AA>Before Adding Work</color>  
- ✅ Visually verify car is in train
- ✅ Confirm car initial and number
- ✅ Check load/empty status
- ✅ Know where car came from (FROM)
- ✅ Know where car is going (TO)

### <color=#20B2AA>During Add Work</color>  
- ✅ Enter car details accurately
- ✅ Use space between initial and number
- ✅ Set correct L/E status
- ✅ Choose proper work instructions

### <color=#20B2AA>After Adding</color>  
- ✅ Verify car shows "In Work Order"
- ✅ Confirm car appears in proper sequence
- ✅ Check that all add cars processed before accepting standing order