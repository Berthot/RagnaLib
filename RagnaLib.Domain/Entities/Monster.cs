using System.Collections.Generic;
using RagnaLib.Domain.ValueObjects;

namespace RagnaLib.Domain.Entities
{
    public class Monster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DbName { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Size { get; set; }
        public string GifUrl { get; set; }
        public int ElementId { get; set; }
        public virtual Element Element { get; set; }
        public bool HasDrop { get; set; }
        public bool HasLocation { get; set; }
        public bool IsMvp { get; set; }
        public int RaceId { get; set; }
        public int ScaleId { get; set; }
        public virtual Scale Scale { get; set; }
        public Experience Experience { get; set; }
        public Attack PhysicalAttack { get; set; }
        public Attack MagicAttack { get; set; }
        public Defense Defense { get; set; }
        public PrimaryAttribute PrimaryAttribute { get; set; }
        public SecondaryAttribute SecondaryAttribute { get; set; }
        public virtual Race Race { get; set; }
        public IEnumerable<MonsterPerLocationMap> MonsterPerLocationMaps { get; set; }
        public IEnumerable<MonsterItemMap> MonsterItemMaps { get; set; }
        
        public List<MonsterMvpDropMap> MonsterMvpDropMaps { get; set; }
    }
}

// "id": "1785",
// "name": "Atroce",
// "gifUrl": "https://static.ragnaplace.com/db/npc/gif/1785.gif",