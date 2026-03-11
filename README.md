# Portfolio
A curated showcase of professional-grade projects developed during the Microsoft Front-End Development series, demonstrating a transition from zero programming background to technical proficiency in C#, Web Development, Blazor, and UI/UX design.

# Project 1: JD Warehouse 📦
A robust, interactive C# console application for dynamic inventory management.

## 🎯 Project Overview
JD Warehouse is a command-line interface (CLI) application built to handle the core CRUD (Create, Read, Update, Delete) operations of a real-world inventory system. 

The goal of this project was to build and document a resilient architecture within an agile sprint. It demonstrates a modern development workflow: prioritizing deep, manual comprehension of C# architecture, rigorously handling edge cases, and utilizing open-source diagramming for technical documentation.

## ✨ Core Features
* **Dynamic Memory Management:** Utilizes C# `List<T>` and custom data classes to support infinitely scalable inventory records, moving beyond fixed-array limitations.
* **Bulletproof Data Validation:** Implements continuous `while` loops with `TryParse` and `string.IsNullOrWhiteSpace` to trap invalid inputs, preventing runtime formatting exceptions.
* **Primary Key Enforcement:** Automatically scans and rejects duplicate Product Codes at the point of entry to maintain database integrity.
* **Smart UX Friction:** Detects partial name matches to warn users of potential duplicate items (soft constraints) and requires explicit confirmation for destructive actions like inventory deletion.
* **Contextual Math Routing:** The Update module intelligently routes logic based on transaction type (Restock vs. Sale), dynamically preventing stock from dropping below zero.

## 🏗️ System Architecture
The application is governed by a central state loop and a `switch` router, ensuring the user remains engaged until they explicitly terminate the session. Operations are heavily modularized into distinct, callable methods for clean maintainability.

## 🚀 Getting Started
To run this project locally or in GitHub Codespaces:

1. Clone this repository to your local machine.
2. Open the project folder in Visual Studio Code or your preferred C# IDE.
3. Open the integrated terminal.
4. Run the application using the .NET CLI:
   ```bash
   dotnet run

## 🛠️ Tech Stack
* Language: C#
* Framework: .NET Console Application
* Documentation: Markdown, Mermaid.js