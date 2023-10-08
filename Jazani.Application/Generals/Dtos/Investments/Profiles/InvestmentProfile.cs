using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile() 
        {
            CreateMap<Investment,  InvestmentDto>();
           CreateMap<Investment, InvestmentSaveDto>().ReverseMap();
        }
    }
}
