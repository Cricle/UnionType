using System;
using System.Numerics;

namespace UnionType
{
    public readonly struct TimeSpanMaxMinValues : ITypeMaxMinValues<TimeSpan>, ITypeMaxMinValues
    {
        public static readonly TimeSpanMaxMinValues Value = new TimeSpanMaxMinValues(TimeSpan.MinValue, TimeSpan.MaxValue);
        public static readonly NumericMaxMinValues Numeric = new NumericMaxMinValues(new BigInteger(TimeSpan.MinValue.Ticks), new BigInteger(TimeSpan.MaxValue.Ticks));

        internal TimeSpanMaxMinValues(TimeSpan minValue, TimeSpan maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public TimeSpan MinValue { get; }

        public TimeSpan MaxValue { get; }

        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;
    }
}
