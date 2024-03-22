using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Bases.Interfaces;
using Domain.Entities;

namespace Domain.Services;

public interface IMonsterService : IService
{
    Task<List<Monster>> GetAllMonsters();

    Task<Monster> GetMonsterById(int id);
}