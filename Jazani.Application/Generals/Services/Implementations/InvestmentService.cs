using AutoMapper;
using Jazani.Application.Cores.Contexts.Exceptions;
using Jazani.Application.Generals.Dtos.Investments;
using Jazani.Core.Paginations;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using Microsoft.Extensions.Logging;

namespace Jazani.Application.Generals.Services.Implementations
{
    internal class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentRepository _investmentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentService> _logger;
        public InvestmentService(IInvestmentRepository investmentRepository, IMapper mapper, ILogger<InvestmentService> logger)
        {
            _investmentRepository = investmentRepository;
            _mapper = mapper;
            _logger = logger;
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
            Investment? investment = await _investmentRepository.FindByIdAsync(id);
            if (investment is null)
            {
                _logger.LogWarning("Tipo de mineral no encontrado para el id: " + id);
                throw InvestmentNotFound(id);
            }

            _logger.LogInformation("Tipo de mineral {name}", investment.Description);

            investment.State=false;

            return _mapper.Map<InvestmentDto>(investment);
        }

        public async Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto saveDto)
        {
            Investment? investment = await _investmentRepository.FindByIdAsync(id);

            if (investment is null)
            {
                _logger.LogWarning("Tipo de mineral no encontrado para el id: " + id);
                throw InvestmentNotFound(id);
            }

            _logger.LogInformation("Tipo de mineral {name}", investment.Description);

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
            Investment? investment = await _investmentRepository.FindByIdAsync(id);
            if (investment is null)
            {
                _logger.LogWarning("Tipo de mineral no encontrado para el id: " + id);
                throw InvestmentNotFound(id);
            }

            _logger.LogInformation("Tipo de mineral {name}", investment.Description);

            return _mapper.Map<InvestmentDto>(investment);
        }

        public async  Task<ResponsePagination<InvestmentDto>> PaginatedSearch(RequestPagination<InvestmentFilterDto> request)
        {
            var entity = _mapper.Map<RequestPagination<Investment>>(request);
            var response = await _investmentRepository.PaginatedSearch(entity);

            return _mapper.Map<ResponsePagination<InvestmentDto>>(response);
        }

        private NotFoundCoreException InvestmentNotFound(int id)
        {
            return new NotFoundCoreException("Tipo de mineral no encontrado para el id: " + id);
        }
    }
}
