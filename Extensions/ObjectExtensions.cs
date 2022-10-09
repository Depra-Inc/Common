using System;

namespace Depra.Common.Extensions
{
    /// <summary>
    /// <see cref="object"/> extensions.
    /// </summary>
    public static class ObjectExtensions
    {
        public static bool IsNull(this object obj) => obj == null;

        public static bool NotNull(this object obj) => obj != null;

        public static bool IsDefault(this object obj) => obj.Equals(default);

        public static bool TryDoAsCasted<TCurrent, TCasted>(this TCurrent self, Action<TCasted> callback)
        {
            if (!(self is TCasted casted))
            {
                return false;
            }

            callback(casted);
            return true;
        }
    }
}