# Baobab Ridge Wildlife Rehabilitation Records System

## Team Members
- Member 1: Suhaan Mooni - 603344
- Member 2: Kganya Phale - 603862 
- Member 3: Amonique van Zyl - 604294

## Project Description
This project is a C# Windows Forms application that manages wildlife rehabilitation records. 

## Features
- Add Animals
- View Animals
- Update Animals
- Delete Animals
- Generate Summary Reports 

## How to Build and Run
1. Clone the repository from GitHub.
2. Open `Project.slnx` in Visual Studio 2022 (latest update) or Visual Studio 2026.
3. The project targets .NET 8 (`net8.0-windows`). It also runs on newer .NET versions if .NET 8 is not installed.
4. Press F5 to build and run. The starter `animals.txt` is copied next to the .exe automatically.

## File Formats

### animals.txt
Stores one animal record per line.

The fields are:
AnimalID | Name | Species | Age | Recovery Score | Status | Housing unit

### summary.txt
Contains the generated summary report with: 
- Total number of animals
- Average age
- Average recovery score
- Number of animals per status

## Known Limitations
None currently known.