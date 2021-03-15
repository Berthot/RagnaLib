namespace RagnaLib.Domain.Entities
{
    public class MonsterItemMap
    {
        public int Id { get; set; }
        public int MonsterId { get; set; }
        public int ItemId { get; set; }
        public virtual Monster Monster { get; set; }
        public virtual Item Item { get; set; }
        public int DropRate { get; set; }
    }
}