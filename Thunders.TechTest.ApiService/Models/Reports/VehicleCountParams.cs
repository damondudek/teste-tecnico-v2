namespace Thunders.TechTest.ApiService.Models.Reports;

public record VehicleCountParams
{
    public Guid Id { get; set; }
    public string TollBooth { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
