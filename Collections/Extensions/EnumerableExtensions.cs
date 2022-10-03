using System;
using System.Collections.Generic;
using System.Linq;

namespace Depra.Common.Collections.Extensions
{
    /// <summary>
    /// <see cref="IEnumerable{T}"/> extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        #region Syntax

        /// <summary>
        /// Returns true if collection is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
            => source == null || source.Any() == false;

        /// <summary>
        /// Returns specified value if source is null/empty/else same.
        /// </summary>
        public static IEnumerable<T> Or<T>(this IEnumerable<T> source, IEnumerable<T> or) =>
            source.IsNullOrEmpty() ? or : source;

        /// <summary>
        /// Returns empty if enumerable is null else same enumerable.
        /// </summary>
        public static IEnumerable<T> OrEmpty<T>(this IEnumerable<T> source)
            => source ?? Enumerable.Empty<T>();

        /// <summary>
        /// Returns empty if enumerable is null else same enumerable.
        /// </summary>
        public static IEnumerable<T> EmptyIfDefault<T>(this IEnumerable<T> source) => source.OrEmpty();

        public static bool ContainsAll<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB) =>
            enumerableB.All(enumerableA.Contains);

        public static bool ContainsAny<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB) =>
            enumerableA.Intersect(enumerableB).Any();

        public static bool ElementsAreEqual<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB) =>
            enumerableA.Except(enumerableB).Any() == false;

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var element in enumerable)
            {
                action?.Invoke(element);
            }
        }

        #endregion

        #region Searching

        public static T2 FirstOfType<T1, T2>(this IEnumerable<T1> self)
        {
            T2 result = default;
            foreach (var item in self)
            {
                if (item is T2 t2)
                {
                    result = t2;
                }
            }

            return result;
        }

        public static bool TryGetFirstOfType<T1, T2>(this IEnumerable<T1> self, out T2 result)
        {
            result = self.FirstOfType<T1, T2>();
            return result != null;
        }

        #endregion

        public static IEnumerable<TOutput> Map<TInput, TOutput>(this IEnumerable<TInput> self,
            Func<TInput, TOutput> func)
        {
            foreach (var input in self)
            {
                yield return func(input);
            }
        }
        
        public static bool IsValid<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                return false;
            }

            var array = enumerable.ToArray();
            if (array.Length == 0)
            {
                return false;
            }

            var isValid = array.All(element => element != null);
            return isValid;
        }
    }
}