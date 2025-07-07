namespace CSVParser.Dtos;

/// <summary>
/// Common DTO to hold parsed data from any file.
/// </summary>
public class DataRowDto
{
    /// <summary>
    /// Gets or sets the data fields for this DTO.
    /// </summary>
    public Dictionary<string, object> Data { get; set; } = new();

    /// <summary>
    /// Returns a string representation of the DTO.
    /// </summary>
    public override string ToString()
    {
        return string.Join(", ", Data);
    }
}