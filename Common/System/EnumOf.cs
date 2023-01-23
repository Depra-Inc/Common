using System;

namespace Depra.Common.System
{
    /// <summary>
    /// Represents static methods related to <see cref="Enum"/> of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Type of <see cref="Enum"/>.</typeparam>
    public static class EnumOf<T> where T : struct
    {
        /// <summary>
        /// Array of <see cref="Enum"/> values.
        /// </summary>
        public static readonly T[] Values = (T[])Enum.GetValues(typeof(T));

        /// <summary>
        /// Converts <see cref="string"/> to <see cref="Enum"/> value in safe way.
        /// </summary>
        /// <param name="text"><see cref="string"/> representation of value.</param>
        /// <returns>
        /// <see cref="Enum"/> value if <paramref name="text"/> represented correct value of <typeparamref name="T"/> nulL otherwise.
        /// </returns>
        public static T? From(string text) => Enum.TryParse<T>(text, out var value) ? value : (T?)null;
    }
}