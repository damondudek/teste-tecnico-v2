﻿namespace Thunders.TechTest.ApiService.Models.Reports;

public record TollBoothRevenueReport
{
    public string TollBooth { get; set; }
    public decimal TotalRevenue { get; set; }

    public TollBoothRevenueReport(string tollBooth, decimal totalRevenue)
    {
        TollBooth = tollBooth;
        TotalRevenue = totalRevenue;
    }
}