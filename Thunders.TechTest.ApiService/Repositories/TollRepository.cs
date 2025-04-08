using Thunders.TechTest.ApiService.Database;
using Thunders.TechTest.ApiService.Entities;

namespace Thunders.TechTest.ApiService.Repositories;

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
}
