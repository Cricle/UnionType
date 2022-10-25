using System.Numerics;

namespace UnionType
{
    public readonly struct FloatMaxMinValues : ITypeMaxMinValues<float>, ITypeMaxMinValues
    {
        public static readonly FloatMaxMinValues Value = new FloatMaxMinValues(float.MinValue, float.MaxValue);
        public static readonly NumericMaxMinValues Numeric = new NumericMaxMinValues(new BigInteger(float.MinValue), new BigInteger(float.MaxValue));

        internal FloatMaxMinValues(float minValue, float maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;

        }

        public float MinValue { get; }

        public float MaxValue { get; }

        object? ITypeMaxMinValues<object>.MinValue => MinValue;

        object? ITypeMaxMinValues<object>.MaxValue => MaxValue;
    }
}
