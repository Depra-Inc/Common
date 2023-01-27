using System.Collections.Generic;

namespace Depra.Common.Extensions.Collections
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Concatenates the members of a sequence, using specified <see cref="string"/> as separator.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="with">String that will be inserted between items of <paramref name="self"/>.</param>
        /// <typeparam name="T">Type of elements in sequence.</typeparam>
        /// <returns>Items of <paramref name="self"/> converted to string and separated with <paramref name="with"/>.</returns>
        public static string Separated<T>(this IEnumerable<T> self, string with) => string.Join(with, self);

        /// <summary>
        /// Concatenates the members of a sequence, using specified <see cref="string"/> as separator.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="with">String that will be inserted between items of <paramref name="self"/>.</param>
        /// <returns>Items of <paramref name="self"/> converted to string and separated with <paramref name="with"/>.</returns>
        public static string Separated(this IEnumerable<string> self, string with) => string.Join(with, self);
    }
}