namespace Thunders.TechTest.ApiService.Domain.Extensions;

public static class DateTimeExtension
{
    public static string ToCacheKey(this DateTime date)
    {
        return date.ToString("yyyyMMdd");
    }
}
