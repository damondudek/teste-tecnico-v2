﻿using Thunders.TechTest.ApiService.Database;
using Thunders.TechTest.ApiService.Entities;
using Thunders.TechTest.ApiService.Interfaces;

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

    public async Task<Toll?> GetByIdAsync(Guid id)
        => await _context.Tolls.FindAsync(id);
}
