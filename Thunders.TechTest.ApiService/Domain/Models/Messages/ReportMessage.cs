using Thunders.TechTest.ApiService.Domain.Enums;
using Thunders.TechTest.ApiService.Domain.Interfaces;

namespace Thunders.TechTest.ApiService.Domain.Models.Messages;

public record ReportMessage : IReportMessage
{
    public Guid Id { get; set; }
    public ReportType ReportType { get; set; }
    public string Params { get; set; } = string.Empty;
}