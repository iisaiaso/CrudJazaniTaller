using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Jazani.Infastructure.Cores.Persistences;

namespace Jazani.Infastructure.Generals.Persistences
{
    public class MiningConcessionRepository : CrudRepository<MiningConcession, int> ,IMiningConcessionRepository
    {
        public MiningConcessionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        
    }
}
