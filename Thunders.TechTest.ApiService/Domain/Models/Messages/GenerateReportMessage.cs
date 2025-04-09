using Thunders.TechTest.ApiService.Domain.Enums;

namespace Thunders.TechTest.ApiService.Domain.Models.Messages;

public record GenerateReportMessage
{
    public Guid Id { get; set; }
    public ReportType ReportType { get; set; }
    public string Params { get; set; } = string.Empty;
}