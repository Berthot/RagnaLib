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
                new EquipPosition() {Id = -1, Position = "Unknown"},
                new EquipPosition() {Id = 1, Position = "Accessory (Left)"},
                new EquipPosition() {Id = 2, Position = "Accessory (Right)"},
                new EquipPosition() {Id = 3, Position = "Armor"},
                new EquipPosition() {Id = 4, Position = "Body"},
                new EquipPosition() {Id = 5, Position = "Both hand"},
                new EquipPosition() {Id = 6, Position = "Costume Garment"},
                new EquipPosition() {Id = 7, Position = "Enchant"},
                new EquipPosition() {Id = 8, Position = "Essence"},
                new EquipPosition() {Id = 9, Position = "Garment"},
                new EquipPosition() {Id = 10, Position = "Headgear"},
                new EquipPosition() {Id = 11, Position = "Left Hand"},
                new EquipPosition() {Id = 12, Position = "Middle Headgear"},
                new EquipPosition() {Id = 13, Position = "Right Hand"},
                new EquipPosition() {Id = 14, Position = "Shadow Accessory (Left)"},
                new EquipPosition() {Id = 15, Position = "Shadow Accessory (Right)"},
                new EquipPosition() {Id = 16, Position = "Shadow Armor"},
                new EquipPosition() {Id = 17, Position = "Shadow Shield"},
                new EquipPosition() {Id = 18, Position = "Shadow Shoes"},
                new EquipPosition() {Id = 19, Position = "Shadow Weapon"},
                new EquipPosition() {Id = 20, Position = "Shield"},
                new EquipPosition() {Id = 21, Position = "Shoes"},
                new EquipPosition() {Id = 22, Position = "Upper Costume Headgear"},
                new EquipPosition() {Id = 23, Position = "Weapon"},
            };
        }
    }
}