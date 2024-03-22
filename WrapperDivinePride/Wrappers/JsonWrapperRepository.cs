using MongoDB.Bson.IO;
using WrapperDivinePride.Extensions;
using WrapperDivinePride.Models;

namespace WrapperDivinePride.Wrappers;

public class JsonWrapperRepository
{
    private const string BasePath = "/home/bertho/Documents/personal_projects/RagnaLib/WrapperDivinePride/Resources";
    public DivinePrideRepository _repo = new DivinePrideRepository();
    public async Task<List<T?>> GetJsonList<T>(ESearchType searchType = ESearchType.Monster) where T : class
    {
        var type = searchType.ToString("G").ToLower();
        var json = await File.ReadAllTextAsync($@"{BasePath}/example_{type}.json");
        var preTreat = json.FromJson<List<GenericJson>>();
        var acc = 0;
        // return preTreat!.Select(x => x.Body.FromJson<T>()).ToList();
        var list = new List<T>();
        foreach (var i in preTreat)
        {
            // Console.WriteLine(i.Body);

            try
            {
                if(IgnoreItem(i.Id, type)) continue;
                T obj = i.Body.FromJson<T>();
                list.Add(obj);
            }
            catch (Exception e)
            {
                acc++;
                // var dta = await _repo.GetById<T>(i.Id, searchType);
                // list.Add(dta);
                // Console.WriteLine($"missing data: {i.Id}");
                // Console.WriteLine(i.Body);
                // throw;
            }
            // Console.WriteLine(obj!.Dbname);
            // System.vironment.Exit(666);
        }

        // Console.WriteLine(acc);


        return list;
    }

    public bool IgnoreItem(int id,  string name)
    {
        var list = new List<int>()
        {
            586,
            598,
            599,
            616, // velho album de cartas
            001,
        };
        return list.Contains(id) && name == "item";
    }
}

public class GenericJson
{
    private string _body;
    public int Id { get; set; }

    public string Body
    {
        get => _body
            .Replace("'", "\"")
            .Replace("\"s ", "'s ")
            .Replace("\"...", "'...")
            .Replace(" \"a ", " 'a ")
            .Replace("O\"C", "O'C")
            .Replace("\"s_Feed", "'s_Feed")
            .Replace("\"anestésico\"", "'anestésico'")
            .Replace("True", "true")
            .Replace("Event\"s", "Event's")
            .Replace("None", "null")
            .Replace("낡은카드", "낡은카드\"")
            .Replace("\"낡은카드\"첩\"", "\"낡은카드\"")
            .Replace("False", "false")
            .Replace(" \"Fragmento Estelar\" ", " 'Fragmento Estelar' ")
            .Replace(" \"Natureza Grandiosa\" ", " 'Natureza Grandiosa' ")
            .Replace(" \"Natureza  Grandiosa\"  ", " 'Natureza  Grandiosa' ")
            .Replace(" \"Natureza  Grandiosa\" q", " 'Natureza  Grandiosa' q")
            .Replace(" \"Vento Bruto\" ", " 'Vento Bruto' ")
            .Replace(" \"Gelo Místico\" ", " 'Gelo Místico' ")
            .Replace(" \"Coração Flamejante\" ", " 'Coração Flamejant' ")
            .Replace("\"U\" ", "'U' ")
            .Replace("\"s_", "'s_")
            .Replace("\"Coluna de Pedra\" ", "'Coluna de Pedra' ")
            .Replace("\"Setembro\"", "'Setembro'")
            .Replace("\"rainha das frutas\"", "'rainha das fruta'")
            .Replace("\\x", "x")
            .Replace("certos \"rituais\"", "certos 'rituais'")
            .Replace("\"rituais", "'rituais")
            .Replace("\"resName\": \"낡은카드\"unidResName\": \"낡은카드\", \"description\"",
                    "\"resName\": \"낡은카드\", \"unidResName\": \"낡은카드\", \"description\"");
        set => _body = value;
    }
}