#if !NET7_0_OR_GREATER

using System;
using System.Collections.Generic;
using static Depra.Common.Guards.Guard;

namespace Depra.Common.Extensions.Collections
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Takes first object from <see cref="IEnumerable{T}"/> that has minimum value, provided by <paramref name="selector"/>.
        /// </summary>
        /// <typeparam name="T">Type of elements in <see cref="IEnumerable{T}"/></typeparam>
        /// <typeparam name="TMin">Type of <see cref="IComparable{T}"/> element, that will be used for search.</typeparam>
        /// <param name="self">A sequence of values to determine the minimum value of.</param>
        /// <param name="selector">A function to extract the key for each element.</param>
        /// <returns>The value with the minimum key in the <see cref="IEnumerable{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="self"/> is null.</exception>
        public static T MinBy<T, TMin>(this IEnumerable<T> self, Func<T, TMin> selector) where TMin : IComparable<TMin>
        {
            Ensure(self).NotNull();
            Ensure(selector).NotNull();

            var min = default(T);
            var first = true;

            foreach (var item in self)
            {
                if (first)
                {
                    min = item;
                    first = false;
                }
                else if (selector(item).CompareTo(selector(min)) < 0)
                {
                    min = item;
                }
            }

            return min;
        }

        /// <summary>
        /// Takes first object from <see cref="IEnumerable{T}"/> that has maximum value, provided by <paramref name="selector"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in <see cref="IEnumerable{T}"/></typeparam>
        /// <typeparam name="TMax">The type of <see cref="IComparable{T}"/> element, that will be used for search.</typeparam>
        /// <param name="self">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">Selector of <see cref="IComparable{T}"/> elements, that will be used for search.</param>
        /// <returns>First object, that has maximum value, provided by <paramref name="selector"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="self"/> is null.</exception>
        public static T MaxBy<T, TMax>(this IEnumerable<T> self, Func<T, TMax> selector) where TMax : IComparable<TMax>
        {
            Ensure(self).NotNull();
            Ensure(selector).NotNull();

            var max = default(T);
            var first = true;

            foreach (var item in self)
            {
                if (first)
                {
                    max = item;
                    first = false;
                }
                else if (selector(item).CompareTo(selector(max)) > 0)
                {
                    max = item;
                }
            }

            return max;
        }
    }
}

#endif