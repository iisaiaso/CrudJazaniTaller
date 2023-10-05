using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Jazani.Infastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infastructure.Generals.Persistences
{
    public class PayRepository : CrudRepository<Pay, int> ,IPayRepository
    {
       private readonly ApplicationDbContext _dbContext;

        public PayRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Pay>> FindAllAsync()
        {
            return await _dbContext.Set<Pay>()
                .Include(t => t.Financialentity)
                .AsNoTracking()
                .ToListAsync();    
        }
        public override async Task<Pay?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Pay>()
                .Include(t =>t.Financialentity)
                .FirstOrDefaultAsync(t => t.Id ==id);
        }
    }
}
