using MongoDB.Bson.Serialization.Attributes;

namespace RagnaLib.Wrapper.ModelsAPI
{
    public class Stats
    {
        [BsonElement("monsterLevel")]
        public int? Level { get; set; }

        [BsonElement("monsterHp")]
        public int? Hp { get; set; }

        [BsonElement("monsterSize")]
        public int? Size { get; set; }

        [BsonElement("monsterRace")]
        public int? Race { get; set; }
    }
}