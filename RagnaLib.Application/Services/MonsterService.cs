using RagnaLib.Domain.Bases.Abstracts;
using RagnaLib.Domain.Bases.Interfaces;
using RagnaLib.Domain.Repositories;
using RagnaLib.Infra.Repositories;

namespace RagnaLib.Application.Services
{
    public class MonsterService : ServiceBase<IMonsterRepository>
    {
        public MonsterService(IMonsterRepository repo) : base(repo)
        {
        }
        
        
        public void Test()
        {
            var x = Repo.GetAll(); // esta certo?
        }


    }
}