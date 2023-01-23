using System;

namespace Depra.Common.Extensions
{
    public static partial class FunctionalExtensions
    {
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

        public static T IfNull<TObj, T>(this TObj value, Func<T> action) where TObj : class =>
            EqualityExtensions.IsNull(value) ? action() : default;

        public static T IfNotNull<TObj, T>(this TObj value, Func<T> action) where TObj : class =>
            value.NotNull() ? action() : default;

        public static T IfNull<TObj, T>(this TObj value, Func<T> actionIfNull, Func<T> actionIfNotNull)
            where TObj : class => EqualityExtensions.IsNull(value) ? actionIfNull() : actionIfNotNull();

        public static T IfNotNull<TObj, T>(this TObj value, Func<T> actionIfNotNull, Func<T> actionIfNull)
            where TObj : class => value.NotNull() ? actionIfNotNull() : actionIfNull();

        public static T IfNull<TObj, T>(this TObj? value, Func<T> action) where TObj : struct =>
            EqualityExtensions.IsNull(value) ? action() : default;

        public static T IfNotNull<TObj, T>(this TObj? value, Func<T> action) where TObj : struct =>
            value.NotNull() ? action() : default;

        public static T IfNull<TObj, T>(this TObj? value, Func<T> actionIfNull, Func<T> actionIfNotNull)
            where TObj : struct => EqualityExtensions.IsNull(value) ? actionIfNull() : actionIfNotNull();

        public static T IfNotNull<TObj, T>(this TObj? value, Func<T> actionIfNotNull, Func<T> actionIfNull)
            where TObj : struct => value.NotNull() ? actionIfNotNull() : actionIfNull();
    }
}