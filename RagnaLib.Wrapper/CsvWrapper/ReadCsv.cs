using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using CsvHelper;

namespace RagnaLib.Wrapper.CsvWrapper
{
    public class ReadCsv
    {
        private readonly string _resourcePath =
            $"{Environment.CurrentDirectory.Split("bin/")[0]}Resources/";

        public List<T> ReadDynamicClass<T>(string fileName)
        {
            try
            {
                var path = Path.Combine(_resourcePath, fileName);
                using var reader = new StreamReader(path);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<T>();
                return records.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERRO ao ler o path [ {_resourcePath} ] + [ {fileName} ]");
                Process.GetCurrentProcess().Kill();
                throw;
            }
        }


    }
}