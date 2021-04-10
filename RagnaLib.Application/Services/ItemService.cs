using RagnaLib.Application.Factory;
using RagnaLib.Domain.Services;

namespace RagnaLib.Application.Services
{
    public class ItemService : IItemService
    {
        private readonly ItemFactory _factory;

        public ItemService()
        {
            _factory = new ItemFactory();
        }
    }
}