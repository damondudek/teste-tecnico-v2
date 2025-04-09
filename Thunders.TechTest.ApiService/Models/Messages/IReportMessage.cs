using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Models.Messages;

public interface IReportMessage
{
    Guid Id { get; }
    ReportType ReportType { get; }
    string? Params { get; }
}
