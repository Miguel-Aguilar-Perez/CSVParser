namespace CSVParser.Contracts;

/// <summary>
/// Defines a contract for CSV parsers that can parse CSV files
/// and map their contents to a common data transfer object (DTO).
/// </summary>
public interface ICsvParser
{
    /// <summary>
    /// Parses the specified CSV file and maps its data to a collection of common DTOs.
    /// </summary>
    /// <param name="csvFilePath">The file path of the CSV file to parse.</param>
    /// <returns>
    /// A <see cref="ParseResult"/> containing the parsed DTOs and any errors encountered during parsing.
    /// </returns>
    ParseResult Parse(string csvFilePath);
}