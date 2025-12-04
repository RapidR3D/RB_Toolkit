# MRT AEI Guide - Accept an AEI Read in MRT Work Order

## Overview

This guide provides step-by-step instructions for processing Automated Equipment Identification (AEI) reads in the Mobile Rail Tool Work Order system.

---

## Access the Read

### Method 1: Alert Bell
Use the **alert bell** icon to access the AEI Read.

### Method 2: Menu Icon
Use the **menu icon** (≡) to access the AEI Read.

---

## When There Are No Cars to Handle

If **AEI Errors** and **Add Cars** both show zero:

1. Navigate to **All Cars** tab
2. Tap **ACCEPT AEI STANDING ORDER**

---

## AEI Scan Overview

The AEI Read Selection screen shows three tabs that must be processed in order:

### Tab Navigation Order

**Step 1:** AEI Errors (4)
- Process error cars first
- Report or Exception all AEI Error Cars

**Step 2:** AEI Add Cars (2)
- Process added cars second
- Handle all AEI Add cars

**Step 3:** All Cars (8)
- Accept standing order last
- Only after Steps 1 and 2 are complete

---

## Notification Display

AEI reads appear in the **Notifications** panel:


AEI    Received at 12/28   09:56
AEI Read: 469 2342 Verified


---

## Steps to Process and Accept an AEI Read

To begin, select the AEI Read you want to use:

1. **Process AEI Error cars**
2. **Process AEI Add cars**
3. **Accept AEI Read**

---

## Important Notes

### Car Status Indicators

**Origin of Car:**
- Highlighted cars show where the car originated
- Destination point of car is also highlighted

**Completion Status:**
- **Car is present by the AEI reader** and is waiting to be completed
- **Car either needs to be completed at destination point** or exception coded if it never existed on the train

---

## Screen Layout

The AEI Read Selection screen displays:

### Header Information
- Mobile Rail Tool
- Train: H79605
- WO# 677846
- AEI Read Selection

### Tab Structure
- **ALL AEI READS** (navigation)
- **CANCEL** (exit button)
- **REJECT AEI READ** (rejection option)

### Three Processing Tabs
1. AEI Errors (with count)
2. AEI Add Cars (with count)
3. All Cars (with count)

### Data Columns
- **AEI Standing Seq** - AEI sequence number
- **WO Seq Order** - Work order sequence
- **Car** - Car initial and number
- **Load/Empty** - L or E status
- **From Instruction** - Origin instruction
- **Reported Time** - When reported
- **To Instruction** - Destination instruction
- **TOC/Requestor Name** - Contact information
- **Info** - Status information (AEI OK, In Work Order, AEI Missing, etc.)