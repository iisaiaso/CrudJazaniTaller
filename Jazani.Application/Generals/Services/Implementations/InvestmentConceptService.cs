using AutoMapper;
using Jazani.Application.Generals.Dtos.InvestmentConcepts;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class InvestmentConceptService : IInvestmentConceptService
    {
        private readonly IInvestmentConceptRepository _investmentConceptRepository;
        private readonly IMapper _mapper;

        public InvestmentConceptService(IInvestmentConceptRepository investmentConceptRepository, IMapper mapper)
        {
            _investmentConceptRepository = investmentConceptRepository;
            _mapper = mapper;
        }

        public async Task<InvestmentConceptDto> CreateAsync(InvestmentConceptSaveDto saveDto)
        {
            InvestmentConcept investmentConcept = _mapper.Map<InvestmentConcept>(saveDto);
            investmentConcept.RegistrationDate = DateTime.Now;
            investmentConcept.State = true;

            await _investmentConceptRepository.SaveAsync(investmentConcept);

            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        public async Task<InvestmentConceptDto> DisabledAsync(int id)
        {
            InvestmentConcept investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            investmentConcept.State = false;

            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        public async Task<InvestmentConceptDto> EditAsync(int id, InvestmentConceptSaveDto saveDto)
        {
            InvestmentConcept investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);

            _mapper.Map<InvestmentConceptSaveDto, InvestmentConcept>(saveDto, investmentConcept);

            await _investmentConceptRepository.SaveAsync(investmentConcept);

            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }

        public async Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync()
        {
            IReadOnlyList<InvestmentConcept> investmentConcepts = await _investmentConceptRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<InvestmentConceptDto>> (investmentConcepts);
         
        }

        public async Task<InvestmentConceptDto> FindByIdAsync(int id)
        {
            InvestmentConcept investmentConcept = await _investmentConceptRepository.FindByIdAsync(id);
            return _mapper.Map<InvestmentConceptDto>(investmentConcept);
        }
    }
}
