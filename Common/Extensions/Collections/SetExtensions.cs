using System.Collections.Generic;

namespace Depra.Common.Extensions.Collections
{
    /// <summary>
    /// Represents extension-methods for <see cref="ISet{T}"/>.
    /// </summary>
    public static class SetExtensions
    {
        public static void Exclude<T>(this ISet<T> self, IEnumerable<T> items) => self.ExceptWith(items);
    }
}