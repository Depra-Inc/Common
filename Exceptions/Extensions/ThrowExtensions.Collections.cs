using System.Collections.Generic;
using System.Linq;
using Depra.Common.Exceptions.Helpers;

namespace Depra.Common.Exceptions.Extensions
{
    public static partial class ThrowExtensions
    {
        public static IEnumerable<T> ThrowIfEmpty<T>(this IEnumerable<T> objects,
            string exMessage = "Collection is empty!")
        {
            ExceptionHelper.ThrowIfEmpty(objects.Any(), exMessage);
            return objects;
        }

        /// <summary>
        /// Throws exception if any of the <paramref name="objects"/> is null.
        /// </summary>
        /// <param name="objects">Input.</param>
        /// <returns>Input.</returns>
        public static IEnumerable<T> ThrowIfAnyNull<T>(this IEnumerable<T> objects)
        {
            foreach (var @object in objects)
            {
                @object.ThrowIfNull();
            }

            return objects;
        }

        /// <summary>
        /// Throws exception if any of the <paramref name="objects"/> arguments is null.
        /// </summary>
        /// <param name="objects">Input.</param>
        /// <returns>Input.</returns>
        public static IEnumerable<T> ThrowIfAnyArgumentNull<T>(this IEnumerable<T> objects)
        {
            foreach (var @object in objects)
            {
                @object.ThrowIfArgumentNull();
            }

            return objects;
        }

        /// <summary>
        /// Throws exception if any of the strings is null or empty.
        /// </summary>
        /// <remarks>Possible multiple enumeration!</remarks>
        /// <param name="strings">Input.</param>
        /// <returns>Input.</returns>
        public static IEnumerable<string> ThrowIfNullOrEmpty(this IEnumerable<string> strings)
        {
            foreach (var s in strings)
            {
                s.ThrowIfNullOrEmpty();
            }

            return strings;
        }

        /// <summary>
        /// Throws exception if any of the string arguments is null or empty.
        /// </summary>
        /// <remarks>Possible multiple enumeration!</remarks>
        /// <param name="strings">Input.</param>
        /// <returns>Input.</returns>
        public static IEnumerable<string> ThrowIfNullOrEmptyArgument(this IEnumerable<string> strings)
        {
            foreach (var s in strings)
            {
                s.ThrowIfNullOrEmptyArgument();
            }

            return strings;
        }
    }
}