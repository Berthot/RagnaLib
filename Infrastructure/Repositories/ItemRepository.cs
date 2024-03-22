using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Repositories;

public class ItemRepository : IItemRepository
{
     
    private readonly Context _context;

    public ItemRepository(Context context)
    {
        _context = context;
    }
        
    public Task<Item> GetById(int id)
    {
        return _context
            .Items
            .Include(x => x.MonsterItemMaps)
            .Include(x => x.ItemEquipPositionMaps)
            .Include(x => x.MonsterMvpDropMaps)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task<List<Item>> GetAll()
    {
        return _context.Items.ToListAsync();
    }

    public Task<List<SubType>> GetSubTypes()
    {
        throw new NotImplementedException();
    }

    public Task<List<Type>> GetTypes()
    {
        throw new NotImplementedException();
    }

    public Task<List<EquipPosition>> GetEquipPositions()
    {
        throw new NotImplementedException();
    }
}