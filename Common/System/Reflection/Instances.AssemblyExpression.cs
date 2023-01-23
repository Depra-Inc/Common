using System;
using System.Collections.Generic;
using System.Reflection;
using Depra.Common.Extensions.Reflection;

namespace Depra.Common.System.Reflection
{
    public static partial class Instances
    {
        public readonly struct AssemblyExpression<T>
        {
            private readonly Predicate<Type> _predicate;

            public AssemblyExpression(Predicate<Type> predicate) => _predicate = predicate;

            public List<T> InCurrentAssembly() => In(Assembly.GetCallingAssembly());

            public List<T> InOwnerAssembly() => In(Assembly.GetAssembly(typeof(T)));

            public List<T> In(Assembly assembly)
            {
                var all = new List<T>();

                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsAbstract)
                    {
                        continue;
                    }

                    if (type.IsGenericTypeDefinition && typeof(T).IsConstructedGenericType == false)
                    {
                        continue;
                    }

                    if (_predicate(type) == false)
                    {
                        continue;
                    }

                    all.Add(type.New<T>());
                }

                return all;
            }
        }
    }
}