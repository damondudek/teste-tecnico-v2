using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Thunders.TechTest.OutOfBox.Database
{
    public static class EntityFrameworkServiceCollectionExtensions
    {
        public static IServiceCollection AddSqlServerDbContext<TContext>(this IServiceCollection services, IConfiguration configuration)
            where TContext : DbContext
        {
            services.AddDbContext<TContext>((options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("ThundersTechTestDb"));
            });

            return services;
        }

        public static void ApplyMigrations<TContext>(this WebApplication app)
            where TContext : DbContext
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TContext>();
            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();
        }
    }
}
