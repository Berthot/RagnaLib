using RagnaLib.Application.Factory;
using RagnaLib.Domain.Services;

namespace RagnaLib.Application.Services
{
    public class MonsterService : IMonsterService
    {
        private readonly MonsterFactory _factory;

        public MonsterService()
        {
            _factory = new MonsterFactory();
        }
    }
}