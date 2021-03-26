namespace RagnaLib.Domain.Entities
{
    public class ItemEquipPositionMap : Entity
    {
        public int Id { get; set; }
        
        public int ItemId { get; set; }
        
        public int EquipPositionId { get; set; }
        
        public virtual Item Item { get; set; }
        
        public virtual EquipPosition EquipPosition { get; set; }
    }
}