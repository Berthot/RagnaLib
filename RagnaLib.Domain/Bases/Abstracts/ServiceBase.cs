using RagnaLib.Domain.Bases.Interfaces;

namespace RagnaLib.Domain.Bases.Abstracts
{
    public abstract class ServiceBase<TRepository> : IService
    {
        protected readonly TRepository Repo;
    
        protected ServiceBase(TRepository repo)
        {
            Repo = repo;
        }
    }
}