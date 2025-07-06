namespace CSVParser.Utils;

// Shared transformation logic
public static class TransformationUtils
{
    public static string SelectPreferredEmail(string corporate, string personal)
    {
        // Example: prefer personal if available, else corporate
        return !string.IsNullOrWhiteSpace(personal) ? personal : corporate;
    }
}