namespace CSVParser.Dtos;

/// <summary>
/// Holds the result of a parse operation, including parsed DTOs and any errors encountered.
/// </summary>
public class ParseResult
{
    /// <summary>
    /// Gets or sets the list of parsed DTOs.
    /// </summary>
    public List<FileInfoDto> ParsedObjects { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of error messages encountered during parsing.
    /// </summary>
    public List<string> Errors { get; set; } = new();
}