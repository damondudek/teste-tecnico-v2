using Thunders.TechTest.ApiService.Domain.Entities;
using Thunders.TechTest.ApiService.Domain.Models.Reports;

namespace Thunders.TechTest.ApiService.Domain.Interfaces;

public interface IReportService
{
    Task<Report> AddAsync(Report report);
    Task<Report> UpdateAsync(Report report);
    Task<Report?> GetByIdAsync(Guid id);
    Task<List<RevenueReportByHourAndCity>> GetRevenueReportByHourAndCityWithCacheAsync(HourlyRevenueParams reportParams);
    Task<List<TollBoothRevenueReport>> GetTopTollBoothsByRevenueWithCacheAsync(TopTollBoothsParams reportParams);
    Task<List<VehicleTypeCountReport>> GetVehicleTypeCountByTollBoothWithCacheAsync(VehicleCountParams reportParams);
}