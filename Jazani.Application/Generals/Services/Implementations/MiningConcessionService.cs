using AutoMapper;
using Jazani.Application.Generals.Dtos.MiningConcessions;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class MiningConcessionService : IMiningConcessionService
    {
        private readonly IMiningConcessionRepository _miningConcessionRepository;
        private readonly IMapper _mapper;

        public MiningConcessionService(IMiningConcessionRepository miningConcessionRepository, IMapper mapper)
        {
            _miningConcessionRepository = miningConcessionRepository;
            _mapper = mapper;
        }

        public async Task<MiningConcessionDto> CreateAsync(MiningConcessionSaveDto saveDto)
        {
            MiningConcession miningConcession = _mapper.Map<MiningConcession>(saveDto);
            miningConcession.RegistrationDate = DateTime.Now;
            miningConcession.State = true;

            await _miningConcessionRepository.SaveAsync(miningConcession);

            return _mapper.Map<MiningConcessionDto>(miningConcession);
        }

        public async Task<MiningConcessionDto> DisabledAsync(int id)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);
            miningConcession.State = false;

            return _mapper.Map<MiningConcessionDto>(miningConcession);
        }

        public async Task<MiningConcessionDto> EditAsync(int id, MiningConcessionSaveDto saveDto)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);

            _mapper.Map<MiningConcessionSaveDto, MiningConcession>(saveDto, miningConcession);

            await _miningConcessionRepository.SaveAsync(miningConcession);

            return _mapper.Map<MiningConcessionDto>(miningConcession);
        }

        public async Task<IReadOnlyList<MiningConcessionDto>> FindAllAsync()
        {
            IReadOnlyList<MiningConcession> miningConcessions = await _miningConcessionRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<MiningConcessionDto>>(miningConcessions);
        }

        public async Task<MiningConcessionDto> FindByIdAsync(int id)
        {
            MiningConcession miningConcession = await _miningConcessionRepository.FindByIdAsync(id);
            return _mapper.Map<MiningConcessionDto>(miningConcession);      
        }
    }
}
