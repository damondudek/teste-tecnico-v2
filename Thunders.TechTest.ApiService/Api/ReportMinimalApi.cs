using AutoMapper;
using Thunders.TechTest.ApiService.Models;
using Thunders.TechTest.ApiService.Models.Messages;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Api
{
    public static class ReportMinimalApi
    {
        public static void ReportApiMap(this WebApplication app)
        {
            app.MapPost("/report", async (ReportRequest request, IMessageSender sender, IMapper mapper) =>
            {
                var message = mapper.Map<ReportMessage>(request);
                message.Id = Guid.NewGuid();
                await sender.SendLocal(message);

                return Results.Accepted(null, new { id = message.Id });
            });
        }
    }
}