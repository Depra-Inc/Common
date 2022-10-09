using System;

namespace Depra.Common.Extensions
{
    public static class GenericTypeExtensions
    {
        /// <summary>
        /// Determines if a <see cref="T"/> is numeric.
        /// </summary>
        /// <returns>Type is numeric.</returns>
        public static bool IsNumeric<T>(this T input) => IsNumericType(typeof(T));

        /// <summary>
        /// Determines if a <see cref="Type"/> is numeric.
        /// </summary>
        /// <param name="type">Object type.</param>
        /// <returns>Type is numeric.</returns>
        public static bool IsNumericType(this Type type) => NumericHelper.NumericCheckUsingHashSet(type);

        public static bool IsNumericAtRuntime<T>(this T input) =>
            input != null && NumericHelper.NumericCheckUsingHashSet(input.GetType());

        /// <summary>
        /// Identifies whether or not this object is a numeric or nullable numeric type.
        /// <para>Examples</para>
        /// <para />int value = 0; true
        /// <para />var objValue = (object)(int)0; true
        /// <para />int? value = 0; true
        /// <para />int? value = null; true
        /// <para />var objValue = (object)(int?)0; true
        /// <para />var objValue = (object)(int?)(null); false - because (int?) is totally lost.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNullableNumeric<T>(this T input) =>
            NumericHelper.NumericCheckUsingHashSet(input == null
                ? Nullable.GetUnderlyingType(typeof(T))
                : input.GetType());
    }
}