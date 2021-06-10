namespace RagnaLib.Domain.Dto.Monster
{
    public class MonsterLocationsDto
    {
        public string LocationName { get; set; }
        public string MapUrl { get; set; } // https://www.divine-pride.net/img/map/original/gef_fild10
        public string MapCleanUrl { get; set; } // https://www.divine-pride.net/img/map/raw/gef_fild10
        public string Type { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int RespawnTime { get; set; }
    }
}