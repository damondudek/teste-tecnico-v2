﻿using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Models.Reports;

namespace Thunders.TechTest.ApiService.Services;

public class ReportService(IReportRepository repository) : IReportService
{
    private readonly IReportRepository _repository = repository;

    public Task<Report> AddAsync(Report report)
        => _repository.AddAsync(report);

    public Task<Report> UpdateAsync(Report report)
        => _repository.UpdateAsync(report);

    public Task<Report?> GetByIdAsync(Guid id)
        => _repository.GetByIdAsync(id);

    public Task<List<RevenueReportByHourAndCity>> GetRevenueReportByHourAndCityWithCacheAsync(HourlyRevenueParams reportParams)
        => _repository.GetRevenueReportByHourAndCityWithCacheAsync(reportParams);

    public Task<List<TollBoothRevenueReport>> GetTopTollBoothsByRevenueWithCacheAsync(TopTollBoothsParams reportParams)
        => _repository.GetTopTollBoothsByRevenueWithCacheAsync(reportParams);

    public Task<List<VehicleTypeCountReport>> GetVehicleTypeCountByTollBoothWithCacheAsync(VehicleCountParams reportParams)
        => _repository.GetVehicleTypeCountByTollBoothWithCacheAsync(reportParams);
}

