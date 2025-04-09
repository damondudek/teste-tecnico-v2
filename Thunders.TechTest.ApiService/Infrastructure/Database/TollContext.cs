using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Thunders.TechTest.ApiService.Domain.Entities;

namespace Thunders.TechTest.ApiService.Infrastructure.Database;

public class TollContext : DbContext
{
    public TollContext(DbContextOptions<TollContext> options) : base(options)
    {
    }

    public DbSet<Toll> Tolls { get; set; }
    public DbSet<Report> Reports { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
