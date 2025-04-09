using Thunders.TechTest.ApiService.Interfaces;
using Thunders.TechTest.ApiService.Repositories;
using Thunders.TechTest.ApiService.Services;
using Thunders.TechTest.ApiService.Services.ReportGenerator;

namespace Thunders.TechTest.ApiService.IoC
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
