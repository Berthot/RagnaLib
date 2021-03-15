using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace RagnaLib.Wrapper.ModelsAPI
{
    [BsonIgnoreExtraElements]
    public class MonsterCollection
    {
        [BsonElement("monsterId")] public string Id { get; set; }
        [BsonElement("monsterName")] public string Name { get; set; }

        [BsonElement("monsterGifUrl")] public string GifUrl { get; set; }
        
        [BsonElement("monsterStats")] public Stats Stats { get; set; }
        
        [BsonElement("elementExtraDamage")] public Element ElementExtraDamage { get; set; }
        
        [BsonElement("monsterDrops")] public List<ItemCollection> Drops { get; set; }

        [BsonElement("monsterSpawnMaps")] public List<Spawn> SpawnMaps { get; set; }
    }
}