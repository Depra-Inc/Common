using System;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="float"/> extensions.
    /// </summary>
    public static class FloatExtensions
    {
        public static float Clamp(this float value, float minInclusive, float maxInclusive)
        {
            if (value > maxInclusive)
            {
                return maxInclusive;
            }

            return value < minInclusive ? minInclusive : value;
        }

        public static bool IsBetween(this float value, float minInclusive, float maxInclusive) =>
            !(value < minInclusive) && !(value > maxInclusive);

        public static bool IsPrettyCloseTo(this float number1, float number2, float margin = 0.01f) =>
            Math.Abs(number1 - number2) <= margin;

        /// <summary>
        /// Used for effectively making a loop for a float, so that if it goes below zero it wraps around back to max, and if it goes above max it wraps around back to zero. </p>
        /// A common use is keeping degree floats between 0 and 360.
        /// </summary>
        public static float CapRange(this float value, float max)
        {
            // This is distinct from using modulus because it prevents negative values.
            while (value < 0)
            {
                value += max;
            }

            while (value > max)
            {
                value -= max;
            }

            return value;
        }

        /// <summary>
        /// In addition to the nicer syntax, this is significantly faster than Math.Pow
        /// because it doesn't have to account for fractional or negative exponents.
        /// </summary>
        public static float ToThePowerOf(this float @base, int exponent)
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
    }
}