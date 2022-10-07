using System.Collections.Generic;
using System.Linq;
using Depra.Common.Exceptions.Helpers;

namespace Depra.Common.Exceptions.Extensions
{
    /// <summary>
    /// Throw extensions.
    /// </summary>
    public static class ThrowExtensions
    {
        /// <summary>
        /// Throws exception if <paramref name="arg"/> is null.
        /// </summary>
        /// <param name="arg">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <returns>Input.</returns>
        public static T ThrowIfNull<T>(this T arg, string exMessage = "")
        {
            ExceptionHelper.ThrowIfNull(arg == null, exMessage);
            return arg;
        }

        /// <summary>
        /// Throws exception if <paramref name="arg"/> argument is null.
        /// </summary>
        /// <param name="arg">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <returns>Input.</returns>
        public static T ThrowIfArgumentNull<T>(this T arg, string exMessage = "")
        {
            ExceptionHelper.ThrowIfArgumentNull(arg == null, exMessage);
            return arg;
        }

        #region Collections

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
            foreach (var o in objects)
            {
                o.ThrowIfNull();
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
            foreach (var o in objects)
            {
                o.ThrowIfArgumentNull();
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

        #endregion

        #region Strings

        /// <summary>
        /// Throws exception if the string is null or empty.
        /// </summary>
        /// <param name="s">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <returns>Input.</returns>
        public static string ThrowIfNullOrEmpty(this string s, string exMessage = "")
        {
            ExceptionHelper.ThrowIfNull(s == null, exMessage);
            ExceptionHelper.ThrowIfEmpty(s.Length == 0, exMessage);
            return s;
        }

        /// <summary>
        /// Throws exception if the string argument is null or empty.
        /// </summary>
        /// <param name="s">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <returns>Input.</returns>
        public static string ThrowIfNullOrEmptyArgument(this string s, string exMessage = "")
        {
            ExceptionHelper.ThrowIfArgumentNull(s == null, exMessage);
            ExceptionHelper.ThrowIfEmpty(s.Length == 0, exMessage);
            return s;
        }

        /// <summary>
        /// Throws exception if the string is null or whitespace.
        /// </summary>
        /// <param name="s">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <returns>Input.</returns>
        public static string ThrowIfNullOrWhiteSpace(this string s, string exMessage = "")
        {
            ExceptionHelper.ThrowIfNull(s == null, exMessage);
            ExceptionHelper.ThrowIfEmpty(s.Trim().Length == 0, exMessage);
            return s;
        }

        /// <summary>
        /// Throws exception if the string argument is null or whitespace.
        /// </summary>
        /// <param name="s">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <returns>Input.</returns>
        public static string ThrowIfNullOrWhiteSpaceArgument(this string s, string exMessage = "")
        {
            ExceptionHelper.ThrowIfArgumentNull(s == null, exMessage);
            ExceptionHelper.ThrowIfEmpty(s.Trim().Length == 0, exMessage);
            return s;
        }

        #endregion

        #region Integer

        /// <summary>
        /// Throws exception if <paramref name="x"/> is out of range.
        /// </summary>
        /// <param name="x">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <param name="minRange">Min range value.</param>
        /// <param name="maxRange">Max range value.</param>
        /// <returns>Input.</returns>
        public static int ThrowIfArgumentOutOfRange(this int x, string exMessage = "",
            int minRange = 0, int maxRange = int.MaxValue)
        {
            ExceptionHelper.ThrowIfArgumentOutOfRange(x < minRange || x > maxRange, exMessage);
            return x;
        }

        /// <summary>
        /// Throws exception if <paramref name="x"/> is out of range (uint).
        /// </summary>
        /// <param name="x">Input.</param>
        /// <param name="exMessage">Exception message.</param>
        /// <param name="minRange">Min range value.</param>
        /// <param name="maxRange">Max range value.</param>
        /// <returns>Input.</returns>
        public static uint ThrowIfArgumentOutOfRange(this uint x, string exMessage = "",
            uint minRange = 0, uint maxRange = uint.MaxValue)
        {
            ExceptionHelper.ThrowIfArgumentOutOfRange(x < minRange || x > maxRange, exMessage);
            return x;
        }

        #endregion
    }
}