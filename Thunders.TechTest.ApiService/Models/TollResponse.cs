﻿using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Models;

public record TollResponse
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime UsageDateTime { get; set; }
    public string Plaza { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public decimal AmountPaid { get; set; }
    public VehicleType VehicleType { get; set; }
}
