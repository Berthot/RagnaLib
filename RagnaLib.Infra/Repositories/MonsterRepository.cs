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
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Monster>> GetAll()
        {
            return await _context
                .Monsters
                .ToListAsync();
        }
    }
}