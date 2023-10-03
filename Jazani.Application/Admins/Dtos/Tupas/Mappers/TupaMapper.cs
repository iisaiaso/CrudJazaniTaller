using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Tupas.Mappers
{
    public class TupaMapper : Profile
    {
        public TupaMapper() 
        {
            CreateMap<Tupa, TupaDto>();
        }
    }
}
