# <color=#FFD700>Getting Started with MRT</color>  

## <color=#FF8C00>Initial Tablet Setup</color>  

### <color=#20B2AA>Step 1: Wake Up Your Tablet</color>  
1. Press the **Power Button**  
2. The screen will illuminate  

### <color=#20B2AA>Step 2: Unlock Screen</color>  
1. **Tap the screen** to access unlock screen  
2. **Swipe up** on the lock screen  
3. Input your **4-digit PIN**  
4. Tap to confirm  

### <color=#20B2AA>Step 3: Launch Mobile Rail Tool</color>  
1. Locate the **Mobile Rail Tool Flex** app icon  
2. Tap to open the application  

### <color=#20B2AA>Step 4: Login with Okta</color>  
1. Tap the **Login with Okta** button  
2. Input your **RACF ID**  
3. Input your **password**  
4. Tap the **Sign in** button  
5. Complete Okta authentication (push notification or verification code)  

---

## <color=#FF8C00>Tool Selection Screen</color>  

After logging in, you'll see three primary tools:  

### <color=#20B2AA>1. Switch Planning Tool (SPT)</color>  
<color=#FF8C00>**Purpose:**</color> Build outbound trains and generate work orders  

<color=#FF8C00>**Use for:**</color>  
- Creating new work orders
- Applying planned work
- Adding locomotives and EOT
- Inputting service exceptions

### <color=#20B2AA>2. Mobile Work Order</color>  
<color=#FF8C00>**Purpose:**</color> Complete and report train work  

<color=#FF8C00>**Use for:**</color>  
- Downloading active work orders
- Reporting customer work
- Handling station pickups and set outs
- Managing AEI reads
- Completing work orders

### <color=#20B2AA>3. Yard Switching Tool (YST)</color>  
<color=#FF8C00>**Purpose:**</color> Move cars within yards  

<color=#FF8C00>**Use for:**</color>  
- Manual switch lists
- Automated switch lists
- Track-to-track movements
- Bad order reporting

---

## <color=#FF8C00>Daily Workflow Overview</color>  

### <color=#20B2AA>For Yard Jobs (Step-by-Step)</color>  

#### Before Starting Work
1. ✅ Tablet fully charged  
2. ✅ Tablet restarted (not powered down)  
3. ✅ Content app updated  
4. ✅ OKTA configured for push notifications  

#### Step 1: Access Yard Switching Tool
<color=#FF8C00>**Purpose:**</color> Update or input switch lists for yard movements  

<color=#FF8C00>**Actions:**</color>  
- Login to Yard Switching Tool
- Update automated switch lists
- Input manual switch lists

#### Step 2: Access Switch Planning Tool
<color=#FF8C00>**Purpose:**</color> Build your outbound train  

<color=#FF8C00>**Actions:**</color>  
- Login to SPT for your train
- Review planned work
- Add all cars you're taking
- Add locomotives and EOT
- Input service exceptions if needed
- Submit SPT build
- Retrieve printed work order

#### Step 3: Access Mobile Work Order
<color=#FF8C00>**Purpose:**</color> Report all work performed  

<color=#FF8C00>**Actions:**</color>  
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

## <color=#FF8C00>Work Order Search</color>  

### <color=#20B2AA>Search Method 1: Train ID with Date</color>  

Train ID: L83207  
Date: Automatically included  
Milepost: (only for yard jobs)  


### <color=#20B2AA>Search Method 2: Work Order Number</color>  

Work Order #: 677637  
Milepost: (only for yard jobs)  


### <color=#20B2AA>For Yard Jobs ONLY</color>  
<color=#FF8C00>**You MUST include the terminal milepost:**</color>  

Train ID: 070729  
Milepost: AY 856  


### <color=#20B2AA>Executing Search</color>  
- <color=#FF8C00>**iPad:**</color> Tap **RETURN** key
- <color=#FF8C00>**Samsung:**</color> Tap **GO** key

---

## <color=#FF8C00>Understanding the Interface</color>  

### <color=#20B2AA>Navigation Elements</color>  

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

## <color=#FF8C00>Tile Color System</color>  

### <color=#20B2AA>Color Indicators</color>  

| Color | Status | Meaning |  
|-------|--------|---------|  
| 🔵 Blue | Active | Work available to perform |  
| ⚪ White | Pending | Work not yet started |  
| 🟢 Green | Complete | All work reported |  
| ⚫ Grey | Done | 100% Complete, no action needed |  

### <color=#20B2AA>Completion Percentages</color>  
- **0%** - No work reported yet
- **50%** - Some work completed
- **100%** - All planned work reported
- **COMPLETED 100%** - Entire work order done

---

## <color=#FF8C00>Sleep Mode vs. Power Down</color>  

### <color=#20B2AA>Sleep Mode ✅ (Recommended)</color>  
<color=#FF8C00>**How:**</color> Press power button once  
<color=#FF8C00>**When:**</color> Between work locations, during travel  
<color=#FF8C00>**Why:**</color> Quick wake-up, maintains connections  

### <color=#20B2AA>Power Down ❌ (Avoid)</color>  
<color=#FF8C00>**How:**</color> Hold power button, select Power Off  
<color=#FF8C00>**When:**</color> Only at end of shift after logging out  
<color=#FF8C00>**Why:**</color> Prevents overnight updates, slower restart  

