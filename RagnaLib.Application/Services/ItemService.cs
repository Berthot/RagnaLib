using RagnaLib.Application.Factory;
using RagnaLib.Domain.Repositories;
using RagnaLib.Domain.Services;

namespace RagnaLib.Application.Services;

public class ItemService : IItemService
{
    private readonly ItemFactory _factory;
    private readonly IItemRepository _repo;

    public ItemService(IItemRepository repo, ItemFactory factory)
    {
            _factory = factory;
            _repo = repo;
        }
}