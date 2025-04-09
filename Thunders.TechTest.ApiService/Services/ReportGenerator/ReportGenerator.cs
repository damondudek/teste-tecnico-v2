using System.Text.Json.Serialization;
using System.Text.Json;
using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Services.ReportGenerator
{
    public abstract class ReportGenerator : IReportGenerator
    {
        public abstract Task GenerateReportAsync(Report report);

        public static void FinishReport(Report report, object result)
        {
            var options = new JsonSerializerOptions
            {
                Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
            };

            report.JsonData = JsonSerializer.Serialize(result, options);
            report.FinishedAt = DateTime.UtcNow;
        }
    }
}
