using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class Scale
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Monster> Monsters { get; set; }
    }
}