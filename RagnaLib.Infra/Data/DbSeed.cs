using Microsoft.EntityFrameworkCore;
using RagnaLib.Domain.Entities;
using RagnaLib.Infra.Data.Seeds;

namespace RagnaLib.Infra.Data
{
    public static class DbSeed
    {
        public static void SetSeed(this ModelBuilder builder)
        {
            
            builder.Entity<ItemType>().HasData(ItemTypeSeed.SeedItemType());
            
        }
    }

}