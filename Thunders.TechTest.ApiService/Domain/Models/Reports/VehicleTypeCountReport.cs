using Thunders.TechTest.ApiService.Domain.Enums;

namespace Thunders.TechTest.ApiService.Domain.Models.Reports;

public record VehicleTypeCountReport
{
    public VehicleType VehicleType { get; set; }
    public int Count { get; set; }

    public VehicleTypeCountReport(VehicleType vehicleType, int count)
    {
        VehicleType = vehicleType;
        Count = count;
    }
}