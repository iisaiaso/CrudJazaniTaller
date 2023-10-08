using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Jazani.Infastructure.Cores.Persistences;

namespace Jazani.Infastructure.Generals.Persistences
{
    public class InvestmentTypeRepository : CrudRepository<InvestmentType, int> ,IInvestmentTypeRepository
    {
        public InvestmentTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
    }
}
