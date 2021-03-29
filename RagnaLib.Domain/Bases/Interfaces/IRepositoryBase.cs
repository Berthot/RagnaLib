using System.Collections.Generic;
using RagnaLib.Domain.Bases.Abstracts;

namespace RagnaLib.Domain.Bases.Interfaces
{
    public interface IRepositoryBase<out TEntity> where TEntity : Entity
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        void Dispose();
    }
}