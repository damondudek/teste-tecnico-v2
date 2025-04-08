using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Repositories;

namespace Thunders.TechTest.ApiService.Services;

public class TollService(ITollRepository repository) : ITollService
{
    private readonly ITollRepository _repository = repository;

    public async Task<Toll> AddAsync(Toll toll)
    {
        var tollAdded = await _repository.AddAsync(toll);
        return tollAdded;
    }

    public async Task<Toll?> GetByIdAsync(Guid id)
    {
        var toll = await _repository.GetByIdAsync(id);
        return toll;
    }
}
