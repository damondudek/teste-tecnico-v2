using Thunders.TechTest.ApiService.Domain.Enums;

namespace Thunders.TechTest.ApiService.Domain.Entities;

public class Toll : Entity
{
    public DateTime UsageDateTime { get; set; }
    public string TollBooth { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public decimal AmountPaid { get; set; }
    public VehicleType VehicleType { get; set; }
}
