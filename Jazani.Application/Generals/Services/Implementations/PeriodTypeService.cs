using AutoMapper;
using Jazani.Application.Generals.Dtos.PeriodTypes;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class PeriodTypeService : IPeriodTypeService
    {
        private readonly IPeriodTypeRepository _periodTypeRepository;
        private readonly IMapper _mapper;

        public PeriodTypeService(IPeriodTypeRepository periodTypeRepository, IMapper mapper)
        {
            _periodTypeRepository = periodTypeRepository;
            _mapper = mapper;
        }

        public async Task<PeriodTypeDto> CreateAsync(PeriodTypeSaveDto saveDto)
        {
            PeriodType periodType = _mapper.Map<PeriodType>(saveDto);   
            periodType.RegistrationDate = DateTime.Now;
            periodType.State = true;

            await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        public async Task<PeriodTypeDto> DisabledAsync(int id)
        {
            PeriodType periodType = await _periodTypeRepository.FindByIdAsync(id);
            periodType.State = false;

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        public async Task<PeriodTypeDto> EditAsync(int id, PeriodTypeSaveDto saveDto)
        {
            PeriodType periodType = await _periodTypeRepository.FindByIdAsync(id);

            _mapper.Map<PeriodTypeSaveDto, PeriodType>(saveDto, periodType);

            await _periodTypeRepository.SaveAsync(periodType);

            return _mapper.Map<PeriodTypeDto>(periodType);
        }

        public async Task<IReadOnlyList<PeriodTypeDto>> FindAllAsync()
        {
            IReadOnlyList<PeriodType> periodTypes = await _periodTypeRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<PeriodTypeDto>>(periodTypes);

        }
        public async Task<PeriodTypeDto> FindByIdAsync(int id)
        {
            PeriodType periodType = await _periodTypeRepository.FindByIdAsync(id);
            return _mapper.Map<PeriodTypeDto>(periodType);

        }
    }
}
