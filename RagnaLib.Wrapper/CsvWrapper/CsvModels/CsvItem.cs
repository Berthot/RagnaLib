namespace RagnaLib.Wrapper.CsvWrapper.CsvModels
{
    public class CsvItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string SmallImageUrl { get; set; }
        public string ImageUrl { get; set; }
        public string CardImageUrl { get; set; }
        public string Description { get; set; }
        public int ItemTypeId { get; set; }
        public int SubTypeId { get; set; }
        public bool Refinable { get; set; }
        public int Attack { get; set; }
        public int MagicAttack { get; set; }
        public int RequiredLevel { get; set; }
        public int LimitLevel { get; set; }
        public int ItemLevel { get; set; }
        public float Weight { get; set; }
        public int Defense { get; set; }
        public int Slots { get; set; }
        public string UnidName { get; set; }
        public string CardPrefix { get; set; }
    }
}