namespace Depra.Common.Extensions
{
    /// <summary>
    /// Represents extension-methods for <see cref="bool"/>.
    /// </summary>
    public static class BoolExtensions
    {
        /// <summary>
        /// Converts bool to int.
        /// </summary>
        /// <param name="self">Bool to convert</param>
        /// <returns>1 if self is true and 0 otherwise</returns>
        public static int Sign(this bool self) => self ? 1 : 0;

        /// <summary>
        /// Inverse the boolean.
        /// </summary>
        /// <param name="self">Boolean to inverse</param>
        /// <returns>True if self is false and false otherwise</returns>
        public static bool Inversed(this bool self) => !self;

        /// <summary>
        /// Applies logical <code>&&</code> operator for both <paramref name="self"/> and <paramref name="other"/> values.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">Second operand of logical operation.</param>
        /// <returns>Result of <code>&&</code> operator applied to <paramref name="self"/> and <paramref name="other"/>.</returns>
        public static bool And(this bool self, bool other) => self && other;

        /// <summary>
        /// Applies logical <code>||</code> operator for both <paramref name="self"/> and <paramref name="other"/> values.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">Second operand of logical operation.</param>
        /// <returns><paramref name="self"/> || <paramref name="other"/>.</returns>
        public static bool Or(this bool self, bool other) => self || other;

        /// <summary>
        /// Applies logical <code>||</code> operator for both <paramref name="self"/> and <paramref name="other"/> values.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">Second operand of logical operation.</param>
        /// <returns>True if one of booleans is true and other is false and false otherwise</returns>
        public static bool Xor(this bool self, bool other) => self ^ other;
        
        /// <summary>
        /// Applies logical implication operator for both <paramref name="self"/> and <paramref name="other"/> values.
        /// </summary>
        /// <param name="self">This object.</param>
        /// <param name="other">Second operand of logical operation.</param>
        /// <returns>If <paramref name="self"/> is true, then <paramref name="other"/>, otherwise true.</returns>
        public static bool Implication(this bool self, bool other) => !self || other;
    }
}