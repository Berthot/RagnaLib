using System.Collections.Generic;
using Domain.Bases.Abstracts;

namespace Domain.Entities;

public class Element : Entity
{
    public string Name { get; set; }
    public short Tier { get; set; }
    public short Neutral { get; set; }
    public short Water { get; set; }
    public short Earth { get; set; }
    public short Fire { get; set; }
    public short Wind { get; set; }
    public short Poison { get; set; }
    public short Holy { get; set; }
    public short Dark { get; set; } // sombrio
    public short Ghost { get; set; } // fanstama
    public short Undead { get; set; } // morto-vivo

    public IEnumerable<Monster> Monsters { get; set; }
}