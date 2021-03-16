using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Tier { get; set; }
        public short Neutral { get; set; }
        public short Water { get; set; }
        public short Earth { get; set; }
        public short Fire { get; set; }
        public short Wind { get; set; }
        public short Poison { get; set; }
        public short Holy { get; set; }
        public short Shadow { get; set; }
        public short Ghost { get; set; }
        public short Undead { get; set; }

        public IEnumerable<Monster> Monsters { get; set; }
    }
}