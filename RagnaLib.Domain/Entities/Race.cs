using System.Collections.Generic;
using RagnaLib.Domain.Bases;
using RagnaLib.Domain.Bases.Abstracts;

namespace RagnaLib.Domain.Entities
{
    public class Race : Entity
    {
        
        public string Name { get; set; }
        
        public IEnumerable<Monster> Monsters { get; set; }
        public string EnName { get; set; }
    }
}