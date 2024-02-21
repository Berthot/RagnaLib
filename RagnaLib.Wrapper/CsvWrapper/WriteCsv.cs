using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using CsvHelper;

namespace RagnaLib.Wrapper.CsvWrapper;

public static class WriterCsv
{
    private static string ResourcePath = Directory.GetCurrentDirectory();
    private const string LogPath = "/home/bertho/Documents/Git/RagnaLib/RagnaLib.Wrapper/Resources/download-log";

    public static void WriteDynamicCsvByClass<T>(string fileName, List<T> list)
    {
            
        var path = Path.Combine(ResourcePath, $"{fileName}.csv");
        using var writer = new StreamWriter(path);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        csv.WriteRecords(list);
    }
        
    public static async Task AppendInFile(string fileName, string text)
    {
        var path = Path.Combine(ResourcePath, $"{fileName}.csv");
        await using var file = new StreamWriter(path, true);
        await file.WriteLineAsync(text);
    }
        
    public static async Task AppendInLogFile(string fileName, string text)
    {
        var path = $"{LogPath}/{fileName}.csv";
        var file = new StreamWriter(path, true);
        await file.WriteLineAsync(text);
    }

        
}