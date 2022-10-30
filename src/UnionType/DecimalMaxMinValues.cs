using System;
using System.Numerics;

namespace UnionType
{
    public readonly struct DecimalMaxMinValues : ITypeMaxMinValues<decimal>, ITypeMaxMinValues, IWithinRangeable<decimal,decimal>, IWithinRangeable<BigInteger, BigInteger>
    {
        public static readonly DecimalMaxMinValues Value = new DecimalMaxMinValues(decimal.MinValue, decimal.MaxValue);
        public static readonly NumericMaxMinValues Numeric = new NumericMaxMinValues(new BigInteger(decimal.MinValue), new BigInteger(decimal.MaxValue));

        public DecimalMaxMinValues(decimal minValue, decimal maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public decimal MinValue { get; }

        public decimal MaxValue { get; }

        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;

        public override int GetHashCode()
        {
            return HashCode.Combine(MaxValue, MinValue);
        }
        public override bool Equals(object? obj)
        {
            if (obj is DecimalMaxMinValues val)
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

        public bool IsIn(decimal value, in ValueIsInOptions<decimal> options = default)
        {
            var left = MinValue;
            var right = MaxValue;
            if (options.Zoom != default)
            {
                left *= options.Zoom;
                right *= options.Zoom;
            }
            return (options.MinNotEquals ? left < value : left <= value) && (options.MaxNotEquals ? right > value : right >= value);
        }
        public bool IsIn(BigInteger value, in ValueIsInOptions<BigInteger> options = default)
        {
            BigInteger dvalue = value;
            BigInteger left = new BigInteger(MinValue);
            BigInteger right = new BigInteger(MaxValue);
            if (options.Zoom != default)
            {
                left *= options.Zoom;
                right *= options.Zoom;
            }
            return (options.MinNotEquals ? left < dvalue : left <= dvalue) && (options.MaxNotEquals ? right > dvalue : right >= dvalue);
        }

        public static bool operator ==(DecimalMaxMinValues a, DecimalMaxMinValues b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(DecimalMaxMinValues a, DecimalMaxMinValues b)
        {
            return !a.Equals(b);
        }
    }
}
