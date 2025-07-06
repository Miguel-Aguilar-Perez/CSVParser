namespace CSVParser.Utils;

// Shared validation logic
public static class ExtractionValidationUtils
{
    public static bool IsValidFullName(string? fullName)
    {
        if (string.IsNullOrWhiteSpace(fullName)) return false;
        
        // TODO: Further cases should be handled, such as: title, middle name and more than one surname.
        return fullName.Split(' ').Length is 2;
    }

    public static bool IsValidEmail(string? email)
    {
        return !string.IsNullOrWhiteSpace(email) &&
               // Simple regex for demonstration
               Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}