using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Repositories;

public interface IReportRepository
{
    Task<Report> AddAsync(Report report);
    Task<Report?> GetByIdAsync(Guid id);
}
