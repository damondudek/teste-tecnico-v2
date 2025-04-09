using Thunders.TechTest.ApiService.Enums;
using Thunders.TechTest.ApiService.Interfaces;

namespace Thunders.TechTest.ApiService.Models.Messages;

public record ReportMessage : IReportMessage
{
    public Guid Id { get; set; }
    public ReportType ReportType { get; set; }
    public string Params { get; set; } = string.Empty;
}