namespace CSVParser;

public class Program
{
    public static void Main(string[] parameters)
    {
        ParameterValidator.ValidateNumberOfParameters(parameters);

        var filePath = parameters[0];
        var parserType = parameters[1];
        
        ParameterValidator.ValidateEntryParameters(filePath, parserType);

        var parser = ParserFactory.CreateParser(parserType);

        var result = parser.Parse(filePath);

        Console.WriteLine("Parsed DTOs:");
        foreach (var parsedObject in result.ParsedObjects)
        {
            Console.WriteLine(parsedObject.ToString());
        }

        Console.WriteLine("\nErrors:");
        foreach (var error in result.Errors)
        {
            Console.WriteLine(error);
        }
    }
}