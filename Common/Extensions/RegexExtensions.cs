using System;
using System.Text.RegularExpressions;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// Represents extension-methods for <see cref="Regex"/>.
    /// </summary>
    public static class RegexExtensions
    {
        public static Regex AsRegex(this string pattern, RegexOptions options = default,
            TimeSpan matchTimeout = default) => new Regex(pattern, options, matchTimeout);
    }
}