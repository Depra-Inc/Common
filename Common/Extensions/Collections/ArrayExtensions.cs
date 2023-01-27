#if !NET7_0_OR_GREATER

using System;
using static Depra.Common.Guards.Guard;

namespace Depra.Common.Extensions.Collections
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Takes first object from <see cref="Array"/> that has minimum value, provided by <paramref name="selector"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in <see cref="Array"/></typeparam>
        /// <typeparam name="TMin">The type of <see cref="IComparable"/> element, that will be used for search.</typeparam>
        /// <param name="self">A array of values to determine the minimum value of.</param>
        /// <param name="selector">A function to extract the key for each element.</param>
        /// <returns>The value with the minimum key in the <see cref="Array"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="self"/> is null.</exception>
        public static T MinBy<T, TMin>(this T[] self, Func<T, TMin> selector) where TMin : IComparable<TMin>
        {
            Ensure(self).NotNull();
            Ensure(selector).NotNull();

            var min = self[0];

            for (var index = 0; index < self.Length; index++)
            {
                var item = self[index];
                if (selector(item).CompareTo(selector(min)) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        /// <summary>
        /// Takes first object from <see cref="Array"/> that has maximum value, provided by <paramref name="selector"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in <see cref="Array"/></typeparam>
        /// <typeparam name="TMax">The type of <see cref="IComparable{T}"/> element, that will be used for search.</typeparam>
        /// <param name="self">A array of values to determine the maximum value of.</param>
        /// <param name="selector">Selector of <see cref="IComparable{T}"/> elements, that will be used for search.</param>
        /// <returns>First object, that has maximum value, provided by <paramref name="selector"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="self"/> is null.</exception>
        public static T MaxBy<T, TMax>(this T[] self, Func<T, TMax> selector) where TMax : IComparable<TMax>
        {
            Ensure(self).NotNull();
            Ensure(selector).NotNull();

            var max = self[0];

            for (var index = 0; index < self.Length; index++)
            {
                var item = self[index];
                if (selector(item).CompareTo(selector(max)) > 0)
                {
                    max = item;
                }
            }

            return max;
        }
    }
}

#endif