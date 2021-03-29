using System.Collections.Generic;
using RagnaLib.Domain.Bases.Interfaces;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Infra.Repositories
{
    public class ItemRepository : IRepositoryBase<Item>
    {
        public Item GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Item> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}