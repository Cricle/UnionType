using System.Numerics;

namespace UnionType
{
    public readonly struct DecimalMaxMinValues : ITypeMaxMinValues<decimal>, ITypeMaxMinValues
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
            return MinValue.GetHashCode() ^ MaxValue.GetHashCode();
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
