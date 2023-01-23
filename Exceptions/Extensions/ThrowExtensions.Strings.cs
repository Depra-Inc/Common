using Depra.Common.Exceptions.Helpers;

namespace Depra.Common.Exceptions.Extensions
{
    public static partial class ThrowExtensions
    {
        /// <summary>
        /// Throws exception if the <see cref="string"/> is null or empty.
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
        /// Throws exception if the <see cref="string"/> argument is null or empty.
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
        /// Throws exception if the <see cref="string"/> is null or whitespace.
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
        /// Throws exception if the <see cref="string"/> argument is null or whitespace.
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
    }
}