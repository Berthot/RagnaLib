using System.Collections.Generic;
using Domain.Bases.Abstracts;

namespace Domain.Entities;

public class Race : Entity
{
        
    public string Name { get; set; }
        
    public IEnumerable<Monster> Monsters { get; set; }
    public string EnName { get; set; }
}