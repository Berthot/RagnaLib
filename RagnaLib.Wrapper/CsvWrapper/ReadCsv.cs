using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace RagnaLib.Wrapper.CsvWrapper
{
    public class ReadCsv
    {
        private const string ResourcePath = "/home/bertho/Documents/Git/RagnaLib/RagnaLib.Wrapper/Resources";

        public List<T> ReadDynamicClass<T>(string fileName)
        {
            var path = Path.Combine(ResourcePath, fileName);
            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<T>();
            return records.ToList();
        }


    }
}