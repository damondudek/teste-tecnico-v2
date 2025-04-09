using Thunders.TechTest.ApiService.Domain.Entities;
using Thunders.TechTest.ApiService.Domain.Interfaces;
using Thunders.TechTest.ApiService.Infrastructure.Database;

namespace Thunders.TechTest.ApiService.Infrastructure.Repositories;

public class TollRepository : ITollRepository
{
    private readonly TollContext _context;

    public TollRepository(TollContext context)
    {
        _context = context;
    }

    public async Task<Toll> AddAsync(Toll toll)
    {
        toll.SetCreation();
        await _context.Tolls.AddAsync(toll);
        await _context.SaveChangesAsync();

        return toll;
    }

    public async Task<Toll?> GetByIdAsync(Guid id)
        => await _context.Tolls.FindAsync(id);
}
