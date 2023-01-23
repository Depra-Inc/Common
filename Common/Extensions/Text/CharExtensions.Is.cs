namespace Depra.Common.Extensions.Text
{
    public static partial class CharExtensions
    {
        /// <summary>
        /// Checks whether current instance is equal to some character.
        /// </summary>
        public static bool Is(this char self, char other) => self == other;

        /// <summary>
        /// Checks whether current instance is digit character.
        /// </summary>
        public static bool IsDigit(this char self) => char.IsDigit(self);

        /// <summary>
        /// Checks whether current instance is letter character.
        /// </summary>
        public static bool IsLetter(this char self) => char.IsLetter(self);

        /// <summary>
        /// Checks whether current instance is letter or digit character.
        /// </summary>
        public static bool IsLetterOrDigit(this char self) => char.IsLetterOrDigit(self);

        /// <summary>
        /// Checks whether current instance is whitespace character.
        /// </summary>
        public static bool IsWhitespace(this char self) => char.IsWhiteSpace(self);

        public static bool IsWhitespaceOrNonBreakingSpace(this char self) =>
            self.IsWhitespace() || self == '\u200B';
    }
}