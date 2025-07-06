namespace CSVParser.Utils;

/// <summary>
/// Provides validation methods for program entry parameters.
/// </summary>
public static class ParameterValidator
{
    /// <summary>
    /// Validates that the correct number of parameters are provided.
    /// Throws an <see cref="ArgumentException"/> if the count is not exactly 2.
    /// </summary>
    /// <param name="parameters">The parameters array.</param>
    public static void ValidateNumberOfParameters(string[] parameters)
    {
        if (parameters.Length is not 2)
            throw new ArgumentException("Wrong number of parameters passed. Length should be 2: FilePath and ParserType)");
    }

    /// <summary>
    /// Validates the file path and parser type parameters.
    /// Throws an <see cref="ArgumentException"/> if either is null or empty.
    /// </summary>
    /// <param name="filePath">The file path parameter.</param>
    /// <param name="parserType">The parser type parameter.</param>
    public static void ValidateEntryParameters(string filePath, string parserType)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));

        if (string.IsNullOrWhiteSpace(parserType))
            throw new ArgumentException("Parser type cannot be null or empty.", nameof(parserType));
    }
}