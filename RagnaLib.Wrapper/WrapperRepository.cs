using System.Collections.Generic;
using System.Linq;
using RagnaLib.Domain.Entities;
using RagnaLib.Infra.Data;


namespace RagnaLib.Wrapper;

public class WrapperRepository
{
    private readonly Context _context;
        
    public WrapperRepository(Context context)
    {
        _context = context;
    }

    public void CreateLocationRange(List<Location> locations)
    {
        _context.Locations.AddRange(locations);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void CreateElementRange(List<Element> elements)
    {
        _context.Elements.AddRange(elements);

    }

    public void CreateItemRange(List<Item> itemModels)
    {
        _context.Items.AddRange(itemModels);
    }

    public List<Item> GetItems()
    {
        return _context.Items.ToList();
    }

    public List<Location> GetLocations()
    {
        return _context.Locations.ToList();
    }

    public void CreateMonsterRange(List<Monster> monsterModel)
    {
        _context.Monsters.AddRange(monsterModel);
    }

    public List<Element> GetElements()
    {
        return _context.Elements.ToList();
    }

    public List<Race> GetRaces()
    {
        return _context.Race.ToList();
    }

    public List<Scale> GetScales()
    {
        return _context.Scales.ToList();
    }

    public List<SubType> GetSubTypes()
    {
        return _context.SubTypes.ToList();
    }

    public List<ItemType> GetItemTypes()
    {
        return _context.ItemTypes.ToList();
    }

    public List<EquipPosition> GetEquipPosition()
    {
        return _context.EquipPositions.ToList();
    }

    public IEnumerable<int> GetMonstersIds()
    {
        return _context.Monsters.Select(x => x.Id).ToList();
    }

    public IEnumerable<int> GetItemCardIds()
    {
        return _context.Items.Where(x => x.CardPrefix != string.Empty).Select(x => x.Id);
    }
        
    public IEnumerable<int> GetItemWithoutCardIds()
    {
        return _context.Items.Where(x => x.CardPrefix == string.Empty).Select(x => x.Id);
    }
}