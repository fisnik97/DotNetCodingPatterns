namespace FileConverter.Interfaces;

public interface IFormatterFactory<TFormatter>
    where TFormatter : IFileFormatter
{
    TFormatter GetFormatter();
}