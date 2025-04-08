using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Services;

public interface IReportService
{
    Task<Report> AddAsync(Report report);
    Task<Report?> GetByIdAsync(Guid id);
}


