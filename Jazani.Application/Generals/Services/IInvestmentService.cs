using Jazani.Application.Cores.Services;
using Jazani.Application.Generals.Dtos.Investments;

namespace Jazani.Application.Generals.Services
{
    public interface IInvestmentService : ICrudService<InvestmentDto, InvestmentSaveDto, int>, IPaginatedService<InvestmentDto, InvestmentFilterDto>
    {
    }
}
