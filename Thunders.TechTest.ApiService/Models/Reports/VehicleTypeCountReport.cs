using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Models.Reports;

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