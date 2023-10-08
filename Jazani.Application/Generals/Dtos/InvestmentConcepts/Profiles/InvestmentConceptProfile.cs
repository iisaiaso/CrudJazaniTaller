using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.InvestmentConcepts.Profiles
{
    public class InvestmentConceptProfile : Profile
    {
        public InvestmentConceptProfile() 
        {
            CreateMap<InvestmentConcept, InvestmentConceptDto>();
            CreateMap<InvestmentConcept, InvestmentConceptSimpleDto>();
            CreateMap<InvestmentConcept, InvestmentConceptSaveDto>().ReverseMap();
        }
    }
}
