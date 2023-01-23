using System;
using System.Reflection;

namespace Depra.Common.Extensions.Reflection
{
    /// <summary>
    /// Represents extension-methods for <see cref="MemberInfo"/>.
    /// </summary>
    public static class MemberInfoExtensions
    {
        public static bool Has<T>(this MemberInfo self, bool includingParents = true) where T : Attribute =>
            self.IsDefined(typeof(T), includingParents);

        public static T Attribute<T>(this MemberInfo self) where T : Attribute =>
            self.GetCustomAttribute<T>();
    }
}