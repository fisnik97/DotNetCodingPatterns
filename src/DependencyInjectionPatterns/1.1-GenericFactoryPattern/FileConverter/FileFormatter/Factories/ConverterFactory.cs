using FileFormatter.Interfaces;

namespace FileFormatter.Factories;

public class FormatterFactor<TFormatter> : IFormatterFactory<TFormatter>
    where TFormatter : IFileFormatter
{
    private readonly IServiceProvider _serviceProvider;

    public FormatterFactor(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TFormatter GetFormatter()
    {
        var formatter = _serviceProvider.GetService<TFormatter>();

        if (formatter != null) return formatter;
        
        Console.WriteLine("Formatter not found. Creating a new instance using Activator.");
        return ActivatorUtilities.CreateInstance<TFormatter>(_serviceProvider);
    }
}