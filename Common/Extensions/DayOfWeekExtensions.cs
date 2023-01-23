using System;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// Represents extension-methods for <see cref="DayOfWeek"/>.
    /// </summary>
    public static class DayOfWeekExtensions
    {
        public static int DaysTo(this DayOfWeek self, DayOfWeek other)
        {
            var difference = other - self;
            if (difference >= 0)
            {
                return difference;
            }

            return 7 + difference;
        }
    }
}