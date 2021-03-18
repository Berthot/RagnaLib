using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class Race
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public IEnumerable<Monster> Monsters { get; set; }
        public string EnName { get; set; }
    }
}