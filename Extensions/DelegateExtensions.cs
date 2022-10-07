using System;
using System.Collections.Generic;
using System.Linq;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="Delegate"/> extensions.
    /// </summary>
    public static class DelegateExtensions
    {
        /// <summary>
        /// Gets the function to get the value by specific value.
        /// </summary>
        /// <param name="self">The self variable to get by function.</param>
        /// <typeparam name="T">Type of variable.</typeparam>
        /// <returns>Function to get variable.</returns>
        public static Func<T> Get<T>(this T self) => () => self;

        /// <summary>
        /// Gets the value by the function.
        /// </summary>
        /// <param name="self">Function to get the value</param>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <returns>Specific value by function without arguments</returns>
        public static T Value<T>(this Func<T> self) => self.Invoke();

        /// <summary>
        /// Converts Func to Comparison.
        /// </summary>
        /// <param name="func">Func to convert.</param>
        /// <typeparam name="T">Type to compare.</typeparam>
        /// <returns>Func converted to Comparison.</returns>
        public static Comparison<T> ToComparison<T>(this Func<T, int> func) =>
            (left, right) => func.Invoke(right) - func.Invoke(left);

        /// <summary>
        /// Converts Predicate to Func.
        /// </summary>
        /// <param name="predicate">Predicate to convert.</param>
        /// <typeparam name="T">Type to predicate.</typeparam>
        /// <returns>Predicate converted to Func.</returns>
        public static Func<T, bool> ToFunc<T>(this Predicate<T> predicate) => predicate as Func<T, bool>;

        /// <summary>
        /// Converts Func to Predicate.
        /// </summary>
        /// <param name="func">Func to convert.</param>
        /// <typeparam name="T">Type to predicate.</typeparam>
        /// <returns>Func converted to Predicate.</returns>
        public static Predicate<T> ToPredicate<T>(this Func<T, bool> func) => func as Predicate<T>;

        public static Func<T, bool> Any<T>(this IEnumerable<Func<T, bool>> predicates) =>
            subject => predicates.Any(value => value.Invoke(subject));
    }
}