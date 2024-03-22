namespace WrapperDivinePride.CsvWrapper;

public interface IReadData
{
    List<T> ReadDynamicClass<T>(string fileName);
}