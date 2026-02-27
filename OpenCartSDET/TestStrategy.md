# Test Strategy – Cart Management & Price Validation

## 1. Objective

Validate cart functionality and price calculation logic on OpenCart demo application.

URL: https://demo.opencart.com

---

## 2. Scope

### In Scope
- Add product to cart
- Update product quantity
- Validate unit price
- Validate total calculation
- Remove product from cart

### Out of Scope
- Payment gateway validation
- Backend API validation
- Performance testing
- Security testing

---

## 3. Test Levels

- UI Testing (End-to-End)
- Functional Testing
- Business Logic Validation

---

## 4. Test Types

- Positive Testing
- Boundary Testing (Quantity)
- Regression Testing
- UI Automation

---

## 5. Key Test Scenarios

1. Add product with quantity > 1 and validate total
2. Remove product and validate empty cart message
3. Validate calculation logic dynamically

---

## 6. Assumptions

- Product prices remain constant during execution
- No login required
- Tax calculation remains consistent

---

## 7. Risks

- UI locator instability
- Demo site availability
- Currency formatting changes

---

## 8. Automation Strategy

- Playwright for .NET used
- Page Object Model design
- Explicit navigation and validation
- Independent test execution

---

## 9. Test Data Strategy

- Using publicly available demo products
- Dynamic extraction of price from UI
- Avoiding hardcoded values

---

## 10. Reporting

- NUnit test results
- Console output
- Extensible for CI/CD integration