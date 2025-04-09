using AutoMapper;
using Thunders.TechTest.ApiService.Domain.Interfaces;
using Thunders.TechTest.ApiService.Domain.Models.Messages;
using Thunders.TechTest.ApiService.Domain.Models.Requests;
using Thunders.TechTest.OutOfBox.Queues;

namespace Thunders.TechTest.ApiService.Api
{
    public static class TollMinimalApi
    {
        public static void TollApiMap(this WebApplication app)
        {
            app.MapPost("/tolls", async (TollRequest toll, IMessageSender sender, IMapper mapper) =>
            {
                var message = mapper.Map<TollMessage>(toll);
                await sender.SendLocal(message);

                return Results.Accepted(null, new { id = message.Id });
            })
            .WithName("AddToll")
            .WithOpenApi();

            app.MapGet("/tolls/{id}", async (Guid id, ITollService tollService) =>
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