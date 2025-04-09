namespace Thunders.TechTest.ApiService.Extensions;

public static class DateTimeExtension
{
    public static string ToCacheKey(this DateTime date)
    {
        return date.ToString("yyyyMMdd");
    }
}
