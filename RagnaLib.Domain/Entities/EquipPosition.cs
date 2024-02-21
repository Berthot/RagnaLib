using System.Collections.Generic;
using RagnaLib.Domain.Bases;
using RagnaLib.Domain.Bases.Abstracts;

namespace RagnaLib.Domain.Entities;

public class EquipPosition : Entity
{
        
    public string Position { get; set; }
        
    public string Description { get; set; }
        
    public virtual IEnumerable<ItemEquipPositionMap> ItemEquipPositionMaps { get; set; }
}