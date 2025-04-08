using Thunders.TechTest.ApiService.Database;
using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly TollContext _context;

    public ReportRepository(TollContext context)
    {
        _context = context;
    }

    public async Task<Report> AddAsync(Report report)
    {
        report.SetCreation();
        await _context.Reports.AddAsync(report);
        await _context.SaveChangesAsync();

        return report;
    }

    public async Task<Report?> GetByIdAsync(Guid id)
        => await _context.Reports.FindAsync(id);

    

}
