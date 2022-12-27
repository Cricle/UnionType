using System;
using System.Runtime.CompilerServices;

namespace UnionType
{
    public static class UnionValueCreator<T>
    {
        public static readonly uint Size = (uint)Unsafe.SizeOf<T>();

        public static readonly UnionValueType Type;

        static UnionValueCreator()
        {
            if (typeof(T) == typeof(TimeSpan))
            {
                Type = UnionValueType.TimeSpan;
            }
            else if (typeof(T) == typeof(Guid))
            {
                Type = UnionValueType.Guid;
            }
            else if (typeof(T) == typeof(IntPtr))
            {
                Type = UnionValueType.IntPtr;
            }
            else if (typeof(T) == typeof(bool))
            {
                Type = UnionValueType.Boolean;
            }
            else if (typeof(T) == typeof(char))
            {
                Type = UnionValueType.Char;
            }
            else if (typeof(T) == typeof(byte))
            {
                Type = UnionValueType.Byte;
            }
            else if (typeof(T) == typeof(sbyte))
            {
                Type = UnionValueType.SByte;
            }
            else if (typeof(T) == typeof(short))
            {
                Type = UnionValueType.Int16;
            }
            else if (typeof(T) == typeof(ushort))
            {
                Type = UnionValueType.UInt16;
            }
            else if (typeof(T) == typeof(int))
            {
                Type = UnionValueType.Int32;
            }
            else if (typeof(T) == typeof(uint))
            {
                Type = UnionValueType.UInt32;
            }
            else if (typeof(T) == typeof(long))
            {
                Type = UnionValueType.Int64;
            }
            else if (typeof(T) == typeof(ulong))
            {
                Type = UnionValueType.UInt64;
            }
            else if (typeof(T) == typeof(float))
            {
                Type = UnionValueType.Single;
            }
            else if (typeof(T) == typeof(double))
            {
                Type = UnionValueType.Double;
            }
            else if (typeof(T) == typeof(decimal))
            {
                Type = UnionValueType.Decimal;
            }
            else if (typeof(T) == typeof(DBNull))
            {
                Type = UnionValueType.DBNull;
            }
            else if (typeof(T) == typeof(string))
            {
                Type = UnionValueType.String;
            }
            else if (typeof(T) == typeof(DateTime))
            {
                Type = UnionValueType.DateTime;
            }
            else
            {
                Type = UnionValueType.Object;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UnionValue Create(T value)
        {
            if (Type == UnionValueType.Object)
            {
                return new UnionValue { Object = value };
            }
            else if (Type == UnionValueType.String)
            {
                return new UnionValue { String = (string?)(object?)value };
            }
            var v = new UnionValue { unionValueType = Type };
#pragma warning disable CS8500
            *(T*)&v = value;
#pragma warning restore CS8500
            return v;
        }
    }

}