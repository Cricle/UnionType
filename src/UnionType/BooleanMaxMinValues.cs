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

        public override int GetHashCode()
        {
            return MinValue.GetHashCode() ^ MaxValue.GetHashCode();
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
    }
}
