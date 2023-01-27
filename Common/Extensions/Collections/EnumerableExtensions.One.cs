using System;
using System.Collections.Generic;
using System.Linq;

namespace Depra.Common.Extensions.Collections
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition of <paramref name="predicate"/>.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="predicate">A function that represents a condition, which will be applied to elements of sequence.</param>
        /// <typeparam name="T">Type of elements in sequence.</typeparam>
        /// <returns>First element of the sequence that satisfies a condition.</returns>
        public static T One<T>(this IEnumerable<T> self, Func<T, bool> predicate) =>
            self.FirstOrDefault(predicate);

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition or throws exception with specified message.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="predicate">A function that represents a condition, which will be applied to elements of sequence.</param>
        /// <param name="orThrow">Message that will be used to throw exception if no element will satisfy a condition.</param>
        /// <typeparam name="T">Type of elements in sequence.</typeparam>
        /// <returns>First element of the sequence that satisfies a condition.</returns>
        /// <exception cref="InvalidOperationException">No element satisfies the condition in <paramref name="predicate"/>.</exception>
        public static T One<T>(this IEnumerable<T> self, Func<T, bool> predicate, string orThrow)
        {
            var item = self.One(predicate);
            if (item == null && orThrow != null)
            {
                throw new InvalidOperationException(orThrow);
            }

            return item;
        }
    }
}