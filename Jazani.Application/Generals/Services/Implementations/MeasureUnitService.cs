using AutoMapper;
using Jazani.Application.Generals.Dtos.MeasureUnits;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class MeasureUnitService : IMeasureUnitService
    {
        private readonly IMeasureUnitRepository _measureUnitRepository;
        private readonly IMapper _mapper;

        public MeasureUnitService(IMeasureUnitRepository measureUnitRepository, IMapper mapper)
        {
            _measureUnitRepository = measureUnitRepository;
            _mapper = mapper;
        }

        public async  Task<MeasureUnitDto> CreateAsync(MeasureUnitSaveDto saveDto)
        {
            MeasureUnit measureUnit = _mapper.Map<MeasureUnit>(saveDto);    
            measureUnit.RegistrationDate = DateTime.Now;
            measureUnit.State = true;
            
            await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnit);   
        }

        public async Task<MeasureUnitDto> DisabledAsync(int id)
        {
            MeasureUnit measureUnit = await _measureUnitRepository.FindByIdAsync(id);
            measureUnit.State = false;

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<MeasureUnitDto> EditAsync(int id, MeasureUnitSaveDto saveDto)
        {
            MeasureUnit measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            _mapper.Map<MeasureUnitSaveDto, MeasureUnit>(saveDto, measureUnit);

            await _measureUnitRepository.SaveAsync(measureUnit);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }

        public async Task<IReadOnlyList<MeasureUnitDto>> FindAllAsync()
        {
            IReadOnlyList<MeasureUnit> measureUnits = await _measureUnitRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<MeasureUnitDto>>(measureUnits);
        }

        public async Task<MeasureUnitDto> FindByIdAsync(int id)
        {
            MeasureUnit measureUnit = await _measureUnitRepository.FindByIdAsync(id);

            return _mapper.Map<MeasureUnitDto>(measureUnit);
        }
    }
}
