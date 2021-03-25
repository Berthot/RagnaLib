using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            try
            {
                var path = Path.Combine(ResourcePath, fileName);
                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<T>();
                return records.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(Path.Combine(ResourcePath, fileName).ToString());
                Process.GetCurrentProcess().Kill();
                throw;
            }
        }


    }
}