using System.Collections.Generic;
using Domain.Entities;

namespace Infrastructure.Data.Seeds;

public static class SeedRace
{

    public static List<Race> SeedsRace()
    {
        return new List<Race>()
        {
            new Race() {Id = 1 , Name = "amorfo", EnName = "formless"},
            new Race() {Id = 2 , Name = "anjo", EnName = "angel"},
            new Race() {Id = 3 , Name = "bruto", EnName = "brute"},
            new Race() {Id = 4 , Name = "demônio", EnName = "demon"},
            new Race() {Id = 5 , Name = "dragão", EnName = "dragon"},
            new Race() {Id = 6 , Name = "humanoide", EnName = "human"},
            new Race() {Id = 7 , Name = "inseto", EnName = "insect"},
            new Race() {Id = 8 , Name = "morto-vivo", EnName = "undead"},
            new Race() {Id = 9 , Name = "peixe", EnName = "fish"},
            new Race() {Id = 10 , Name = "planta", EnName = "plant"},
            new Race() {Id = 11 , Name = "doram", EnName = "null"},
            new Race() {Id = 12 , Name = "humano", EnName = "null"},
        };
    }
}