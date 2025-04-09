using Thunders.TechTest.ApiService.Domain.Enums;

namespace Thunders.TechTest.ApiService.Domain.Entities;

public class Report : Entity
{
    public DateTime? StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
    public ReportType ReportType { get; set; }
    public string Params { get; set; }
    public string? JsonData { get; set; }
    public string? Error { get; set; }
}
