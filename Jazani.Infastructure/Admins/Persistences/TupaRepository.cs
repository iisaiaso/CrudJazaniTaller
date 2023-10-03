using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infastructure.Admins.Persistences
{
    public class TupaRepository : ITupaRepository
    {
        private readonly ApplicationDbContext _dbcontext;
        public TupaRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }
        public async Task<IReadOnlyList<Tupa>> FindAllAsync()
        {
            return await _dbcontext.Tupas.ToListAsync();
        }

        public async Task<Tupa?> FindByIdAsync(int id)
        {
            return _dbcontext.Tupas.FirstOrDefault(t => t.Id == id);
        }

        public async Task<Tupa> SaveAsync(Tupa tupa)
        {
            EntityState state = _dbcontext.Entry(tupa).State;
            _ = state switch
            {
                EntityState.Detached => _dbcontext.Tupas.Add(tupa),
                EntityState.Modified => _dbcontext.Tupas.Update(tupa)
            };
            await _dbcontext.SaveChangesAsync();
            return tupa;
        }
    }
}
