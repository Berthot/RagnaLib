using System.Collections;
using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class Npc
    {
        public int Id { get; set; }
        public int RagnaPrideNpcId { get; set; }
        public string Name { get; set; }
        public string MapName { get; set; }
        public int Price { get; set; }
        public IEnumerable<NpcItemMap> NpcItemMaps { get; set; }
    }
}