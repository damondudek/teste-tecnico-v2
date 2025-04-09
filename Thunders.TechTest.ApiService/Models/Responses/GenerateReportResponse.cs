using System.Text.Json;
using System.Text.Json.Serialization;
using Thunders.TechTest.ApiService.Enums;

namespace Thunders.TechTest.ApiService.Models.Responses
{
    public record GenerateReportResponse
    {
        public Guid Id { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public ReportType Type { get; set; }

        public ReportStatus Status =>
            Error != null ? ReportStatus.Error :
            StartedAt == null ? ReportStatus.InQueue :
            FinishedAt == null ? ReportStatus.InProgress :
            ReportStatus.Ready;

        [JsonPropertyName("params")]
        public object? ReportParams => DeserializeJson(Params);

        [JsonPropertyName("data")]
        public object? ReportData => DeserializeJson(JsonData);

        public string? Error { get; set; }

        [JsonIgnore]
        public string? Params { get; set; }

        [JsonIgnore]
        public string? JsonData { get; set; }

        private static object? DeserializeJson(string? json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            try
            {
                return JsonSerializer.Deserialize<object>(json);
            }
            catch (JsonException ex)
            {
                return JsonSerializer.Deserialize<object>(ex.Message);
            }
        }
    }
}