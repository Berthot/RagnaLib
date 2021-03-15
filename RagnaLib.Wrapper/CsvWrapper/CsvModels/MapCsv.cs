using CsvHelper.Configuration.Attributes;

namespace RagnaLib.Wrapper.CsvWrapper.CsvModels
{
    public class MapCsv
    {
        // id,name
        [Name("id")]
        public string IdMap { get; set; }
        
        [Name("name")]
        public string DescName { get; set; }
        
    }
}