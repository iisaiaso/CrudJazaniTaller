using AutoMapper;
using Jazani.Application.Generals.Dtos.Holders;
using Jazani.Application.Generals.Dtos.InvestmentConcepts;
using Jazani.Application.Generals.Dtos.InvestmentTypes;
using Jazani.Application.Generals.Dtos.MeasureUnits;
using Jazani.Application.Generals.Dtos.MiningConcessions;
using Jazani.Application.Generals.Dtos.PeriodTypes;
using Jazani.Core.Paginations;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile() 
        {
            CreateMap<Investment,  InvestmentDto>();
           CreateMap<Investment, InvestmentSaveDto>().ReverseMap();

            

            //Paginations
            CreateMap<Investment, InvestmentFilterDto>().ReverseMap();

		   CreateMap<ResponsePagination<Investment>, ResponsePagination<InvestmentDto>>();
		   CreateMap<RequestPagination<Investment>, RequestPagination<InvestmentFilterDto>>()
				.ReverseMap();
        }
    }
}
