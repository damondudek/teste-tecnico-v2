namespace Thunders.TechTest.ApiService.Models.Requests;

public record HourlyRevenueRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
