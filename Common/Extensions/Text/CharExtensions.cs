namespace Depra.Common.Extensions.Text
{
    /// <summary>
    /// Represents extension-methods for <see cref="char"/>.
    /// </summary>
    public static partial class CharExtensions
    {
        public static bool EqualsCaseInsensitive(this char self, char other) =>
            char.ToUpperInvariant(self) == char.ToUpperInvariant(other);
    }
}