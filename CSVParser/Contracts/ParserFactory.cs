namespace CSVParser.Contracts;

// Factory to select parser by type
public static class ParserFactory
{
    public static ICsvParser CreateParser(string parserType)
    {
        return parserType switch
        {
            "TypeAParser" => new TypeAParser(),
            "TypeBParser" => new TypeBParser(),
            _ => throw new ArgumentException($"Invalid parser type: {parserType}")
        };
    }
}