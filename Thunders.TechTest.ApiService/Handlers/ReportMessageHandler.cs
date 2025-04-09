using AutoMapper;
using Rebus.Handlers;
using System.Text.Json;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Models.Messages;
using Thunders.TechTest.ApiService.Models.Reports;
using Thunders.TechTest.ApiService.Services;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Handlers;

public class ReportMessageHandler(IReportService reportService, ILogger<ReportMessageHandler> logger, IMapper mapper, IMessageSender sender) :
    IHandleMessages<HourlyRevenueMessage>,
    IHandleMessages<TopTollBoothsMessage>,
    IHandleMessages<VehicleCountMessage>
{
    private readonly IReportService _reportService = reportService;
    private readonly ILogger<ReportMessageHandler> _logger = logger;
    private readonly IMapper _mapper = mapper;
    private readonly IMessageSender _sender = sender;

    public async Task Handle(HourlyRevenueMessage message)
    {
        await HandleGenerateReportMessage<HourlyRevenueParams>(message);
    }

    public async Task Handle(TopTollBoothsMessage message)
    {
        await HandleGenerateReportMessage<TopTollBoothsParams>(message);
    }

    public async Task Handle(VehicleCountMessage message)
    {
        await HandleGenerateReportMessage<VehicleCountParams>(message);
    }

    private async Task HandleGenerateReportMessage<T>(object message)
    {
        try
        {
            var report = ReportMap<T>(message);
            await _reportService.AddAsync(report);

            var generateMessage = _mapper.Map<GenerateReportMessage>(report);
            await _sender.SendLocal(generateMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on {ClassName} processing this message {Message}", nameof(ReportMessageHandler), message);
            throw;
        }
    }

    private Report ReportMap<T>(object message)
    {
        var report = _mapper.Map<Report>(message);
        var reportParams = _mapper.Map<T>(message);
        report.Params = JsonSerializer.Serialize(reportParams);

        return report;
    }
}
