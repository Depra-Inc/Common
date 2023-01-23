using System;
using System.Collections.Generic;
using System.Linq;
using static Depra.Common.Guards.Guard;

namespace Depra.Common.Extensions.Reflection
{
    public static partial class TypeExtensions
    {
        public readonly struct EnumType
        {
            private readonly List<(string Name, object Value)> _values;

            public EnumType(Type type)
            {
                Ensure(type.IsEnum);

                var underlying = type.GetEnumUnderlyingType();

                Underlying = underlying;

                _values = type
                    .GetEnumValues()
                    .Cast<object>()
                    .Select(x => (x.ToString(), Convert.ChangeType(x, underlying)))
                    .ToList();
            }

            public Type Underlying { get; }

            public IReadOnlyList<(string Name, object Value)> Values => _values;
        }
    }
}