using RagnaLib.Domain.Bases.Abstracts;
using RagnaLib.Domain.Bases.Interfaces;
using RagnaLib.Infra.Repositories;

namespace RagnaLib.Application.Services
{
    public class MonsterService : ServiceBase<MonsterRepository>
    {
        public MonsterService(MonsterRepository repo) : base(repo)
        {
        }

        public void Test()
        {
            var x = Repo.GetAll(); // esta certo?
        }
    }
}