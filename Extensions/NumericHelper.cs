using System;
using System.Collections.Generic;

namespace Depra.Common.Extensions
{
    public static class NumericHelper
    {
        private static readonly HashSet<Type> NUMERIC_TYPES = new HashSet<Type>();

        internal static bool NumericCheckUsingHashSet(Type type) => NUMERIC_TYPES.Contains(type);

        internal static bool NumericCheckUsingSwitch(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
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
    }
}