using AutoMapper;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Models.Messages;

namespace Thunders.TechTest.ApiService.Models.Mappers;

public class ReportMappingProfile : Profile
{
    public ReportMappingProfile()
    {
        CreateMap<ReportRequest, ReportMessage>();
        CreateMap<ReportMessage, Report>();
        CreateMap<Report, ReportResponse>();
    }
}
