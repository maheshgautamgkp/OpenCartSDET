# SDET Assignment  
## Application: Parabank  
## Scenario: Fund Transfer & Balance Validation (BDD Implementation)

---

## Overview

This project automates and validates the Fund Transfer functionality of the Parabank application using a Behavior Driven Development (BDD) approach.

The primary focus of this implementation is **financial business logic validation**, ensuring that account balances are updated correctly after a transfer operation.

The framework is designed for scalability, maintainability, and CI/CD readiness.

---

## Technology Stack

- Language: C#
- Framework: .NET 10
- BDD Framework: SpecFlow
- UI Automation: Playwright for .NET
- Test Framework: NUnit
- Assertions: FluentAssertions
- Design Pattern: Page Object Model (POM)
- CI/CD: GitHub Actions

---

## Architecture Overview

The framework follows a layered automation architecture:

OpenCartSDET  
│  
├── Core  
│   └── BaseTest.cs (Browser lifecycle management)  
│  
├── Pages  
│   ├── LoginPage.cs  
│   ├── AccountsPage.cs  
│   └── TransferPage.cs  
│  
├── Features  
│   └── TransferFunds.feature (BDD Scenario)  
│  
├── StepDefinitions  
│   └── TransferSteps.cs 
│  
├── README.md  
└── TestStrategy.md  

---

## BDD Approach

The solution uses SpecFlow to define behavior in Gherkin format:

Example Scenario:

- Given the user logs into Parabank  
- And the user captures initial account balances  
- When the user transfers 100 dollars  
- Then the transfer should be successful  
- And account balances should be updated correctly  

This ensures:

- Clear business readability
- Alignment between requirement and automation
- Separation of behavior and implementation

---

## Design Decisions

### 1. Page Object Model (POM)

All UI interactions are encapsulated in Page classes.  
This ensures separation of concerns and maintainability.

### 2. Explicit Synchronization

The framework uses:

- WaitForURLAsync
- WaitForSelectorAsync

Thread.Sleep is intentionally avoided to reduce flakiness.

### 3. Financial Validation Strategy

Balances are captured dynamically before and after transfer.

Assertions validate:

- Source account decreases by transfer amount
- Destination account increases by transfer amount

Validation is delta-based, not dependent on hardcoded values.

### 4. Defensive Automation

Demo environment variability is handled by:

- Dynamic dropdown option detection
- Currency sanitization before parsing
- Decimal-based financial comparison

---

## CI/CD Integration

This project includes a GitHub Actions pipeline that:

- Restores .NET dependencies
- Builds the project
- Installs Playwright browsers
- Executes BDD test scenarios

The pipeline runs automatically on push and pull requests.

This ensures:

- Continuous validation
- Early failure detection
- Automation stability

---

## How to Run Locally

1. Clone the repository
2. Navigate to repository root

   dotnet restore

3. Build the project

   dotnet build

4. Install Playwright browsers

   pwsh OpenCartSDET/bin/Debug/net10.0/playwright.ps1 install

5. Run tests

   dotnet test

You can also execute tests via Visual Studio Test Explorer.

---

## Scenario Covered

### Fund Transfer & Balance Validation

- Login using demo credentials
- Capture initial balances
- Transfer fixed amount (100)
- Validate transfer confirmation
- Re-capture balances
- Validate financial correctness

---

## SOLID Principles Applied

- Single Responsibility Principle – Each class has a single responsibility.
- Open/Closed Principle – Framework is extendable without modifying core logic.
- Dependency Inversion Principle – Pages depend on Playwright abstractions.

---

## Possible Enhancements

- Screenshot capture on failure
- Structured logging
- Allure or HTML reporting
- Parallel test execution
- Data-driven BDD scenarios
- Dockerized test execution

---

## Conclusion

This implementation focuses on validating financial state transitions rather than UI-only behavior.

By combining BDD principles, robust synchronization, financial precision handling, and CI/CD integration, the solution demonstrates a scalable and production-ready automation design aligned with modern SDET practices.
