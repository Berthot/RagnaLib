namespace RagnaLib.Domain.Dto.Monster
{
    public class MonsterDropsDto
    {
        public int ItemId { get; set; }
        public int MonsterId { get; set; }
        public int DropRate { get; set; }
        public string Name { get; set; }
        public string SmallImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string CardImageUrl { get; set; }
        public string ItemType { get; set; }
    }
}