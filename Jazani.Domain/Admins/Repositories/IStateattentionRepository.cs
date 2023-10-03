using Jazani.Domain.Admins.Models;

namespace Jazani.Domain.Admins.Repositories
{
    public interface IStateattentionRepository
    {
        Task<IReadOnlyList<Stateattention>> FindAllAsync();  
        Task<Stateattention?> FindByIdAsync(int id);
        Task<Stateattention> SaveAsync(Stateattention stateattention);
    }
}
