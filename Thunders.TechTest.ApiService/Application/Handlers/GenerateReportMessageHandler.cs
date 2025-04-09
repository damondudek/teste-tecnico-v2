using Rebus.Handlers;
using Thunders.TechTest.ApiService.Application.Services.ReportGenerator;
using Thunders.TechTest.ApiService.Domain.Interfaces;
using Thunders.TechTest.ApiService.Domain.Models.Messages;

public class GenerateReportMessageHandler(
    IReportService reportService,
    ILogger<GenerateReportMessageHandler> logger,
    ReportGeneratorFactory generatorFactory) : IHandleMessages<GenerateReportMessage>
{
    private readonly IReportService _reportService = reportService;
    private readonly ILogger<GenerateReportMessageHandler> _logger = logger;
    private readonly ReportGeneratorFactory _generatorFactory = generatorFactory;

    public async Task Handle(GenerateReportMessage message)
    {
        try
        {
            var report = await _reportService.GetByIdAsync(message.Id) ?? throw new ArgumentException("Report does not exist");
            report.StartedAt = DateTime.UtcNow;
            await _reportService.UpdateAsync(report);

            var generator = _generatorFactory.GetGenerator(report.ReportType);
            await generator.GenerateReportAsync(report);
            await _reportService.UpdateAsync(report);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error processing message: {MessageId}", message.Id);
            throw;
        }
    }
}