using Thunders.TechTest.ApiService.Domain.Enums;

namespace Thunders.TechTest.ApiService.Domain.Models.Requests;

public record TollRequest
{
    public DateTime UsageDateTime { get; set; }

    public required string TollBooth { get; set; }

    public required string City { get; set; }

    public required string State { get; set; }

    public decimal AmountPaid { get; set; }

    public VehicleType VehicleType { get; set; }
}