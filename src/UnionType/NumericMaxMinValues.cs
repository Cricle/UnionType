using System;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace UnionType
{
    public readonly struct NumericMaxMinValues : ITypeMaxMinValues<BigInteger>, ITypeMaxMinValues
    {
        public static readonly NumericMaxMinValues Byte = new NumericMaxMinValues(sizeof(byte), false);
        public static readonly NumericMaxMinValues SByte = new NumericMaxMinValues(sizeof(byte), true);
        public static readonly NumericMaxMinValues Char = new NumericMaxMinValues(sizeof(char), false);
        public static readonly NumericMaxMinValues Short = new NumericMaxMinValues(sizeof(short), true);
        public static readonly NumericMaxMinValues UShort = new NumericMaxMinValues(sizeof(short), false);
        public static readonly NumericMaxMinValues Int = new NumericMaxMinValues(sizeof(int), true);
        public static readonly NumericMaxMinValues UInt = new NumericMaxMinValues(sizeof(int), false);
        public static readonly NumericMaxMinValues Long = new NumericMaxMinValues(sizeof(long), true);
        public static readonly NumericMaxMinValues ULong = new NumericMaxMinValues(sizeof(long), false);

        public BigInteger MinValue { get; }

        public BigInteger MaxValue { get; }


        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;

        public NumericMaxMinValues(int byteSize, bool sign)
        {
            var size = ((byteSize * 8) + (sign ? -1 : 0));
            if (!sign)
            {
                MinValue = 0;
            }
            else
            {
                MinValue = -new BigInteger(Math.Pow(2, size));
            }
            MaxValue = new BigInteger(Math.Pow(2, size)) - 1;

        }

        public NumericMaxMinValues(BigInteger minValue, BigInteger maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
        public override int GetHashCode()
        {
            return MinValue.GetHashCode() ^ MaxValue.GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            var val = (NumericMaxMinValues)obj;
            return val.MaxValue == MaxValue &&
                val.MinValue == MinValue;
        }
        public override string ToString()
        {
            return $"{{Max:{MaxValue}, Min:{MinValue}}}";
        }

        public static bool operator ==(NumericMaxMinValues a, NumericMaxMinValues b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(NumericMaxMinValues a, NumericMaxMinValues b)
        {
            return !a.Equals(b);
        }

        public static NumericMaxMinValues operator *(NumericMaxMinValues a, BigInteger b)
        {
            return new NumericMaxMinValues(a.MinValue*b, a.MaxValue*b);
        }
        public static NumericMaxMinValues operator /(NumericMaxMinValues a, BigInteger b)
        {
            return new NumericMaxMinValues(a.MinValue/b,a.MaxValue/b);
        }
        public static NumericMaxMinValues operator +(NumericMaxMinValues a, BigInteger b)
        {
            return new NumericMaxMinValues(a.MinValue+b, a.MaxValue + b);
        }
        public static NumericMaxMinValues operator -(NumericMaxMinValues a, BigInteger b)
        {
            return new NumericMaxMinValues(a.MinValue-b, a.MaxValue-b);
        }
        public static NumericMaxMinValues operator %(NumericMaxMinValues a, BigInteger b)
        {
            return new NumericMaxMinValues(a.MinValue % b, a.MaxValue % b);
        }
        public static NumericMaxMinValues operator -(NumericMaxMinValues a)
        {
            return new NumericMaxMinValues(-a.MinValue, -a.MaxValue);
        }
        public static NumericMaxMinValues operator +(NumericMaxMinValues a)
        {
            return new NumericMaxMinValues(+a.MinValue, +a.MaxValue);
        }
        public static NumericMaxMinValues operator &(NumericMaxMinValues a, BigInteger b)
        {
            return new NumericMaxMinValues(a.MinValue & b, a.MaxValue & b);
        }
        public static NumericMaxMinValues operator |(NumericMaxMinValues a, BigInteger b)
        {
            return new NumericMaxMinValues(a.MinValue | b, a.MaxValue | b);
        }
        public static NumericMaxMinValues operator ^(NumericMaxMinValues a, BigInteger b)
        {
            return new NumericMaxMinValues(a.MinValue ^ b, a.MaxValue ^ b);
        }
    }
}
