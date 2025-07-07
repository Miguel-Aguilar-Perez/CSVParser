namespace CSVParser.Parsers;

/// <summary>
/// Parser implementation for CSV files of TypeA structure.
/// </summary>
public class TypeAParser : ICsvParser
{
    private static readonly string[] ColumnsToExtract =
    [
        "Full Name",
        "Email",
        "CustomerID",
        "Phone",
        "Salary"
    ];

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
        var rows = CsvUtils.ReadRows(csvFilePath);

        foreach (var row in rows)
        {
            var parsedObject = ExtractData(row, result.Errors);
            result.ParsedObjects.Add(parsedObject);
        }

        return result;
    }

    private static DataRowDto ExtractData(CsvUtils.CsvRow row, List<string> errors)
    {
        var dto = new DataRowDto();

        foreach (var column in ColumnsToExtract)
        {
            switch (column)
            {
                case "Full Name":
                    ExtractFullName(row, column, dto, errors);
                    break;

                case "Email":
                    ExtractEmail(row, column, dto, errors);
                    break;

                default:
                    ParserFieldHelper.ExtractGenericField(row, dto, column);
                    break;
            }
        }

        return dto;
    }

    private static void ExtractEmail(CsvUtils.CsvRow row, string column, DataRowDto dto, List<string> errors)
    {
        var email = ParserFieldHelper.ExtractRowValue(row.Data, column);

        if (ExtractionValidationUtils.IsValidEmail(email))
        {
            dto.Data["Email"] = email;
        }
        else
        {
            errors.Add($"Row {row.RowNumber}: Invalid Email '{email}'");
        }
    }

    private static void ExtractFullName(CsvUtils.CsvRow row, string column, DataRowDto dto, List<string> errors)
    {
        var fullName = ParserFieldHelper.ExtractRowValue(row.Data, column);

        if (ExtractionValidationUtils.IsValidFullName(fullName))
        {
            var splitFullName = fullName.Split(' ');
            dto.Data["FirstName"] = splitFullName[0];
            dto.Data["LastName"] = splitFullName[1];
        }
        else
        {

            errors.Add($"Row {row.RowNumber}: Invalid Full Name");
        }
    }
}