using System.Collections.Generic;
using System.Threading.Tasks;
using RagnaLib.Application.Factory;
using RagnaLib.Domain.Entities;
using RagnaLib.Domain.Repositories;
using RagnaLib.Domain.Services;

namespace RagnaLib.Application.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly MonsterFactory _factory;
        private readonly IMonsterRepository _repo;

        public MonsterService(IMonsterRepository repo, MonsterFactory factory)
        {
            _factory = factory;
            _repo = repo;
        }

        public async Task<List<Monster>> GetAllMonsters()
        {
            var monsters = await _repo.GetAll();

            return monsters.Count == 0 ? null : monsters;
        }


        public async Task<Monster> GetMonsterById(int id)
        {
            return await _repo.GetById(id);
        }
    }
}