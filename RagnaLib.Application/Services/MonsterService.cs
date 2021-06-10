using System;
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
            var monster = await _repo.GetById(id);

            var locations = await _repo.GetLocationsByMonsterId(id);
            var drops = await _repo.GetDrop(id);
            var mvpDrops = await _repo.GetMvpDrop(id);
            monster.MonsterPerLocationMaps = locations;
            monster.MonsterMvpDropMaps = mvpDrops;
            monster.MonsterItemMaps = drops;
            return monster;
        }
    }
}