using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Tupas.Mappers
{
    public class TupaSaveMapper:Profile
    {
        public TupaSaveMapper() 
        {
            CreateMap<Tupa, TupaSaveDto>().ReverseMap();
        }
    }
}
