using FileFormatter.Interfaces;

namespace FileFormatter.Providers;

public class XmlFormatter : IFileFormatter
{
    public void FormatFile(string fileName)
    {
        Console.WriteLine($"Formatting {fileName} to XML");
    }
}