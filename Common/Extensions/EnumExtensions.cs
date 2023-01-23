using System;
using System.ComponentModel;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// Represents extension-methods for <see cref="Enum"/>.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Extension method of getting the Description self to string.
        /// </summary>
        /// <param name="self"></param>
        public static string Description(this Enum self)
        {
            var field = self.GetType().GetField(self.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0
                ? ((DescriptionAttribute)attributes[0]).Description
                : string.Empty;
        }
    }
}