using Thunders.TechTest.ApiService.Domain.Entities;

namespace Thunders.TechTest.ApiService.Domain.Interfaces;

public interface ITollService
{
    Task<Toll> AddAsync(Toll toll);
    Task<Toll?> GetByIdAsync(Guid id);
}
