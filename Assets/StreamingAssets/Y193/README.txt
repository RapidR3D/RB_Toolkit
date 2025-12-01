Job Y197 Data Package

This folder contains structured data for Yard Job Y197 (RCO HUMP), suitable for loading into a Unity application.

Files:
- job.json              : Main metadata and file references for this job.
- summary.md            : High-level job summary and basic details.
- radio_procedures.md   : Radio phrases and operating notes.
- contacts.csv          : Key contacts and phone numbers.
- address.csv           : Yard office address information.
- territory.csv         : Territory and subdivision pay-claim codes.
- test_procedures/      : Detailed test procedures in markdown format.

You can point your Unity data loader at this folder, parse job.json, and then read the referenced markdown and CSV files to populate your in-app UI.
