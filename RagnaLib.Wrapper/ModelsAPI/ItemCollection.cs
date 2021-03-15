using MongoDB.Bson.Serialization.Attributes;

namespace RagnaLib.Wrapper.ModelsAPI
{
    [BsonIgnoreExtraElements]
    public class ItemCollection
    {
        [BsonElement("itemId")] public int Id { get; set; }

        [BsonElement("nameItem")] public string Name { get; set; }

        [BsonElement("itemImgUrl")] public string ImgUrl { get; set; }

        [BsonElement("collectionImgUrl")] public string CollectionImgUrl { get; set; }

        [BsonElement("cardImgUrl")] public string CardImgUrl { get; set; }

        [BsonElement("itemDescription")] public string Description { get; set; }
    }
}