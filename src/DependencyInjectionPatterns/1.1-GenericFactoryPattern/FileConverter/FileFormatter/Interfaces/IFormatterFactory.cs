namespace FileFormatter.Interfaces;

public interface IFormatterFactory<TFormatter>
    where TFormatter : IFileFormatter
{
    TFormatter GetFormatter();
}