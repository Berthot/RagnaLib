using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.Data.Seeds;

public static class SeedItemType
{
    public static List<ItemType> SeedsItemType()
    {
        return new List<ItemType>()
        {
            new ItemType() {Id = -1, Name = "Unknown"},                
            new ItemType()
            {
                Id = 1,
                Name = "Weapon"
            },                
            new ItemType()
            {
                Id = 2,
                Name = "Armor"
            },
            new ItemType()
            {
                Id = 3,
                Name = "Consumable"
            },
            new ItemType()
            {
                Id = 4,
                Name = "Ammo"
            },
            new ItemType()
            {
                Id = 5,
                Name = "Etc."
            },
            new ItemType()
            {
                Id = 6,
                Name = "Cash"
            },
            new ItemType()
            {
                Id = 7,
                Name = "Costume"
            },
            new ItemType()
            {
                Id = 8,
                Name = "Shadow Equipment"
            }
            , new ItemType()
            {
                Id = 9,
                Name = "Card"
            }
        };
    }
}