using Thunders.TechTest.ApiService.Domain.Enums;
using Thunders.TechTest.ApiService.Domain.Interfaces;

namespace Thunders.TechTest.ApiService.Application.Services.ReportGenerator;

public class ReportGeneratorFactory(IServiceProvider serviceProvider)
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public IReportGenerator GetGenerator(ReportType reportType)
    {
        return reportType switch
        {
            ReportType.HourlyRevenueByCity => _serviceProvider.GetRequiredService<HourlyRevenueReportGenerator>(),
            ReportType.TopTollBoothsByMonth => _serviceProvider.GetRequiredService<TopTollBoothsReportGenerator>(),
            ReportType.VehicleCountByTollBooth => _serviceProvider.GetRequiredService<VehicleCountReportGenerator>(),
            _ => throw new NotImplementedException($"No generator implemented for report type: {reportType}")
        };
    }
}
