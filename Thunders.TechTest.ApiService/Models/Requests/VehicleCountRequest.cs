namespace Thunders.TechTest.ApiService.Models.Requests;

public record VehicleCountRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required string TollBooth { get; set; }
}
