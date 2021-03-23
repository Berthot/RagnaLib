using CsvHelper.Configuration.Attributes;

namespace RagnaLib.Wrapper.CsvWrapper.CsvModels
{
    public class CardPosition
    {
        // id,type,location_id,desc
        [Name("id")]
        public string Id { get; set; }
        
        [Name("type")]
        public string Type { get; set; }
        
        [Name("location_id")]
        public int LocationId { get; set; }
        
        [Name("desc")]
        public string Desc { get; set; }
    }
}