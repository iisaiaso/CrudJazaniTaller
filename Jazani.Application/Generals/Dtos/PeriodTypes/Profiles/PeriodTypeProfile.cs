﻿using AutoMapper;
using Jazani.Domain.Generals.Models;

namespace Jazani.Application.Generals.Dtos.PeriodTypes.Profiles
{
    public class PeriodTypeProfile : Profile
    {
        public PeriodTypeProfile() 
        {
            CreateMap<PeriodType, PeriodTypeDto>();
            CreateMap<PeriodType, PeriodTypeSimpleDto>();
            CreateMap<PeriodType, PeriodTypeSaveDto>().ReverseMap();
        }
    }
}
