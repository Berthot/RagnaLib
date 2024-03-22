using Domain.Bases.Abstracts;

namespace Domain.Entities;

public class MonsterItemMap : Entity
{
    public int MonsterId { get; set; }
    public int ItemId { get; set; }
    public virtual Monster Monster { get; set; }
    public virtual Item Item { get; set; }
    public int DropRate { get; set; }
    public bool Stealable { get; set; }
}