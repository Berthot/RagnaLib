using System.Collections.Generic;

namespace RagnaLib.Domain.Entities
{
    public class ItemType : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}