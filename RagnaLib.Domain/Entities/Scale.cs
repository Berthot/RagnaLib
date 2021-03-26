using System.Collections.Generic;
using RagnaLib.Domain.Entities.Base;

namespace RagnaLib.Domain.Entities
{
    public class Scale : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Monster> Monsters { get; set; }
    }
}