using System;
using System.Data.SqlTypes;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="DateTime"/> extensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// UTC date format string.
        /// </summary>
        public const string UTC_DATE_FORMAT = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";

        /// <summary>
        /// Min value for Sql datetime to save in sql db.
        /// </summary>
        public static readonly DateTime SqlDateTimeMinUtc = SqlDateTime.MinValue.Value.AsUtcKind();

        /// <summary>
        /// Gets the UTC datetime format for the date.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToUtcFormatString(this DateTime date) => date.ToUniversalTime().ToString(UTC_DATE_FORMAT);

        /// <summary>
        /// Gets the min value for Sql datetime.
        /// </summary>
        public static DateTime ToSqlDateTimeMinUtc(this DateTime date) => SqlDateTimeMinUtc;

        /// <summary>
        /// Specifies datetime's kind as UTC.
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        /// <remarks>
        /// Date read from db or parsed from string has its Kind as Unspecified.
        /// Specifying its kind as UTC is needed if date is expected to be UTC.
        /// ToUniversalTime() assumes that the kind is local while converting it and is undesirable.
        /// </remarks>
        public static DateTime AsUtcKind(this DateTime datetime) => DateTime.SpecifyKind(datetime, DateTimeKind.Utc);

        public static bool IsEarlierThan(this DateTime a, DateTime b) => a.CompareTo(b) < 0;

        public static bool IsLaterThan(this DateTime a, DateTime b) => a.CompareTo(b) > 0;

        public static bool IsTheSameAs(this DateTime a, DateTime b) => a.CompareTo(b) == 0;
    }
}