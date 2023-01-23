using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Common.System.Equality;
using static Depra.Common.Guards.Guard;

namespace Depra.Common.Extensions.Collections
{
    /// <summary>
    /// Represents extension-methods for <see cref="IEnumerable{T}"/>.
    /// </summary>
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

        /// <summary>
        /// Returns the second element of the sequence.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <typeparam name="T">Type of elements in sequence.</typeparam>
        /// <returns>Second element of the sequence.</returns>
        /// <exception cref="InvalidOperationException">Sequence is empty or contains one element.</exception>
        public static T Second<T>(this IEnumerable<T> self) => self.Skip(1).First();

        /// <summary>
        /// Returns the previous element to <paramref name="item"/>. 
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="item">Item, the previous one to which will be returned.</param>
        /// <typeparam name="T">Type of elements in sequence.</typeparam>
        /// <returns>The previous to <paramref name="item"/>.</returns>
        public static T PreviousTo<T>(this IEnumerable<T> self, T item)
        {
            var previous = default(T);

            foreach (var element in self)
            {
                if (EqualityComparer<T>.Default.Equals(element, item))
                {
                    return previous;
                }

                previous = element;
            }

            return previous;
        }

        /// <summary>
        /// Returns the next element to <paramref name="item"/>. 
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="item">Item, the next one to which will be returned.</param>
        /// <typeparam name="T">Type of elements in sequence.</typeparam>
        /// <returns>The next to <paramref name="item"/>.</returns>
        public static T NextTo<T>(this IEnumerable<T> self, T item)
        {
            var @return = false;

            foreach (var element in self)
            {
                if (EqualityComparer<T>.Default.Equals(element, item))
                {
                    @return = true;
                    continue;
                }

                if (@return)
                {
                    return element;
                }
            }

            return default;
        }

        /// <summary>
        /// Returns empty if enumerable is null else same enumerable.
        /// </summary>
        public static IEnumerable<T> EmptyIfDefault<T>(this IEnumerable<T> self) => self.OrEmpty();

        public static bool ContainsAll<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB) =>
            enumerableB.All(enumerableA.Contains);

        public static bool ContainsAny<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB) =>
            enumerableA.Intersect(enumerableB).Any();

        public static bool ElementsAreEqual<T>(this IEnumerable<T> enumerableA, IEnumerable<T> enumerableB) =>
            enumerableA.Except(enumerableB).Any() == false;

        /// <summary>
        /// Performs some action on each element of <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of element in <see cref="IEnumerable{T}"/>.</typeparam>
        /// <param name="self">This object.</param>
        /// <param name="do">Action, that will be performed on each element of <see cref="IEnumerable{T}"/>.</param>
        /// <returns>Source <see cref="IEnumerable{T}"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="self"/> is <code>null</code>.</exception>
        public static IEnumerable<T> Each<T>(this IEnumerable<T> self, Action<T> @do)
        {
            Ensure(self).NotNull();

            return Iterator();

            IEnumerable<T> Iterator()
            {
                foreach (var item in self)
                {
                    @do(item);
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Performs some action on each element of <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">Type of element in <see cref="IEnumerable{T}"/>.</typeparam>
        /// <param name="self">This object.</param>
        /// <param name="do">Action, that will be performed on each element of <see cref="IEnumerable{T}"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="self"/> is null.</exception>
        public static void ForEach<T>(this IEnumerable<T> self, Action<T> @do)
        {
            Ensure(self).NotNull();

            foreach (var element in self)
            {
                @do?.Invoke(element);
            }
        }

        /// <summary>
        /// Takes first object from <see cref="IEnumerable{T}"/> that has minimum value, provided by <paramref name="selector"/>.
        /// </summary>
        /// <typeparam name="T">Type of elements in <see cref="IEnumerable{T}"/></typeparam>
        /// <typeparam name="TMin">Type of <see cref="IComparable{T}"/> element, that will be used for search.</typeparam>
        /// <param name="self">This object.</param>
        /// <param name="selector">Selector of <see cref="IComparable{T}"/> elements, that will be used for search.</param>
        /// <returns>First object, that has minimum value, provided by <paramref name="selector"/>.</returns>
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
        /// <typeparam name="T">Type of elements in <see cref="IEnumerable{T}"/></typeparam>
        /// <typeparam name="TMax">Type of <see cref="IComparable{T}"/> element, that will be used for search.</typeparam>
        /// <param name="self">This object.</param>
        /// <param name="selector">Selector of <see cref="IComparable{T}"/> elements, that will be used for search.</param>
        /// <returns>First object, that has maximum value, provided by <paramref name="selector"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="self"/> is <code>null</code>.</exception>
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

        /// <summary>
        /// Produces the set difference of two sequences by using specified comparer function to compare values.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">
        /// An <see cref="IEnumerable{T}"/> whose elements that also occur in the first sequence
        /// will cause those elements to be removed from the returned sequence.
        /// </param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values.</param>
        /// <typeparam name="T">Type of elements in sequence.</typeparam>
        /// <returns>A sequence that contains the set difference of the elements of two sequences.</returns>
        public static IEnumerable<T> Except<T>(this IEnumerable<T> self, IEnumerable<T> other,
            Func<T, T, bool> comparer) => self.Except(other, new FuncEqualityComparer<T>(comparer));

        /// <summary>
        /// Returns distinct elements from a sequence by using specified comparer function to compare values.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare values.</param>
        /// <typeparam name="T">Type of elements in sequence.</typeparam>
        /// <returns>An <see cref="IEnumerable{T}"/> that contains distinct elements from the source sequence.</returns>
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> self, Func<T, T, bool> comparer) =>
            self.Distinct(new FuncEqualityComparer<T>(comparer));

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