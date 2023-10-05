using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Jazani.Infastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Jazani.Infastructure.Admins.Persistences
{
    public class TupaRepository : CrudRepository<Tupa, int>, ITupaRepository
    {
        public TupaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

    }
}
