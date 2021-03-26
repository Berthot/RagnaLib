using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class SubType : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}