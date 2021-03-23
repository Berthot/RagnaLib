using System.Collections.Generic;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Seeds
{
    public static class SeedEquipPosition
    {
        public static IEnumerable<EquipPosition> EquipPositionSeed()
        {
            return new List<EquipPosition>()
            {
                new() {Id = -1, Position = "Unknown", Description = "-"},
                new() {Id =  1, Position = "Accessory", Description = "Accessory"},
                new() {Id =  2, Position = "Accessory (Left)", Description = "Accessory"},
                new() {Id =  3, Position = "Accessory (Right)", Description = "Accessory"},
                new() {Id =  4, Position = "Body", Description = "Armor"},
                new() {Id =  5, Position = "Both Hand", Description = "Boath Hand"},
                new() {Id =  6, Position = "Garment", Description = "Garment"},
                new() {Id =  7, Position = "Left Hand", Description = "Shield"},
                new() {Id =  8, Position = "Shoes", Description = "Shoes"},
                new() {Id =  9, Position = "Right Hand", Description = "Weapon"},
                new() {Id = 10, Position = "Shadow Weapon", Description = "Shadow Weapon"},
                new() {Id = 11, Position = "Right Shadow Accessory", Description = "Shadow Acessory"},
                new() {Id = 12, Position = "Shadow Armor", Description = "Shadow Armor"},
                new() {Id = 13, Position = "Shadow Shield", Description = "Shadow Shield"},
                new() {Id = 14, Position = "Shadow Shoes", Description = "Shadow Shoes"},
                new() {Id = 15, Position = "Left Shadow Accessory", Description = "Shadow Acessory"},
                new() {Id = 16, Position = "Lower Costume Headgear", Description = "Costume"},
                new() {Id = 17, Position = "Middle Costume Headgear", Description = "Costume"},
                new() {Id = 18, Position = "Upper Costume Headgear", Description = "Costume"},
                new() {Id = 19, Position = "Middle/Lower Costume Headgear", Description = "Costume"},
                new() {Id = 20, Position = "Upper/Lower Costume Headgear", Description = "Costume"},
                new() {Id = 21, Position = "Upper/Middle Costume Headgear", Description = "Costume"},
                new() {Id = 22, Position = "Upper/Middle/Lower Costume Headgear", Description = "Costume"},
                new() {Id = 23, Position = "Costume Garment", Description = "Costume Garment"},
                new() {Id = 24, Position = "Lower Headgear", Description = "Headgear"},
                new() {Id = 25, Position = "Middle Headgear", Description = "Headgear"},
                new() {Id = 26, Position = "Upper Headgear", Description = "Headgear"},
                new() {Id = 27, Position = "Upper/Middle/Lower Headgear", Description = "Headgear"},
                new() {Id = 28, Position = "Upper/Middle Headgear", Description = "Headgear"},
                new() {Id = 29, Position = "Upper/Lower Headgear", Description = "Headgear"},
                new() {Id = 30, Position = "Middle/Lower Headgear", Description = "Headgear"},
                new() {Id = 31, Position = "Enchant", Description = "Enchant"},
            };
        }
    }
}