namespace CSVParser.Parsers;

/// <summary>
/// Parser implementation for CSV files of TypeB structure.
/// </summary>
public class TypeBParser : ICsvParser
{
    /// <summary>
    /// Parses a TypeB CSV file and maps its data to the common DTO.
    /// Performs validation, transformation, and external data loading specific to TypeB format.
    /// </summary>
    /// <param name="csvFilePath">The file path of the TypeB CSV file to parse.</param>
    /// <returns>
    /// A <see cref="ParseResult"/> containing the parsed DTOs and any errors encountered during parsing.
    /// </returns>
    public ParseResult Parse(string csvFilePath)
    {
        var result = new ParseResult();

        foreach (var row in CsvUtils.ReadRows(csvFilePath))
        {
            var dto = new FileInfoDto();

            // Email selection logic
            var corporateEmail = row.GetValueOrDefault("CorporateEmail") ?? "";
            var personalEmail = row.GetValueOrDefault("PersonalEmail") ?? "";
            var selectedEmail = TransformationUtils.SelectPreferredEmail(corporateEmail, personalEmail);
            
            if (!ExtractionValidationUtils.IsValidEmail(selectedEmail))
            {
                result.Errors.Add($"Row {row.RowNumber}: Invalid Email '{selectedEmail}'");
            }

            dto.Data["Email"] = selectedEmail;

            // Other fields that might be present in TypeB CSV. More fields can be added as needed and errors could be added to the result.Errors list if needed.
            var hasFirstName = row.Data.TryGetValue("Name", out var firstName);
            var hasLastName = row.Data.TryGetValue("Surname", out var lastName);
            var hasCustomerId = row.Data.TryGetValue("ID", out var customerId);
            var hasSalary = row.Data.TryGetValue("Salary", out var salary);

            if (hasFirstName && !string.IsNullOrWhiteSpace(firstName)) dto.Data["FirstName"] = firstName;
            if (hasLastName && !string.IsNullOrWhiteSpace(lastName)) dto.Data["LastName"] = lastName;
            if (hasSalary && !string.IsNullOrWhiteSpace(salary)) dto.Data["CustomerID"] = salary;

            if (hasCustomerId && !string.IsNullOrWhiteSpace(customerId))
            {
                dto.Data["CustomerID"] = customerId;

                // Phone might need to be loaded from an external source
                var phone = ExternalDataUtils.GetPhoneById(customerId);
                dto.Data["Phone"] = phone;
            }

            result.ParsedObjects.Add(dto);
        }

        return result;
    }
}