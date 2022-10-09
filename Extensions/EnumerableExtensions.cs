using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="IEnumerable{T}"/> extensions.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns true if collection is null or empty.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
            => source == null || source.Any() == false;

        /// <summary>
        /// Returns specified value if source is null/empty/else same.
        /// <remarks>Possible multiple enumeration!</remarks>
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
        
        #region Async
        
        public static Task ParallelForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> funcBody, int maxDoP = 4)
        {
            async Task AwaitPartition(IEnumerator<T> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    {
                        await Task.Yield();
                        await funcBody(partition.Current).ConfigureAwait(false);
                    }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .AsParallel()
                    .Select(AwaitPartition));
        }

        public static Task ParallelForEachAsync<T1, T2>(this IEnumerable<T1> source, Func<T1, T2, Task> funcBody, T2 secondInput, int maxDoP = 4)
        {
            async Task AwaitPartition(IEnumerator<T1> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    {
                        await Task.Yield();
                        await funcBody(partition.Current, secondInput).ConfigureAwait(false);
                    }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .AsParallel()
                    .Select(AwaitPartition));
        }

        public static Task ParallelForEachAsync<T1, T2, T3>(this IEnumerable<T1> source, Func<T1, T2, T3, Task> funcBody, T2 secondInput, T3 thirdInput, int maxDoP = 4)
        {
            async Task AwaitPartition(IEnumerator<T1> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    {
                        await Task.Yield();
                        await funcBody(partition.Current, secondInput, thirdInput).ConfigureAwait(false);
                    }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .AsParallel()
                    .Select(AwaitPartition));
        }

        public static Task ParallelForEachAsync<T1, T2, T3, T4>(this IEnumerable<T1> source, Func<T1, T2, T3, T4, Task> funcBody, T2 secondInput, T3 thirdInput, T4 fourthInput, int maxDoP = 4)
        {
            async Task AwaitPartition(IEnumerator<T1> partition)
            {
                using (partition)
                {
                    while (partition.MoveNext())
                    {
                        await Task.Yield();
                        await funcBody(partition.Current, secondInput, thirdInput, fourthInput).ConfigureAwait(false);
                    }
                }
            }

            return Task.WhenAll(
                Partitioner
                    .Create(source)
                    .GetPartitions(maxDoP)
                    .AsParallel()
                    .Select(AwaitPartition));
        }
        
        #endregion
    }
}