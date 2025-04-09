using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Models.Requests;

public record TollRequest
{
    public DateTime UsageDateTime { get; set; }

    public required string TollBooth { get; set; }

    public required string City { get; set; }

    public required string State { get; set; }

    public decimal AmountPaid { get; set; }

    public VehicleType VehicleType { get; set; }
}