using System.Collections.Generic;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Data.Seeds;

public static class SeedItemSubType
{
    public static IEnumerable<SubType> SubTypeSeed()
    {
        return new List<SubType>()
        {
            new SubType() {Id = -1, Name = "Unknown", Location = "-"},
            new SubType() {Id = 1, Name = "Dagger", Location = "Right Hand"},
            new SubType() {Id = 2, Name = "Sword", Location = "Right Hand"},
            new SubType() {Id = 3, Name = "Two-handed Sword", Location = "Both hand"},
            new SubType() {Id = 4, Name = "Spear", Location = "Right Hand"},
            new SubType() {Id = 5, Name = "Two-handed Spear", Location = "Both hand"},
            new SubType() {Id = 6, Name = "Axe", Location = "Right Hand"},
            new SubType() {Id = 7, Name = "Two-handed Axe", Location = "Both hand"},
            new SubType() {Id = 8, Name = "Mace", Location = "Right Hand"},
            new SubType() {Id = 9, Name = "Rod", Location = "Right Hand"},
            new SubType() {Id = 10, Name = "Two-handed Rod", Location = "Both hand"},
            new SubType() {Id = 11, Name = "Bow", Location = "Both hand"},
            new SubType() {Id = 12, Name = "Fist weapon", Location = "Right Hand"},
            new SubType() {Id = 13, Name = "Instrument", Location = "Right Hand"},
            new SubType() {Id = 14, Name = "Whip", Location = "Right Hand"},
            new SubType() {Id = 15, Name = "Book", Location = "Right Hand"},
            new SubType() {Id = 16, Name = "Katar", Location = "Both hand"},
            new SubType() {Id = 17, Name = "Gatling Gun", Location = "Both hand"},
            new SubType() {Id = 18, Name = "Shotgun", Location = "Both hand"},
            new SubType() {Id = 19, Name = "Grenade Launcher", Location = "Both hand"},
            new SubType() {Id = 20, Name = "Shuriken", Location = "Both hand"},
            new SubType() {Id = 21, Name = "Accessory", Location = "Accessory"},
            new SubType() {Id = 22, Name = "Accessory (Right)", Location = "Accessory"},
            new SubType() {Id = 23, Name = "Accessory (Left)", Location = "Accessory"},
            new SubType() {Id = 24, Name = "Helm", Location = "Middle Headgear"},
            new SubType() {Id = 25, Name = "Armor", Location = "Body"},
            new SubType() {Id = 26, Name = "Garment", Location = "Garment"},
            new SubType() {Id = 27, Name = "Shoes", Location = "Shoes"},
            new SubType() {Id = 28, Name = "Pet", Location = "-"},
            new SubType() {Id = 29, Name = "Special", Location = "-"},
            new SubType() {Id = 30, Name = "Regeneration", Location = "-"},
            new SubType() {Id = 31, Name = "Taming item", Location = "-"},
            new SubType() {Id = 32, Name = "Arrow", Location = "-"},
            new SubType() {Id = 33, Name = "Cannonball", Location = "-"},
            new SubType() {Id = 34, Name = "Throw Weapon", Location = "-"},
            new SubType() {Id = 35, Name = "Ammo", Location = "-"},
            new SubType() {Id = 36, Name = "-", Location = "-"},
            new SubType() {Id = 37, Name = "Pistol", Location = "-"},
            new SubType() {Id = 38, Name = "Rifle", Location = "-"},
            new SubType() {Id = 39, Name = "Shield", Location = "Left Hand"},
            new SubType() {Id = 40, Name = "Costume Garment", Location = "Costume Garment"},
            new SubType() {Id = 41, Name = "Shadow Weapon", Location = "Shadow Weapon"},
            new SubType() {Id = 42, Name = "Shadow Armor", Location = "Shadow Armor"},
            new SubType() {Id = 43, Name = "Shadow Shield", Location = "Shadow Shield"},
            new SubType() {Id = 44, Name = "Shadow Shoes", Location = "Shadow Shoes"},
            new SubType() {Id = 45, Name = "Shadow Acc. (Right)", Location = "Right Shadow Accessory"},
            new SubType() {Id = 46, Name = "Shadow Acc. (Left)", Location = "Left Shadow Accessory"},
            new SubType() {Id = 47, Name = "Costume Helm", Location = "Upper Costume Headgear"},
        };
    }
}