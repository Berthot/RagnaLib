using System.Collections.Generic;

namespace RagnaLib.Wrapper.CsvWrapper;

public interface IReadData
{
    List<T> ReadDynamicClass<T>(string fileName);
}