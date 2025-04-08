using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Models.Messages
{
    public record ReportMessage
    {
        public Guid Id { get; set; }
        public ReportType ReportType { get; set; }
        public string Params { get; set; } = string.Empty;
    }
}