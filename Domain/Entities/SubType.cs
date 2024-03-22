using System.Collections.Generic;
using Domain.Bases.Abstracts;

namespace Domain.Entities;

public class SubType : Entity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public virtual List<Item> Items { get; set; }
}