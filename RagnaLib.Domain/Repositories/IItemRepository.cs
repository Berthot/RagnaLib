using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RagnaLib.Domain.Bases.Interfaces;
using RagnaLib.Domain.Entities;

namespace RagnaLib.Domain.Repositories;

public interface IItemRepository : IRepository<Item>
{
    Task<List<SubType>> GetSubTypes();
    Task<List<Type>> GetTypes();
    Task<List<EquipPosition>> GetEquipPositions();

}