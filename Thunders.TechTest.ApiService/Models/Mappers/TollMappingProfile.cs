using AutoMapper;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Models.Messages;
using Thunders.TechTest.ApiService.Models.Requests;
using Thunders.TechTest.ApiService.Models.Responses;

namespace Thunders.TechTest.ApiService.Models.Mappers;

public class TollMappingProfile : Profile
{
    public TollMappingProfile()
    {
        CreateMap<TollRequest, TollMessage>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()));

        CreateMap<TollMessage, Toll>();
        CreateMap<Toll, TollResponse>();
    }
}
