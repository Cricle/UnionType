using System;

namespace UnionType
{
    public interface IUnionValueTransformer
    {
        object? BytesToObject(byte[] buffer, int startIndex, int count, Type type);

        byte[] ObjectToBytes(object value, Type type);
    }


}