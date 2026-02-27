# Test Strategy
## Parabank – Fund Transfer & Balance Validation

### 1. Objective

The objective of this assignment is to validate the correctness of the Fund Transfer functionality in the Parabank application, with a strong focus on business logic and financial calculations.

The primary goal is to ensure that account balances are updated accurately after a transfer operation and that the system maintains financial consistency.

---

### 2. Scope

#### In Scope
- User login with valid credentials
- Navigation to Accounts Overview
- Capturing account balances
- Performing fund transfer between accounts
- Verifying transfer confirmation
- Validating post-transaction balance updates

#### Out of Scope
- User registration flow
- Loan processing
- Bill payment functionality
- Performance testing
- Security and penetration testing
- API-level validation

---

### 3. Test Levels Covered

- End-to-End UI Testing
- Functional Testing
- Business Logic Validation
- Financial Calculation Verification

---

### 4. Core Business Validation

The primary validation logic ensures:

- Source Account Balance decreases by transfer amount
- Destination Account Balance increases by transfer amount
- Transfer confirmation message is displayed
- No unexpected state corruption occurs

Special handling is implemented for demo environments where only a single account exists. In such cases, defensive validation ensures test stability without false failures.

---

### 5. Test Approach

#### Automation Design Principles

- Page Object Model (POM) for separation of concerns
- Explicit synchronization (WaitForURL / WaitForSelector)
- No hardcoded balance values
- Dynamic extraction of financial data
- Defensive handling of demo environment variability

#### Data Strategy

- Uses demo credentials (`john/demo`)
- Fixed transfer amount (100)
- Balance values extracted dynamically at runtime
- No assumptions about pre-existing balances

---

### 6. Risk Assessment

| Risk | Mitigation |
|------|------------|
| Demo site instability | Explicit waits and retry-safe structure |
| Account count variability | Dynamic option detection |
| Formatting differences in currency | String sanitization before parsing |
| Test data mutation across runs | Validation based on delta, not fixed values |

---

### 7. Assumptions

- User has at least one valid account
- Sufficient balance is available for transfer
- Demo site behavior remains functionally consistent

---

### 8. Automation Scalability

The framework is designed to be extensible:

- Additional flows can be added via new Page classes
- Supports parallel execution
- Can integrate CI pipelines
- Can be extended with reporting and logging layers

---

### 9. Conclusion

The implemented solution validates financial state transitions rather than UI-only behavior. The focus remains on correctness of business logic, reliability, and maintainability of automation design.