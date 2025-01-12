using FileConverter.Interfaces;

namespace FileConverter.Providers;

public class XmlFormatter : IFileFormatter
{
    public void FormatFile(string fileName)
    {
        Console.WriteLine($"Formatting {fileName} to XML");
    }
}