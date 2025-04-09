namespace Thunders.TechTest.ApiService.Domain.Models.Reports;

public record HourlyRevenueParams
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
