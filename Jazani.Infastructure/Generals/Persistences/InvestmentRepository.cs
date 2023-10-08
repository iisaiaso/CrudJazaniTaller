using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Jazani.Infastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infastructure.Generals.Persistences
{
    public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        {
            return await _dbContext.Set<Investment>()
                .Include(x => x.Holder)
                .Include(x => x.InvestmentConcept)
                .Include(x => x.InvestmentType)
                .Include(x => x.MiningConcession)
                .Include(x => x.MeasureUnit)
                .Include(x => x.PeriodType)
                .AsNoTracking()
                .ToListAsync();
        }

        public override async Task<Investment?> FindByIdAsync(int id)
        {
            return await _dbContext.Set<Investment>()
                .Include(x => x.Holder)
                .Include(x => x.InvestmentConcept)
                .Include(x => x.InvestmentType)
                .Include(x => x.MiningConcession)
                .Include(x => x.MeasureUnit)
                .Include(x => x.PeriodType)
                .FirstOrDefaultAsync(x => x.Id == id);  
        }
    }
}
