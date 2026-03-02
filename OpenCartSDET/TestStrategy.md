# Test Strategy  
## Parabank – Fund Transfer & Balance Validation (BDD Implementation)

---

## 1. Objective

The objective of this assignment is to validate the correctness of the Fund Transfer functionality in the Parabank application using a Behavior Driven Development (BDD) approach.

The primary focus is on verifying financial business logic, ensuring that account balances are accurately updated after a transfer operation and that transactional state transitions are correct.

The automation solution emphasizes maintainability, reliability, and business-level validation rather than UI-only verification.

---

## 2. Scope

### In Scope

- User authentication (login)
- Navigation to Accounts Overview
- Dynamic extraction of account balances
- Transfer of funds between accounts
- Validation of transfer confirmation message
- Validation of financial balance updates
- CI/CD execution of automated tests

### Out of Scope

- User registration
- Loan requests
- Bill payment functionality
- Performance testing
- Security testing
- API-level validation

---

## 3. Test Levels Covered

- End-to-End UI Testing
- Functional Testing
- Business Logic Validation
- Financial Calculation Verification
- CI Pipeline Validation

---

## 4. Test Approach – BDD Driven

The solution is implemented using **SpecFlow (BDD framework)** with Gherkin syntax.

### Feature Representation

Business behavior is described using:

- Feature
- Scenario
- Given / When / Then

This ensures that test scenarios are readable, business-aligned, and traceable.

Example scenario:

- Given the user logs into Parabank  
- And the user captures initial account balances  
- When the user transfers 100 dollars  
- Then the transfer should be successful  
- And account balances should be updated correctly  

This bridges the gap between business requirements and technical implementation.

---

## 5. Core Business Validation

The automation validates:

- Source account balance decreases by the transfer amount
- Destination account balance increases by the transfer amount
- Transfer confirmation is displayed
- No unexpected balance corruption occurs

To handle demo environment variability, defensive logic detects account availability dynamically to avoid brittle assumptions.

---

## 6. Automation Design Principles

### 6.1 Architecture

The framework follows a layered design:

- Feature Layer (BDD scenarios)
- Step Definition Layer (Glue logic)
- Page Object Layer (UI abstraction)
- Test Infrastructure Layer (Browser lifecycle management)

### 6.2 Design Patterns Used

- Page Object Model (POM)
- Constructor-based Dependency Injection
- Explicit Synchronization Strategy
- Defensive Automation Strategy

### 6.3 SOLID Principles Applied

- **Single Responsibility Principle** – Each class has one responsibility.
- **Open/Closed Principle** – Framework can be extended with new features without modifying existing logic.
- **Dependency Inversion Principle** – Page classes depend on abstractions (IPage) rather than concrete implementations.

---

## 7. Synchronization Strategy

Explicit synchronization is implemented using:

- WaitForURLAsync
- WaitForSelectorAsync

Thread.Sleep is avoided to reduce flakiness and ensure deterministic execution.

---

## 8. Test Data Strategy

- Uses demo credentials (john/demo)
- Fixed transfer amount (100)
- Balance values extracted dynamically at runtime
- No hardcoded financial values
- Validation performed using delta comparison (Before vs After)

Financial calculations are handled using the `decimal` data type to ensure precision.

---

## 9. Risk Assessment

| Risk | Mitigation |
|------|------------|
| Demo site instability | Explicit waits and resilient selectors |
| Account count variability | Dynamic dropdown detection |
| Currency formatting differences | Sanitization before parsing |
| Test data mutation | Delta-based validation approach |
| CI environment differences | Automated Playwright browser installation |

---

## 10. CI/CD Integration

A GitHub Actions pipeline is implemented to:

- Restore .NET dependencies
- Build the project
- Install Playwright browsers
- Execute SpecFlow BDD tests

The pipeline runs automatically on push and pull requests, ensuring continuous validation of the automation suite.

---

## 11. Scalability & Extensibility

The framework is designed to support:

- Additional banking flows
- Data-driven scenarios
- Parallel test execution
- Integration with reporting tools
- Screenshot capture on failure
- CI/CD extensions

---

## 12. Conclusion

This implementation focuses on validating financial state transitions rather than superficial UI verification.

By combining BDD principles, robust synchronization, financial precision handling, and CI/CD automation, the solution demonstrates a scalable and maintainable automation design aligned with real-world SDET expectations.