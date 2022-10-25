namespace UnionType.Test
{
    [TestClass]
    public class MaxMinValueHelperTest
    {
        [TestMethod]
        public void GetNotSupport()
        {
            Assert.IsNull(MaxMinValueHelper.GetMaxMinValues(UnionValueType.Guid));
        }
        [TestMethod]
        [DataRow(UnionValueType.Boolean, typeof(BooleanMaxMinValues))]
        [DataRow(UnionValueType.Byte, typeof(NumericMaxMinValues))]
        [DataRow(UnionValueType.Char, typeof(NumericMaxMinValues))]
        [DataRow(UnionValueType.SByte, typeof(NumericMaxMinValues))]
        [DataRow(UnionValueType.Int16, typeof(NumericMaxMinValues))]
        [DataRow(UnionValueType.UInt16, typeof(NumericMaxMinValues))]
        [DataRow(UnionValueType.Int32, typeof(NumericMaxMinValues))]
        [DataRow(UnionValueType.UInt32, typeof(NumericMaxMinValues))]
        [DataRow(UnionValueType.Int64, typeof(NumericMaxMinValues))]
        [DataRow(UnionValueType.UInt64, typeof(NumericMaxMinValues))]
        [DataRow(UnionValueType.Single, typeof(FloatMaxMinValues))]
        [DataRow(UnionValueType.Double, typeof(DoubleMaxMinValues))]
        [DataRow(UnionValueType.Decimal, typeof(DecimalMaxMinValues))]
        [DataRow(UnionValueType.DateTime, typeof(DateTimeMaxMinValues))]
        [DataRow(UnionValueType.TimeSpan, typeof(TimeSpanMaxMinValues))]
        public void Get(UnionValueType type, Type actualType)
        {
            Assert.IsInstanceOfType(MaxMinValueHelper.GetMaxMinValues(type), actualType);
        }
    }
}
