using System.Collections.Generic;
using RagnaLib.Domain.Bases.Abstracts;
using RagnaLib.Domain.Entities;
using RagnaLib.Domain.Repositories;
using RagnaLib.Infra.Data;

namespace RagnaLib.Infra.Repositories
{
    public class MonsterRepository : RepositoryBase<Context, Monster>
    {
        public MonsterRepository(Context context) : base(context)
        {
        }

        public override Monster GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public override List<Monster> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}