namespace Thunders.TechTest.ApiService.Domain.Models.Messages;

public record TopTollBoothsMessage : ReportMessage
{
    public int Month { get; set; }
    public int Year { get; set; }
    public int TopCount { get; set; }
}
