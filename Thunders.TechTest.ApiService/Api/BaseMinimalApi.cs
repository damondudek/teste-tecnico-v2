namespace Thunders.TechTest.ApiService.Api
{
    public static class BaseMinimalApi
    {
        public static void BaseApiMap(this WebApplication app)
        {
            app.UsePathBase("/api/v1");
        }
    }
}