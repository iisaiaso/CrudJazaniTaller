using AutoMapper;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Financialentitys.Profiles
{
    public class FinancialentityProfile: Profile
    {
       public FinancialentityProfile() 
        {
            CreateMap<Financialentity, FinancialentityDto>();
            CreateMap<Financialentity, FinancialentitySaveDto>().ReverseMap();
        }
    }
}
