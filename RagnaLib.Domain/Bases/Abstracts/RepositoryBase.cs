using System.Collections.Generic;
using RagnaLib.Domain.Bases.Interfaces;

namespace RagnaLib.Domain.Bases.Abstracts
{
    public abstract class RepositoryBase<TContext, TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        private TContext _context;

        protected RepositoryBase(TContext context)
        {
            _context = context;
        }

        public abstract TEntity GetById(int id);
        public abstract List<TEntity> GetAll();
    }
}