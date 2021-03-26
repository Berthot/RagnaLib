using RagnaLib.Domain.Entities.Base;

namespace RagnaLib.Domain.Entities
{
    public class MonsterMvpDropMap : Entity
    {
        public int MonsterId { get; set; }
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public virtual Monster Monster { get; set; }
        public bool Stealable { get; set; }
        public int DropRate { get; set; }
    }
}