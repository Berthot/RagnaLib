using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RagnaLib.Domain.Entities;
using RagnaLib.Domain.Repositories;
using RagnaLib.Infra.Data;

namespace RagnaLib.Infra.Repositories
{
    public class ItemRepository : IItemRepository
    {
     
        private readonly Context _context;

        public ItemRepository(Context context)
        {
            _context = context;
        }
        
        public Item GetById(int id)
        {
            return _context
                .Items
                .Include(x=>x.MonsterItemMaps)
                .Include(x=>x.ItemEquipPositionMaps)
                .Include(x=>x.MonsterMvpDropMaps)
                .FirstOrDefault(x => x.Id == id);
        }

        public List<Item> GetAll()
        {
            return _context.Items.ToList();
        }
    }
}