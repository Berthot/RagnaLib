using System.Collections.Generic;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Seeds
{
    public static class ItemTypeSeed
    {
        public static List<ItemType> SeedItemType()
        {
            return new List<ItemType>()
            {
                new ItemType()
                {
                    Id = 1,
                    Name = "Consumable"
                },
                new ItemType()
                {
                    Id = 2,
                    Name = "Armor"
                },
                new ItemType()
                {
                    Id = 3,
                    Name = "Weapon"
                },
                new ItemType()
                {
                    Id = 4,
                    Name = "Ammo"
                },
                new ItemType()
                {
                    Id = 5,
                    Name = "Card"
                },
                new ItemType()
                {
                    Id = 6,
                    Name = "Costume"
                },
                new ItemType()
                {
                    Id = 7,
                    Name = "Other"
                },
                new ItemType()
                {
                    Id = 8,
                    Name = "Shadow Equipment"
                }
            };
        }
    }
}