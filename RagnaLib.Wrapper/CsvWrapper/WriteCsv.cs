using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;

namespace RagnaLib.Wrapper.CsvWrapper
{
    public class WriterCsv
    {
        private const string ResourcePath = "/home/bertho/Documents/Git/RagnaLib/RagnaLib.Wrapper/Resources";

        public void WriteDynamicCsvByClass<T>(string fileName, List<T> list)
        {
            var path = Path.Combine(ResourcePath, $"{fileName}.csv");
            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(list);
        }
        
        public async Task AppendInFile(string fileName, string text)
        {
            var path = Path.Combine(ResourcePath, $"{fileName}.csv");
            await using StreamWriter file = new(path, append: true);
            await file.WriteLineAsync(text);
        }
        
    }
}