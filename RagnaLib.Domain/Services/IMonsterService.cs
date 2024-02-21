using System.Collections.Generic;
using System.Threading.Tasks;
using RagnaLib.Domain.Bases.Interfaces;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Domain.Services;

public interface IMonsterService : IService
{
    Task<List<Monster>> GetAllMonsters();

    Task<Monster> GetMonsterById(int id);
}