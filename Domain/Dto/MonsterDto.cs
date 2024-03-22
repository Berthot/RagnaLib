using System.Collections.Generic;
using System.Text.Json.Serialization;
using Domain.Dto.Monster;

namespace Domain.Dto;

public class MonsterDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    [JsonPropertyName("DatabaseName")] public string DbName { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public string Size { get; set; }
    public string GifUrl { get; set; }
    public bool IsMvp { get; set; }
    public string Scale { get; set; }
    public string PhysicalAttack { get; set; }
    public string MagicAttack { get; set; }
    public string MagicDefense { get; set; }
    public string PhysicalDefense { get; set; }
    public string Race { get; set; }
    public ElementDto Element { get; set; }
    public ExperienceDto Experience { get; set; }
    public PrimaryStatsDto PrimaryStats { get; set; }
    public SecondaryStatsDto SecondaryStats { get; set; }
    public List<MonsterLocationsDto> Locations { get; set; }
    public List<MonsterDropsDto> MonsterDrops { get; set; }
    public List<MonsterDropsDto> MonsterMvpDrops { get; set; }
}