using AutoMapper;
using Jazani.Application.Generals.Dtos.Financialentitys;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Services.Implementations
{
    internal class FinancialentityService : IFinancialentityService
    {
        public readonly IFinancialentityRepository _finaancialentityRepository;
        public readonly IMapper _mapper;

        public FinancialentityService(IFinancialentityRepository finaancialentityRepository, IMapper mapper)
        {
            _finaancialentityRepository = finaancialentityRepository;
            _mapper = mapper;
        }

        public async Task<FinancialentityDto> CreateAsync(FinancialentitySaveDto saveDto)
        {
            Financialentity financialentity = _mapper.Map<Financialentity>(saveDto);
            financialentity.RegistrationDate = DateTime.Now;
            financialentity.State = true;

            await _finaancialentityRepository.SaveAsync(financialentity);

            return _mapper.Map<FinancialentityDto>(financialentity);
        }

        public async Task<FinancialentityDto> DisableAsync(int id)
        {
            Financialentity financialentity = await _finaancialentityRepository.FindByIdAsync(id);
            financialentity.State = false;

            await _finaancialentityRepository.SaveAsync(financialentity);

            return _mapper.Map<FinancialentityDto>(financialentity);
        }

        public async Task<FinancialentityDto> EditAsync(int id, FinancialentitySaveDto saveDto)
        {
            Financialentity financialentity = await _finaancialentityRepository.FindByIdAsync(id);

            _mapper.Map<FinancialentitySaveDto, Financialentity>(saveDto, financialentity);

            await _finaancialentityRepository.SaveAsync(financialentity);

            return _mapper.Map<FinancialentityDto>(financialentity);
        }

        public async Task<IReadOnlyList<FinancialentityDto>> FindAllAsync()
        {
            IReadOnlyList<Financialentity> financialentitys = await _finaancialentityRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<FinancialentityDto>>(financialentitys);
        }

        public async Task<FinancialentityDto?> FindByIdAsync(int id)
        {
            Financialentity financialentity = await _finaancialentityRepository.FindByIdAsync(id);

            return _mapper.Map<FinancialentityDto>(financialentity);
        }
    }
}
