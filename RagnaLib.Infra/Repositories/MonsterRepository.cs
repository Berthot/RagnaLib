using System.Collections.Generic;
using System.Linq;
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

        public Monster GetById(int id)
        {
            return _context.Monsters.FirstOrDefault(x => x.Id == id);

        }

        public List<Monster> GetAll()
        {
            throw new System.NotImplementedException();
        }

        List<Monster> IMonsterRepository.GetAll()
        {
            return _context.Monsters.ToList();
        }
    }
}