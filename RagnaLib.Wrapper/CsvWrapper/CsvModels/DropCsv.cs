using CsvHelper.Configuration.Attributes;

namespace RagnaLib.Wrapper.CsvWrapper.CsvModels
{
    public class DropCsv
    {
        //id,name,img_url,collection_img_url,card_img_url,desc
        [Name("id")]
        public string Id { get; set; }
        
        [Name("name")]
        public string Name { get; set; }

        [Name("img_url")]
        public string ImageUrl { get; set; }
        
        [Name("collection_img_url")]
        public string CollectionImageUrl { get; set; }

        [Name("card_img_url")]
        public string CardImageUrl { get; set; }
        
        [Name("desc")]
        public string Description { get; set; }

    }
}