# CSVParser

A flexible and extensible C# program skeleton for parsing CSV files with varying structures and mapping their data to a common Data Transfer Object (DTO).  
This project demonstrates clean architecture, separation of concerns, and the use of design patterns for parser selection and data validation.

## Features

- **ParserType Selection:** Dynamically select parsing logic based on a parser type string.
- **Extensible Parsers:** Easily add new parser types for different CSV structures.
- **Common DTO:** All parsed data is mapped to a flexible, dictionary-based DTO.
- **Validation & Transformation:** Shared and parser-specific validation/transformation utilities.
- **Error Handling:** Detailed error reporting for validation and format issues.
- **Separation of Concerns:** Utilities, DTOs, interfaces, and parsers are organized in dedicated folders.

## Adding a New Parser

1. Create a new class in `Parsers/` implementing `ICsvParser`.
2. Implement the `Parse` method, using shared utilities from `Utils/` as needed.
3. Register your parser in `ParserFactory` (in `Contracts/`).

## Assumptions & Notes

- The CSV reading logic is stored in `CsvUtils.ReadRows` for demonstration.
- The DTO (`DataRowDto`) uses a dictionary for maximum flexibility.
- Validation and transformation logic is shared and can be extended.
- Error handling is detailed, with row numbers and field-specific messages.

## Example Parsers

- **TypeAParser:** Handles CSVs with fields like `CustomerID`, `Full Name`, `Email`, `Phone`, `Salary`.
- **TypeBParser:** Handles CSVs with fields like `ID`, `Name`, `Surname`, `CorporateEmail`, `PersonalEmail`, `Salary`.

## Requirements

- .NET 9 SDK
- C# 13
