using AutoMapper;
using Jazani.Application.Generals.Dtos.Holders;
using Jazani.Domain.Generals.Models;
using Jazani.Domain.Generals.Repositories;

namespace Jazani.Application.Generals.Services.Implementations
{
    public class HolderService : IHolderService
    {
        private readonly IHolderRepository _holderRepository;
        private readonly IMapper _mapper;

        public HolderService(IHolderRepository holderRepository, IMapper mapper)
        {
            _holderRepository = holderRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<HolderDto>> FindAllAsync()
        {
            IReadOnlyList<Holder> holder = await _holderRepository.FindAllAsync();
            return _mapper.Map<IReadOnlyList<HolderDto>>(holder);
        }

        public async Task<HolderDto?> FindByIdAsync(int id)
        {
            Holder holder = await _holderRepository.FindByIdAsync(id);
            return _mapper.Map<HolderDto>(holder);
        }
    }
}
