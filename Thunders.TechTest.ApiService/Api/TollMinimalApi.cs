using AutoMapper;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Models;
using Thunders.TechTest.ApiService.Services;
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

            app.MapGet("/toll/{id}", async (Guid id, ITollService tollService, IMapper mapper) =>
            {
                var toll = await tollService.GetByIdAsync(id);
                if (toll == null)
                    return Results.NotFound("Toll does not exists");

                return Results.Ok(toll);
            })
            .WithName("GetTollById")
            .WithOpenApi();
        }
    }
}