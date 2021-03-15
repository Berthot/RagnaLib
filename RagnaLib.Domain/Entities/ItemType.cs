using RagnaLib.Domain.Enum;

namespace RagnaLib.Domain.Entities
{
    public class ItemType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SubType SubType { get; set; }
    }
}