#if !NET7_0_OR_GREATER

using System;
using System.Collections.Generic;
using static Depra.Common.Guards.Guard;

namespace Depra.Common.Extensions.Collections
{
    public static partial class ListExtensions
    {
        /// <summary>
        /// Takes first object from <see cref="List{T}"/> that has minimum value, provided by <paramref name="selector"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in <see cref="List{T}"/></typeparam>
        /// <typeparam name="TMin">The type of <see cref="IComparable"/> element, that will be used for search.</typeparam>
        /// <param name="self">A list of values to determine the minimum value of.</param>
        /// <param name="selector">A function to extract the key for each element.</param>
        /// <returns>The value with the minimum key in the <see cref="List{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="self"/> is null.</exception>
        public static T MinBy<T, TMin>(this List<T> self, Func<T, TMin> selector) where TMin : IComparable<TMin>
        {
            Ensure(self).NotNull();
            Ensure(selector).NotNull();

            var min = self[0];

            for (var index = 0; index < self.Count; index++)
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
        /// Takes first object from <see cref="List{T}"/> that has maximum value, provided by <paramref name="selector"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in <see cref="List{T}"/></typeparam>
        /// <typeparam name="TMax">The type of <see cref="IComparable{T}"/> element, that will be used for search.</typeparam>
        /// <param name="self">A list of values to determine the maximum value of.</param>
        /// <param name="selector">Selector of <see cref="IComparable{T}"/> elements, that will be used for search.</param>
        /// <returns>First object, that has maximum value, provided by <paramref name="selector"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="self"/> is null.</exception>
        public static T MaxBy<T, TMax>(this List<T> self, Func<T, TMax> selector) where TMax : IComparable<TMax>
        {
            Ensure(self).NotNull();
            Ensure(selector).NotNull();

            var max = self[0];

            for (var index = 0; index < self.Count; index++)
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