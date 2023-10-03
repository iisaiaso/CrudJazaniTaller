using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infastructure.Admins.Persistences
{
    internal class StateattentionRepository: IStateattentionRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public StateattentionRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IReadOnlyList<Stateattention>> FindAllAsync()
        {
            return await _dbcontext.Stateattentions.ToListAsync();
        }

        public async Task<Stateattention?> FindByIdAsync(int id)
        {
            return await _dbcontext.Stateattentions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Stateattention> SaveAsync(Stateattention stateattention)
        {
            EntityState state = _dbcontext.Entry(stateattention).State;
            _ = state switch
            {
                EntityState.Detached => _dbcontext.Stateattentions.Add(stateattention),
                EntityState.Modified => _dbcontext.Stateattentions.Update(stateattention)
            };

            await _dbcontext.SaveChangesAsync();
            return stateattention;
        }
    }
}
