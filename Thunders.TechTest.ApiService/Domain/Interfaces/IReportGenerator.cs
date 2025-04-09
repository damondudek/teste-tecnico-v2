using Thunders.TechTest.ApiService.Domain.Entities;

namespace Thunders.TechTest.ApiService.Domain.Interfaces;

public interface IReportGenerator
{
    Task GenerateReportAsync(Report report);
}
