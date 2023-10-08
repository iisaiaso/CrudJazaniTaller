using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Financialentitys.Profiles
{
    public class FinancialentityProfile: Profile
    {
       public FinancialentityProfile() 
        {
            CreateMap<Financialentity, FinancialentityDto>();
            CreateMap<Financialentity, FinancialentitySimpleDto>();
            CreateMap<Financialentity, FinancialentitySaveDto>().ReverseMap();
        }
    }
}
