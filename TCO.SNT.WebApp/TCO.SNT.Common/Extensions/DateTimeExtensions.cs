using System;

namespace TCO.SNT.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ConvertToUtcKind(this DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Unspecified)
            {
                throw new InvalidOperationException($"Incorrect DateTimeKind. {dateTime.Kind} found but {DateTimeKind.Unspecified} expected");
            }
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }

        public static void EnsureUtcKind(this DateTime dateTime)
        {
            if (dateTime.Kind != DateTimeKind.Utc)
            {
                throw new InvalidOperationException($"Incorrect DateTimeKind. {dateTime.Kind} found but {DateTimeKind.Utc} expected");
            }
        }

        public static DateTime SetDateWithOffset(this DateTime dateTime, int offsetMinutes)
        {
            dateTime.EnsureUtcKind();

            var utcOffset = new DateTimeOffset(dateTime);
            var localOffset = utcOffset.ToOffset(TimeSpan.FromMinutes(offsetMinutes));
            return localOffset.Date;
        }

        public static string ToStringCommonDateFormat(this DateTime dateTime)
        {
            return dateTime.ToString(GlobalConst.CommonDateFormat);
        }

        public static string ToStringCommonDateFormat(this DateTimeOffset dateTime)
        {
            return dateTime.ToString(GlobalConst.CommonDateFormat);
        }
    }
}
