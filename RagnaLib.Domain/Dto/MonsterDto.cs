using System.Collections.Generic;
using System.Text.Json.Serialization;
using RagnaLib.Domain.Dto.Monster;

namespace RagnaLib.Domain.Dto
{
    public class MonsterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonPropertyName("DatabaseName")]
        public string DbName { get; set; }
        public int Level { get; set; }
        public int Health { get; set; }
        public int Size { get; set; }
        public string GifUrl { get; set; }
        public int ElementId { get; set; }
        public string Element { get; set; }
        public bool IsMvp { get; set; }
        public string Scale { get; set; }
        public ExperienceDto Experience { get; set; }
        public string PhysicalAttack { get; set; }
        public string MagicAttack { get; set; }
        public string MagicDefense { get; set; }
        public string PhysicalDefense { get; set; }
        public string Race { get; set; }
        public PrimaryStatsDto PrimaryStats { get; set; }
        public SecondaryStatsDto SecondaryStats { get; set; }
        public List<MonsterLocationsDto> MonsterPerLocationMaps { get; set; }
        public List<MonsterDropsDto> MonsterItemMaps { get; set; }
        public List<MonsterDropsDto> MonsterMvpDrop { get; set; }
        

    }


}
