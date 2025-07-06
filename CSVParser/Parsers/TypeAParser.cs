using System.Reflection.Metadata.Ecma335;

namespace CSVParser.Parsers;

/// <summary>
/// Parser implementation for CSV files of TypeA structure.
/// </summary>
public class TypeAParser : ICsvParser
{
    /// <summary>
    /// Parses a TypeA CSV file and maps its data to the common DTO.
    /// Performs validation and transformation specific to TypeA format.
    /// </summary>
    /// <param name="csvFilePath">The file path of the TypeA CSV file to parse.</param>
    /// <returns>
    /// A <see cref="ParseResult"/> containing the parsed DTOs and any errors encountered during parsing.
    /// </returns>
    public ParseResult Parse(string csvFilePath)
    {
        var result = new ParseResult();

        // Pseudo-code for reading CSV rows
        foreach (var row in CsvUtils.ReadRows(csvFilePath))
        {
            var dto = new FileInfoDto();

            // Example: Validate FullName
            var hasFullName = row.Data.TryGetValue("Full Name", out var fullName);
            
            if (!hasFullName || !ExtractionValidationUtils.IsValidFullName(fullName))
            {
                result.Errors.Add($"Row {row.RowNumber}: Invalid Full Name");
            }
            else
            {
                var splitFullName = fullName!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                dto.Data["FirstName"] = splitFullName[0];
                dto.Data["LastName"] = splitFullName[1];
            }

            // Example: Validate Email
            var hasValidEmail = row.Data.TryGetValue("Email", out var email);
            
            if (!hasValidEmail || !ExtractionValidationUtils.IsValidEmail(email))
            {
                result.Errors.Add($"Row {row.RowNumber}: Invalid Email");
            }
            else
            {
                dto.Data["Email"] = email!;
            }

            // Other fields that might be present in TypeA CSV. More fields can be added as needed and errors could be added to the result.Errors list if needed.
            var hasCustomerId = row.Data.TryGetValue("CustomerID", out var customerId);
            var hasPhone = row.Data.TryGetValue("Phone", out var phone);
            var hasSalary = row.Data.TryGetValue("Salary", out var salary);

            if (hasCustomerId) dto.Data["CustomerID"] = customerId ?? "";
            if (hasPhone) dto.Data["CustomerID"] = phone ?? "";
            if (hasSalary) dto.Data["CustomerID"] = salary ?? "";

            result.ParsedObjects.Add(dto);
        }

        return result;
    }
}