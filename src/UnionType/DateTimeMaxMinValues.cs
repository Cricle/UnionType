using System;
using System.Numerics;

namespace UnionType
{
    public readonly struct DateTimeMaxMinValues : ITypeMaxMinValues<DateTime>, ITypeMaxMinValues, IWithinRangeable<DateTime,double>
    {
        public static readonly DateTimeMaxMinValues Value = new DateTimeMaxMinValues(DateTime.MinValue, DateTime.MaxValue);
        public static readonly NumericMaxMinValues Numeric = new NumericMaxMinValues(new BigInteger(DateTime.MinValue.Ticks), new BigInteger(DateTime.MaxValue.Ticks));

        public DateTimeMaxMinValues(DateTime minValue, DateTime maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public DateTime MinValue { get; }

        public DateTime MaxValue { get; }

        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;

        public override int GetHashCode()
        {
            return HashCode.Combine(MaxValue, MinValue);
        }
        public override bool Equals(object? obj)
        {
            if (obj is DateTimeMaxMinValues val)
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

        public bool IsIn(DateTime value, in ValueIsInOptions<double> options = default)
        {
            double left = MinValue.Ticks;
            double right = MaxValue.Ticks;
            if (options.Zoom != default)
            {
                left *= options.Zoom;
                right *= options.Zoom;
            }
            var leftTime = new DateTime((long)left);
            var rightTime = new DateTime((long)right);
            return (options.MinNotEquals ? leftTime < value : leftTime <= value) && (options.MaxNotEquals ? rightTime > value : rightTime >= value);
        }


        public static bool operator ==(DateTimeMaxMinValues a, DateTimeMaxMinValues b)
        {
            return a.Equals(b);
        }
        public static bool operator !=(DateTimeMaxMinValues a, DateTimeMaxMinValues b)
        {
            return !a.Equals(b);
        }
    }
}
