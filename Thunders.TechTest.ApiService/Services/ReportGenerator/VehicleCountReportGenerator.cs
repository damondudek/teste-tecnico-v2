using System.Text.Json;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Models.Reports;

namespace Thunders.TechTest.ApiService.Services.ReportGenerator
{
    public class VehicleCountReportGenerator(IReportService reportService, ILogger<VehicleCountReportGenerator> logger) : ReportGenerator
    {
        private readonly IReportService _reportService = reportService;
        private readonly ILogger<VehicleCountReportGenerator> _logger = logger;

        public override async Task GenerateReportAsync(Report report)
        {
            try
            {
                var reportParams = JsonSerializer.Deserialize<VehicleCountParams>(report.Params);
                var result = await _reportService.GetVehicleTypeCountByTollBoothWithCacheAsync(reportParams);
                FinishReport(report, result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating vehicle count report: {ReportId}", report.Id);
                report.Error = ex.Message;
            }
        }
    }
}
