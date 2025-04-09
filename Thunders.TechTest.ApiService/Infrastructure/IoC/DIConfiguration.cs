using Thunders.TechTest.ApiService.Application.Services;
using Thunders.TechTest.ApiService.Application.Services.ReportGenerator;
using Thunders.TechTest.ApiService.Domain.Interfaces;
using Thunders.TechTest.ApiService.Infrastructure.Repositories;

namespace Thunders.TechTest.ApiService.Infrastructure.IoC
{
    public static class DIConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITollService, TollService>();
            services.AddScoped<IReportService, ReportService>();

            services.AddScoped<HourlyRevenueReportGenerator>();
            services.AddScoped<TopTollBoothsReportGenerator>();
            services.AddScoped<VehicleCountReportGenerator>();
            services.AddScoped<ReportGeneratorFactory>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITollRepository, TollRepository>();
            services.AddScoped<IReportRepository, ReportRepository>();
        }
    }
}
