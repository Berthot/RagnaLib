using Domain.Bases.Abstracts;

namespace Domain.Entities;

public class ItemEquipPositionMap : Entity
{
        
    public int ItemId { get; set; }
        
    public int EquipPositionId { get; set; }
        
    public virtual Item Item { get; set; }
        
    public virtual EquipPosition EquipPosition { get; set; }
}