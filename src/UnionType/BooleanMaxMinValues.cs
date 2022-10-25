namespace UnionType
{
    public readonly struct BooleanMaxMinValues : ITypeMaxMinValues<bool>, ITypeMaxMinValues
    {
        public static readonly BooleanMaxMinValues Value = new BooleanMaxMinValues(false, true);
        public static readonly NumericMaxMinValues Numeric = new NumericMaxMinValues(0, 1);

        internal BooleanMaxMinValues(bool minValue, bool maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public bool MinValue { get; }

        public bool MaxValue { get; }

        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;
    }
}
