using System;
using System.Collections.Generic;

namespace Depra.Common.Extensions
{
    public static class NumericHelper
    {
        private static readonly HashSet<Type> NUMERIC_TYPES = new HashSet<Type>();

        static NumericHelper()
        {
            NUMERIC_TYPES.Add(typeof(byte));
            NUMERIC_TYPES.Add(typeof(sbyte));
            NUMERIC_TYPES.Add(typeof(ushort));
            NUMERIC_TYPES.Add(typeof(uint));
            NUMERIC_TYPES.Add(typeof(ulong));
            NUMERIC_TYPES.Add(typeof(short));
            NUMERIC_TYPES.Add(typeof(int));
            NUMERIC_TYPES.Add(typeof(long));
            NUMERIC_TYPES.Add(typeof(decimal));
            NUMERIC_TYPES.Add(typeof(double));
            NUMERIC_TYPES.Add(typeof(float));
        }

        internal static bool NumericCheckUsingHashSet(Type type) => NUMERIC_TYPES.Contains(type);

        internal static bool NumericCheckUsingSwitch(Type type)
        {
            return Type.GetTypeCode(type) switch
            {
                TypeCode.Byte => true,
                TypeCode.SByte => true,
                TypeCode.UInt16 => true,
                TypeCode.UInt32 => true,
                TypeCode.UInt64 => true,
                TypeCode.Int16 => true,
                TypeCode.Int32 => true,
                TypeCode.Int64 => true,
                TypeCode.Decimal => true,
                TypeCode.Double => true,
                TypeCode.Single => true,
                _ => false
            };
        }

        public static void AddCustomNumericType<T>(this T _)
            where T : IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable =>
            NUMERIC_TYPES.Add(typeof(T));

        public static bool TryAddCustomNumeric<T>(T input)
        {
            Type type;
            if (input == null)
            {
                type = Nullable.GetUnderlyingType(typeof(T));
                if (type is null) return false;
            }
            else
            {
                type = input.GetType();
            }

            if (NUMERIC_TYPES.Contains(type))
            {
                return true;
            }

            var interfaces = type.GetInterfaces();
            var count = 0;

            for (var i = 0; i < interfaces.Length; i++)
            {
                switch (interfaces[i])
                {
                    case IComparable _:
                    case IComparable<T> _:
                    case IConvertible _:
                    case IEquatable<T> _:
                    case IFormattable _:
                        count++;
                        break;
                    default: continue;
                }
            }

            if (count != 5)
            {
                return false;
            }

            NUMERIC_TYPES.Add(type);
            return true;
        }

        public static bool TryAddCustomNumericType<T>(Type type)
        {
            if (type is null)
            {
                return false;
            }

            if (NUMERIC_TYPES.Contains(type))
            {
                return true;
            }

            var interfaces = type.GetInterfaces();
            var count = 0;

            for (var i = 0; i < interfaces.Length; i++)
            {
                switch (interfaces[i])
                {
                    case IComparable _:
                    case IComparable<T> _:
                    case IConvertible _:
                    case IEquatable<T> _:
                    case IFormattable _:
                        count++;
                        break;
                    default: continue;
                }
            }

            if (count != 5)
            {
                return false;
            }

            NUMERIC_TYPES.Add(type);
            return true;
        }
    }
}