using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Bases.Interfaces;
using Domain.Entities;

namespace Domain.Repositories;

public interface IItemRepository : IRepository<Item>
{
    Task<List<SubType>> GetSubTypes();
    Task<List<Type>> GetTypes();
    Task<List<EquipPosition>> GetEquipPositions();

}