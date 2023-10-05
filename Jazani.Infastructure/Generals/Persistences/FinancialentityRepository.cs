using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Jazani.Infastructure.Cores.Contexts;
using Jazani.Infastructure.Cores.Persistences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infastructure.Generals.Persistences
{
    internal class FinancialentityRepository : CrudRepository<Financialentity, int>, IFinancialentityRepository
    {
        public FinancialentityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
