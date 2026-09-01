# Budget Tracking System
# 💰 Student Budget Tracker

A personal finance management application designed to help students track their income, expenses, budgets, shared expenses, and savings goals.

This project started as a beginner C# console application and is intended to grow into a fully featured mini financial management application as I develop my programming, Object-Oriented Programming, database, and software development skills.

---

## 📌 Project Overview

Managing money as a student can be difficult, especially when dealing with limited income, monthly expenses, shared costs, and savings goals.

The **Student Budget Tracker** was created to provide a simple way to:

* Record income
* Record expenses
* Categorise expenses
* Set budget limits
* Track spending
* View transaction history
* Split shared expenses
* Create savings goals
* Contribute money towards savings goals
* Monitor savings progress

The project is currently being developed as a C# application and will progressively be improved as new programming concepts are learned.

---

# 🎯 Project Goals

The main goal of this project is not only to create a useful budgeting application, but also to document my growth as a software developer.

The application will be improved over time by introducing:

* Object-Oriented Programming
* Better validation
* Exception handling
* Windows Forms
* Database integration
* Improved application architecture
* User authentication
* Data visualisation
* Reporting
* Software design principles
* Testing
* Version control
* Potential cloud integration

The intention is for the project to evolve from a simple student project into a small, professionally structured application.

---

# 🛠️ Technologies

## Current

* C#
* .NET
* Console Application
* `List<T>`
* `Dictionary<TKey, TValue>`
* Enums
* Basic input validation
* Basic calculations

## Planned

* Windows Forms
* SQL Server
* ADO.NET
* Entity Framework
* Git & GitHub
* Unit Testing
* Data Visualisation
* Authentication
* Reporting
* Cloud Services

---

# 🚀 Current Features

## 1. Income Tracking

Users can record income.

Each income transaction stores:

* Transaction type
* Amount
* Date
* Description

Example:

```text
Income: R5000
Date: 2026/05/17
```

---

## 2. Expense Tracking

Users can record expenses and assign them to categories.

Current categories include:

* Rent
* Groceries
* Utilities
* Entertainment
* Transport
* WiFi

---

## 3. Budget Limits

Users can define spending limits for different categories.

For example:

```text
Groceries:      R2000
Transport:      R1000
Entertainment:  R500
```

The application can then compare spending against the defined budget.

---

## 4. Budget Warnings

The application provides warnings when spending approaches or exceeds a budget.

Current warning levels include:

### 80% of budget

The application warns the user that their budget is almost exceeded.

### 100%+ of budget

The application warns the user that the budget has been exceeded.

---

## 5. Transaction History

Users can view previously recorded transactions.

Transactions currently contain:

```text
Type
Category
Amount
Date
Description
```

---

## 6. Budget Summary

The application calculates:

* Total income
* Total expenses
* Remaining balance
* Highest spending category

Example:

```text
Total Income: R8000
Total Expense: R5200
Remaining Balance: R2800

Highest spending category:
Groceries - R1800
```

---

## 7. Shared Expense Splitting

Users can enter:

* Total expense
* Number of people sharing the expense

The application calculates how much each person should pay.

Example:

```text
Total Expense: R1000
People: 4

Each person pays: R250
```

---

## 8. Savings Goals

Users can create savings goals by providing:

* Goal name
* Target amount

Example:

```text
Goal: New Phone
Target: R15000
```

---

## 9. Savings Progress

Users can add money towards their savings goals.

The application calculates the percentage of the goal that has been completed.

Example:

```text
New Phone
R5000 / R15000
33.3% complete
```

The application also notifies the user when a savings goal reaches 100%.

---

# 🧱 Current Architecture

The current version is a simple console application where most functionality is contained within `Program.cs`.

The current structure is approximately:

```text
Program
│
├── Transaction data
├── Budget data
├── Savings data
│
├── DisplayMenu()
├── AddIncome()
├── AddExpense()
├── ViewHistory()
├── ShowBudgetSummary()
├── SplitExpense()
├── SetBudgetLimit()
├── UpdateLimit()
├── AddSavingsGoal()
├── AddToSavingsGoal()
└── Main()
```

This structure works for a beginner application, but it has several limitations.

---

# ⚠️ Current Limitations

The current version is intentionally simple, but there are areas that need improvement.

### 1. Too much responsibility in `Program`

The main program currently handles:

* User input
* Validation
* Business logic
* Data management
* Calculations
* Display

This makes the application harder to maintain as it grows.

---

### 2. Savings goals use multiple lists

The current application stores savings goals using separate lists for:

```text
Goal names
Goal targets
Current goal amounts
```

This creates a dependency between the lists.

A future version will replace these with a dedicated `SavingsGoal` class.

---

### 3. Transactions need stronger encapsulation

The current transaction model uses fields.

Future versions will use properties and better encapsulation.

---

### 4. Data is not persistent

Currently, data exists only while the application is running.

Closing the application removes the stored information.

A future version will introduce a database.

---

### 5. Console-based interface

The current interface is entirely console based.

A future version will introduce a graphical user interface using Windows Forms.

