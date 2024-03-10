using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnionType
{
    public static class UnionValueCreator<T>
    {
        public static readonly uint Size = (uint)Unsafe.SizeOf<T>();

        public static readonly TypeInfo? TypeInfo;

        static UnionValueCreator()
        {
            if (typeof(T) == typeof(TimeSpan))
            {
                TypeInfo = TypeInfo.TimeSpanInfo;
            }
            else if (typeof(T) == typeof(Guid))
            {
                TypeInfo = TypeInfo.GuidInfo;
            }
            else if (typeof(T) == typeof(IntPtr))
            {
                TypeInfo = TypeInfo.IntPtrInfo;
            }
            else if (typeof(T) == typeof(bool))
            {
                TypeInfo = TypeInfo.BooleanInfo;
            }
            else if (typeof(T) == typeof(char))
            {
                TypeInfo = TypeInfo.CharInfo;
            }
            else if (typeof(T) == typeof(byte))
            {
                TypeInfo = TypeInfo.ByteInfo;
            }
            else if (typeof(T) == typeof(sbyte))
            {
                TypeInfo = TypeInfo.SByteInfo;
            }
            else if (typeof(T) == typeof(short))
            {
                TypeInfo = TypeInfo.Int16Info;
            }
            else if (typeof(T) == typeof(ushort))
            {
                TypeInfo = TypeInfo.UInt16Info;
            }
            else if (typeof(T) == typeof(int))
            {
                TypeInfo = TypeInfo.Int32Info;
            }
            else if (typeof(T) == typeof(uint))
            {
                TypeInfo = TypeInfo.UInt32Info;
            }
            else if (typeof(T) == typeof(long))
            {
                TypeInfo = TypeInfo.Int64Info;
            }
            else if (typeof(T) == typeof(ulong))
            {
                TypeInfo = TypeInfo.UInt64Info;
            }
            else if (typeof(T) == typeof(float))
            {
                TypeInfo = TypeInfo.SingleInfo;
            }
            else if (typeof(T) == typeof(double))
            {
                TypeInfo = TypeInfo.DoubleInfo;
            }
            else if (typeof(T) == typeof(decimal))
            {
                TypeInfo = TypeInfo.DecimalInfo;
            }
            else if (typeof(T) == typeof(DBNull))
            {
                TypeInfo = TypeInfo.DBNullInfo;
            }
            else if (typeof(T) == typeof(DateTime))
            {
                TypeInfo = TypeInfo.DateTimeInfo;
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UnionValue Create(T value)
        {
            if (TypeInfo == null)
            {
                var uv = new UnionValue();
                uv.Object = value;
                return uv;
            }
            var v = new UnionValue { @object = TypeInfo };
#pragma warning disable CS8500
            *(T*)&v = value;
#pragma warning restore CS8500
            return v;
        }
    }

}