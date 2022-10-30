using System;
using System.Numerics;

namespace UnionType
{
    public readonly struct BooleanMaxMinValues : ITypeMaxMinValues<bool>, ITypeMaxMinValues, IWithinRangeable<bool, bool>,IWithinRangeable<BigInteger, BigInteger>
    {
        public static readonly BooleanMaxMinValues Value = new BooleanMaxMinValues(false, true);
        public static readonly NumericMaxMinValues Numeric = new NumericMaxMinValues(0, 1);

        public BooleanMaxMinValues(bool minValue, bool maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public bool MinValue { get; }

        public bool MaxValue { get; }

        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;

        public override int GetHashCode()
        {
            return HashCode.Combine(MaxValue, MinValue);
        }
        public override bool Equals(object? obj)
        {
            if (obj is BooleanMaxMinValues val)
            {
                return val.MaxValue == MaxValue &&
                    val.MinValue == MinValue;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{{Max:{MaxValue}, Min:{MinValue}}}";
        }

        public bool IsIn(bool value, in ValueIsInOptions<bool> options = default)
        {
            return value == MinValue || value == MaxValue;
        }
        public bool IsIn(BigInteger value, in ValueIsInOptions<BigInteger> options = default)
        {
            BigInteger dvalue = value;
            BigInteger left = new BigInteger(MinValue ? 1 : 0);
            BigInteger right = new BigInteger(MaxValue ? 1 : 0);
            if (options.Zoom != default)
            {
                left *= options.Zoom;
                right *= options.Zoom;
            }
            return (options.MinNotEquals ? left < dvalue : left <= dvalue) && (options.MaxNotEquals ? right > dvalue : right >= dvalue);
        }

        public static bool operator ==(BooleanMaxMinValues a, BooleanMaxMinValues b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(BooleanMaxMinValues a, BooleanMaxMinValues b)
        {
            return !a.Equals(b);
        }
    }
}
