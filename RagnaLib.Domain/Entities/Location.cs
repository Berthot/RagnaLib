using System.Collections.Generic;
using RagnaLib.Domain.Bases;
using RagnaLib.Domain.Bases.Abstracts;

namespace RagnaLib.Domain.Entities
{
    public class Location : Entity
    {
        public string NameId { get; set; }
        public string Name { get; set; }
        public string MapUrl { get; set; } // https://www.divine-pride.net/img/map/original/gef_fild10
        public string MapCleanUrl { get; set; } // https://www.divine-pride.net/img/map/raw/gef_fild10
        public string Type { get; set; }

        public IEnumerable<MonsterPerLocationMap> MonsterPerLocationMaps { get; set; }
    }
}