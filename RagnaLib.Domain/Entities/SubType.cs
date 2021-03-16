using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class SubType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}