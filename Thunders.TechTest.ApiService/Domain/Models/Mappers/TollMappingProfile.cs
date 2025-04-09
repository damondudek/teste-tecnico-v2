using AutoMapper;
using Thunders.TechTest.ApiService.Domain.Entities;
using Thunders.TechTest.ApiService.Domain.Models.Messages;
using Thunders.TechTest.ApiService.Domain.Models.Requests;
using Thunders.TechTest.ApiService.Domain.Models.Responses;

namespace Thunders.TechTest.ApiService.Domain.Models.Mappers;

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
