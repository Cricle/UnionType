namespace UnionType
{
    public interface ITypeMaxMinValues<T>
    {
        T? MinValue { get; }

        T? MaxValue { get; }
    }
}
