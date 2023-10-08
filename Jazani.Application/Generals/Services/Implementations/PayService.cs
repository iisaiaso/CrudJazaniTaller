using AutoMapper;
using Jazani.Application.Generals.Dtos.Pays;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class PayService : IPayService
    {
        public readonly IPayRepository _payRepository;
        public readonly IMapper _mapper;

        public PayService(IPayRepository payRepository, IMapper mapper)
        {
            _payRepository = payRepository;
            _mapper = mapper;
        }

        public async Task<PayDto> CreateAsync(PaySaveDto saveDto)
        {
            Pay pay = _mapper.Map<Pay>(saveDto);
            pay.ReceiptDate = DateTime.Now;
            pay.RegistrationDate = DateTime.Now;
            pay.State = true;
            await _payRepository.SaveAsync(pay);

            return _mapper.Map<PayDto>(pay);
        }

        public async Task<PayDto> DisabledAsync(int id)
        {
            Pay pay = await _payRepository.FindByIdAsync(id);
            pay.State = false;

            return _mapper.Map<PayDto>(pay); 
        }

        public async Task<PayDto> EditAsync(int id, PaySaveDto saveDto)
        {
            Pay pay = await _payRepository.FindByIdAsync(id);

            _mapper.Map<PaySaveDto, Pay>(saveDto, pay);

            await _payRepository.SaveAsync(pay);

            return _mapper.Map<PayDto>(pay);
        }

        public async Task<IReadOnlyList<PayDto>> FindAllAsync()
        {
            IReadOnlyList<Pay> pay = await _payRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<PayDto>>(pay);
        }

        public async Task<PayDto?> FindByIdAsync(int id)
        {
            Pay pay = await _payRepository.FindByIdAsync(id);

            return _mapper.Map<PayDto>(pay);
        }
    }
}
