using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace UnionType
{
    public static class MaxMinValueHelper
    {
        public static ITypeMaxMinValues? GetMaxMinValues(UnionValueType type)
        {
            switch (type)
            {
                case UnionValueType.Boolean:
                    return BooleanMaxMinValues.Value;
                case UnionValueType.Char:
                    return NumericMaxMinValues.Char;
                case UnionValueType.SByte:
                    return NumericMaxMinValues.SByte;
                case UnionValueType.Byte:
                    return NumericMaxMinValues.Byte;
                case UnionValueType.Int16:
                    return NumericMaxMinValues.Short;
                case UnionValueType.UInt16:
                    return NumericMaxMinValues.UShort;
                case UnionValueType.Int32:
                    return NumericMaxMinValues.Int;
                case UnionValueType.UInt32:
                    return NumericMaxMinValues.UInt;
                case UnionValueType.Int64:
                    return NumericMaxMinValues.Long;
                case UnionValueType.UInt64:
                    return NumericMaxMinValues.ULong;
                case UnionValueType.Single:
                    return FloatMaxMinValues.Value;
                case UnionValueType.Double:
                    return DoubleMaxMinValues.Value;
                case UnionValueType.Decimal:
                    return DecimalMaxMinValues.Value;
                case UnionValueType.DateTime:
                    return DateTimeMaxMinValues.Value;
                case UnionValueType.TimeSpan:
                    return TimeSpanMaxMinValues.Value;
                default:
                    break;
            }
            return null;
        }
    }
}
