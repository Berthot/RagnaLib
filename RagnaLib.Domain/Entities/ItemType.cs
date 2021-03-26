using System.Collections.Generic;
using RagnaLib.Domain.Entities.Base;

namespace RagnaLib.Domain.Entities
{
    public class ItemType : Entity
    {
        public string Name { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}