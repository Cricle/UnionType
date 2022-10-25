using System;
using System.Numerics;

namespace UnionType
{
    public readonly struct DoubleMaxMinValues : ITypeMaxMinValues<double>, ITypeMaxMinValues
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
