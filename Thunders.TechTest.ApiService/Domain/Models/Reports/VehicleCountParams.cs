namespace Thunders.TechTest.ApiService.Domain.Models.Reports;

public record VehicleCountParams
{
    public string TollBooth { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
