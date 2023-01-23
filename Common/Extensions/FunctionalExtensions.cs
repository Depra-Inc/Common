using System;
using static Depra.Common.Guards.Guard;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// Represents extension-methods with functional style for generic types.
    /// </summary>
    public static partial class FunctionalExtensions
    {
        /// <summary>
        /// Represents specified object as object of other type using specified <paramref name="map"/> function.
        /// </summary>
        /// <param name="self"><code>this</code> object.</param>
        /// <param name="map">Function that maps <paramref name="self"/> to object of type <typeparamref name="TResult"/>.</param>
        /// <typeparam name="TInput">Type of object to be represented.</typeparam>
        /// <typeparam name="TResult">Type of result object that will represent <paramref name="self"/>.</typeparam>
        /// <returns>Representation of <paramref name="self"/> in <typeparamref name="TResult"/> type.</returns>
        public static TResult As<TInput, TResult>(this TInput self, Func<TInput, TResult> map)
        {
            Ensure(map).NotNull();
            return map(self);
        }

        /// <summary>
        /// Performs specified <see cref="Action"/> function on object and returns this object.
        /// </summary>
        /// <param name="self"><code>this</code> object.</param>
        /// <param name="apply">Function that will be applied on <paramref name="self"/> object.</param>
        /// <typeparam name="T">Type of <paramref name="self"/> object.</typeparam>
        /// <returns><code>this</code> object.</returns>
        public static T Do<T>(this T self, Action<T> apply)
        {
            apply?.Invoke(self);
            return self;
        }

        /// <summary>
        /// Uses the element and returns it.
        /// </summary>
        /// <param name="self">Self variable.</param>
        /// <param name="action">Action to execute with element.</param>
        /// <typeparam name="T">Type of self variable</typeparam>
        /// <returns>Same variable</returns>
        public static T Use<T>(this T self, Action<T> action)
        {
            action.Invoke(self);
            return self;
        }

        /// <summary>
        /// Gets the TOut in the TIn variable.
        /// </summary>
        /// <param name="self">Self variable</param>
        /// <param name="func">Func to get something</param>
        /// <typeparam name="TIn">Self variable type</typeparam>
        /// <typeparam name="TOut">Variable to get type</typeparam>
        /// <returns>Result of a Func</returns>
        public static TOut Get<TIn, TOut>(this TIn self, Func<TIn, TOut> func) => func.Invoke(self);

        /// <summary>
        /// Modifies a variable by func and returns it.
        /// </summary>
        /// <param name="self">Variable to modify</param>
        /// <param name="func">Func to modify</param>
        /// <typeparam name="T">Type of variable</typeparam>
        /// <returns>Same variable</returns>
        public static T Modify<T>(this T self, Func<T, T> func) => func.Invoke(self);

        public static T OrDefault<T>(this T self, T defaultValue) => self ?? defaultValue;

        public static TOut With<TIn, TOut>(this TIn self, Func<TIn, TOut> function, TOut failValue = null)
            where TIn : class
            where TOut : class
        {
            return self == null ? failValue : function(self);
        }

        public static TOut Try<TIn, TOut>(this TIn self, Func<TIn, TOut> function, TOut failValue = default)
            where TIn : class
        {
            if (self == null)
            {
                return failValue;
            }

            try
            {
                return function(self);
            }
            catch
            {
                return failValue;
            }
        }

        public static bool TryCast<TFrom, TTo>(this TFrom self, out TTo result)
        {
            if (self is TTo to)
            {
                result = to;
                return true;
            }

            result = default;
            return false;
        }

        public static T IfTrue<T>(this bool value, Func<T> action) => 
            value ? action() : default;

        public static T IfFalse<T>(this bool value, Func<T> action) => 
            value == false ? action() : default;

        public static T If<T>(this bool value, Func<T> actionIfTrue, Func<T> actionIfFalse) =>
            value ? actionIfTrue() : actionIfFalse();
    }
}