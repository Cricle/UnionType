using System.Numerics;

namespace UnionType
{
    public interface ITypeMaxMinValues<T>
    {
        T? MinValue { get; }

        T? MaxValue { get; }
    }
    public interface IWithinRangeable<TValue, TZoom>
    {
        bool IsIn(TValue value, in ValueIsInOptions<TZoom> options = default);
    }
    public struct ValueIsInOptions<TZoom>
    {
        public TZoom? Zoom { get; set; }

        public bool MaxNotEquals { get; set; }

        public bool MinNotEquals { get; set; }
    }
}
