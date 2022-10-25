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
    }
}
