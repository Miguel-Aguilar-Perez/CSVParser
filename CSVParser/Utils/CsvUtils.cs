namespace CSVParser.Utils;

/// <summary>
/// Utility class for reading CSV files.
/// </summary>
public static class CsvUtils
{
    /// <summary>
    /// Simulates reading rows from a CSV file.
    /// Each row is represented as a <see cref="CsvRow"/> with a RowNumber property for error reporting.
    /// </summary>
    /// <param name="csvFilePath">The path to the CSV file.</param>
    /// <returns>An enumerable of <see cref="CsvRow"/> objects representing CSV rows.</returns>
    public static IEnumerable<CsvRow> ReadRows(string csvFilePath)
    {
        // Skeleton: Replace with actual CSV reading logic as needed.
        // Here, we yield a couple of example rows for demonstration.
        yield return new CsvRow(1, new Dictionary<string, string>
        {
            { "ID", "1" },
            { "Name", "John" },
            { "Surname", "Doe" },
            { "CorporateEmail", "john.doe@company.com" },
            { "PersonalEmail", "" },
            { "Salary", "50000" }
        });

        yield return new CsvRow(2, new Dictionary<string, string>
        {
            { "ID", "2" },
            { "Name", "Jane" },
            { "Surname", "Smith" },
            { "CorporateEmail", "" },
            { "PersonalEmail", "jane.smith@gmail.com" },
            { "Salary", "60000" }
        });
    }

    /// <summary>
    /// Represents a CSV row with a RowNumber and dictionary access.
    /// </summary>
    public class CsvRow(int rowNumber, IDictionary<string, string> data) : Dictionary<string, string>(data)
    {
        /// <summary>
        /// Gets the row number of this CSV row.
        /// </summary>
        public int RowNumber { get; } = rowNumber;

        /// <summary>
        /// Gets the data dictionary for this row.
        /// </summary>
        public IDictionary<string, string> Data { get; } = data;
    }
}