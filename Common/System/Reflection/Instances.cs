using System;
using Depra.Common.Extensions.Reflection;

namespace Depra.Common.System.Reflection
{
    public static partial class Instances
    {
        public static AssemblyExpression<T> Of<T>() where T : class =>
            new AssemblyExpression<T>(x => Implements(x, typeof(T)) || Extends(x, typeof(T)));

        public static AssemblyExpression<T> ThatExtend<T>() where T : class =>
            new AssemblyExpression<T>(x => Implements(x, typeof(T)));

        public static AssemblyExpression<T> ThatImplement<T>() where T : class =>
            new AssemblyExpression<T>(x => Extends(x, typeof(T)));

        private static bool Implements(Type self, Type other)
        {
            if (other.IsInterface == false)
            {
                return false;
            }

            return other.IsConstructedGenericType
                ? self.Implements(other.GetGenericTypeDefinition())
                : self.Implements(other);
        }

        private static bool Extends(Type self, Type other)
        {
            if (other.IsClass == false)
            {
                return false;
            }

            return other.IsConstructedGenericType
                ? self.Extends(other.GetGenericTypeDefinition())
                : self.Extends(other);
        }
    }
}