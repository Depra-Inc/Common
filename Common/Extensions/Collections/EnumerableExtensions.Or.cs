using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Depra.Common.Extensions.Collections
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns specified value if source is null/empty/else same.
        /// <remarks>Possible multiple enumeration!</remarks>
        /// </summary>
        [SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
        public static IEnumerable<T> Or<T>(this IEnumerable<T> self, IEnumerable<T> or) =>
            self.IsNullOrEmpty() ? or : self;

        /// <summary>
        /// Returns <see cref="Enumerable.Empty{TResult}"/>, if this is null.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <typeparam name="T">Type of elements in <see cref="IEnumerable{T}"/>.</typeparam>
        /// <returns><see cref="Enumerable.Empty{T}"/> if this is null, otherwise returns this.</returns>
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> self) => self ?? Enumerable.Empty<T>();
    }
}