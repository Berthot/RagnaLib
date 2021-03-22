using Microsoft.EntityFrameworkCore;
using RagnaLib.Domain.Entities;
using RagnaLib.Infra.Data.Seeds;

namespace RagnaLib.Infra.Data
{
    public static class DbSeed
    {
        public static void SetSeed(this ModelBuilder builder)
        {
            
            builder.Entity<ItemType>().HasData(SeedItemType.SeedsItemType());
            builder.Entity<Race>().HasData(SeedRace.SeedsRace());
            builder.Entity<SubType>().HasData(SeedItemSubType.SubTypeSeed());
            builder.Entity<EquipPosition>().HasData(SeedEquipPosition.EquipPositionSeed());

        }
    }

}