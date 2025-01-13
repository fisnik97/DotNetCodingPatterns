using FileFormatter.Interfaces;
using FileFormatter.Providers;

namespace FileFormatter.Services;

public class FormatterService
{
    private readonly IFormatterFactory<JsonFormatter> _jsonFormatterFactory;
    private readonly IFormatterFactory<XmlFormatter> _xmlFormatterFactory;
    private readonly IFormatterFactory<TsFormatter> _tsFormatterFactory;

    public FormatterService(
        IFormatterFactory<JsonFormatter> jsonFormatterFactory,
        IFormatterFactory<XmlFormatter> xmlFormatterFactory,
        IFormatterFactory<TsFormatter> tsFormatterFactory
    )
    {
        _jsonFormatterFactory = jsonFormatterFactory;
        _xmlFormatterFactory = xmlFormatterFactory;
        _tsFormatterFactory = tsFormatterFactory;
    }

    public void FormatFile(string fileName, string format)
    {
        IFileFormatter formatter = format switch
        {
            "json" => _jsonFormatterFactory.GetFormatter(),
            "xml" => _xmlFormatterFactory.GetFormatter(),
            "ts" => _tsFormatterFactory.GetFormatter(),
            _ => throw new ArgumentException("Invalid format")
        };

        formatter.FormatFile(fileName);
    }
}