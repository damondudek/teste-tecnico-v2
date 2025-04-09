using AutoMapper;
using Rebus.Handlers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Models.Messages;
using Thunders.TechTest.ApiService.Models.Reports;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.ApiService.Handlers;

public class GenerateReportMessageHandler(IReportService reportService, ILogger<ReportMessageHandler> logger, IMapper mapper) : IHandleMessages<GenerateReportMessage>
{
    private readonly IReportService _reportService = reportService;
    private readonly ILogger<ReportMessageHandler> _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task Handle(GenerateReportMessage message)
    {
        try
        {
            var report = await _reportService.GetByIdAsync(message.Id) ?? throw new ArgumentException("Report does not exists");
            report.StartedAt = DateTime.UtcNow;
            await _reportService.UpdateAsync(report);
            
            switch (report.ReportType)
            {
                case Enums.ReportType.HourlyRevenueByCity:
                    await GenerateHourlyRevenueByCity(report);
                    break;
                case Enums.ReportType.TopTollBoothsByMonth:
                    await GenerateTopTollBoothsByMonth(report);
                    break;
                case Enums.ReportType.VehicleCountByTollBooth:
                    await GenerateVehicleCountByTollBooth(report);
                    break;
                default:
                    throw new NotImplementedException("Invalid report type");
            }

            await _reportService.UpdateAsync(report);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on {ClassName} processing this message {Message}", nameof(ReportMessageHandler), message);
            throw;
        }
    }

    private async Task GenerateHourlyRevenueByCity(Report report)
    {
        try
        {
            var reportParams = JsonSerializer.Deserialize<HourlyRevenueParams>(report.Params);
            var result = await _reportService.GetRevenueReportByHourAndCityWithCacheAsync(reportParams);
            FinishReport(report, result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erron on {MethodName} with entity {Entity}", nameof(GenerateHourlyRevenueByCity), report);
            report.Error = ex.Message;
        }
    }

    private async Task GenerateTopTollBoothsByMonth(Report report)
    {
        try
        {
            var reportParams = JsonSerializer.Deserialize<TopTollBoothsParams>(report.Params);
            var result = await _reportService.GetTopTollBoothsByRevenueWithCacheAsync(reportParams);
            FinishReport(report, result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erron on {MethodName} with entity {Entity}", nameof(GenerateTopTollBoothsByMonth), report);
            report.Error = ex.Message;
        }
    }

    private async Task GenerateVehicleCountByTollBooth(Report report)
    {
        try
        {
            var reportParams = JsonSerializer.Deserialize<VehicleCountParams>(report.Params);
            var result = await _reportService.GetVehicleTypeCountByTollBoothWithCacheAsync(reportParams);
            FinishReport(report, result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erron on {MethodName} with entity {Entity}", nameof(GenerateVehicleCountByTollBooth), report);
            report.Error = ex.Message;
        }
    }

    private void FinishReport(Report report, object result)
    {
        var options = new JsonSerializerOptions
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
        };

        report.JsonData = JsonSerializer.Serialize(result, options);
        report.FinishedAt = DateTime.Now;
    }
}
