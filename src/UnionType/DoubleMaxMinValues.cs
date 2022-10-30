using System;
using System.Numerics;

namespace UnionType
{
    public readonly struct DoubleMaxMinValues : ITypeMaxMinValues<double>, ITypeMaxMinValues, IWithinRangeable<double, double>,IWithinRangeable<BigInteger,BigInteger>
    {
        public static readonly DoubleMaxMinValues Value = new DoubleMaxMinValues(double.MinValue, double.MaxValue);
        public static readonly NumericMaxMinValues Numeric = new NumericMaxMinValues(new BigInteger(double.MinValue), new BigInteger(double.MaxValue));

        public DoubleMaxMinValues(double minValue, double maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public double MinValue { get; }

        public double MaxValue { get; }

        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;
        public override int GetHashCode()
        {
            return HashCode.Combine(MaxValue, MinValue);
        }
        public override bool Equals(object? obj)
        {
            if (obj is DoubleMaxMinValues val)
            {
                return val.MaxValue == MaxValue &&
                    val.MinValue == MinValue;
            }
            return false;
        }
        public bool IsIn(double value, in ValueIsInOptions<double> options = default)
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

        public override string ToString()
        {
            return $"{{Max:{MaxValue}, Min:{MinValue}}}";
        }
        public static bool operator ==(DoubleMaxMinValues a, DoubleMaxMinValues b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(DoubleMaxMinValues a, DoubleMaxMinValues b)
        {
            return !a.Equals(b);
        }
    }
}
