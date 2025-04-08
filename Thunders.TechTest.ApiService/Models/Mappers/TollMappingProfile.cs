using AutoMapper;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Models.Messages;

namespace Thunders.TechTest.ApiService.Models.Mappers;

public class TollMappingProfile : Profile
{
    public TollMappingProfile()
    {
        CreateMap<TollRequest, TollMessage>();
        CreateMap<TollMessage, Toll>();
        CreateMap<Toll, TollResponse>();
    }
}
