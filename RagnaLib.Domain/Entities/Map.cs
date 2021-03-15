using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class Map
    {
        public string Name { get; set; }
        
        public string Id { get; set; }
        
        public string MapUrl { get; set; } // https://www.divine-pride.net/img/map/original/gef_fild10
        
        public string MapCleanUrl { get; set; } // https://www.divine-pride.net/img/map/raw/gef_fild10
        
        public List<Monster> Monsters { get; set; }
    }
}