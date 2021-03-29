using System.Collections.Generic;
using RagnaLib.Domain.Bases.Abstracts;

namespace RagnaLib.Domain.Bases.Interfaces
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

    }
}