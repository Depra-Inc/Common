using System;
using System.Text.RegularExpressions;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="Regex"/> extensions.
    /// </summary>
    public static class RegexExtensions
    {
        public static Regex CreateRegex(this string pattern, RegexOptions options = default,
            TimeSpan matchTimeout = default) => new Regex(pattern, options, matchTimeout);
    }
}