using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Jazani.Infastructure.Cores.Persistences;

namespace Jazani.Infastructure.Generals.Persistences
{
    public class FinancialentityRepository : CrudRepository<Financialentity, int> ,IFinancialentityRepository
    {
        public FinancialentityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
    }
}
