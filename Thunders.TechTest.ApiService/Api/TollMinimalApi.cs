using AutoMapper;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Models;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Api
{
    public static class TollMinimalApi
    {
        public static void TollApiMap(this WebApplication app)
        {
            app.MapPost("/toll", async (TollRequest toll, IMessageSender sender, IMapper mapper) =>
            {
                var message = mapper.Map<Toll>(toll);
                message.SetId();
                await sender.Publish(message);

                return Results.Accepted(null, new { id = message.Id });
            })
            .WithName("AddToll")
            .WithOpenApi();
        }
    }
}