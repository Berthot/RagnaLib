using System.Collections.Generic;
using RagnaLib.Domain.Bases.Abstracts;
using RagnaLib.Domain.Bases.Interfaces;
using RagnaLib.Domain.Entities;
using RagnaLib.Infra.Data;

namespace RagnaLib.Infra.Repositories
{
    public class ItemRepository : RepositoryBase<Context, Item>
    {
        public ItemRepository(Context context) : base(context)
        {
        }

        public override Item GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public override List<Item> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}