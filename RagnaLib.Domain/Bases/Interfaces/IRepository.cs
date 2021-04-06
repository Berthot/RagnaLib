using System.Collections.Generic;
using RagnaLib.Domain.Bases.Abstracts;

namespace RagnaLib.Domain.Bases.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity GetById(int id);

        List<TEntity> GetAll();

    }
}