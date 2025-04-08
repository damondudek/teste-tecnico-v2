using AutoMapper;
using Rebus.Handlers;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Models.Messages;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.ApiService.Handlers;

public class ReportMessageHandler(IReportService reportService, ILogger<ReportMessageHandler> logger, IMapper mapper) : IHandleMessages<ReportMessage>
{
    private readonly IReportService _reportService = reportService;
    private readonly ILogger<ReportMessageHandler> _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task Handle(ReportMessage message)
    {
        try
        {
            var report = _mapper.Map<Report>(message);
            await _reportService.AddAsync(report);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on {ClassName} processing this message {Message}", nameof(ReportMessageHandler), message);
            throw;
        }
    }
}
