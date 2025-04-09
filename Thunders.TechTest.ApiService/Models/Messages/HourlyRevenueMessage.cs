namespace Thunders.TechTest.ApiService.Models.Messages;

public record HourlyRevenueMessage : ReportMessage
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
