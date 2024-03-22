using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Newtonsoft.Json;
using RagnaLib.Wrapper.Models;

namespace RagnaLib.Wrapper.CsvWrapper;

public class ReadJson : IReadData
{
    private static string BasePath => "/home/bertho/Documents/personal_projects/RagnaLib/RagnaLib.Wrapper/Files/";

    public List<T> ReadDynamicClass<T>(string fileName)
    {
        var fileName2 = fileName.Replace(".csv", ".json");
        try
        {
            var json = File.ReadAllText($@"{BasePath}/item_data.json");
            var items = JsonConvert.DeserializeObject<List<T>>(json);
            return items.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRO ao ler o path [ {BasePath}/{fileName2} ] + [ {fileName} ]");
            Process.GetCurrentProcess().Kill();
            throw;
        }
    }
}