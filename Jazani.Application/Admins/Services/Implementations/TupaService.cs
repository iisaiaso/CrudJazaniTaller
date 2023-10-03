using AutoMapper;
using Jazani.Application.Admins.Dtos.Stateattentions;
using Jazani.Application.Admins.Dtos.Tupas;
using Jazani.Domain.Admins.Models;
using Jazani.Domain.Admins.Repositories;

namespace Jazani.Application.Admins.Services.Implementations
{
    public class TupaService : ITupaService
    {
        private readonly ITupaRepository _tupaRepository;

        private readonly IMapper _mapper;

        public TupaService(ITupaRepository tupaRepository, IMapper mapper)
        {
            _tupaRepository = tupaRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<TupaDto>> FindAllAsync()
        {
            IReadOnlyList<Tupa> tupa = await _tupaRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<TupaDto>>(tupa);
        }

        public async Task<TupaDto?> FindByIdAsync(int id)
        {
            Tupa? tupa = await _tupaRepository.FindByIdAsync(id);
            return _mapper.Map<TupaDto>(tupa);
        }

        public async Task<TupaDto> CreateAsync(TupaSaveDto tupaSaveDto)
        {
            Tupa tupa = _mapper.Map<Tupa>(tupaSaveDto);
            tupa.RegistrationDate = DateTime.UtcNow;
            tupa.State = true;

            Tupa tupaSaved = await _tupaRepository.SaveAsync(tupa);

            return _mapper.Map<TupaDto>(tupaSaved);
        }

        public async  Task<TupaDto> EditAsync(int id, TupaSaveDto tupaSaveDto)
        {
            Tupa tupa = await _tupaRepository.FindByIdAsync(id);

            _mapper.Map<TupaSaveDto, Tupa>(tupaSaveDto, tupa);

            Tupa tupaSaved = await _tupaRepository.SaveAsync(tupa);

            return _mapper.Map<TupaDto>(tupaSaved);
        }
        public async Task<TupaDto> DisableAsync(int id)
        {
            Tupa tupa = await _tupaRepository.FindByIdAsync(id);
            tupa.State = false;

            Tupa tupaSaved = await _tupaRepository.SaveAsync(tupa);

            return _mapper.Map<TupaDto>(tupaSaved);
        }

    }
}
