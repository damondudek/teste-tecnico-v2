using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Thunders.TechTest.ApiService.Database;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Models.Reports;

namespace Thunders.TechTest.ApiService.Repositories;

public class ReportRepository : IReportRepository
{
    private readonly TollContext _context;
    private readonly IDistributedCache _cache;

    public ReportRepository(TollContext context, IDistributedCache cache)
    {
        _context = context;
        _cache = cache;
    }

    public async Task<Report> AddAsync(Report report)
    {
        report.SetCreation();
        await _context.Reports.AddAsync(report);
        await _context.SaveChangesAsync();

        return report;
    }

    public async Task<Report> UpdateAsync(Report report)
    {
        report.SetUpdate();
        _context.Reports.Update(report);
        await _context.SaveChangesAsync();

        return report;
    }

    public async Task<Report?> GetByIdAsync(Guid id)
        => await _context.Reports.FindAsync(id);

    public async Task<List<RevenueReportByHourAndCity>> GetRevenueReportByHourAndCityAsync(DateTime startDate, DateTime endDate)
    {
        var result = await _context.Tolls
            .AsNoTracking()
            .Where(t => t.UsageDateTime >= startDate && t.UsageDateTime <= endDate)
            .GroupBy(t => new { t.City, t.UsageDateTime.Hour })
            .Select(g => new
            {
                g.Key.City,
                g.Key.Hour,
                AmountPaid = g.Sum(t => t.AmountPaid)
            })
            .OrderBy(r => r.City)
                .ThenBy(r => r.Hour)
            .ToListAsync();

        var reportData = result.Select(r => new RevenueReportByHourAndCity(r.City, r.Hour, r.AmountPaid)).ToList();

        return reportData;
    }


    public async Task<List<RevenueReportByHourAndCity>> GetRevenueReportByHourAndCityWithCacheAsync(HourlyRevenueParams reportParams)
    {
        var cacheKey = $"revenue_report_by_hour_and_city_{reportParams.Id}";
        var cachedReport = await _cache.GetStringAsync(cacheKey);

        if (!string.IsNullOrEmpty(cachedReport))
            return JsonConvert.DeserializeObject<List<RevenueReportByHourAndCity>>(cachedReport!)!;

        var report = await GetRevenueReportByHourAndCityAsync(reportParams.StartDate, reportParams.EndDate);
        await SetCache(cacheKey, report);

        return report;
    }

    public async Task<List<TollBoothRevenueReport>> GetTopTollBoothsByRevenueAsync(int month, int year, int topCount)
    {
        var result = await _context.Tolls
            .AsNoTracking()
            .Where(t => t.UsageDateTime.Month == month && t.UsageDateTime.Year == year)
            .GroupBy(t => t.TollBooth)
            .Select(g => new { TollBooth = g.Key, TotalRevenue = g.Sum(t => t.AmountPaid) })
            .OrderByDescending(r => r.TotalRevenue)
            .Take(topCount)
            .ToListAsync();

        var reportData = result.Select(r => new TollBoothRevenueReport(r.TollBooth, r.TotalRevenue)).ToList();

        return reportData;
    }

    public async Task<List<TollBoothRevenueReport>> GetTopTollBoothsByRevenueWithCacheAsync(TopTollBoothsParams reportParams)
    {
        var cacheKey = $"top_toll_booths_by_revenue_{reportParams.Id}";
        var cachedReport = await _cache.GetStringAsync(cacheKey);

        if (!string.IsNullOrEmpty(cachedReport))
            return JsonConvert.DeserializeObject<List<TollBoothRevenueReport>>(cachedReport!)!;

        var report = await GetTopTollBoothsByRevenueAsync(reportParams.Month, reportParams.Year, reportParams.TopCount);
        await SetCache(cacheKey, report);

        return report;
    }

    public Task<List<VehicleTypeCountReport>> GetVehicleTypeCountByTollBoothAsync(string tollBooth, DateTime startDate, DateTime endDate)
        => _context.Tolls
            .AsNoTracking()
            .Where(t => t.TollBooth == tollBooth && t.UsageDateTime >= startDate && t.UsageDateTime <= endDate)
            .GroupBy(t => t.VehicleType)
            .Select(g => new VehicleTypeCountReport(g.Key, g.Count()))
            .ToListAsync();

    public async Task<List<VehicleTypeCountReport>> GetVehicleTypeCountByTollBoothWithCacheAsync(VehicleCountParams reportParams)
    {
        var cacheKey = $"vehicle_type_count_by_toll_booth_{reportParams.Id}";
        var cachedReport = await _cache.GetStringAsync(cacheKey);

        if (!string.IsNullOrEmpty(cachedReport))
            return JsonConvert.DeserializeObject<List<VehicleTypeCountReport>>(cachedReport!)!;

        var report = await GetVehicleTypeCountByTollBoothAsync(reportParams.TollBooth, reportParams.StartDate, reportParams.EndDate);
        await SetCache(cacheKey, report);

        return report;
    }

    private async Task SetCache(string key, object value)
    {
        await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value), new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(1)
        });
    }
}
