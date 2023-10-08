using AutoMapper;
using Jazani.Application.Generals.Dtos.Investments;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    internal class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;

        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
        }

        public async Task<InvestmentDto> CreateAsync(InvestmentSaveDto saveDto)
        {
            Investment investment = _mapper.Map<Investment>(saveDto);
            investment.RegistrationDate = DateTime.Now;
            investment.State = true;

            await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investment);

        }

        public async Task<InvestmentDto> DisabledAsync(int id)
        {
            Investment investment = await _investmentRepository.FindByIdAsync(id);
            investment.State=false;

            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto saveDto)
        {
            Investment investment = await _investmentRepository.FindByIdAsync(id);
           
            _mapper.Map<InvestmentSaveDto, Investment>(saveDto, investment);

            await _investmentRepository.SaveAsync(investment);

            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task<IReadOnlyList<InvestmentDto>> FindAllAsync()
        {
            IReadOnlyList<Investment> investments = await _investmentRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<InvestmentDto>>(investments);
        }

        public async Task<InvestmentDto?> FindByIdAsync(int id)
        {

            Investment investment = await _investmentRepository.FindByIdAsync(id);
            return _mapper.Map<InvestmentDto>(investment);
        }
    }
}
