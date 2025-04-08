using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Services;

public interface ITollService
{
    Task<Toll> AddAsync(Toll toll);
    Task<Toll?> GetByIdAsync(Guid id);
}
