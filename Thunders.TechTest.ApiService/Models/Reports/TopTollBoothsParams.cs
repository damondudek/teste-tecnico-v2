namespace Thunders.TechTest.ApiService.Models.Reports;

public record TopTollBoothsParams
{
    public Guid Id { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int TopCount { get; set; } = 10;
}
