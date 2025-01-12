using FileConverter.Interfaces;

namespace FileConverter.Providers;

public class TsFormatter : IFileFormatter
{
    public void FormatFile(string fileName)
    {
        Console.WriteLine($"Formatting {fileName} to TypeScript");
    }
}