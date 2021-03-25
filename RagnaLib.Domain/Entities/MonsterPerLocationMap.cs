namespace RagnaLib.Domain.Entities
{
    public class MonsterPerLocationMap
    {
        public int Id { get; set; }
        public int MonsterId { get; set; }
        public int LocationId { get; set; }
        public int Quantity { get; set; }
        public virtual Monster Monster { get; set; }
        public virtual Location Location { get; set; }
        public int RespawnTime { get; set; }
    }
}