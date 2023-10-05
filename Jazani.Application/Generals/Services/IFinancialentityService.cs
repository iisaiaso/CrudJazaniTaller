using Jazani.Application.Generals.Dtos.Financialentitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services
{
    public interface IFinancialentityService
    {
        
        Task<IReadOnlyList<FinancialentityDto>> FindAllAsync();
        Task<FinancialentityDto?> FindByIdAsync(int id);
        Task<FinancialentityDto> CreateAsync(FinancialentitySaveDto saveDto);
        Task<FinancialentityDto> EditAsync(int id, FinancialentitySaveDto saveDto);
        Task<FinancialentityDto> DisableAsync(int id);
         
    }
}
