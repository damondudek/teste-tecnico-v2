namespace Thunders.TechTest.ApiService.Models.Requests;

public record TopTollBoothsRequest
{
    public int Month { get; set; }
    public int Year { get; set; }
    public int? TopCount { get; set; }
}
