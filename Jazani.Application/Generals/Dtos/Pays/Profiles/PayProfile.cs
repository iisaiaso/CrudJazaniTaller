using AutoMapper;
using Jazani.Domain.Generals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Application.Generals.Dtos.Pays.Profiles
{
    public class PayProfile: Profile
    {
        public PayProfile() 
        {
            CreateMap<Pay, PayDto>();
            CreateMap<Pay, PaySaveDto>().ReverseMap();
        }
    }
}
