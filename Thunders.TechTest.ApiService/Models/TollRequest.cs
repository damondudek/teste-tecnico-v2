using System.Text.Json.Serialization;
using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Models;

public record TollRequest
{
    [JsonPropertyName("usageDateTime")]
    public DateTime UsageDateTime { get; set; }

    [JsonPropertyName("plaza")]
    public string Plaza { get; set; } = string.Empty;

    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("state")]
    public string State { get; set; } = string.Empty;

    [JsonPropertyName("amountPaid")]
    public decimal AmountPaid { get; set; }

    [JsonPropertyName("vehicleType")]
    public VehicleType VehicleType { get; set; }
}