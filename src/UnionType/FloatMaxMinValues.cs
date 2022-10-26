using System;
using System.Numerics;

namespace UnionType
{
    public readonly struct FloatMaxMinValues : ITypeMaxMinValues<float>, ITypeMaxMinValues, IWithinRangeable<float, double>, IWithinRangeable<BigInteger, BigInteger>
    {
        public static readonly FloatMaxMinValues Value = new FloatMaxMinValues(float.MinValue, float.MaxValue);
        public static readonly NumericMaxMinValues Numeric = new NumericMaxMinValues(new BigInteger(float.MinValue), new BigInteger(float.MaxValue));

        public FloatMaxMinValues(float minValue, float maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public float MinValue { get; }

        public float MaxValue { get; }

        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;

        public override int GetHashCode()
        {
            return HashCode.Combine(MaxValue, MinValue);
        }
        public override bool Equals(object? obj)
        {
            if (obj is FloatMaxMinValues val)
            {
                return val.MaxValue == MaxValue &&
                    val.MinValue == MinValue;
            }
            return false;
        }
        public bool IsIn(float value, in ValueIsInOptions<double> options = default)
        {
            var dvalue = (double)value;
            double left = MinValue;
            double right = MaxValue;
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

        public static bool operator ==(FloatMaxMinValues a, FloatMaxMinValues b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(FloatMaxMinValues a, FloatMaxMinValues b)
        {
            return !a.Equals(b);
        }
    }
}
