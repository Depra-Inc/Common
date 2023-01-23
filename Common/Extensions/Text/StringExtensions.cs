using System;
using System.Text;

namespace Depra.Common.Extensions.Text
{
    /// <summary>
    /// Represents extension-methods for <see cref="string"/>.
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Returns <paramref name="self"/> if <see cref="string"/> is null/empty/whitespace else same <see cref="string"/>.
        /// </summary>
        public static string Or(this string self, string @default)
            => self.IsNullOrWhiteSpace() ? @default : self;

        /// <summary>
        /// Returns empty if <see cref="string"/> is null/empty/whitespace else same <see cref="string"/>.
        /// </summary>
        public static string OrEmpty(this string self) => self.Or("");

        /// <summary>
        /// Returns null if <see cref="string"/> is null/empty else same <see cref="string"/>.
        /// </summary>
        public static string NullIfEmpty(this string self)
            => self.IsNullOrEmpty() == false ? self : null;

        /// <summary>
        /// Returns null if <see cref="string"/> is null/empty/whitespace else same <see cref="string"/>.
        /// </summary>
        public static string NullIfWhiteSpace(this string self)
            => self.IsNullOrWhiteSpace() == false ? self : null;

        public static int CountInstancesOf(this string source, string substring)
        {
            var removedInstancesLength = source.Replace(substring, string.Empty).Length;
            return (source.Length - removedInstancesLength) / substring.Length;
        }

        public static int CountInstancesOf(this string source, char @char)
        {
            var removedInstancesLength = source.Replace(@char.ToString(), string.Empty).Length;
            return source.Length - removedInstancesLength;
        }

        /// <summary>
        /// Like <see cref="string.Replace(string, string)"/> but it only replaces the first instance.
        /// </summary>
        public static string ReplaceFirst(this string text, string search, string replace, int startIndex = 0)
        {
            var index = text.IndexOf(search, startIndex);
            if (index < 0)
            {
                return text;
            }

            return text.Substring(0, index) + replace + text.Substring(index + search.Length);
        }

        /// <summary>
        /// Replace any characters from a list with a given character.
        /// </summary>
        public static string ReplaceAny(this string text, char[] search, char replace, int startIndex = 0)
        {
            var builder = new StringBuilder(text);
            builder.ReplaceAny(search, replace, startIndex);
            return builder.ToString();
        }

        /// <summary>
        /// Get a section of text.
        /// </summary>
        public static string Snip(this string text, int startIndex, int endIndex)
        {
            if (startIndex < 0)
            {
                throw new ArgumentException($"{nameof(startIndex)} must not be less than 0");
            }

            if (endIndex < 0)
            {
                throw new ArgumentException($"{nameof(endIndex)} must not be less than 0");
            }

            if (endIndex < startIndex)
            {
                throw new ArgumentException($"{nameof(endIndex)} must not be less than {nameof(startIndex)}");
            }

            if (startIndex >= text.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(startIndex)} is outside the range of the string!");
            }

            if (endIndex >= text.Length)
            {
                throw new ArgumentOutOfRangeException($"{nameof(endIndex)} is outside the range of the string!");
            }

            var length = endIndex - startIndex + 1;
            return text.Substring(startIndex, length);
        }

        public static bool Contains(this string self, char ch) => self.IndexOf(ch) != 1;

        public static bool ContainsAnyOf(this string self, params char[] chars)
        {
            foreach (var @char in chars)
            {
                if (self.Contains(@char))
                {
                    return true;
                }
            }

            return false;
        }
        

        public static string AllAfter(this string self, string part)
        {
            var index = self.IndexOf(part);
            return index == -1 ? self : self.Substring(index + part.Length);
        }
    }
}