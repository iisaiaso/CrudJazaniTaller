using Jazani.Application.Admins.Dtos.Stateattentions;
using Jazani.Application.Admins.Dtos.Tupas;

namespace Jazani.Application.Admins.Services
{
    public interface ITupaService
    {
        Task<IReadOnlyList<TupaDto>> FindAllAsync();
        Task<TupaDto?> FindByIdAsync(int id);
        Task<TupaDto> CreateAsync(TupaSaveDto tupaSaveDto);
        Task<TupaDto> EditAsync(int id, TupaSaveDto tupaSaveDto);
        Task<TupaDto> DisableAsync(int id);
    }
}
