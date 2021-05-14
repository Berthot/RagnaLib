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
            var y = await _context
                .Monsters
                .AsNoTracking()
                .AsQueryable()
                .Include(x => x.Scale)
                .Include(x => x.Element)
                .Include(x => x.Race)
                .Include(x => x.MonsterPerLocationMaps)
                .Include(x => x.MonsterMvpDropMaps)
                .Include(x => x.MonsterItemMaps)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return y;

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
    }
}