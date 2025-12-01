# (2) AEI Added Cars

## Definition

**AEI Added Cars:** Cars on your train but not on your work order.

---

## Processing Steps

### Step 1: Select AEI Added Cars

Navigate to the **AEI Add Cars** tab.

---

## Actions Required

### Option 1: Add Work (From/To)

For cars that should be on your train:

1. Select the **AEI Added Cars**
2. Set **LE** (Load/Empty) status if needed
3. Add work with proper **FROM** and **TO** instructions

---

## AEI OK Cars

### Definition
**AEI OK Cars:** Cars on your train AND on your work order.

### Status
Once all cars show **AEI OK**, you can accept the AEI Scan.

---

## Example Display

### AEI Add Cars Tab

**Column Headers:**
| AEI Standing Seq | WO Seq Order | Car | Load/Empty | From Instruction | Reported Time | To Instruction | TOC/Requestor Name | Info |
|------------------|--------------|-----|------------|------------------|---------------|----------------|-------------------|------|

### Sample Added Car Entry


Seq: 001   WO: ADD
Car: CSXT 2092
L/E: L
From: (to be set)
To: (to be set)
Info: AEI Added


**Highlighted Row:**
Seq: U72   WO: ADD
Car: AEI ##7166A
Status: AEI Added (highlighted in green)

---

## Add Work Process

### Step 1: Select Car
Tap and select the car that needs to be added.

### Step 2: Set Initial Number
1. Tap **Set Initial Number**
2. A pop-up box will open

### Step 3: Enter Car Details

**Pop-up: "Please enter new car details:"**

┌─────────────────────────────────────┐
│ Please enter new car details:       │
│                                     │
│ ENTER CAR INITIAL & NUMBER          │
│ [                                ]  │
│                                     │
│         [Submit]                    │
└─────────────────────────────────────┘

### Step 4: Input Information
1. Enter the **car initial**, **space**, and the **car number**
2. Click **Submit**

### Step 5: Set Load/Empty Status
Then, indicate the **Load/Empty** status using the **Set Loaded** or **Set Empty** button.

### Step 6: Add to Work Order
If there is no car, or you're unsure of the car type, select the car and tap the **Skip/Unskip Car** button.

---

## Scenario Example

### Situation
Two cars show missing but the conductor verified they are on the train.

**Actions:**

1. Check the **Add Cars** tab for **AEI Placeholder cars**
2. There is one car (position 72)
3. Tap and select **the car** that is there
4. Tap **Set Initial Number**
5. A pop-up box will open
6. Input the railcar that is present in that spot by entering the **car initial**, **space**, and the **car number**
7. Then, tap **Submit**

---

## Status Information

### Info Column Values

**AEI Added**
- Car scanned by AEI
- Not on work order
- Needs to be added

**In Work Order** (after adding)
- Car successfully added
- Now part of work order
- Ready for processing

---

## Important Notes

### Add Work Requirements
When adding cars, you must provide:
- ✅ Car initial and number
- ✅ Load/Empty (L/E) status
- ✅ FROM instruction (where you got it)
- ✅ TO instruction (where you're taking it)

### Skip/Unskip Option
Use **Skip/Unskip Car** when:
- No car is present at that position
- Unsure of car type
- Need to bypass placeholder

---

## Best Practices

### Before Adding Work
- ✅ Visually verify car is in train
- ✅ Confirm car initial and number
- ✅ Check load/empty status
- ✅ Know where car came from (FROM)
- ✅ Know where car is going (TO)

### During Add Work
- ✅ Enter car details accurately
- ✅ Use space between initial and number
- ✅ Set correct L/E status
- ✅ Choose proper work instructions

### After Adding
- ✅ Verify car shows "In Work Order"
- ✅ Confirm car appears in proper sequence
- ✅ Check that all add cars processed before accepting standing order