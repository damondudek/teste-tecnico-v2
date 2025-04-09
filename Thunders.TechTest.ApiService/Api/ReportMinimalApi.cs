using AutoMapper;
using Thunders.TechTest.ApiService.Domain.Interfaces;
using Thunders.TechTest.ApiService.Domain.Models.Messages;
using Thunders.TechTest.ApiService.Domain.Models.Requests;
using Thunders.TechTest.ApiService.Domain.Models.Responses;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Api
{
    public static class ReportMinimalApi
    {
        public static void ReportApiMap(this WebApplication app)
        {
            app.MapPost("/reports/hourly-revenue", async (
                HourlyRevenueRequest request,
                IMessageSender sender, IMapper mapper) =>
                {
                    var message = mapper.Map<HourlyRevenueMessage>(request);
                    await sender.SendLocal(message);
                    var response = mapper.Map<ReportResponse>(message);

                    return Results.AcceptedAtRoute("GetReportStatus", response, response);
                })
            .WithName("GenerateHourlyRevenueReport")
            .WithOpenApi();

            app.MapPost("/reports/top-toll-booths", async (
                TopTollBoothsRequest request,
                IMessageSender sender, IMapper mapper) =>
                {
                    var message = mapper.Map<TopTollBoothsMessage>(request);
                    await sender.SendLocal(message);
                    var response = mapper.Map<ReportResponse>(message);

                    return Results.AcceptedAtRoute("GetReportStatus", response, response);
                })
            .WithName("GenerateTopTollBoothsReport")
            .WithOpenApi();

            app.MapPost("/reports/vehicle-count", async (
                VehicleCountRequest request,
                IMessageSender sender, IMapper mapper) =>
                {
                    var message = mapper.Map<VehicleCountMessage>(request);
                    await sender.SendLocal(message);
                    var response = mapper.Map<ReportResponse>(message);

                    return Results.AcceptedAtRoute("GetReportStatus", response, response);
                })
            .WithName("GenerateVehicleCountReport")
            .WithOpenApi();

            app.MapGet("/reports/{id}", async (
                Guid id,
                IReportService reportService,
                IMapper mapper) =>
                {
                    var report = await reportService.GetByIdAsync(id);
                    if (report == null)
                        return Results.NotFound("Report does not exists");

                    var response = mapper.Map<GenerateReportResponse>(report);

                    return Results.Ok(response);
                })
            .WithName("GetReportStatus")
            .WithOpenApi();
        }
    }
}