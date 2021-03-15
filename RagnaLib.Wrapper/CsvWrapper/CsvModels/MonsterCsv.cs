using CsvHelper.Configuration.Attributes;
using DocumentFormat.OpenXml.Wordprocessing;

namespace RagnaLib.Wrapper.CsvWrapper.CsvModels
{
    // id,name,hp,level,race,size,gif_url,item_list,map_list
    public class MonsterCsv
    {
        [Name("id")] public string Id { get; set; }
        [Name("name")] public string Name { get; set; }
        [Name("hp")] public string Hp { get; set; }
        [Name("level")] public string Level { get; set; }
        [Name("race")] public string Race { get; set; }
        [Name("size")] public string Size { get; set; }
        [Name("gif_url")] public string GifUrl { get; set; }
        [Name("item_list")] public string ItemList { get; set; }
        [Name("map_list")] public string MapList { get; set; }
    }
}