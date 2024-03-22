using Domain.Entities;
using Domain.ValueObjects;
using WrapperDivinePride.Dicts;
using WrapperDivinePride.Models;
using Attack = Domain.ValueObjects.Attack;

namespace WrapperDivinePride.Mapper;

public static class MonsterMap
{
    private const int DefaultValue = 0;

    public static Monster Map(this MonsterJson obj)
    {
        var map = new Monster();
        map.Id = obj.Id.GetValueOrDefault();
        map.Name = obj.Name;
        map.DbName = obj.Dbname;
        map.Level = obj.Stats.Level.GetValueOrDefault();
        map.Health = obj.Stats.Health.GetValueOrDefault();
        map.Size = obj.Stats.Scale.GetValueOrDefault();
        map.GifUrl = $"https://static.ragnaplace.com/db/npc/gif/{obj.Id}.gif";
        map.HasDrop = obj.Drops.Any();
        map.HasLocation = obj.Spawn.Any();
        map.IsMvp = obj.Stats.Mvp == 1;
        map.Experience = new Experience
        {
            Base = obj.Stats.BaseExperience.GetValueOrDefault(),
            Job = obj.Stats.JobExperience.GetValueOrDefault()
        };
        map.PhysicalAttack = new Attack
        {
            MinimalDamage = obj.Stats?.Attack?.Minimum.GetValueOrDefault() ?? DefaultValue,
            MaximumDamage = obj.Stats?.Attack?.Maximum.GetValueOrDefault() ?? DefaultValue
        };
        map.MagicAttack = new Attack
        {
            MinimalDamage = obj.Stats?.MagicAttack?.Minimum.GetValueOrDefault() ?? DefaultValue,
            MaximumDamage = obj.Stats?.MagicAttack?.Maximum.GetValueOrDefault() ?? DefaultValue,
        };
        map.Defense = new Defense
        {
            MagicDefense =    obj.Stats?.MagicDefense.GetValueOrDefault() ?? DefaultValue,
            PhysicalDefense = obj.Stats?.Defense.GetValueOrDefault() ?? DefaultValue,
        };
        map.PrimaryAttribute = new PrimaryAttribute
        {
            Str = obj.Stats?.Str.GetValueOrDefault() ?? DefaultValue,
            Agi = obj.Stats?.Agi.GetValueOrDefault() ?? DefaultValue,
            Vit = obj.Stats?.Vit.GetValueOrDefault() ?? DefaultValue,
            Int = obj.Stats?.Int.GetValueOrDefault() ?? DefaultValue,
            Dex = obj.Stats?.Dex.GetValueOrDefault() ?? DefaultValue,
            Luk = obj.Stats?.Luk.GetValueOrDefault() ?? DefaultValue
        };
        map.SecondaryAttribute = new SecondaryAttribute
        {
            Hp =   obj.Stats?.Health.GetValueOrDefault() ?? DefaultValue,
            Sp =   obj.Stats?.Sp.GetValueOrDefault() ?? DefaultValue,
            Flee = obj.Stats?.Flee.GetValueOrDefault() ?? DefaultValue,
            Hit =  obj.Stats?.Hit.GetValueOrDefault() ?? DefaultValue,
            AttackSpeed = obj.Stats?.AttackSpeed.GetValueOrDefault() ?? DefaultValue,
            AttackRange = obj.Stats?.AttackRange.GetValueOrDefault() ?? DefaultValue
        };
        map.MonsterPerLocationMaps = obj.Spawn.Select(x=> new MonsterPerLocationMap
        {
            // Id = 0,
            // MonsterId = 0,
            // Monster = null,
            LocationId = 0,
            // Location = null,
            Quantity = x.Amount.GetValueOrDefault(),
            RespawnTime = x.RespawnTime.GetValueOrDefault()
        });
        map.MonsterItemMaps = obj.Drops.Select(x=> new MonsterItemMap
        {
            // Id = 0,
            // MonsterId = 0,
            // Monster = null,
            ItemId = x.ItemId.GetValueOrDefault(),
            // Item = null,
            DropRate = x.Chance.GetValueOrDefault() / 100,
            Stealable = x.StealProtected
        });
        map.MonsterMvpDropMaps = obj.Mvpdrops.Select(x => new MonsterMvpDropMap
        {
            // Id = 0,
            // MonsterId = 0,
            // Monster = null,
            ItemId = x.ItemId.GetValueOrDefault(),
            // Item = null,
            DropRate = x.Chance.GetValueOrDefault() / 100,
            Stealable = x.StealProtected
        });
        map.ElementId = ElementDict.Get()[obj?.Stats?.Element.GetValueOrDefault() ?? DefaultValue]; // Element = new Element(),
        map.ScaleId = ScaleDict.Get()[obj?.Stats?.Scale.GetValueOrDefault() ?? DefaultValue]; // Scale = new Scale(),
        map.RaceId = RaceDict.Get()[obj?.Stats?.Race.GetValueOrDefault() ?? DefaultValue]; // Race = new Race(),
        return map;
    }
}