namespace Depra.Common.Extensions.Text
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Checks whether <paramref name="self"/> is null or empty <see cref="string"/>.
        /// </summary>
        public static bool IsNullOrEmpty(this string self) => string.IsNullOrEmpty(self);

        /// <summary>
        /// Checks whether <paramref name="self"/> is null or empty <see cref="string"/>.
        /// </summary>
        public static bool IsNullOrEmpty(this string self, bool trimSpaces)
        {
            if (self == null)
            {
                return true;
            }

            return trimSpaces == false ? self.Length == 0 : self.Trim().Length == 0;
        }

        /// <summary>
        /// Checks whether <paramref name="self"/> is null, empty or only whitespaces.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string self)
            => string.IsNullOrWhiteSpace(self);

        /// <summary>
        /// Checks whether <paramref name="self"/> is not null and not empty.
        /// </summary>
        public static bool IsNotNullAndNotEmpty(this string self)
            => string.IsNullOrEmpty(self) == false;

        /// <summary>
        /// Checks whether <paramref name="self"/> is not null, not empty, and not only whitespaces.
        /// </summary>
        public static bool IsNotNullAndNotWhiteSpace(this string self)
            => string.IsNullOrWhiteSpace(self) == false;
        
        public static bool IsNumber(this string self)
        {
            foreach (var @char in self)
            {
                if (char.IsDigit(@char) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}