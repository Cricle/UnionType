using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace UnionType
{
    public interface IUnionValueTransformer
    {
        object? BytesToObject(byte[] buffer, int startIndex, int count, Type type);

        byte[] ObjectToBytes(object value, Type type);
    }
    public class UnionValueToBytesHelper
    {
        private static readonly byte[] EmptyStringBuffer;

        static UnionValueToBytesHelper()
        {
            var v = new UnionValue();
            v.String = null;
            EmptyStringBuffer = v.ToBytes();
        }

        public UnionValueToBytesHelper(Encoding encoding)
        {
            Encoding = encoding;
        }

        public UnionValueToBytesHelper(Encoding encoding, IUnionValueTransformer? transformer)
            : this(encoding)
        {
            Transformer = transformer;
        }

        public Encoding Encoding { get; }

        public IUnionValueTransformer? Transformer { get; }

        public UnionValue ToValue(byte[] bytes)
        {
            var offset = 0;
            var val = UnionValue.FromBytes(bytes.AsSpan(0, UnionValue.Size));
            offset += UnionValue.Size;
            if (val.UnionValueType == UnionValueType.String)
            {
                val.String = Encoding.GetString(bytes, offset, bytes.Length - offset);
            }
            else if (val.UnionValueType == UnionValueType.Object)
            {
                var len = BitConverter.ToInt32(bytes, offset);
                offset += sizeof(int);
                var typeName = Encoding.GetString(bytes, offset, len);
                offset += len;
                var type = Type.GetType(typeName);
                if (type == null)
                {
                    throw new ArgumentException($"Type {typeName} not found!");
                }
                if (Transformer == null)
                {
                    throw new InvalidOperationException("Transformer is null");
                }
                val.SetObject(Transformer.BytesToObject(bytes, offset, bytes.Length - offset, type));
            }
            return val;
        }
        public List<byte> ToBytes(in UnionValue value)
        {
            var list = new List<byte>(UnionValue.Size);
            ToBytes(value, list);
            return list;
        }
        public void ToBytes(in UnionValue value, List<byte> lists)
        {
            if (value.unionValueType == UnionValueType.String)
            {
                lists.AddRange(EmptyStringBuffer);
            }
            else if (value.unionValueType == UnionValueType.Object)
            {
                var v = new UnionValue();
                v.unionValueType = UnionValueType.Object;
                v.TypeNameString = value.TypeNameString;
                lists.AddRange(v.ToBytes());
            }
            else
            {
                lists.AddRange(value.ToBytes());
            }
            if (value.UnionValueType == UnionValueType.String)
            {
                var str = value.String;
                if (str != null)
                {
                    lists.AddRange(Encoding.GetBytes(str));
                }
            }
            else if (value.UnionValueType == UnionValueType.Object)
            {
                var inst = value.Object;
                var typeName = value.TypeNameString;
                if (typeName == null)
                {
                    throw new InvalidOperationException("typeName is null");
                }
                lists.AddRange(BitConverter.GetBytes(typeName.Length));
                lists.AddRange(Encoding.GetBytes(typeName));
                if (inst != null)
                {
                    if (Transformer == null)
                    {
                        throw new InvalidOperationException("Transformer is null");
                    }
                    lists.AddRange(Transformer.ObjectToBytes(inst, value.TypeNameType!));
                }
            }
        }
    }


}