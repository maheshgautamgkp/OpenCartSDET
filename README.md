# SDET Take-Home Assignment
## Application: Parabank
## Scenario: Fund Transfer & Balance Validation

---

## Overview

This project validates the Fund Transfer functionality of the Parabank application using C# and Playwright (.NET).

The focus of this implementation is business logic validation — specifically, verifying that account balances are updated correctly after a transfer operation.

---

## Technology Stack

- Language: C#
- Framework: .NET 8 / 10
- UI Automation: Playwright for .NET
- Test Framework: NUnit
- Assertions: FluentAssertions
- Design Pattern: Page Object Model (POM)

---

## Project Structure

OpenCartSDET  
│  
├── Core  
│   └── BaseTest.cs  
│  
├── Pages  
│   ├── LoginPage.cs  
│   ├── AccountsPage.cs  
│   └── TransferPage.cs  
│  
├── Tests  
│   └── ParabankTests.cs  
│  
├── README.md  
└── TestStrategy.md  

---

## Design Decisions

### 1. Page Object Model
All UI interactions are encapsulated within dedicated Page classes to maintain separation between test logic and UI behavior.

### 2. Synchronization Strategy
Explicit waits are used for:
- URL transitions
- Element visibility
- Post-transfer confirmation

This avoids brittle timing dependencies.

### 3. Dynamic Business Validation
Balances are captured dynamically before and after transfer. Assertions validate delta changes rather than fixed values.

### 4. Defensive Automation
The demo environment may provide only one account. The implementation dynamically detects account availability to prevent false negatives.

---

## How to Run

1. Clone the repository
2. Navigate to project folder
3. Restore dependencies:

   dotnet restore

4. Install Playwright browsers:

   dotnet build  
   .\bin\Debug\net10.0\playwright.ps1 install  

5. Execute tests:

   dotnet test  

Or run via Test Explorer in Visual Studio.

---

## Scenario Covered

### Transfer Funds & Validate Balances

- Login using demo credentials
- Capture initial account balances
- Perform transfer of fixed amount (100)
- Validate confirmation message
- Re-fetch balances
- Validate financial correctness

---

## Possible Enhancements

- Screenshot capture on failure
- Structured logging
- CI/CD integration (GitHub Actions)
- Parallel test execution
- Data-driven testing

---

## Notes

This implementation focuses on correctness of financial state transitions rather than UI-only verification. Emphasis has been placed on maintainability, synchronization reliability, and defensive automation design.
