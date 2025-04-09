using System.Text.Json;
using System.Text.Json.Serialization;
using Thunders.TechTest.ApiService.Domain.Entities;
using Thunders.TechTest.ApiService.Domain.Interfaces;

namespace Thunders.TechTest.ApiService.Application.Services.ReportGenerator
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
