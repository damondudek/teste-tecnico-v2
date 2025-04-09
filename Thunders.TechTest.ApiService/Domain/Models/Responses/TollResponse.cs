using Thunders.TechTest.ApiService.Domain.Enums;

namespace Thunders.TechTest.ApiService.Domain.Models.Responses;

public record TollResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime UsageDateTime { get; set; }
    public required string TollBooth { get; set; }
    public required string City { get; set; }
    public required string State { get; set; }
    public decimal AmountPaid { get; set; }
    public VehicleType VehicleType { get; set; }
}
