using FileConverter.Interfaces;

namespace FileConverter.Providers;

public class JsonFormatter : IFileFormatter
{
    public void FormatFile(string fileName)
    {
        Console.WriteLine($"Formatting {fileName} to JSON");
    }
}