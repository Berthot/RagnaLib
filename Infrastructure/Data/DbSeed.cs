using Infrastructure.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Data;

public static class DbSeed
{
    public static void SetSeed(this ModelBuilder builder)
    {
            
        builder.Entity<ItemType>().HasData(SeedItemType.SeedsItemType());
        builder.Entity<Race>().HasData(SeedRace.SeedsRace());
        builder.Entity<SubType>().HasData(SeedItemSubType.SubTypeSeed());
        builder.Entity<EquipPosition>().HasData(SeedEquipPosition.EquipPositionSeed());
        builder.Entity<Scale>().HasData(SeedScale.ScaleSeed());

    }
}