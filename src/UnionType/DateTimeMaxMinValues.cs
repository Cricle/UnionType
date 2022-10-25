using System;
using System.Numerics;

namespace UnionType
{
    public readonly struct DateTimeMaxMinValues : ITypeMaxMinValues<DateTime>, ITypeMaxMinValues
    {
        public static readonly DateTimeMaxMinValues Value = new DateTimeMaxMinValues(DateTime.MinValue, DateTime.MaxValue);
        public static readonly NumericMaxMinValues Numeric = new NumericMaxMinValues(new BigInteger(DateTime.MinValue.Ticks), new BigInteger(DateTime.MaxValue.Ticks));

        internal DateTimeMaxMinValues(DateTime minValue, DateTime maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public DateTime MinValue { get; }

        public DateTime MaxValue { get; }

        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;
    }
}
