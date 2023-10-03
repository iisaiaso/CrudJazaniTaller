using AutoMapper;
using Jazani.Domain.Admins.Models;

namespace Jazani.Application.Admins.Dtos.Stateattentions.Mappers
{
    public class StateattentionSaveMapper : Profile
    {
      public StateattentionSaveMapper() 
      {
        CreateMap<Stateattention, StateattentionSaveDto>().ReverseMap();
      }
    }
}
