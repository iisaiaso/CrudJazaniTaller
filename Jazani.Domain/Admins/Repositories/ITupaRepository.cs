using Jazani.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Domain.Admins.Repositories
{
    public interface ITupaRepository
    {
        Task<IReadOnlyList<Tupa>> FindAllAsync();
        Task<Tupa?> FindByIdAsync(int id);
        Task<Tupa> SaveAsync(Tupa tupa);
    }
}
