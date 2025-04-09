using System.Text.Json;
using Thunders.TechTest.ApiService.Domain.Entities;
using Thunders.TechTest.ApiService.Domain.Interfaces;
using Thunders.TechTest.ApiService.Domain.Models.Reports;

namespace Thunders.TechTest.ApiService.Application.Services.ReportGenerator
{
    public class HourlyRevenueReportGenerator(IReportService reportService, ILogger<HourlyRevenueReportGenerator> logger) : ReportGenerator
    {
        private readonly IReportService _reportService = reportService;
        private readonly ILogger<HourlyRevenueReportGenerator> _logger = logger;

        public override async Task GenerateReportAsync(Report report)
        {
            try
            {
                var reportParams = JsonSerializer.Deserialize<HourlyRevenueParams>(report.Params);
                var result = await _reportService.GetRevenueReportByHourAndCityWithCacheAsync(reportParams);
                FinishReport(report, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating hourly revenue report: {ReportId}", report.Id);
                report.Error = ex.Message;
            }
        }
    }
}
