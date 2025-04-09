using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Interfaces;

public interface IReportGenerator
{
    Task GenerateReportAsync(Report report);
}
