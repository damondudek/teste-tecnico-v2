using AutoMapper;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Enums;
using Thunders.TechTest.ApiService.Models.Messages;
using Thunders.TechTest.ApiService.Models.Reports;
using Thunders.TechTest.ApiService.Models.Requests;
using Thunders.TechTest.ApiService.Models.Responses;

namespace Thunders.TechTest.ApiService.Models.Mappers;

public class ReportMappingProfile : Profile
{
    public ReportMappingProfile()
    {
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
        
        CreateMap<ReportMessage, Report>();
        CreateMap<HourlyRevenueMessage, HourlyRevenueParams>();
        CreateMap<TopTollBoothsMessage, TopTollBoothsParams>();
        CreateMap<VehicleCountMessage, VehicleCountParams>();

        CreateMap<HourlyRevenueMessage, ReportResponse>();
        CreateMap<TopTollBoothsMessage, ReportResponse>();
        CreateMap<VehicleCountMessage, ReportResponse>();

        CreateMap<Report, ReportResponse>();
        CreateMap<Report, GenerateReportResponse>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ReportType));
    }
}
