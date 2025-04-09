using System.Text.Json;
using Thunders.TechTest.ApiService.Domain.Entities;
using Thunders.TechTest.ApiService.Domain.Interfaces;
using Thunders.TechTest.ApiService.Domain.Models.Reports;

namespace Thunders.TechTest.ApiService.Application.Services.ReportGenerator
{
    public class TopTollBoothsReportGenerator(IReportService reportService, ILogger<TopTollBoothsReportGenerator> logger) : ReportGenerator
    {
        private readonly IReportService _reportService = reportService;
        private readonly ILogger<TopTollBoothsReportGenerator> _logger = logger;

        public override async Task GenerateReportAsync(Report report)
        {
            try
            {
                var reportParams = JsonSerializer.Deserialize<TopTollBoothsParams>(report.Params);
                var result = await _reportService.GetTopTollBoothsByRevenueWithCacheAsync(reportParams);
                FinishReport(report, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating top toll booths report: {ReportId}", report.Id);
                report.Error = ex.Message;
            }
        }
    }
}
