using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Repositories;

public interface ITollRepository
{
    Task<Toll> AddAsync(Toll toll);
    Task<Toll?> GetByIdAsync(Guid id);
}
