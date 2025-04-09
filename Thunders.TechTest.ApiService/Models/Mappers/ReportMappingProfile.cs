using AutoMapper;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Enums;
using Thunders.TechTest.ApiService.Models.Messages;
using Thunders.TechTest.ApiService.Models.Requests;
using Thunders.TechTest.ApiService.Models.Responses;

namespace Thunders.TechTest.ApiService.Models.Mappers;

public class ReportMappingProfile : Profile
{
    public ReportMappingProfile()
    {
        CreateMap<ReportMessage, Report>();
        CreateMap<Report, ReportResponse>();
        CreateMap<Report, GenerateReportMessage>();

        CreateMap<HourlyRevenueRequest, HourlyRevenueMessage>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.ReportType, opt => opt.MapFrom(_ => ReportType.HourlyRevenueByCity));

        CreateMap<TopTollBoothsRequest, TopTollBoothsMessage>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.ReportType, opt => opt.MapFrom(_ => ReportType.TopTollBoothsByMonth));

        CreateMap<VehicleCountRequest, VehicleCountMessage>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(_ => Guid.NewGuid()))
            .ForMember(dest => dest.ReportType, opt => opt.MapFrom(_ => ReportType.VehicleCountByTollBooth));
    }
}
