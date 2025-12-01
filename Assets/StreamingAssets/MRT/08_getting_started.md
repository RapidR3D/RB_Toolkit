# Getting Started with MRT

## Initial Tablet Setup

### Step 1: Wake Up Your Tablet
1. Press the **Power Button**
2. The screen will illuminate

### Step 2: Unlock Screen
1. **Tap the screen** to access unlock screen
2. **Swipe up** on the lock screen
3. Input your **4-digit PIN**
4. Tap to confirm

### Step 3: Launch Mobile Rail Tool
1. Locate the **Mobile Rail Tool Flex** app icon
2. Tap to open the application

### Step 4: Login with Okta
1. Tap the **Login with Okta** button
2. Input your **RACF ID**
3. Input your **password**
4. Tap the **Sign in** button
5. Complete Okta authentication (push notification or verification code)

---

## Tool Selection Screen

After logging in, you'll see three primary tools:

### 1. Switch Planning Tool (SPT)
**Purpose:** Build outbound trains and generate work orders

**Use for:**
- Creating new work orders
- Applying planned work
- Adding locomotives and EOT
- Inputting service exceptions

### 2. Mobile Work Order
**Purpose:** Complete and report train work

**Use for:**
- Downloading active work orders
- Reporting customer work
- Handling station pickups and set outs
- Managing AEI reads
- Completing work orders

### 3. Yard Switching Tool (YST)
**Purpose:** Move cars within yards

**Use for:**
- Manual switch lists
- Automated switch lists
- Track-to-track movements
- Bad order reporting

---

## Daily Workflow Overview

### For Yard Jobs (Step-by-Step)

#### Before Starting Work
1. ✅ Tablet fully charged
2. ✅ Tablet restarted (not powered down)
3. ✅ Content app updated
4. ✅ OKTA configured for push notifications

#### Step 1: Access Yard Switching Tool
**Purpose:** Update or input switch lists for yard movements

**Actions:**
- Login to Yard Switching Tool
- Update automated switch lists
- Input manual switch lists

#### Step 2: Access Switch Planning Tool
**Purpose:** Build your outbound train

**Actions:**
- Login to SPT for your train
- Review planned work
- Add all cars you're taking
- Add locomotives and EOT
- Input service exceptions if needed
- Submit SPT build
- Retrieve printed work order

#### Step 3: Access Mobile Work Order
**Purpose:** Report all work performed

**Actions:**
- Login to Mobile Work Order
- Download your work order
- Report origin pickup
- Depart train
- Take tablet with you on train

#### Step 4: En Route
**Put device in sleep mode** (press power button once)
**Keep tablet with you** on the train

#### Step 5: At Each Location
- Report customer work (places, pulls, intraplants)
- Report station work (pickups, set outs)
- Handle AEI reads
- Check notifications

#### Step 6: Complete Work Order
- Ensure all tiles show 100% Complete
- Report locomotives
- Logout of MRT

---

## Work Order Search

### Search Method 1: Train ID with Date

Train ID: L83207
Date: Automatically included
Milepost: (only for yard jobs)


### Search Method 2: Work Order Number

Work Order #: 677637
Milepost: (only for yard jobs)


### For Yard Jobs ONLY
**You MUST include the terminal milepost:**

Train ID: 070729
Milepost: AY 856


### Executing Search
- **iPad:** Tap **RETURN** key
- **Samsung:** Tap **GO** key

---

## Understanding the Interface

### Navigation Elements

#### Top Bar
- Train ID and Work Order number
- Current location/milepost
- Back button
- Help button

#### Main Tiles
Each tile represents work at a location:
- 🏭 **Customer tiles** (places, pulls, intraplants)
- 🚂 **Station tiles** (pickups, set outs)
- 🔄 **Interchange tiles** (deliver, receive)

#### Tile Information
- Location name and milepost
- Planned work count
- Applied work count
- Completion percentage
- EAC (Estimated Arrival to Customer) time

#### Bottom Navigation
- Menu button (☰)
- Add Work button
- Notification bell (🔔)

---

## Tile Color System

### Color Indicators

| Color | Status | Meaning |
|-------|--------|---------|
| 🔵 Blue | Active | Work available to perform |
| ⚪ White | Pending | Work not yet started |
| 🟢 Green | Complete | All work reported |
| ⚫ Grey | Done | 100% Complete, no action needed |

### Completion Percentages
- **0%** - No work reported yet
- **50%** - Some work completed
- **100%** - All planned work reported
- **COMPLETED 100%** - Entire work order done

---

## Sleep Mode vs. Power Down

### Sleep Mode ✅ (Recommended)
**How:** Press power button once
**When:** Between work locations, during travel
**Why:** Quick wake-up, maintains connections

### Power Down ❌ (Avoid)
**How:** Hold power button, select Power Off
**When:** Only at end of shift after logging out
**Why:** Prevents overnight updates, slower restart

