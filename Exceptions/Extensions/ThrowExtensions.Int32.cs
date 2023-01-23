using Depra.Common.Exceptions.Helpers;

namespace Depra.Common.Exceptions.Extensions
{
    public static partial class ThrowExtensions
    {
        /// <summary>
        /// Throws exception if <paramref name="x"/> is out of range.
        /// </summary>
        /// <param name="x">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <param name="minRange">Min range value.</param>
        /// <param name="maxRange">Max range value.</param>
        /// <returns>Input.</returns>
        public static int ThrowIfArgumentOutOfRange(this int x, string exMessage = "",
            int minRange = 0, int maxRange = int.MaxValue)
        {
            ExceptionHelper.ThrowIfArgumentOutOfRange(x < minRange || x > maxRange, exMessage);
            return x;
        }

        /// <summary>
        /// Throws exception if <paramref name="x"/> is out of range (uint).
        /// </summary>
        /// <param name="x">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <param name="minRange">Min range value.</param>
        /// <param name="maxRange">Max range value.</param>
        /// <returns>Input.</returns>
        public static uint ThrowIfArgumentOutOfRange(this uint x, string exMessage = "",
            uint minRange = 0, uint maxRange = uint.MaxValue)
        {
            ExceptionHelper.ThrowIfArgumentOutOfRange(x < minRange || x > maxRange, exMessage);
            return x;
        }
    }
}