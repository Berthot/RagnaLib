using System.Collections.Generic;
using RagnaLib.Domain.Entities.Base;

namespace RagnaLib.Domain.Entities
{
    public class SubType : Entity
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual List<Item> Items { get; set; }
    }
}