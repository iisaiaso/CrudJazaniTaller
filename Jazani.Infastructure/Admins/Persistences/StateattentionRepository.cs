using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Jazani.Infastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infastructure.Admins.Persistences
{
    internal class StateattentionRepository : CrudRepository<Stateattention, int>, IStateattentionRepository
    {
        public StateattentionRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
