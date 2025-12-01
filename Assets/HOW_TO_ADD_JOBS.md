# How to Add New Jobs

To add a new job to the Playbook, follow these steps:

## 1. Create a Job Folder
Navigate to `Assets/StreamingAssets/` and create a new folder. The name of this folder will be the **Job ID** you type into the search bar (e.g., `JobY197`, `JobZ999`).

## 2. Create the `job.json` File
Inside the new folder, create a file named `job.json`. You can copy the `job.json` from the `JobTemplate` folder as a starting point.

Structure of `job.json`:
```json
{
  "jobNumber": "Y197",
  "jobName": "RCO HUMP",
  "craft": "FOREMAN",
  "onduty": "0630",
  "location": "Crew Room",
  "sections": [
    { "label": "Summary", "file": "summary.md" }
  ],
  "tables": [
    { "name": "Contacts", "file": "contacts.csv" }
  ],
  "procedures": [
    { "name": "Brake Test", "file": "brake_test.md" }
  ],
  "images": [
    { "name": "Yard Map", "file": "yard_map.png" },
    { "name": "Schematic", "file": "schematic.png" }
  ]
}
```

## 3. Add Content Files
Create the Markdown (`.md`), CSV (`.csv`), and Image (`.png`, `.jpg`) files referenced in your `job.json`.
- **Markdown (.md)**: Used for text content like Summaries and Procedures. Supports headers, lists, and basic formatting.
- **CSV (.csv)**: Used for tabular data like Contacts. The first line should be the headers (e.g., `Name,Role,Phone`).
- **Images (.png, .jpg)**: Place your image files in the same folder. Reference them in the `images` section of `job.json`.

## 4. Test
1. Play the game.
2. Type the folder name (e.g., `JobZ999`) into the search bar.
3. Click "Load Job".

## Tips
- Ensure file names in `job.json` match exactly with the files in the folder (case-sensitive).
- You can reuse common files (like a standard procedure) by copying them into the new folder.
