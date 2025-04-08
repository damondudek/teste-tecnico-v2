using Rebus.Handlers;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.ApiService.Handlers;

public class TollMessageHandler(ITollService tollService, ILogger<TollMessageHandler> logger) : IHandleMessages<Toll>
{
    private readonly ITollService _tollService = tollService;
    private readonly ILogger<TollMessageHandler> _logger = logger;

    public async Task Handle(Toll toll)
    {
        try
        {
            await _tollService.AddAsync(toll);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on {ClassName} processing this message {Message}", nameof(TollMessageHandler), toll.ToString());
            throw;
        }
    }
}
