using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Models.Messages;

public record GenerateReportMessage
{
    public Guid Id { get; set; }
    public ReportType ReportType { get; set; }
    public string Params { get; set; } = string.Empty;
}