namespace Thunders.TechTest.ApiService.Domain.Models.Requests;

public record VehicleCountRequest
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public required string TollBooth { get; set; }
}
