using Jazani.Application.Admins.Dtos.Stateattentions;

namespace Jazani.Application.Admins.Services
{
    public interface IStateattentionService
    {
        Task<IReadOnlyList<StateattentionDto>> FindAllAsync();
        Task<StateattentionDto?> FindByIdAsync(int id);
        Task<StateattentionDto> CreateAsync(StateattentionSaveDto stateattentionSaveDto);
        Task<StateattentionDto> EditAsync(int id, StateattentionSaveDto stateattentionSaveDto);
        Task<StateattentionDto> DisableAsync(int id);
    }
}
