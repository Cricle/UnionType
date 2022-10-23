using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnionType
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct UnionValue : IEquatable<UnionValue>, ICloneable, IComparable, IConvertible, IFormattable
    {
        public static readonly int Size = sizeof(UnionValue);

        private static readonly IntPtr stringPtr;
        private static readonly byte[] EmptyBytes = Array.Empty<byte>();

        static UnionValue()
        {
            var n = typeof(string).AssemblyQualifiedName;
            stringPtr = (IntPtr)GCHandle.Alloc(n, GCHandleType.Pinned);
        }

        [FieldOffset(0)]
        private bool @boolean;
        [FieldOffset(0)]
        private byte @byte;
        [FieldOffset(0)]
        private char @char;
        [FieldOffset(0)]
        private sbyte @sbyte;
        [FieldOffset(0)]
        private short @short;
        [FieldOffset(0)]
        private ushort @ushort;
        [FieldOffset(0)]
        private int @int;
        [FieldOffset(0)]
        private uint @uint;
        [FieldOffset(0)]
        private long @long;
        [FieldOffset(0)]
        private ulong @ulong;
        [FieldOffset(0)]
        private float @float;
        [FieldOffset(0)]
        private double @double;
        [FieldOffset(0)]
        private decimal @decimal;
        [FieldOffset(0)]
        private DateTime @dateTime;
        [FieldOffset(0)]
        private TimeSpan @timeSpan;
        [FieldOffset(0)]
        private Guid @guid;
        [FieldOffset(0)]//8L
        private IntPtr @intPtr;
        [FieldOffset(8)]//8L
        private IntPtr @typeName;
        [FieldOffset(16)]
        private UnionValueType unionValueType;

        public Guid Guid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @guid;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @guid = value;
                unionValueType = UnionValueType.Guid;
            }
        }
        public bool Boolean
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @boolean;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @boolean = value;
                unionValueType = UnionValueType.Boolean;
            }
        }
        public byte Byte
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @byte;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @byte = value;
                unionValueType = UnionValueType.Byte;
            }
        }
        public sbyte SByte
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @sbyte;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @sbyte = value;
                unionValueType = UnionValueType.SByte;
            }
        }
        public char Char
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @char;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @char = value;
                unionValueType = UnionValueType.Char;
            }
        }
        public short Short
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @short;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @short = value;
                unionValueType = UnionValueType.Int16;
            }
        }
        public ushort UShort
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @ushort;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @ushort = value;
                unionValueType = UnionValueType.UInt16;
            }
        }
        public int Int
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @int;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @int = value;
                unionValueType = UnionValueType.Int32;
            }
        }
        public uint UInt
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @uint;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @uint = value;
                unionValueType = UnionValueType.UInt32;
            }
        }
        public long Long
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @long;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @long = value;
                unionValueType = UnionValueType.Int64;
            }
        }
        public ulong ULong
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @ulong;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @ulong = value;
                unionValueType = UnionValueType.UInt64;
            }
        }
        public float Float
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @float;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @float = value;
                unionValueType = UnionValueType.Single;
            }
        }
        public double Double
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @double;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @double = value;
                unionValueType = UnionValueType.Double;
            }
        }
        public decimal Decimal
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @decimal;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @decimal = value;
                unionValueType = UnionValueType.Decimal;
            }
        }
        public DateTime DateTime
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => dateTime;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                dateTime = value;
                unionValueType = UnionValueType.DateTime;
            }
        }
        public IntPtr IntPtr
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @intPtr;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (@intPtr!=IntPtr.Zero)
                {
                    GCHandle.FromIntPtr(@intPtr).Free();
                }
                @intPtr = value;
                unionValueType = UnionValueType.IntPtr;
            }
        }
        public UnionValueType UnionValueType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => unionValueType;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set=> unionValueType = value;
        }
        public TypeCode TypeCode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (TypeCode)unionValueType;
        }
        public IntPtr TypeName
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => typeName;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => typeName = value;
        }
        public Type? TypeNameType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var name = TypeNameString;
                if (string.IsNullOrEmpty(name))
                {
                    return null;
                }
                return Type.GetType(name, false);
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                TypeNameString = value?.AssemblyQualifiedName;
            }
        }
        public string? TypeNameString
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (typeName == IntPtr.Zero)
                {
                    return null;
                }
                return (string?)GCHandle.FromIntPtr(typeName).Target;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (typeName!=IntPtr.Zero)
                {
                    GCHandle.FromIntPtr(typeName).Free();
                }
                if (value!=null)
                {
                    typeName = (IntPtr)GCHandle.Alloc(value);
                }
                else
                {
                    typeName = IntPtr.Zero;
                }
            }
        }
        public string? String
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (IntPtr == IntPtr.Zero)
                {
                    return null;
                }
                return (string?)GCHandle.FromIntPtr(IntPtr).Target;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (intPtr!=IntPtr.Zero)
                {
                    GCHandle.FromIntPtr(intPtr).Free();
                }
                if (value != null)
                {
                    intPtr = (IntPtr)GCHandle.Alloc(value);
                }
                else
                {
                    intPtr = IntPtr.Zero;
                }
                unionValueType = UnionValueType.String;
                @typeName = stringPtr;
            }
        }
        public TimeSpan TimeSpan
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => timeSpan;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                timeSpan = value;
                unionValueType = UnionValueType.TimeSpan;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetTypeCode(TypeCode code)
        {
            unionValueType = (UnionValueType)code;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe static UnionValue FromBytes(byte[] buffer)
        {
            var val = default(UnionValue);
            fixed (byte* ptr = buffer)
                Unsafe.Copy(ref val, ptr);
            return val;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] ToBytes()
        {
            var buffer = new byte[Size];
            ToBytes(buffer);
            return buffer;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void ToBytes(byte[] buffer)
        {
            fixed (void* ptr = buffer)
            {
                ToBytes(ptr);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void ToBytes(void* buffer)
        {
            Unsafe.Copy(buffer, ref this);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T? GetObject<T>()
        {
            return (T?)GetObject();
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object? GetObject()
        {
            return GCHandle.FromIntPtr(IntPtr).Target;
        }
        public void SetObject(object? value)
        {
            if (value == null)
            {
                unionValueType = UnionValueType.Empty;
                intPtr = IntPtr.Zero;
                typeName = IntPtr.Zero;
            }
            else
            {
                var point = GCHandle.Alloc(value);
                IntPtr = (IntPtr)point;
                TypeNameType = value!.GetType();
                unionValueType = UnionValueType.Object;
            }
        }

        public override int GetHashCode()
        {
            var buffer = stackalloc byte[Size];
            ToBytes(buffer);
            var hc = new HashCode();
            for (int i = 0; i < Size; i++)
            {
                hc.Add(*(buffer + i));
            }
            return hc.ToHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is UnionValue value)
            {
                return Equals(value);
            }
            return false;
        }

        public override string? ToString()
        {
            switch (UnionValueType)
            {
                case UnionValueType.Empty:
                    return "(null)";
                case UnionValueType.Object:
                    return intPtr.ToString("X");
                case UnionValueType.DBNull:
                    return DBNull.Value.ToString();
                case UnionValueType.DateTime:
                    return dateTime.ToString();
                case UnionValueType.TimeSpan:
                    return timeSpan.ToString();
                case UnionValueType.String:
                    return String;
                case UnionValueType.Char:
                    return @char.ToString();
                case UnionValueType.IntPtr:
                    return intPtr.ToString("X");
                case UnionValueType.Guid:
                    return guid.ToString();
                default:
                    {
                        if (IsNumeric())
                        {
                            var buffer = stackalloc byte[Size];
                            ToBytes(buffer);
                            var span = new Span<byte>(buffer, Size);
#if NETSTANDARD2_0
                            return BitConverter.ToInt64(span.ToArray(),Size).ToString();
#else
                            return BitConverter.ToInt64(span).ToString();
#endif
                        }
                        else
                        {
                            switch (UnionValueType)
                            {
                                case UnionValueType.Single:
                                    return Float.ToString();
                                case UnionValueType.Double:
                                    return Double.ToString();
                                case UnionValueType.Decimal:
                                    return Decimal.ToString();
                                default:
                                    return null;
                            }
                        }
                    }
            }
        }
        public bool IsFraction()
        {
            switch (UnionValueType)
            {
                case UnionValueType.Single:
                case UnionValueType.Double:
                case UnionValueType.Decimal:
                    return true;
                default:
                    return false;
            }
        }
        public bool IsNumeric()
        {
            switch (UnionValueType)
            {
                case UnionValueType.Boolean:
                case UnionValueType.Char:
                case UnionValueType.SByte:
                case UnionValueType.Byte:
                case UnionValueType.Int16:
                case UnionValueType.UInt16:
                case UnionValueType.Int32:
                case UnionValueType.UInt32:
                case UnionValueType.Int64:
                case UnionValueType.UInt64:
                    return true;
                default:
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(UnionValue other)
        {
            var leftBuffer = stackalloc byte[Size];
            var rightBuffer = stackalloc byte[Size];
            ToBytes(leftBuffer);
            other.ToBytes(rightBuffer);
            return new ReadOnlySpan<byte>(leftBuffer, Size).SequenceEqual(new ReadOnlySpan<byte>(rightBuffer, Size));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(UnionValue left, UnionValue right)
        {
            return left.Equals(right);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(UnionValue left, UnionValue right)
        {
            return !(left == right);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(Guid val)
        {
            return new UnionValue { Guid = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(bool val)
        {
            return new UnionValue { Boolean = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(char val)
        {
            return new UnionValue { Char = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(byte val)
        {
            return new UnionValue { Byte = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(sbyte val)
        {
            return new UnionValue { SByte = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(short val)
        {
            return new UnionValue { Short = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(ushort val)
        {
            return new UnionValue { UShort = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(int val)
        {
            return new UnionValue { Int = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(uint val)
        {
            return new UnionValue { UInt = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(long val)
        {
            return new UnionValue { Long = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(ulong val)
        {
            return new UnionValue { ULong = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(float val)
        {
            return new UnionValue { Float = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(double val)
        {
            return new UnionValue { Double = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(decimal val)
        {
            return new UnionValue { Decimal = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(DateTime val)
        {
            return new UnionValue { DateTime = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(TimeSpan val)
        {
            return new UnionValue { TimeSpan = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(DBNull val)
        {
            return new UnionValue { UnionValueType = UnionValueType.DBNull};
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(string val)
        {
            return new UnionValue { String = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(IntPtr val)
        {
            return new UnionValue { IntPtr = val };
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Guid(UnionValue val)
        {
            return val.Guid;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(UnionValue val)
        {
            return val.Boolean;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator char(UnionValue val)
        {
            return val.Char;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte(UnionValue val)
        {
            return val.Byte;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte(UnionValue val)
        {
            return val.SByte;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short(UnionValue val)
        {
            return val.Short;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort(UnionValue val)
        {
            return val.UShort;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(UnionValue val)
        {
            return val.Int;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint(UnionValue val)
        {
            return val.UInt;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long(UnionValue val)
        {
            return val.Long;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong(UnionValue val)
        {
            return val.ULong;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float(UnionValue val)
        {
            return val.Float;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double(UnionValue val)
        {
            return val.Double;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator decimal(UnionValue val)
        {
            return val.Decimal;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator DateTime(UnionValue val)
        {
            return val.DateTime;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator TimeSpan(UnionValue val)
        {
            return val.TimeSpan;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator DBNull(UnionValue val)
        {
            return DBNull.Value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator string?(UnionValue val)
        {
            return val.String;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator IntPtr(UnionValue val)
        {
            return val.IntPtr;
        }
        object ICloneable.Clone()
        {
            return Clone();
        }
        public UnionValue Clone()
        {
            return this;
        }

        public int CompareTo(object? obj)
        {
            var box = Box();
            var objBox = obj;
            if (obj is UnionValue uv)
            {
                objBox = uv.Box();
            }
            if (box is IComparable comparable)
            {
                return comparable.CompareTo(objBox);
            }
            throw new NotSupportedException("Type must implement IComparable");
        }
        public object? Box()
        {
            switch (unionValueType)
            {
                case UnionValueType.Empty:
                    return null;
                case UnionValueType.Object:
                    return GetObject();
                case UnionValueType.DBNull:
                    return DBNull.Value;
                case UnionValueType.Boolean:
                    return boolean;
                case UnionValueType.Char:
                    return @char;
                case UnionValueType.SByte:
                    return @sbyte;
                case UnionValueType.Byte:
                    return @byte;
                case UnionValueType.Int16:
                    return @short;
                case UnionValueType.UInt16:
                    return @ushort;
                case UnionValueType.Int32:
                    return @int;
                case UnionValueType.UInt32:
                    return @uint;
                case UnionValueType.Int64:
                    return @long;
                case UnionValueType.UInt64:
                    return @ulong;
                case UnionValueType.Single:
                    return @float;
                case UnionValueType.Double:
                    return @double;
                case UnionValueType.Decimal:
                    return @decimal;
                case UnionValueType.DateTime:
                    return dateTime;
                case UnionValueType.String:
                    return String;
                case UnionValueType.TimeSpan:
                    return timeSpan;
                case UnionValueType.IntPtr:
                    return intPtr;
                case UnionValueType.Guid:
                    return guid;
                default:
                    throw new NotSupportedException(UnionValueType.ToString());
            }
        }
        public TypeCode GetTypeCode()
        {
            return TypeCode;
        }

        public bool ToBoolean(IFormatProvider? provider)
        {
            if (unionValueType== UnionValueType.Boolean)
            {
                return Boolean;
            }
            return Convert.ToBoolean(Box(), provider);
        }

        public byte ToByte(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.Byte)
            {
                return Byte;
            }
            return Convert.ToByte(Box(), provider);
        }

        public char ToChar(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.Char)
            {
                return @char;
            }
            return Convert.ToChar(Box(), provider);
        }

        public DateTime ToDateTime(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.DateTime)
            {
                return dateTime;
            }
            return Convert.ToDateTime(Box(), provider);
        }

        public decimal ToDecimal(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.Decimal)
            {
                return @decimal;
            }
            return Convert.ToDecimal(Box(), provider);
        }

        public double ToDouble(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.Double)
            {
                return @double;
            }
            return Convert.ToDouble(Box(), provider);
        }

        public short ToInt16(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.Int16)
            {
                return @short;
            }
            return Convert.ToInt16(Box(), provider);
        }

        public int ToInt32(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.Int32)
            {
                return @int;
            }
            return Convert.ToInt32(Box(), provider);
        }

        public long ToInt64(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.Int64)
            {
                return @long;
            }
            return Convert.ToInt64(Box(), provider);
        }

        public sbyte ToSByte(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.SByte)
            {
                return @sbyte;
            }
            return Convert.ToSByte(Box(), provider);
        }

        public float ToSingle(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.Single)
            {
                return @float;
            }
            return Convert.ToSingle(Box(), provider);
        }

        public string ToString(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.String)
            {
                return String ?? string.Empty;
            }
            return Convert.ToString(Box(), provider) ?? string.Empty;
        }

        public object? ToType(Type conversionType, IFormatProvider? provider)
        {
            return Convert.ChangeType(Box(),conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.UInt16)
            {
                return @ushort;
            }
            return Convert.ToUInt16(Box(), provider);
        }

        public uint ToUInt32(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.UInt32)
            {
                return @uint;
            }
            return Convert.ToUInt32(Box(), provider);
        }

        public ulong ToUInt64(IFormatProvider? provider)
        {
            if (unionValueType == UnionValueType.UInt64)
            {
                return @ulong;
            }
            return Convert.ToUInt64(Box(), provider);
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var b = Box();
            if ( b is IFormattable formattable)
            {
                return formattable.ToString(format, formatProvider);
            }
            throw new NotSupportedException("Must implement IFormattable");
        }
    }
}