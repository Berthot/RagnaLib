using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;

namespace RagnaLib.Wrapper.CsvWrapper
{
    public class WriterCsv
    {
        private string ResourcePath = Directory.GetCurrentDirectory();

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
            await using StreamWriter file = new StreamWriter(path, true);
            await file.WriteLineAsync(text);
        }
        
    }
}