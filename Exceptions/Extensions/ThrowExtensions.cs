using Depra.Common.Exceptions.Helpers;

namespace Depra.Common.Exceptions.Extensions
{
    /// <summary>
    /// Throw extensions.
    /// </summary>
    public static partial class ThrowExtensions
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
    }
}