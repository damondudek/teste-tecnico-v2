using AutoMapper;
using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Models.Mappers;

public class TollMappingProfile : Profile
{
    public TollMappingProfile()
    {
        CreateMap<TollRequest, Toll>();
        CreateMap<Toll, TollResponse>();
    }
}
