using Application.Factory;
using Domain.Repositories;
using Domain.Services;

namespace Application.Services;

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