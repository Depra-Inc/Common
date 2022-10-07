using System;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="double"/> extensions.
    /// </summary>
    public static class DoubleExtensions
    {
        /// <summary>
        /// In addition to the nicer syntax, this is significantly faster than Math.Pow
        /// because it doesn't have to account for fractional or negative exponents.
        /// </summary>
        public static double ToThePowerOf(this double @base, int exponent)
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