using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Bases.Interfaces;
using Domain.Entities;

namespace Domain.Repositories;

public interface IMonsterRepository: IRepository<Monster>
{
    Task<List<Scale>> GetMonsterScales();
    Task<List<Race>> GetRaces();
    Task<List<Element>> GetElements();
    Task<List<MonsterPerLocationMap>> GetLocationsByMonsterId(int id);
    Task<List<MonsterItemMap>> GetDrop(int id);
    Task<List<MonsterMvpDropMap>> GetMvpDrop(int id);
    Task<Monster> TestById(int id);
}