using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Jazani.Infastructure.Cores.Persistences;

namespace Jazani.Infastructure.Generals.Persistences
{
    public class InvestmentConceptRepository : CrudRepository<InvestmentConcept, int> ,IInvestmentConceptRepository
    {
        public InvestmentConceptRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
    }
}
