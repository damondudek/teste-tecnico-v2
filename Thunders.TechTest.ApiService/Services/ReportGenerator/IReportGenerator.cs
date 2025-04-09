using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Services.ReportGenerator;

public interface IReportGenerator
{
    Task GenerateReportAsync(Report report);
}
