using FileFormatter.Interfaces;

namespace FileFormatter.Providers;

// not registered to DI
public class TsFormatter : IFileFormatter
{
    public void FormatFile(string fileName)
    {
        Console.WriteLine($"Formatting {fileName} to TypeScript");
    }
}