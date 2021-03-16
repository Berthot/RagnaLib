using CsvHelper.Configuration.Attributes;

namespace RagnaLib.Wrapper.CsvWrapper.CsvModels
{
    public class LocationCsv
    {
        // id_map,name,type_map
        [Name("id_map")]
        public string IdMap { get; set; }
        
        [Name("name")]
        public string DescName { get; set; }  
        
        [Name("type_map")]
        public string TypeMap { get; set; }
        
    }
}