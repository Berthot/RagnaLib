using System.Diagnostics;
using Newtonsoft.Json;

namespace WrapperDivinePride.CsvWrapper;

public class ReadJson : IReadData
{
    private static string BasePath => "/home/bertho/Documents/personal_projects/RagnaLib/WrapperDivinePride/Resources/";

    public List<T> ReadDynamicClass<T>(string fileName)
    {
        var fileNameRefactor = fileName + ".json";
        try
        {
            var json = File.ReadAllText($@"{BasePath}/{fileNameRefactor}");
            var items = JsonConvert.DeserializeObject<List<T>>(json);
            return items.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERROR ao ler o path [ {BasePath}/{fileNameRefactor} ]");
            Process.GetCurrentProcess().Kill();
            throw;
        }
    }
}