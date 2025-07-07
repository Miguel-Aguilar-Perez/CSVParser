namespace CSVParser.Utils;

/// <summary>
/// Helper methods for extracting and assigning fields from CSV rows to DTOs.
/// </summary>
public static class ParserFieldHelper
{
    public static string ExtractRowValue(IDictionary<string, string> rowData, string fieldName) 
        => rowData.TryGetValue(fieldName, out var value) ? value : string.Empty;

    public static void ExtractGenericField(CsvUtils.CsvRow row, DataRowDto dto, string originColumn, string? targetColumn = null)
    {
        var value = ExtractRowValue(row.Data, originColumn);
        targetColumn ??= originColumn;

        if (!string.IsNullOrEmpty(value))
        {
            dto.Data[targetColumn] = value;
        }
    }
}