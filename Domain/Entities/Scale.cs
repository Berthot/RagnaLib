using System.Collections.Generic;
using Domain.Bases.Abstracts;

namespace Domain.Entities;

public class Scale : Entity
{
    public string Name { get; set; }
    public IEnumerable<Monster> Monsters { get; set; }
}