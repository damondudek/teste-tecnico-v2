namespace Thunders.TechTest.ApiService.Models.Messages;

public record VehicleCountMessage : ReportMessage
{
    public required string TollBooth { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
