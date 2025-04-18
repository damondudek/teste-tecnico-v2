﻿using AutoMapper;
using Rebus.Handlers;
using Thunders.TechTest.ApiService.Domain.Entities;
using Thunders.TechTest.ApiService.Domain.Interfaces;
using Thunders.TechTest.ApiService.Domain.Models.Messages;

namespace Thunders.TechTest.ApiService.Application.Handlers;

public class TollMessageHandler(ITollService tollService, ILogger<TollMessageHandler> logger, IMapper mapper) : IHandleMessages<TollMessage>
{
    private readonly ITollService _tollService = tollService;
    private readonly ILogger<TollMessageHandler> _logger = logger;
    private readonly IMapper _mapper = mapper;

    public async Task Handle(TollMessage message)
    {
        try
        {
            var toll = _mapper.Map<Toll>(message);
            await _tollService.AddAsync(toll);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error on {ClassName} processing this message {Message}", nameof(TollMessageHandler), message);
            throw;
        }
    }
}
