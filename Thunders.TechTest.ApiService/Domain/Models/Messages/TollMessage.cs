using Thunders.TechTest.ApiService.Domain.Enums;

namespace Thunders.TechTest.ApiService.Domain.Models.Messages;

public record TollMessage
{
    public Guid Id { get; set; }
    public DateTime UsageDateTime { get; set; }
    public string TollBooth { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public decimal AmountPaid { get; set; }
    public VehicleType VehicleType { get; set; }
}