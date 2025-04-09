using System.Text.RegularExpressions;

namespace Thunders.TechTest.ApiService.Domain.Extensions;

public static class StringExtension
{
    public static string SanitizeAsKey(this string content)
    {
        string sanitized = Regex.Replace(content, @"[^a-zA-Z0-9_-]", "");
        sanitized = sanitized.ToLowerInvariant().Trim();

        return sanitized;
    }
}
