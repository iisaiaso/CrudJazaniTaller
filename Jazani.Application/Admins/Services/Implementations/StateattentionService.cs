using AutoMapper;
using Jazani.Application.Admins.Dtos.Stateattentions;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class StateattentionService : IStateattentionService
    {
        private readonly IStateattentionRepository _stateattentionRepository;

        private readonly IMapper _mapper;

        public StateattentionService(IStateattentionRepository stateattentionRepository, IMapper mapper)
        {
            _stateattentionRepository = stateattentionRepository;
            _mapper = mapper;
        }
        
        public async Task<IReadOnlyList<StateattentionDto>> FindAllAsync()
        {
            IReadOnlyList<Stateattention> stateattention = await _stateattentionRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<StateattentionDto>>(stateattention);
        }

        public async Task<StateattentionDto?> FindByIdAsync(int id)
        {
            Stateattention? stateattention = await _stateattentionRepository.FindByIdAsync(id);
            return _mapper.Map<StateattentionDto>(stateattention);
        }

        public async Task<StateattentionDto> CreateAsync(StateattentionSaveDto stateattentionSaveDto)
        {
            Stateattention stateattention = _mapper.Map<Stateattention>(stateattentionSaveDto);
            stateattention.RegistrationDate = DateTime.UtcNow;
            stateattention.State = true;

            Stateattention stateattentionSaved = await _stateattentionRepository.SaveAsync(stateattention);   

            return _mapper.Map<StateattentionDto>(stateattentionSaved); 
        }

        public async Task<StateattentionDto> EditAsync(int id, StateattentionSaveDto stateattentionSaveDto)
        {
            Stateattention stateattention = await _stateattentionRepository.FindByIdAsync(id);

            _mapper.Map<StateattentionSaveDto, Stateattention>(stateattentionSaveDto, stateattention);

            Stateattention stateattentionSaved = await _stateattentionRepository.SaveAsync(stateattention);

            return _mapper.Map<StateattentionDto>(stateattentionSaved);
        }

        public async Task<StateattentionDto> DisableAsync(int id)
        {
            Stateattention stateattention = await _stateattentionRepository.FindByIdAsync(id);
            stateattention.State = false;

            Stateattention stateattentionSaved = await _stateattentionRepository.SaveAsync(stateattention);

            return _mapper.Map<StateattentionDto>(stateattentionSaved);
        }

        
    }
}
