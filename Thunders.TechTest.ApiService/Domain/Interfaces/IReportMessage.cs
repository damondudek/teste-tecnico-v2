using Thunders.TechTest.ApiService.Domain.Enums;

namespace Thunders.TechTest.ApiService.Domain.Interfaces;

public interface IReportMessage
{
    Guid Id { get; }
    ReportType ReportType { get; }
    string? Params { get; }
}
