using System.Runtime.CompilerServices;

namespace CSVParser.Parsers;

/// <summary>
/// Parser implementation for CSV files of TypeB structure.
/// </summary>
public class TypeBParser : ICsvParser
{
    private static readonly string[] ColumnsToExtract =
    [
        "Name",
        "Surname",
        "Salary",
        "ID",
        "Salary"
    ];

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
        var rows = CsvUtils.ReadRows(csvFilePath);

        foreach (var row in rows)
        {
            var parsedObject = ExtractData(row);

            ProcessEmail(parsedObject, result.Errors, row.RowNumber);
            result.ParsedObjects.Add(parsedObject);
        }

        return result;
    }

    private static DataRowDto ExtractData(CsvUtils.CsvRow row)
    {
        var dto = new DataRowDto();

        foreach (var column in ColumnsToExtract)
        {
            switch (column)
            {
                case "Name":
                    ParserFieldHelper.ExtractGenericField(row, dto, column, "FirstName");
                    break;

                case "Surname":
                    ParserFieldHelper.ExtractGenericField(row, dto, column, "LastName");
                    break;

                case "ID":
                    ExtractCustomerId(row, dto, column, "CustomerID");
                    break;

                default:
                    ParserFieldHelper.ExtractGenericField(row, dto, column);
                    break;
            }
        }

        return dto;
    }

    private static void ExtractCustomerId(CsvUtils.CsvRow row, DataRowDto dto, string column, string targetColumn)
    {
        ParserFieldHelper.ExtractGenericField(row, dto, column, targetColumn);

        var customerId = dto.Data[targetColumn].ToString();

        if (string.IsNullOrEmpty(customerId)) return; // No customer ID to process

        var phone = ExternalDataUtils.GetPhoneById(customerId);
        dto.Data["Phone"] = phone;
    }

    private static void ProcessEmail(DataRowDto dto, List<string> errors, int rowNumber)
    {
        var corporateEmail = dto.Data["CorporateEmail"].ToString();
        var personalEmail = dto.Data["PersonalEmail"].ToString();

        var selectedEmail = SelectPreferredEmail(corporateEmail, personalEmail);
        
        if (!ExtractionValidationUtils.IsValidEmail(selectedEmail))
        {
            errors.Add($"Row {rowNumber}: Invalid Email '{selectedEmail}'");
        }
        
        dto.Data["Email"] = selectedEmail;

        dto.Data.Remove("CorporateEmail");
        dto.Data.Remove("PersonalEmail");
    }

    private static string SelectPreferredEmail(string? corporate, string? personal)
    {
        // Example: prefer personal if available, else corporate
        return !string.IsNullOrWhiteSpace(personal)
            ? personal
            : corporate ?? string.Empty;
    }
}