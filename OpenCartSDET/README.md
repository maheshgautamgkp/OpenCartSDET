# OpenCart SDET Take-Home Assignment
Flow 4 – Cart Management & Price Validation

## 🔹 Tech Stack

- Language: C#
- Framework: .NET 10
- UI Automation: Microsoft Playwright for .NET
- Test Framework: NUnit
- Assertion Library: FluentAssertions
- Design Pattern: Page Object Model (POM)

---

## 🔹 Project Structure

OpenCartSDET
│
├── Core
│   └── BaseTest.cs
│
├── Pages
│   ├── HomePage.cs
│   ├── ProductPage.cs
│   └── CartPage.cs
│
├── Tests
│   └── CartTests.cs
│
└── README.md

---

## 🔹 Setup Instructions

1. Install:
   - .NET 8 or later
   - Visual Studio 2022

2. Clone repository:
   git clone <repo-url>

3. Navigate to project folder:
   cd OpenCartSDET

4. Restore dependencies:
   dotnet restore

5. Install Playwright browsers:
   dotnet build
   .\bin\Debug\net10.0\playwright.ps1 install

6. Run tests:
   dotnet test

---

## 🔹 Implemented Test Scenarios

### 1. Add Product & Validate Total Price
- Open product
- Capture unit price
- Update quantity
- Add to cart
- Validate total = unit price × quantity

### 2. Remove Product From Cart
- Add product
- Navigate to cart
- Remove product
- Validate cart empty message

---

## 🔹 Design Decisions

- Page Object Model for maintainability
- Async/Await for non-blocking execution
- FluentAssertions for readable validation
- Dynamic price calculation (no hardcoded values)
- Independent & repeatable test cases

---

## 🔹 Future Improvements

- Add CI/CD pipeline (GitHub Actions)
- Add parallel execution
- Add HTML reporting
- Add retry mechanism
- Add screenshot capture on failure