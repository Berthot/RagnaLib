using RagnaLib.Domain.Entities;
using RagnaLib.Domain.ValueObjects;
using RagnaLib.Wrapper.CsvWrapper.CsvModels;

namespace RagnaLib.Wrapper;

public class WrapperFactory
{
    public Element GetElementModel(CsvElement csv)
    {
        return new Element()
        {
            Id = csv.Id,
            Name = csv.Name,
            Tier = csv.Tier,
            Neutral = csv.Neutral,
            Water = csv.Water,
            Earth = csv.Earth,
            Fire = csv.Fire,
            Wind = csv.Wind,
            Poison = csv.Poison,
            Holy = csv.Holy,
            Dark = csv.Dark,
            Ghost = csv.Ghost,
            Undead = csv.Undead,
        };
    }

    public Location GetLocationModel(CsvLocation csv)
    {
        return new Location()
        {
            Id = csv.Id,
            NameId = csv.NameId,
            Name = csv.Name,
            MapUrl = csv.MapUrl,
            MapCleanUrl = csv.MapCleanUrl,
            Type = csv.Type,
        };
    }

    public Item GetItemModel(CsvItem csv)
    {
        return new Item()
        {
            Id = csv.Id,
            Name = csv.Name,
            Price = csv.Price,
            SmallImageUrl = csv.SmallImageUrl,
            ImageUrl = csv.ImageUrl,
            CardImageUrl = csv.CardImageUrl,
            Description = csv.Description,
            ItemTypeId = csv.ItemTypeId,
            SubTypeId = csv.SubTypeId,
            Refinable = csv.Refinable,
            Attack = csv.Attack,
            MagicAttack = csv.MagicAttack,
            RequiredLevel = csv.RequiredLevel,
            LimitLevel = csv.LimitLevel,
            ItemLevel = csv.ItemLevel,
            Weight = csv.Weight,
            Defense = csv.Defense,
            Slots = csv.Slots,
            UnidName = csv.UnidName,
            CardPrefix = csv.CardPrefix,
        };
    }

    public Monster GetMonsterModel(CsvMonster csv)
    {
        return new Monster()
        {
            Id = csv.Id,
            Name = csv.Name,
            DbName = csv.DbName,
            Level = csv.Level,
            Health = csv.Health,
            Size = csv.Size,
            GifUrl = csv.GifUrl,
            HasDrop = csv.HasDrop,
            HasLocation = csv.HasLocation,
            IsMvp = csv.IsMvp,
            Experience = new Experience()
            {
                Job = csv.JobExperience,
                Base = csv.BaseExperience
            },
            PhysicalAttack = new Attack()
            {
                MinimalDamage = csv.MinimumPhysicalAttack,
                MaximumDamage = csv.MaximumPhysicalAttack
            },
            MagicAttack = new Attack()
            {
                MinimalDamage = csv.MinimumMagicAttack,
                MaximumDamage = csv.MaximumMagicAttack
            },
            Defense = new Defense()
            {
                MagicDefense = csv.MagicDefense,
                PhysicalDefense = csv.PhysicalDefense
            },
            PrimaryAttribute = new PrimaryAttribute()
            {
                Str = csv.Str,
                Agi = csv.Agi,
                Vit = csv.Vit,
                Int = csv.Int,
                Dex = csv.Dex,
                Luk = csv.Luk
            },
            SecondaryAttribute = new SecondaryAttribute()
            {
                AttackRange = csv.AttackRange,
                AttackSpeed = csv.AttackSpeed,
                Flee = csv.Flee,
                Hit = csv.Hit,
                Hp = csv.Hp,
                Sp = csv.Sp
            },
            ElementId = csv.ElementId,
            RaceId = csv.RaceId,
            ScaleId = csv.ScaleId,
        };
    }
}