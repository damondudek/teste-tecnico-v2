﻿using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Entities;

public class Toll : Entity
{
    public DateTime UsageDateTime { get; set; }
    public string Plaza { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public decimal AmountPaid { get; set; }
    public VehicleType VehicleType { get; set; }
}
