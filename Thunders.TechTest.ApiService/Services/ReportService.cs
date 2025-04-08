using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Repositories;

namespace Thunders.TechTest.ApiService.Services;

public class ReportService : IReportService
{
    private readonly IReportRepository _repository;

    public ReportService(IReportRepository repository)
    {
        _repository = repository;
    }

    public async Task<Report> AddAsync(Report report)
    {
        var reportAdded = await _repository.AddAsync(report);
        return reportAdded;
    }

    public async Task<Report?> GetByIdAsync(Guid id)
    {
        var report = await _repository.GetByIdAsync(id);
        return report;
    }

}

