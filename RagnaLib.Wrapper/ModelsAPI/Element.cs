using MongoDB.Bson.Serialization.Attributes;

namespace RagnaLib.Wrapper.ModelsAPI
{
    public class Element
    {
        [BsonElement("neutral")]
        public int Neutral { get; set; }

        [BsonElement("water")]
        public int Water { get; set; }

        [BsonElement("earth")]
        public int Earth { get; set; }

        [BsonElement("fire")]
        public int Fire { get; set; }

        [BsonElement("wind")]
        public int Wind { get; set; }

        [BsonElement("poison")]
        public int Poison { get; set; }

        [BsonElement("holy")]
        public int Holy { get; set; }

        [BsonElement("dark")]
        public int Dark { get; set; }

        [BsonElement("ghost")]
        public int Ghost { get; set; }

        [BsonElement("undead")]
        public int Undead { get; set; }
    }

}