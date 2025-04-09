namespace Thunders.TechTest.ApiService.Domain.Models.Reports;

public record HourlyRevenueParams
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
