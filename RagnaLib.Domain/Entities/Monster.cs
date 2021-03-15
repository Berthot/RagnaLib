using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GifUrl { get; set; }
        public int ElementId { get; set; }
        public List<MonsterPerLocationMap> MonsterPerLocationMaps { get; set; }
        public List<MonsterItemMap> MonsterItemMaps { get; set; }
        
        public virtual Element Element { get; set; }

    }
}

// "id": "1785",
// "name": "Atroce",
// "gifUrl": "https://static.ragnaplace.com/db/npc/gif/1785.gif",