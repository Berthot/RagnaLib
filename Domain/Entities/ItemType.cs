using System.Collections.Generic;
using Domain.Bases.Abstracts;

namespace Domain.Entities;

public class ItemType : Entity
{
    public string Name { get; set; }
    public IEnumerable<Item> Items { get; set; }
}