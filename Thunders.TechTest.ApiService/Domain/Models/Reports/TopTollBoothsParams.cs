namespace Thunders.TechTest.ApiService.Domain.Models.Reports;

public record TopTollBoothsParams
{
    public int Month { get; set; }
    public int Year { get; set; }
    public int TopCount { get; set; } = 10;
}
