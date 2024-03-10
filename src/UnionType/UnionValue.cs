using System;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnionType
{
    [Serializable]
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct UnionValue : IEquatable<UnionValue>, ICloneable, IComparable, IConvertible, IFormattable
    {
        public static readonly int Size = Unsafe.SizeOf<UnionValue>();

        public static UnionValue Empty => new UnionValue();

        private static readonly byte[] EmptyBytes = Array.Empty<byte>();

        [FieldOffset(0)]
        internal bool @boolean;
        [FieldOffset(0)]
        internal byte @byte;
        [FieldOffset(0)]
        internal char @char;
        [FieldOffset(0)]
        internal sbyte @sbyte;
        [FieldOffset(0)]
        internal short @short;
        [FieldOffset(0)]
        internal ushort @ushort;
        [FieldOffset(0)]
        internal int @int;
        [FieldOffset(0)]
        internal uint @uint;
        [FieldOffset(0)]
        internal long @long;
        [FieldOffset(0)]
        internal ulong @ulong;
        [FieldOffset(0)]
        internal float @float;
        [FieldOffset(0)]
        internal double @double;
        [FieldOffset(0)]
        internal decimal @decimal;
        [FieldOffset(0)]
        internal int @decimal_flags;
        [FieldOffset(4)]
        internal uint @decimal_hi32;
        [FieldOffset(8)]
        internal ulong @decimal_lo64;
        [FieldOffset(0)]
        internal DateTime @dateTime;
        [FieldOffset(0)]
        internal TimeSpan @timeSpan;
        [FieldOffset(0)]
        internal Guid @guid;
        [FieldOffset(0)]//8L
        internal IntPtr @intPtr;
        [FieldOffset(0)]//8L
        internal UIntPtr @uintPtr;
        [FieldOffset(16)]//8L
        internal object? @object;

        public Guid Guid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @guid;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @guid = value;
                @object = TypeInfo.GuidInfo;
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
                @object = TypeInfo.BooleanInfo;
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
                @object = TypeInfo.ByteInfo;
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
                @object = TypeInfo.SByteInfo;
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
                @object = TypeInfo.CharInfo;
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
                @object = TypeInfo.Int16Info;
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
                @object = TypeInfo.UInt16Info;
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
                @object = TypeInfo.Int32Info;
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
                @object = TypeInfo.UInt32Info;
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
                @object = TypeInfo.Int64Info;
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
                @object = TypeInfo.UInt64Info;
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
                @object = TypeInfo.SingleInfo;
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
                @object = TypeInfo.DoubleInfo;
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
                @object = TypeInfo.DecimalInfo;
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
                @object = TypeInfo.DateTimeInfo;
            }
        }
        public IntPtr IntPtr
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @intPtr;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @intPtr = value;
                @object = TypeInfo.IntPtrInfo;
            }
        }
        public UIntPtr UIntPtr
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @uintPtr;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                @uintPtr = value;
                @object = TypeInfo.UIntPtrInfo;
            }
        }
        public UnionValueType UnionValueType
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if (@object is TypeInfo type)
                {
                    return type.TypeCode;
                }
                else if (@object is string)
                {
                    return UnionValueType.String;
                }
                else if (@object is null)
                {
                    return UnionValueType.Empty;
                }
                return UnionValueType.Object;
            }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => @object = TypeInfo.GetTypeInfo(value);
        }
        public TypeCode TypeCode
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (TypeCode)UnionValueType;
        }
        public string? String
        {
            get => ToString();
            set => Object = value;
        }
        public object? Object
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => @object;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if (value == null)
                {
                    @object = TypeInfo.EmptyInfo;
                    return;
                }
                else if (value is DBNull)
                {
                    @object = TypeInfo.DBNullInfo;
                    return;
                }
                @object = value;
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
                @object = TypeInfo.TimeSpanInfo;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UnionValue FromBytes(byte[] buffer)
        {
            var val = new UnionValue();
            Unsafe.Copy(ref val, Unsafe.AsPointer(ref buffer[0]));
            return val;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe UnionValue FromBytes(ReadOnlySpan<byte> buffer)
        {
            var val = new UnionValue();
            fixed (byte* ptr = buffer)
            {
                Unsafe.Copy(ref val, ptr);
            }
            return val;
        }
        //https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Decimal.cs,79
        private const int SignMask = unchecked((int)0x80000000);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionValue FromAsDecimal(int i)
        {
            if (i < 0)
            {
                i = -i;
                return new UnionValue { decimal_flags = SignMask, decimal_lo64 = (uint)i, @object = TypeInfo.DecimalInfo };
            }
            return new UnionValue { decimal_lo64 = (uint)i, @object = TypeInfo.DecimalInfo };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionValue FromAsDecimal(uint i)
        {
            return new UnionValue { decimal_lo64 = i, @object = TypeInfo.DecimalInfo };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionValue FromAsDecimal(long i)
        {
            if (i < 0)
            {
                i = -i;
                return new UnionValue { decimal_flags = SignMask, decimal_lo64 = (ulong)i, @object = TypeInfo.DecimalInfo    };
            }
            return new UnionValue { decimal_lo64 = (ulong)i, @object = TypeInfo.DecimalInfo };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionValue FromAsDecimal(ulong i)
        {
            return new UnionValue { decimal_lo64 = i, @object = TypeInfo.DecimalInfo };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionValue FromObject<T>(T input)
            where T:class
        {
            return new UnionValue { Object = input };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CleanNoUsed(ref UnionValue value)
        {
            var size = GetBitsSize(value.UnionValueType);
            if (size != 16)
            {
                new Span<byte>(((byte*)value.ToPointer() + size), 17 - size - 1).Fill(0);
            }
            return 17 - size - 1;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetBitsSize(UnionValueType type)
        {
            switch (type)
            {
                case UnionValueType.Empty:
                    return 0;
                case UnionValueType.Object:
                case UnionValueType.String:
                case UnionValueType.IntPtr:
                case UnionValueType.DBNull:
                    return 16;
                case UnionValueType.Boolean:
                    return sizeof(bool);
                case UnionValueType.Char:
                    return sizeof(char);
                case UnionValueType.SByte:
                    return sizeof(sbyte);
                case UnionValueType.Byte:
                    return sizeof(byte);
                case UnionValueType.Int16:
                    return sizeof(short);
                case UnionValueType.UInt16:
                    return sizeof(ushort);
                case UnionValueType.Int32:
                    return sizeof(int);
                case UnionValueType.UInt32:
                    return sizeof(uint);
                case UnionValueType.Int64:
                    return sizeof(long);
                case UnionValueType.UInt64:
                    return sizeof(ulong);
                case UnionValueType.Single:
                    return sizeof(float);
                case UnionValueType.Double:
                    return sizeof(double);
                case UnionValueType.Decimal:
                    return sizeof(decimal);
                case UnionValueType.DateTime:
                    return sizeof(long);
                case UnionValueType.TimeSpan:
                    return sizeof(long);
                case UnionValueType.Guid:
                    return 16;
                default:
                    throw new NotSupportedException(type.ToString());
            }
        }
        public static unsafe UnionValue FromObject(object input)
        {
            if (input is TimeSpan ts)
            {
                return ts;
            }
            if (input is Guid gid)
            {
                return gid;
            }
            if (input is IntPtr ptr)
            {
                return ptr;
            }
            var typeCode = Convert.GetTypeCode(input);
            switch (typeCode)
            {
                case TypeCode.Empty:
                   return default;
                case TypeCode.Object:
                    {
                        var uv = new UnionValue();
                        uv.Object = input;
                        return uv;
                    }
                case TypeCode.DBNull:
                    return new UnionValue { @object = TypeInfo.DBNullInfo };
                case TypeCode.Boolean:
                    return (bool)input;
                case TypeCode.Char:
                    return (char)input;
                case TypeCode.SByte:
                    return (sbyte)input;
                case TypeCode.Byte:
                    return (byte)input;
                case TypeCode.Int16:
                    return (short)input;
                case TypeCode.UInt16:
                    return (ushort)input;
                case TypeCode.Int32:
                    return (int)input;
                case TypeCode.UInt32:
                    return (uint)input;
                case TypeCode.Int64:
                    return (long)input;
                case TypeCode.UInt64:
                    return (ulong)input;
                case TypeCode.Single:
                    return (float)input;
                case TypeCode.Double:
                    return (double)input;
                case TypeCode.Decimal:
                    return (decimal)input;
                case TypeCode.DateTime:
                    return (DateTime)input;
                case TypeCode.String:
                    {
                        var uv = new UnionValue();
                        uv.Object = input;
                        return uv;
                    }
                default:
                    break;
            }
            throw new NotSupportedException(input.GetType().ToString());
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] ToUsedBytes()
        {
            var buffer = new byte[GetBitsSize(UnionValueType)];
            ToBytes(buffer.AsSpan());
            return buffer;
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
        public void ToBytes(Span<byte> buffer)
        {
            new ReadOnlySpan<byte>(ToPointer(), buffer.Length).CopyTo(buffer);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<byte> AsSpan()
        {
            return new Span<byte>(ToPointer(), Size);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Span<T> AsSpan<T>()
            where T:unmanaged
        {
            return new Span<T>(ToPointer(), Size / sizeof(T));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref byte GetReference()
        {
            return ref Unsafe.AsRef<byte>(Unsafe.AsPointer(ref this));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ref T GetReference<T>()
        {
            return ref Unsafe.AsRef<T>(Unsafe.AsPointer(ref this));
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public unsafe void ToBytes(void* buffer)
        {
            Unsafe.Copy(buffer, ref this);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T? GetObject<T>()
        {
            return (T?)@object;
        }

        public override int GetHashCode()
        {
            if (UnionValueType == UnionValueType.Object||UnionValueType== UnionValueType.String)
            {
                return Object?.GetHashCode() ?? 0;
            }
            var hc = new HashCode();
            var ptr = (byte*)ToPointer();
#if NET6_0_OR_GREATER
            hc.AddBytes(new ReadOnlySpan<byte>(ptr, Size));
#else
            for (int i = 0; i < Size; i++)
            {
                hc.Add(*(ptr + i));
            }
#endif
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
                case UnionValueType.String:
                case UnionValueType.Object:
                    return @object?.ToString();
                case UnionValueType.DBNull:
                    return "DBNull";
                case UnionValueType.DateTime:
                    return dateTime.ToString();
                case UnionValueType.TimeSpan:
                    return timeSpan.ToString();
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
                            return BitConverter.ToInt64(span.ToArray(), 0).ToString();
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
            if (other.UnionValueType!=UnionValueType)
            {
                return false;
            }
            else if (UnionValueType== UnionValueType.Object||UnionValueType== UnionValueType.String)
            {
                return Equals(@object, other.@object);
            }
            return new ReadOnlySpan<byte>(ToPointer(), Size).SequenceEqual(new ReadOnlySpan<byte>(&other, Size));
        }
        public void* ToPointer()
        {
            return Unsafe.AsPointer(ref this);
        }
        public T* ToPointer<T>()
            where T:unmanaged
        {
            return (T*)Unsafe.AsPointer(ref this);
        }
        public static UnionValue operator +(UnionValue left, UnionValue right)
        {
            if (left.IsFraction() || right.IsFraction())
            {
                return left.ToDecimal(null) + right.ToDecimal(null);
            }
            return left.ToInt64(null) + right.ToInt64(null);
        }
        public static UnionValue operator -(UnionValue left, UnionValue right)
        {
            if (left.IsFraction() || right.IsFraction())
            {
                return left.ToDecimal(null) - right.ToDecimal(null);
            }
            return left.ToInt64(null) - right.ToInt64(null);
        }
        public static UnionValue operator *(UnionValue left, UnionValue right)
        {
            if (left.IsFraction() || right.IsFraction())
            {
                return left.ToDecimal(null) * right.ToDecimal(null);
            }
            return left.ToInt64(null) * right.ToInt64(null);
        }
        public static UnionValue operator /(UnionValue left, UnionValue right)
        {
            if (left.IsFraction() || right.IsFraction())
            {
                return left.ToDecimal(null) / right.ToDecimal(null);
            }
            return left.ToInt64(null) / right.ToInt64(null);
        }
        public static UnionValue operator %(UnionValue left, UnionValue right)
        {
            if (left.IsFraction() || right.IsFraction())
            {
                return left.ToDecimal(null) % right.ToDecimal(null);
            }
            return left.ToInt64(null) % right.ToInt64(null);
        }
        public static bool operator >(UnionValue left, UnionValue right)
        {
            if (left.IsFraction() || right.IsFraction())
            {
                return left.ToDecimal(null) > right.ToDecimal(null);
            }
            return left.ToInt64(null) > right.ToInt64(null);
        }
        public static bool operator <(UnionValue left, UnionValue right)
        {
            if (left.IsFraction() || right.IsFraction())
            {
                return left.ToDecimal(null) < right.ToDecimal(null);
            }
            return left.ToInt64(null) < right.ToInt64(null);
        }
        public static bool operator >=(UnionValue left, UnionValue right)
        {
            if (left.IsFraction() || right.IsFraction())
            {
                return left.ToDecimal(null) >= right.ToDecimal(null);
            }
            return left.ToInt64(null) >= right.ToInt64(null);
        }
        public static bool operator <=(UnionValue left, UnionValue right)
        {
            if (left.IsFraction() || right.IsFraction())
            {
                return left.ToDecimal(null) <= right.ToDecimal(null);
            }
            return left.ToInt64(null) <= right.ToInt64(null);
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
            return new UnionValue { @object = TypeInfo.DBNullInfo };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(string val)
        {
            return new UnionValue { Object = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator UnionValue(IntPtr val)
        {
            return new UnionValue { IntPtr = val };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator Guid(UnionValue val)
        {
            return val.@guid;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator bool(UnionValue val)
        {
            return val.@boolean;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator char(UnionValue val)
        {
            return val.@char;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator byte(UnionValue val)
        {
            return val.@byte;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator sbyte(UnionValue val)
        {
            return val.@sbyte;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator short(UnionValue val)
        {
            return val.@short;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ushort(UnionValue val)
        {
            return val.@ushort;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(UnionValue val)
        {
            return val.@int;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator uint(UnionValue val)
        {
            return val.@uint;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator long(UnionValue val)
        {
            return val.@long;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator ulong(UnionValue val)
        {
            return val.@ulong;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator float(UnionValue val)
        {
            return val.@float;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator double(UnionValue val)
        {
            return val.@double;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator decimal(UnionValue val)
        {
            return val.@decimal;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator DateTime(UnionValue val)
        {
            return val.@dateTime;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator TimeSpan(UnionValue val)
        {
            return val.@timeSpan;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator DBNull(UnionValue val)
        {
            return DBNull.Value;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator string?(UnionValue val)
        {
            return val.@object?.ToString();
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
            switch (UnionValueType)
            {
                case UnionValueType.Empty:
                    return null;
                case UnionValueType.String:
                case UnionValueType.Object:
                    return @object;
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
            if (UnionValueType == UnionValueType.Boolean)
            {
                return Boolean;
            }
            return Convert.ToBoolean(Box(), provider);
        }

        public byte ToByte(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.Byte)
            {
                return Byte;
            }
            return Convert.ToByte(Box(), provider);
        }

        public char ToChar(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.Char)
            {
                return @char;
            }
            return Convert.ToChar(Box(), provider);
        }

        public DateTime ToDateTime(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.DateTime)
            {
                return dateTime;
            }
            return Convert.ToDateTime(Box(), provider);
        }

        public decimal ToDecimal(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.Decimal)
            {
                return @decimal;
            }
            return Convert.ToDecimal(Box(), provider);
        }

        public double ToDouble(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.Double)
            {
                return @double;
            }
            return Convert.ToDouble(Box(), provider);
        }

        public short ToInt16(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.Int16)
            {
                return @short;
            }
            return Convert.ToInt16(Box(), provider);
        }

        public int ToInt32(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.Int32)
            {
                return @int;
            }
            return Convert.ToInt32(Box(), provider);
        }

        public long ToInt64(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.Int64)
            {
                return @long;
            }
            return Convert.ToInt64(Box(), provider);
        }

        public sbyte ToSByte(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.SByte)
            {
                return @sbyte;
            }
            return Convert.ToSByte(Box(), provider);
        }

        public float ToSingle(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.Single)
            {
                return @float;
            }
            return Convert.ToSingle(Box(), provider);
        }

        public string ToString(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.String)
            {
                return (string?)@object ?? string.Empty;
            }
            return Convert.ToString(Box(), provider) ?? string.Empty;
        }

        public object? ToType(Type conversionType, IFormatProvider? provider)
        {
            return Convert.ChangeType(Box(), conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.UInt16)
            {
                return @ushort;
            }
            return Convert.ToUInt16(Box(), provider);
        }

        public uint ToUInt32(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.UInt32)
            {
                return @uint;
            }
            return Convert.ToUInt32(Box(), provider);
        }

        public ulong ToUInt64(IFormatProvider? provider)
        {
            if (UnionValueType == UnionValueType.UInt64)
            {
                return @ulong;
            }
            return Convert.ToUInt64(Box(), provider);
        }

        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            var b = Box();
            if (b is IFormattable formattable)
            {
                return formattable.ToString(format, formatProvider);
            }
            throw new NotSupportedException("Must implement IFormattable");
        }

        public ITypeMaxMinValues? GetMaxMinValues()
        {
            return MaxMinValueHelper.GetMaxMinValues(UnionValueType);
        }
        public IWithinRangeable<BigInteger,BigInteger>? GetBigIntegerWithin()
        {
            var val= MaxMinValueHelper.GetMaxMinValues(UnionValueType);
            return val as IWithinRangeable<BigInteger, BigInteger>;
        }
        public BigInteger ToBigInteger()
        {
            return new BigInteger(ToDecimal(null));
        }
    }

}