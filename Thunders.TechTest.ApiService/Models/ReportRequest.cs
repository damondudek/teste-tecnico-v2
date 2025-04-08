using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Models
{
    public record ReportRequest
    {
        public ReportType ReportType { get; set; }
        public string Params { get; set; } = string.Empty;
    }
}
