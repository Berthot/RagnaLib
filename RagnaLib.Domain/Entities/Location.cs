using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class Location
    {
        public string Name { get; set; }
        
        public string Id { get; set; }
        
        public string MapUrl { get; set; } // https://www.divine-pride.net/img/map/original/gef_fild10
        
        public string MapCleanUrl { get; set; } // https://www.divine-pride.net/img/map/raw/gef_fild10
        
        public IEnumerable<Monster> Monsters { get; set; }
    }
}