namespace UnionType.Test
{
    [TestClass]
    public class DoubleMaxMinValuesTest
    {
        [TestMethod]
        public void Double()
        {
            Assert.AreEqual(double.MaxValue, DoubleMaxMinValues.Value.MaxValue);
            Assert.AreEqual(double.MinValue, DoubleMaxMinValues.Value.MinValue);
        }
        [TestMethod]
        public void Double_ToNumeric()
        {
            var v = DoubleMaxMinValues.Numeric;
            Assert.AreEqual(double.MaxValue, (double)v.MaxValue);
            Assert.AreEqual(double.MinValue, (double)v.MinValue);
        }
        [TestMethod]
        public void Double_Box()
        {
            var v = (ITypeMaxMinValues)DoubleMaxMinValues.Value;
            Assert.AreEqual(double.MaxValue, (double)v.MaxValue!);
            Assert.AreEqual(double.MinValue, (double)v.MinValue!);
        }
        [TestMethod]
        public void EqualsHashCodeString()
        {
            Assert.AreEqual(DoubleMaxMinValues.Value.GetHashCode(), DoubleMaxMinValues.Value.GetHashCode());
            Assert.AreNotEqual(DoubleMaxMinValues.Value.GetHashCode(), NumericMaxMinValues.UInt.GetHashCode());
            Assert.AreEqual(DoubleMaxMinValues.Value.ToString(), DoubleMaxMinValues.Value.ToString());
            Assert.AreNotEqual(DoubleMaxMinValues.Value.ToString(), NumericMaxMinValues.UInt.ToString());
            Assert.IsFalse(DoubleMaxMinValues.Value.Equals(NumericMaxMinValues.UInt));
            Assert.IsTrue(DoubleMaxMinValues.Value.Equals(DoubleMaxMinValues.Value));
            Assert.IsFalse(DoubleMaxMinValues.Value.Equals(null));
            Assert.IsTrue(DoubleMaxMinValues.Value == DoubleMaxMinValues.Value);
            Assert.IsFalse(DoubleMaxMinValues.Value != DoubleMaxMinValues.Value);
        }
    }
}
