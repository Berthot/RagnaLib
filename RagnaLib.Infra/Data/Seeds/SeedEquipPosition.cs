using System.Collections.Generic;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Seeds;

public static class SeedEquipPosition
{
    public static IEnumerable<EquipPosition> EquipPositionSeed()
    {
            return new List<EquipPosition>()
            {
                new EquipPosition()  {Id = -1, Position = "Unknown", Description = "-"},
                new EquipPosition()  {Id =  1, Position = "Accessory", Description = "Accessory"},
                new EquipPosition()  {Id =  2, Position = "Accessory (Left)", Description = "Accessory"},
                new EquipPosition()  {Id =  3, Position = "Accessory (Right)", Description = "Accessory"},
                new EquipPosition()  {Id =  4, Position = "Body", Description = "Armor"},
                new EquipPosition()  {Id =  5, Position = "Both Hand", Description = "Boath Hand"},
                new EquipPosition()  {Id =  6, Position = "Garment", Description = "Garment"},
                new EquipPosition()  {Id =  7, Position = "Left Hand", Description = "Shield"},
                new EquipPosition()  {Id =  8, Position = "Shoes", Description = "Shoes"},
                new EquipPosition()  {Id =  9, Position = "Right Hand", Description = "Weapon"},
                new EquipPosition()  {Id = 10, Position = "Shadow Weapon", Description = "Shadow Weapon"},
                new EquipPosition()  {Id = 11, Position = "Right Shadow Accessory", Description = "Shadow Acessory"},
                new EquipPosition()  {Id = 12, Position = "Shadow Armor", Description = "Shadow Armor"},
                new EquipPosition()  {Id = 13, Position = "Shadow Shield", Description = "Shadow Shield"},
                new EquipPosition()  {Id = 14, Position = "Shadow Shoes", Description = "Shadow Shoes"},
                new EquipPosition()  {Id = 15, Position = "Left Shadow Accessory", Description = "Shadow Acessory"},
                new EquipPosition()  {Id = 16, Position = "Lower Costume Headgear", Description = "Costume"},
                new EquipPosition()  {Id = 17, Position = "Middle Costume Headgear", Description = "Costume"},
                new EquipPosition()  {Id = 18, Position = "Upper Costume Headgear", Description = "Costume"},
                new EquipPosition()  {Id = 19, Position = "Middle/Lower Costume Headgear", Description = "Costume"},
                new EquipPosition()  {Id = 20, Position = "Upper/Lower Costume Headgear", Description = "Costume"},
                new EquipPosition()  {Id = 21, Position = "Upper/Middle Costume Headgear", Description = "Costume"},
                new EquipPosition()  {Id = 22, Position = "Upper/Middle/Lower Costume Headgear", Description = "Costume"},
                new EquipPosition()  {Id = 23, Position = "Costume Garment", Description = "Costume Garment"},
                new EquipPosition()  {Id = 24, Position = "Lower Headgear", Description = "Headgear"},
                new EquipPosition()  {Id = 25, Position = "Middle Headgear", Description = "Headgear"},
                new EquipPosition()  {Id = 26, Position = "Upper Headgear", Description = "Headgear"},
                new EquipPosition()  {Id = 27, Position = "Upper/Middle/Lower Headgear", Description = "Headgear"},
                new EquipPosition()  {Id = 28, Position = "Upper/Middle Headgear", Description = "Headgear"},
                new EquipPosition()  {Id = 29, Position = "Upper/Lower Headgear", Description = "Headgear"},
                new EquipPosition()  {Id = 30, Position = "Middle/Lower Headgear", Description = "Headgear"},
                new EquipPosition()  {Id = 31, Position = "Enchant", Description = "Enchant"},
            };
        }
}