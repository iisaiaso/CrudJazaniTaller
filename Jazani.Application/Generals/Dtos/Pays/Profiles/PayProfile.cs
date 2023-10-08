using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Pays.Profiles
{
    public class PayProfile : Profile
    {
        public PayProfile() 
        {
            CreateMap<Pay, PayDto>();
            CreateMap<Pay, PaySaveDto>().ReverseMap();
        }
    }
}
