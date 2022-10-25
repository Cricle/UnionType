namespace UnionType.Test
{
    [TestClass]
    public class DecimalMaxMinValuesTest
    {
        [TestMethod]
        public void Decimal()
        {
            Assert.AreEqual(decimal.MaxValue, DecimalMaxMinValues.Value.MaxValue);
            Assert.AreEqual(decimal.MinValue, DecimalMaxMinValues.Value.MinValue);
        }
        [TestMethod]
        public void Decimal_ToNumeric()
        {
            var v = DecimalMaxMinValues.Numeric;
            Assert.AreEqual(decimal.MaxValue, (decimal)v.MaxValue);
            Assert.AreEqual(decimal.MinValue, (decimal)v.MinValue);
        }
        [TestMethod]
        public void Decimal_Box()
        {
            var v = (ITypeMaxMinValues)DecimalMaxMinValues.Value;
            Assert.AreEqual(decimal.MaxValue, (decimal)v.MaxValue!);
            Assert.AreEqual(decimal.MinValue, (decimal)v.MinValue!);
        }
        [TestMethod]
        public void EqualsHashCodeString()
        {
            Assert.AreEqual(DecimalMaxMinValues.Value.GetHashCode(), DecimalMaxMinValues.Value.GetHashCode());
            Assert.AreNotEqual(DecimalMaxMinValues.Value.GetHashCode(), NumericMaxMinValues.UInt.GetHashCode());
            Assert.AreEqual(DecimalMaxMinValues.Value.ToString(), DecimalMaxMinValues.Value.ToString());
            Assert.AreNotEqual(DecimalMaxMinValues.Value.ToString(), NumericMaxMinValues.UInt.ToString());
            Assert.IsFalse(DecimalMaxMinValues.Value.Equals(NumericMaxMinValues.UInt));
            Assert.IsTrue(DecimalMaxMinValues.Value.Equals(DecimalMaxMinValues.Value));
            Assert.IsFalse(DecimalMaxMinValues.Value.Equals(null));
            Assert.IsTrue(DecimalMaxMinValues.Value == DecimalMaxMinValues.Value);
            Assert.IsFalse(DecimalMaxMinValues.Value != DecimalMaxMinValues.Value);
        }
    }
}
