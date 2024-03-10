using System;

namespace UnionType
{
    public class TypeInfo
    {
        public static readonly TypeInfo EmptyInfo = new TypeInfo(null);
        public static readonly TypeInfo DBNullInfo = new TypeInfo(typeof(DBNull));
        public static readonly TypeInfo BooleanInfo = new TypeInfo(typeof(bool));
        public static readonly TypeInfo CharInfo = new TypeInfo(typeof(char));
        public static readonly TypeInfo ByteInfo = new TypeInfo(typeof(byte));
        public static readonly TypeInfo SByteInfo = new TypeInfo(typeof(sbyte));
        public static readonly TypeInfo Int16Info = new TypeInfo(typeof(short));
        public static readonly TypeInfo UInt16Info = new TypeInfo(typeof(ushort));
        public static readonly TypeInfo Int32Info = new TypeInfo(typeof(int));
        public static readonly TypeInfo UInt32Info = new TypeInfo(typeof(uint));
        public static readonly TypeInfo Int64Info = new TypeInfo(typeof(long));
        public static readonly TypeInfo UInt64Info = new TypeInfo(typeof(ulong));
        public static readonly TypeInfo SingleInfo = new TypeInfo(typeof(float));
        public static readonly TypeInfo DoubleInfo = new TypeInfo(typeof(double));
        public static readonly TypeInfo DecimalInfo = new TypeInfo(typeof(decimal));
        public static readonly TypeInfo DateTimeInfo = new TypeInfo(typeof(DateTime));
        public static readonly TypeInfo TimeSpanInfo = new TypeInfo(typeof(TimeSpan));
        public static readonly TypeInfo IntPtrInfo = new TypeInfo(typeof(IntPtr));
        public static readonly TypeInfo UIntPtrInfo = new TypeInfo(typeof(UIntPtr));
        public static readonly TypeInfo GuidInfo = new TypeInfo(typeof(Guid));

        public static TypeInfo? GetTypeInfo(UnionValueType type)
        {
            switch (type)
            {
                case UnionValueType.Empty:
                    return EmptyInfo;
                case UnionValueType.DBNull:
                    return DBNullInfo;
                case UnionValueType.Boolean:
                    return BooleanInfo;
                case UnionValueType.Char:
                    return CharInfo;
                case UnionValueType.SByte:
                    return SByteInfo;
                case UnionValueType.Byte:
                    return ByteInfo;
                case UnionValueType.Int16:
                    return Int16Info;
                case UnionValueType.UInt16:
                    return UInt16Info;
                case UnionValueType.Int32:
                    return Int32Info;
                case UnionValueType.UInt32:
                    return UInt32Info;
                case UnionValueType.Int64:
                    return Int64Info;
                case UnionValueType.UInt64:
                    return UInt64Info;
                case UnionValueType.Single:
                    return SingleInfo;
                case UnionValueType.Double:
                    return DoubleInfo;
                case UnionValueType.Decimal:
                    return DecimalInfo;
                case UnionValueType.DateTime:
                    return DateTimeInfo;
                case UnionValueType.TimeSpan:
                    return TimeSpanInfo;
                case UnionValueType.IntPtr:
                    return IntPtrInfo;
                case UnionValueType.Guid:
                    return GuidInfo;
                case UnionValueType.UIntPtr:
                    return UIntPtrInfo;
                default:
                    return null;
            }
        }

        public TypeInfo(Type? type)
        {
            Type = type;
            if (type==null)
                TypeCode = UnionValueType.Empty;
            else if (type == typeof(DBNull))
                TypeCode = UnionValueType.DBNull;
            else if (type == typeof(bool))
                TypeCode = UnionValueType.Boolean;
            else if (type == typeof(char))
                TypeCode = UnionValueType.Char;
            else if (type == typeof(byte))
                TypeCode = UnionValueType.Byte;
            else if (type == typeof(sbyte))
                TypeCode = UnionValueType.SByte;
            else if (type == typeof(short))
                TypeCode = UnionValueType.Int16;
            else if (type == typeof(ushort))
                TypeCode = UnionValueType.UInt16;
            else if (type == typeof(int))
                TypeCode = UnionValueType.Int32;
            else if (type == typeof(uint))
                TypeCode = UnionValueType.UInt32;
            else if (type == typeof(long))
                TypeCode = UnionValueType.Int64;
            else if (type == typeof(ulong))
                TypeCode = UnionValueType.UInt64;
            else if (type == typeof(float))
                TypeCode = UnionValueType.Single;
            else if (type == typeof(double))
                TypeCode = UnionValueType.Double;
            else if (type == typeof(decimal))
                TypeCode = UnionValueType.Decimal;
            else if (type == typeof(DateTime))
                TypeCode = UnionValueType.DateTime;
            else if (type == typeof(TimeSpan))
                TypeCode = UnionValueType.TimeSpan;
            else if (type == typeof(IntPtr))
                TypeCode = UnionValueType.IntPtr;
            else if (type == typeof(UIntPtr))
                TypeCode = UnionValueType.UIntPtr;
            else if (type == typeof(Guid))
                TypeCode = UnionValueType.Guid;
        }

        public Type? Type { get; }

        public UnionValueType TypeCode { get; }
    }
    [Flags]
    public enum UnionValueType : int
    {
        Empty = TypeCode.Empty,
        Object = TypeCode.Object,
        DBNull = TypeCode.DBNull,
        Boolean = TypeCode.Boolean,
        Char = TypeCode.Char,
        SByte = TypeCode.SByte,
        Byte = TypeCode.Byte,
        Int16 = TypeCode.Int16,
        UInt16 = TypeCode.UInt16,
        Int32 = TypeCode.Int32,
        UInt32 = TypeCode.UInt32,
        Int64 = TypeCode.Int64,
        UInt64 = TypeCode.UInt64,
        Single = TypeCode.Single,
        Double = TypeCode.Double,
        Decimal = TypeCode.Decimal,
        DateTime = TypeCode.DateTime,
        String = TypeCode.String,

        TimeSpan = 100,
        IntPtr = TimeSpan + 1,
        Guid = TimeSpan + 2,
        UIntPtr = TimeSpan + 3,
    }
}