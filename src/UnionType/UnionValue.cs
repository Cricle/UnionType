using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
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
        public static readonly int Size = 17;

        public static UnionValue Empty => new UnionValue();

        private static readonly IntPtr stringPtr;
        private static readonly byte[] EmptyBytes = Array.Empty<byte>();

        static UnionValue()
        {
            var n = string.Intern(typeof(string).AssemblyQualifiedName!);
            stringPtr = (IntPtr)GCHandle.Alloc(n, GCHandleType.Pinned);
        }

        [FieldOffset(0)]
        public bool @boolean;
        [FieldOffset(0)]
        public byte @byte;
        [FieldOffset(0)]
        public char @char;
        [FieldOffset(0)]
        public sbyte @sbyte;
        [FieldOffset(0)]
        public short @short;
        [FieldOffset(0)]
        public ushort @ushort;
        [FieldOffset(0)]
        public int @int;
        [FieldOffset(0)]
        public uint @uint;
        [FieldOffset(0)]
        public long @long;
        [FieldOffset(0)]
        public ulong @ulong;
        [FieldOffset(0)]
        public float @float;
        [FieldOffset(0)]
        public double @double;
        [FieldOffset(0)]
        public decimal @decimal;
        [FieldOffset(0)]
        public int @decimal_flags;
        [FieldOffset(4)]
        public uint @decimal_hi32;
        [FieldOffset(8)]
        public ulong @decimal_lo64;
        [FieldOffset(0)]
        public DateTime @dateTime;
        [FieldOffset(0)]
        public TimeSpan @timeSpan;
        [FieldOffset(0)]
        public Guid @guid;
        [FieldOffset(0)]//8L
        public IntPtr @intPtr;
        [FieldOffset(8)]//8L
        public IntPtr @typeName;
        [FieldOffset(16)]
        public UnionValueType unionValueType;

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
                if (@intPtr != IntPtr.Zero)
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
            set => unionValueType = value;
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
        public object? Object
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => GetObject();
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set => SetObject(value);
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
                if (typeName != IntPtr.Zero)
                {
                    GCHandle.FromIntPtr(typeName).Free();
                }
                if (value != null)
                {
                    typeName = (IntPtr)GCHandle.Alloc(value, GCHandleType.Weak);
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
                if (intPtr != IntPtr.Zero)
                {
                    GCHandle.FromIntPtr(intPtr).Free();
                }
                if (value != null)
                {
                    intPtr = (IntPtr)GCHandle.Alloc(value, GCHandleType.Weak);
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
                return new UnionValue { decimal_flags = SignMask, decimal_lo64 = (uint)i, unionValueType = UnionValueType.Decimal };
            }
            return new UnionValue { decimal_lo64 = (uint)i, unionValueType = UnionValueType.Decimal };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionValue FromAsDecimal(uint i)
        {
            return new UnionValue { decimal_lo64 = i, unionValueType = UnionValueType.Decimal };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionValue FromAsDecimal(long i)
        {
            if (i < 0)
            {
                i = -i;
                return new UnionValue { decimal_flags = SignMask, decimal_lo64 = (ulong)i, unionValueType = UnionValueType.Decimal };
            }
            return new UnionValue { decimal_lo64 = (ulong)i, unionValueType = UnionValueType.Decimal };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionValue FromAsDecimal(ulong i)
        {
            return new UnionValue { decimal_lo64 = i, unionValueType = UnionValueType.Decimal };
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UnionValue FromObject<T>(T input)
        {
            return UnionValueCreator<T>.Create(input);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int CleanNoUsed(ref UnionValue value)
        {
            var size = GetBitsSize(value.unionValueType);
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
                    return new UnionValue { Object= input };
                case TypeCode.DBNull:
                    return new UnionValue { UnionValueType = UnionValueType.DBNull };
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
                    return (string)input;
                default:
                    break;
            }
            throw new NotSupportedException(input.GetType().ToString());
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public byte[] ToUsedBytes()
        {
            var buffer = new byte[GetBitsSize(unionValueType)];
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
                var point = GCHandle.Alloc(value, GCHandleType.Weak);
                IntPtr = (IntPtr)point;
                TypeNameType = value!.GetType();
                unionValueType = UnionValueType.Object;
            }
        }

        public override int GetHashCode()
        {
            if (unionValueType== UnionValueType.String)
            {
                return String?.GetHashCode() ?? 0;
            }
            if (unionValueType == UnionValueType.Object)
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
                case UnionValueType.Object:
                    return GetObject()?.ToString();
                case UnionValueType.DBNull:
                    return "DBNull";
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
            if (other.unionValueType!=unionValueType)
            {
                return false;
            }
            if (unionValueType== UnionValueType.String)
            {
                return other.String == String;
            }
            else if (unionValueType== UnionValueType.Object)
            {
                if (other.Object==null&&Object==null)
                {
                    return true;
                }
                if (other.Object == null || Object == null)
                {
                    return false;
                }
                return other.Object.Equals(Object);
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
            return new UnionValue { UnionValueType = UnionValueType.DBNull };
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
            if (unionValueType == UnionValueType.Boolean)
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
            return Convert.ChangeType(Box(), conversionType, provider);
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
            if (b is IFormattable formattable)
            {
                return formattable.ToString(format, formatProvider);
            }
            throw new NotSupportedException("Must implement IFormattable");
        }

        public ITypeMaxMinValues? GetMaxMinValues()
        {
            return MaxMinValueHelper.GetMaxMinValues(unionValueType);
        }
        public IWithinRangeable<BigInteger,BigInteger>? GetBigIntegerWithin()
        {
            var val= MaxMinValueHelper.GetMaxMinValues(unionValueType);
            return val as IWithinRangeable<BigInteger, BigInteger>;
        }
        public BigInteger ToBigInteger()
        {
            return new BigInteger(ToDecimal(null));
        }

    }

}