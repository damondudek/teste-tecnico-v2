using AutoMapper;
using Thunders.TechTest.ApiService.Models.Messages;
using Thunders.TechTest.ApiService.Models.Requests;
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
                var message = mapper.Map<TollMessage>(toll);
                message.Id = Guid.NewGuid();
                await sender.SendLocal(message);

                return Results.Accepted(null, new { id = message.Id });
            })
            .WithName("AddToll")
            .WithOpenApi();

            app.MapGet("/toll/{id}", async (Guid id, ITollService tollService) =>
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