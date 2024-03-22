using System.Collections.Generic;
using Domain.Bases.Abstracts;

namespace Domain.Entities;

public class EquipPosition : Entity
{
        
    public string Position { get; set; }
        
    public string Description { get; set; }
        
    public virtual IEnumerable<ItemEquipPositionMap> ItemEquipPositionMaps { get; set; }
}