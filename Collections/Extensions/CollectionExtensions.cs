using System.Collections.Generic;

namespace Depra.Common.Collections.Extensions
{
    /// <summary>
    /// <see cref="ICollection{T}"/> extensions.
    /// </summary>
    public static class CollectionExtensions
    {
        public static T AddTo<T>(this T self, ICollection<T> collection)
        {
            collection.Add(self);
            return self;
        }

        public static bool IsOneOf<T>(this T self, ICollection<T> collection) => collection.Contains(self);
    }
}