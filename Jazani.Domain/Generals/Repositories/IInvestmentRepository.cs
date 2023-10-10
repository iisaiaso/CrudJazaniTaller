using Jazani.Domain.Cores.Repositories;
using Jazani.Domain.Generals.Models;

namespace Jazani.Domain.Generals.Repositories
{
    public interface IInvestmentRepository : ICrudRepository<Investment, int>, IPaginatedRepository<Investment>
    {
       
    }
}
