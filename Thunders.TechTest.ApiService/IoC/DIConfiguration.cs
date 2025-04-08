using Thunders.TechTest.ApiService.Repositories;
using Thunders.TechTest.ApiService.Services;

namespace Thunders.TechTest.ApiService.IoC
{
    public static class DIConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITollService, TollService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITollRepository, TollRepository>();
        }
    }
}
