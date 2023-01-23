using System.Collections.Generic;
using System.Linq;

namespace Depra.Common.Extensions.Collections
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Returns true if collection is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> self) => self == null || self.IsEmpty();

        /// <summary>
        /// Checks whether <paramref name="self"/> contains no elements.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <typeparam name="T">Type of elements in sequence.</typeparam>
        /// <returns>True if <paramref name="self"/> is empty, otherwise — false.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> self)
        {
            switch (self)
            {
                case IList<T> list:
                    return list.Count == 0;
                case ICollection<T> collection:
                    return collection.Count == 0;
                default:
                    return self.Any() == false;
            }
        }

        public static bool IsValid<T>(this IEnumerable<T> self)
        {
            if (self == null)
            {
                return false;
            }

            var array = self.ToArray();
            if (array.Length == 0)
            {
                return false;
            }

            var isValid = array.All(element => element != null);
            return isValid;
        }
    }
}