using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Repositories;

namespace Thunders.TechTest.ApiService.Services;

public class TollService : ITollService
{
    private readonly ITollRepository _repository;

    public TollService(ITollRepository repository)
    {
        _repository = repository;
    }

    public async Task<Toll> AddAsync(Toll toll)
    {
        var tollAdded = await _repository.AddAsync(toll);
        return tollAdded;
    }
}