### Restart ✅ (Daily Requirement)
**How:** Hold power button, select Restart, confirm
**When:** End of each shift
**Why:** Applies updates, clears memory, maintains performance

---

## Critical Daily Habits

### Morning Checklist
- [ ] Tablet charged overnight
- [ ] Restart tablet (from last night)
- [ ] Check Settings → Sync Hub
- [ ] Check Settings → Reload Profile (if apps missing)
- [ ] Verify OKTA working
- [ ] Check Content app for updates

### During Shift
- [ ] Report work in real-time
- [ ] Check notification bell regularly
- [ ] Handle AEI reads promptly
- [ ] Keep tablet with you on train

### End of Shift
- [ ] Complete all work tiles to 100%
- [ ] Report locomotives
- [ ] Logout of MRT (Menu → Logout)
- [ ] Close all apps (3 vertical lines → Close All)
- [ ] Restart tablet (not power down!)
- [ ] Place on charger

---

## First-Time Setup Checklist

### OKTA Configuration
1. Open OKTA app on tablet
2. Add your account
3. Enable push notifications
4. Test authentication

### Content App Setup
1. Open Content app
2. Navigate to CSX folder
3. Download all required documents:
   - CSX Rule Books
   - System Bulletins & Notices
   - Subdivision Bulletins & Notices
   - Timetables
4. Download location-specific materials
5. Tap blue arrows to convert to PDFs

### OneDrive Setup (Backup)
1. Locate OneDrive on Page 2 of tablet
2. Login with CSX credentials
3. Configure sync settings
4. Open every few days to update

---

## Getting Help

### In-App Help
- Tap **GET HELP HERE** button (top right of most screens)
- Access context-sensitive help
- View quick tips

### Menu Options
Tap Menu (☰) to access:
- Undo Last Reporting
- AEI Reads
- Error Cars
- EAC Review
- Yard Switching Tool
- Customer Insights
- Send Client Logs
- About (version info, MQTT status)
- Logout

### About Screen
Shows critical system information:
- App Version (should be 2.0.6000 for iPad)
- MQTT Connected: **Must show YES**
- MQTT Subscribed: **Must show YES**
- MQTT Client ID
- MQTT Subscriptions

### Support Contacts

| Issue Type | Number | Option |
|------------|--------|--------|
| Cannot login to MRT | 800-243-7743 | #4 |
| App errors/crashes | 800-243-7743 | #4 |
| Cannot input work | 800-243-7743 | #4 |
| Tablet hardware | 800-243-7743 | #2 |
| Printer/fax issues | 800-243-7743 | #3 |

---

## Common First-Day Questions

### Q: Do I need WiFi or cellular?
**A:** Cellular is primary. WiFi helpful at terminals but not required.

### Q: What if I lose signal?
**A:** MRT queues data and syncs when signal returns. Keep working offline.

### Q: Can I use MRT on my personal device?
**A:** No. Only approved CSX tablets with proper security.

### Q: How do I know my data saved?
**A:** After logout, you'll see "Log in with Okta" button. That confirms data posted.

### Q: What if I make a mistake?
**A:** Use Menu → Undo Last Reporting (within 4 minutes) or call MRT Helpdesk.

### Q: Do I need to print anything?
**A:** SPT generates printed work order. Keep it as reference during your shift.

---

## Quick Start: Your First Work Order

1. **Login** → Select Mobile Work Order
2. **Search** → Input Train ID or WO# (+ milepost for yard jobs)
3. **Download** → Work order appears with tiles
4. **Service Equipment** → Add locomotives and EOT
5. **Origin Pickup** → Select departing cars
6. **Train Standing Order** → Verify/adjust car sequence
7. **EAC** → Input estimated arrival times for customers
8. **Departure Time** → Input when you left origin
9. **Travel** → Put tablet in sleep mode
10. **Report Work** → At each location, complete the tiles
11. **AEI Reads** → Handle inbound/outbound scans
12. **Complete** → All tiles show 100%
13. **Logout** → Menu → Logout

**Congratulations!** You've completed your first MRT work order. 🎉

---

## Pro Tips

### Speed Tips
- Use Select All when taking entire cuts
- Use Select Range for continuous strings of cars
- Keep commonly-used exception reasons noted
- Report work immediately, not batch at end

### Accuracy Tips
- Double-check car initials and numbers
- Verify FROM and TO instructions
- Use correct customer codes (not track names)
- Input actual times, backdate when necessary

### Efficiency Tips
- Review SPT before building work order
- Have equipment numbers ready
- Know your yard track layout
- Memorize common exception codes

### Safety Tips
- Keep tablet secure during movement
- Don't operate device while train is moving
- Maintain situational awareness
- Report safety issues via proper channels (not just Customer Insights)