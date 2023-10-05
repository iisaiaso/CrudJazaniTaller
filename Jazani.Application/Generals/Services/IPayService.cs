using Jazani.Application.Generals.Dtos.Pays;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Services
{
    public interface IPayService
    {
        Task<IReadOnlyList<PayDto>> FindAllAsync();
        Task<PayDto?> FindByIdAsync(int id);
        Task<PayDto> CreateAsync(PaySaveDto saveDto);
        Task<PayDto> EditAsync(int id, PaySaveDto saveDto);
        Task<PayDto> DisableAsync(int id);
    }
}
