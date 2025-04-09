using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Repositories;

namespace Thunders.TechTest.ApiService.Services;

public class TollService(ITollRepository repository) : ITollService
{
    private readonly ITollRepository _repository = repository;

    public Task<Toll> AddAsync(Toll toll)
        => _repository.AddAsync(toll);

    public Task<Toll?> GetByIdAsync(Guid id)
        => _repository.GetByIdAsync(id);
}