### <color=#20B2AA>Restart ✅ (Daily Requirement)</color>  
<color=#FF8C00>**How:**</color> Hold power button, select Restart, confirm  
<color=#FF8C00>**When:**</color> End of each shift  
<color=#FF8C00>**Why:**</color> Applies updates, clears memory, maintains performance  

---

## <color=#FF8C00>Critical Daily Habits</color>  

### <color=#20B2AA>Morning Checklist</color>  
- [ ] Tablet charged overnight
- [ ] Restart tablet (from last night)
- [ ] Check Settings → Sync Hub
- [ ] Check Settings → Reload Profile (if apps missing)
- [ ] Verify OKTA working
- [ ] Check Content app for updates

### <color=#20B2AA>During Shift</color>  
- [ ] Report work in real-time
- [ ] Check notification bell regularly
- [ ] Handle AEI reads promptly
- [ ] Keep tablet with you on train

### <color=#20B2AA>End of Shift</color>  
- [ ] Complete all work tiles to 100%
- [ ] Report locomotives
- [ ] Logout of MRT (Menu → Logout)
- [ ] Close all apps (3 vertical lines → Close All)
- [ ] Restart tablet (not power down!)
- [ ] Place on charger

---

## <color=#FF8C00>First-Time Setup Checklist</color>  

### <color=#20B2AA>OKTA Configuration</color>  
1. Open OKTA app on tablet  
2. Add your account  
3. Enable push notifications  
4. Test authentication  

### <color=#20B2AA>Content App Setup</color>  
1. Open Content app  
2. Navigate to CSX folder  
3. Download all required documents:  
   - CSX Rule Books
   - System Bulletins & Notices
   - Subdivision Bulletins & Notices
   - Timetables
4. Download location-specific materials  
5. Tap blue arrows to convert to PDFs  

### <color=#20B2AA>OneDrive Setup (Backup)</color>  
1. Locate OneDrive on Page 2 of tablet  
2. Login with CSX credentials  
3. Configure sync settings  
4. Open every few days to update  

---

## <color=#FF8C00>Getting Help</color>  

### <color=#20B2AA>In-App Help</color>  
- Tap **GET HELP HERE** button (top right of most screens)
- Access context-sensitive help
- View quick tips

### <color=#20B2AA>Menu Options</color>  
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

### <color=#20B2AA>About Screen</color>  
Shows critical system information:  
- App Version (should be 2.0.6000 for iPad)
- MQTT Connected: **Must show YES**
- MQTT Subscribed: **Must show YES**
- MQTT Client ID
- MQTT Subscriptions

### <color=#20B2AA>Support Contacts</color>  

| Issue Type | Number | Option |  
|------------|--------|--------|  
| Cannot login to MRT | 800-243-7743 | #4 |  
| App errors/crashes | 800-243-7743 | #4 |  
| Cannot input work | 800-243-7743 | #4 |  
| Tablet hardware | 800-243-7743 | #2 |  
| Printer/fax issues | 800-243-7743 | #3 |  

---

## <color=#FF8C00>Common First-Day Questions</color>  

### <color=#20B2AA>Q: Do I need WiFi or cellular?</color>  
<color=#FF8C00>**A:**</color> Cellular is primary. WiFi helpful at terminals but not required.  

### <color=#20B2AA>Q: What if I lose signal?</color>  
<color=#FF8C00>**A:**</color> MRT queues data and syncs when signal returns. Keep working offline.  

### <color=#20B2AA>Q: Can I use MRT on my personal device?</color>  
<color=#FF8C00>**A:**</color> No. Only approved CSX tablets with proper security.  

### <color=#20B2AA>Q: How do I know my data saved?</color>  
<color=#FF8C00>**A:**</color> After logout, you'll see "Log in with Okta" button. That confirms data posted.  

### <color=#20B2AA>Q: What if I make a mistake?</color>  
<color=#FF8C00>**A:**</color> Use Menu → Undo Last Reporting (within 4 minutes) or call MRT Helpdesk.  

### <color=#20B2AA>Q: Do I need to print anything?</color>  
<color=#FF8C00>**A:**</color> SPT generates printed work order. Keep it as reference during your shift.  

---

## <color=#FF8C00>Quick Start: Your First Work Order</color>  

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

## <color=#FF8C00>Pro Tips</color>  

### <color=#20B2AA>Speed Tips</color>  
- Use Select All when taking entire cuts
- Use Select Range for continuous strings of cars
- Keep commonly-used exception reasons noted
- Report work immediately, not batch at end

### <color=#20B2AA>Accuracy Tips</color>  
- Double-check car initials and numbers
- Verify FROM and TO instructions
- Use correct customer codes (not track names)
- Input actual times, backdate when necessary

### <color=#20B2AA>Efficiency Tips</color>  
- Review SPT before building work order
- Have equipment numbers ready
- Know your yard track layout
- Memorize common exception codes

### <color=#20B2AA>Safety Tips</color>  
- Keep tablet secure during movement
- Don't operate device while train is moving
- Maintain situational awareness
- Report safety issues via proper channels (not just Customer Insights)