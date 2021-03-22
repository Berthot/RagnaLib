using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class EquipPosition
    {
        public int Id { get; set; }
        
        public string Position { get; set; }
        
        public string Description { get; set; }
        
        public virtual IEnumerable<ItemEquipPositionMap> ItemEquipPositionMaps { get; set; }
    }
}