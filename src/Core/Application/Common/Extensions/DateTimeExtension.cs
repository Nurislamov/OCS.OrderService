namespace Application.Common.Extensions;

internal static class DateTimeExtension
{
    internal static string GetDateTimeForView(this DateTime dateTime)
    {
        var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
        return TimeZoneInfo
            .ConvertTimeFromUtc(dateTime, timeZoneInfo)
            .ToString("yyyy-MM-dd hh:mm.zz");
    }
}