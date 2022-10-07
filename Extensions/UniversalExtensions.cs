using System;

namespace Depra.Common.Extensions
{
    public static class UniversalExtensions
    {
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

        public static T OrDefault<T>(this T self, T defaultValue)
        {
            if (self != null)
            {
                return self;
            }

            return defaultValue;
        }

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

        #region Null classes

        public static void IfNull<TObject>(this TObject value, Action action) where TObject : class
        {
            if (EqualityExtensions.IsNull(value))
            {
                action();
            }
        }

        public static void IfNotNull<TObject>(this TObject value, Action action) where TObject : class
        {
            if (value.NotNull())
            {
                action();
            }
        }

        public static void IfNull<TObject>(this TObject value, Action actionIfNull, Action actionIfNotNull)
            where TObject : class
        {
            if (EqualityExtensions.IsNull(value))
            {
                actionIfNull();
            }
            else
            {
                actionIfNotNull();
            }
        }

        #endregion

        #region Null nullables

        public static void IfNull<TObject>(this TObject? value, Action action) where TObject : struct
        {
            if (EqualityExtensions.IsNull(value))
            {
                action();
            }
        }

        public static void IfNotNull<TObject>(this TObject? value, Action action) where TObject : struct
        {
            if (value.NotNull())
            {
                action();
            }
        }

        public static void IfNull<TObject>(this TObject? value, Action actionIfNull, Action actionIfNotNull)
            where TObject : struct
        {
            if (EqualityExtensions.IsNull(value))
            {
                actionIfNull();
            }
            else
            {
                actionIfNotNull();
            }
        }

        public static void IfNotNull<TObject>(this TObject? value, Action actionIfNotNull, Action actionIfNull)
            where TObject : struct
        {
            if (value.NotNull())
            {
                actionIfNotNull();
            }
            else
            {
                actionIfNull();
            }
        }

        #endregion

        #region Funcs on true, false, null, notNull

        public static T IfTrue<T>(this bool value, Func<T> action) => value ? action() : default;

        public static T IfFalse<T>(this bool value, Func<T> action) => value == false ? action() : default;

        public static T If<T>(this bool value, Func<T> actionIfTrue, Func<T> actionIfFalse) =>
            value ? actionIfTrue() : actionIfFalse();

        // Null classes.

        public static T IfNull<TObj, T>(this TObj value, Func<T> action) where TObj : class =>
            EqualityExtensions.IsNull(value) ? action() : default;

        public static T IfNotNull<TObj, T>(this TObj value, Func<T> action) where TObj : class
        {
            return value.NotNull() ? action() : default;
        }

        public static T IfNull<TObj, T>(this TObj value, Func<T> actionIfNull, Func<T> actionIfNotNull)
            where TObj : class => EqualityExtensions.IsNull(value) ? actionIfNull() : actionIfNotNull();

        public static T IfNotNull<TObj, T>(this TObj value, Func<T> actionIfNotNull, Func<T> actionIfNull)
            where TObj : class => value.NotNull() ? actionIfNotNull() : actionIfNull();

        // Null Nullables.

        public static T IfNull<TObj, T>(this TObj? value, Func<T> action) where TObj : struct =>
            EqualityExtensions.IsNull(value) ? action() : default;

        public static T IfNotNull<TObj, T>(this TObj? value, Func<T> action) where TObj : struct =>
            value.NotNull() ? action() : default;

        public static T IfNull<TObj, T>(this TObj? value, Func<T> actionIfNull, Func<T> actionIfNotNull)
            where TObj : struct => EqualityExtensions.IsNull(value) ? actionIfNull() : actionIfNotNull();

        public static T IfNotNull<TObj, T>(this TObj? value, Func<T> actionIfNotNull, Func<T> actionIfNull)
            where TObj : struct => value.NotNull() ? actionIfNotNull() : actionIfNull();

        #endregion
    }
}