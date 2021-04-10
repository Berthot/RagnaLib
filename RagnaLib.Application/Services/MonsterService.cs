using RagnaLib.Application.Factory;
using RagnaLib.Domain.Services;

namespace RagnaLib.Application.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly Monster _factory;

        public MonsterService()
        {
            _factory = new Monster();
        }
    }
}