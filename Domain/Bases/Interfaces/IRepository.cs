using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Bases.Abstracts;

namespace Domain.Bases.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetById(int id);

    Task<List<TEntity>> GetAll();

}