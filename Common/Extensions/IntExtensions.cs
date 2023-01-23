using System;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// Represents extension-methods for <see cref="int"/>.
    /// </summary>
    public static class IntExtensions
    {
        public static bool IsEven(this int value) => value % 2 == 0;

        public static bool IsOdd(this int value) => !value.IsEven();

        public static bool IsBetween(this int value, int minInclusive, int maxInclusive) =>
            value >= minInclusive && value <= maxInclusive;

        public static bool IsPrettyCloseTo(this double number1, double number2, double margin = 0.01) =>
            Math.Abs(number1 - number2) <= margin;

        public static double ToThePowerOf(this double @base, double exponent) => Math.Pow(@base, exponent);

        public static double AbsoluteValue(this double value) => Math.Abs(value);

        public static double Sign(this double value) => Math.Sign(value);

        public static int Clamp(this int value, int minInclusive, int maxInclusive)
        {
            if (value > maxInclusive)
            {
                return maxInclusive;
            }

            return value < minInclusive ? minInclusive : value;
        }

        /// <summary>
        /// Used for effectively making a loop for the number, so that if it goes below min it wraps around back to max, and if it goes above max it wraps around back to min.
        /// </summary>
        public static int CapRange(this int value, int max, int min = 0)
        {
            if (max < min)
            {
                throw new ArgumentException($"{nameof(max)} must be greater than or equal to {nameof(min)}");
            }

            if (min == max)
            {
                return min;
            }

            var diff = max - min + 1;

            while (value < min)
            {
                value += diff;
            }

            while (value > max)
            {
                value -= diff;
            }

            return value;
        }

        /// <summary>
        /// This is usefully disctinct from Math.Pow because it uses integers.
        /// </summary>
        public static int ToThePowerOf(this int @base, int exponent)
        {
            if (exponent < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(exponent), "must be at least 0");
            }
            
            switch (exponent)
            {
                case 0:
                    return 1;
                case 1:
                    return @base;
            }

            var result = @base;
            for (var i = 1; i < exponent; i++)
            {
                result *= @base;
            }

            return result;
        }
        
        public static string ConvertSeconds(this int time)
        {
            var minutes = time / 60;
            var minutesText = "";

            var seconds = time % 60;
            var secondsText = "";

            if (minutes > 0)
            {
                minutesText = minutes + " minute" + (minutes > 1 ? "s " : " ");
            }

            if (seconds > 0)
            {
                secondsText = seconds + " second" + (seconds > 1 ? "s " : " ");
            }

            return (minutesText + secondsText)[..((minutesText + secondsText).Length - 1)];
        }
    }
}