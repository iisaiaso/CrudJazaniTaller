using Jazani.Core.Paginations;
using Jazani.Domain.Cores.Paginations;
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
        private readonly IPaginator<Investment> _paginator;

        public InvestmentRepository(ApplicationDbContext dbContext, IPaginator<Investment> paginator) : base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;
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

        public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
        {
            var filter = request.Filter;

            var query = _dbContext.Set<Investment>().AsQueryable();

            if (filter is not null)
            {
                query = query
                    .Where(x =>
                        (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper()))
                        && (string.IsNullOrWhiteSpace(filter.MonthName) || x.MonthName.ToUpper().Contains(filter.MonthName.ToUpper()))
                    );
            }


            query = query.OrderByDescending(x => x.Id)
                 .Include(t => t.InvestmentConcept)
            .Include(t => t.Holder)
            .Include(t => t.InvestmentType)
            .Include(t => t.MiningConcession)
            .Include(t => t.MeasureUnit)
            .Include(t => t.PeriodType);


            return await _paginator.Paginate(query, request);
        }
    }
}
