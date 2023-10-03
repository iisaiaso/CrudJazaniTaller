using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Stateattentions.Mappers
{
    public class StateattentionMapper : Profile
    {
        public StateattentionMapper() 
        {
            CreateMap<Stateattention, StateattentionDto>();        
        }
    }
}
