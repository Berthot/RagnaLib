using System.Collections.Generic;
using RagnaLib.Domain.Bases.Interfaces;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Domain.Repositories
{
    public interface IMonsterRepository: IRepository<Monster>
    {
        List<Monster> GetAll();
    }
}