---

# 🔨 Planned Object-Oriented Design

The next major refactoring will introduce dedicated classes.

### Transaction

```text
Transaction
├── Id
├── Type
├── Category
├── Amount
├── Date
└── Description
```

### Budget

```text
Budget
├── Id
├── Category
├── Limit
├── AmountSpent
├── Remaining
└── PercentageUsed
```

### SavingsGoal

```text
SavingsGoal
├── Id
├── Name
├── TargetAmount
├── CurrentAmount
├── Progress
└── IsCompleted
```

---

# 🗺️ Development Roadmap

The project will be developed in stages.

## Version 1.0 — Console Application

* [x] Add income
* [x] Add expenses
* [x] Categorise expenses
* [x] Set budget limits
* [x] Update budget limits
* [x] View transaction history
* [x] View budget summary
* [x] Split shared expenses
* [x] Create savings goals
* [x] Add money to savings goals

---

## Version 2.0 — Object-Oriented Refactoring

* [ ] Create `Transaction` class
* [ ] Create `Budget` class
* [ ] Create `SavingsGoal` class
* [ ] Improve encapsulation
* [ ] Introduce constructors
* [ ] Improve properties
* [ ] Introduce enums where appropriate
* [ ] Separate responsibilities
* [ ] Improve validation
* [ ] Introduce exception handling

---

## Version 3.0 — Windows Forms

* [ ] Create dashboard
* [ ] Add transaction form
* [ ] Add budget management form
* [ ] Add savings goal form
* [ ] Add transaction DataGridView
* [ ] Add search functionality
* [ ] Add filtering
* [ ] Improve user experience

---

## Version 4.0 — Database

* [ ] Design database
* [ ] Create SQL Server database
* [ ] Create tables
* [ ] Create relationships
* [ ] Add CRUD operations
* [ ] Connect C# application to database
* [ ] Implement data persistence

---

## Version 5.0 — Application Architecture

* [ ] Separate UI from business logic
* [ ] Introduce services
* [ ] Introduce repositories
* [ ] Apply SOLID principles
* [ ] Improve dependency management
* [ ] Improve error handling

Possible structure:

```text
BudgetTracker
│
├── Models
│   ├── Transaction.cs
│   ├── Budget.cs
│   ├── SavingsGoal.cs
│   └── User.cs
│
├── Services
│   ├── TransactionService.cs
│   ├── BudgetService.cs
│   ├── SavingsService.cs
│   └── ExpenseSplitter.cs
│
├── Forms
│   ├── MainForm.cs
│   ├── AddTransactionForm.cs
│   ├── BudgetForm.cs
│   ├── SavingsForm.cs
│   └── ReportsForm.cs
│
└── Data
    ├── DatabaseContext.cs
    ├── TransactionRepository.cs
    ├── BudgetRepository.cs
    └── SavingsRepository.cs
```

---

# 📊 Future Features

Potential future improvements include:

* User registration and login
* Password security
* Multiple users
* Monthly budgets
* Recurring expenses
* Recurring income
* Financial reports
* Spending charts
* Savings progress charts
* Export to Excel
* Export to PDF
* Notifications
* Budget alerts
* Search and filtering
* Dark mode
* Cloud backup
* Mobile/web version

---

# 🧠 What I Am Learning Through This Project

This project is also being used as a practical learning journey.

Concepts that will be explored include:

### Programming

* C#
* Collections
* LINQ
* Exception handling
* File handling
* Debugging

### Object-Oriented Programming

* Classes
* Objects
* Encapsulation
* Inheritance
* Polymorphism
* Abstraction
* Interfaces
* Composition

### Software Development

* SOLID principles
* Design patterns
* Separation of concerns
* Layered architecture
* Repository pattern
* Unit testing

### Databases

* SQL
* Relational database design
* Primary keys
* Foreign keys
* Normalisation
* CRUD
* ADO.NET
* Entity Framework

### Development Tools

* Visual Studio
* Git
* GitHub
* Version control

---

# 📈 Project Evolution

One of the main purposes of this project is to document how it changes over time.

The goal is to preserve previous versions rather than simply replacing them.

```text
Version 1
Simple Console Application
        ↓
Version 2
Object-Oriented Application
        ↓
Version 3
Windows Forms Application
        ↓
Version 4
Database-Driven Application
        ↓
Version 5
Structured Multi-Layer Application
        ↓
Future
Full Mini Financial Management System
```

Each version should demonstrate something new that I have learned.

---

# 📝 Development Philosophy

> Build it.
> Break it.
> Understand why it broke.
> Fix it.
> Refactor it.
> Improve it.
> Repeat.

The purpose of this project is not to create perfect code from the beginning.

It is to demonstrate continuous improvement and show how my programming knowledge develops throughout my studies.

---

# 👨‍💻 Author

**Muzi Manaka**

Student Software Development Project

Started as a second-year C# learning project with the goal of developing it into a portfolio project for future internship opportunities.

---

# 📜 License

This project is currently intended as a personal educational and portfolio project.
