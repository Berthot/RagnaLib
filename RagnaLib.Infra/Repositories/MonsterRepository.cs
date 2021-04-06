using System.Collections.Generic;
using RagnaLib.Domain.Bases.Abstracts;
using RagnaLib.Domain.Bases.Interfaces;
using RagnaLib.Domain.Entities;
using RagnaLib.Domain.Repositories;
using RagnaLib.Infra.Data;

namespace RagnaLib.Infra.Repositories
{
    public class MonsterRepository : IMonsterRepository
    {
        public Monster GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Monster> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}