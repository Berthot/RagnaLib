using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RagnaLib.Domain.Entities;
using RagnaLib.Domain.Repositories;
using RagnaLib.Infra.Data;

namespace RagnaLib.Infra.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        private readonly Context _context;

        public MonsterRepository(Context context)
        {
            _context = context;
        }

        public async Task<Monster> GetById(int id)
        {
            return await _context
                .Monsters
                .AsNoTracking()
                .AsQueryable()
                .Include(x => x.Scale)
                .Include(x => x.Element)
                .Include(x => x.Race)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Monster>> GetAll()
        {
            return await _context
                .Monsters
                .ToListAsync();
        }

        public Task<List<Scale>> GetMonsterScales()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Race>> GetRaces()
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Element>> GetElements()
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<MonsterPerLocationMap>> GetLocationsByMonsterId(int id)
        {
            return await _context.MonsterPerLocationMaps
                .Include(x => x.Location)
                .Where(x => x.MonsterId == id).ToListAsync();
        }

        public async Task<List<MonsterItemMap>> GetDrop(int id)
        {
            return await _context.MonsterItemMaps
                .Include(x => x.Item)
                    .ThenInclude(x => x.ItemType)
                .Where(x => x.MonsterId == id).ToListAsync();
        }

        public async Task<List<MonsterMvpDropMap>> GetMvpDrop(int id)
        {
            return await _context.MonsterMvpDropMaps
                .Include(x => x.Item)
                    .ThenInclude(x => x.ItemType)
                .Where(x => x.MonsterId == id).ToListAsync();
        }
    }
}