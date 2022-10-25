namespace UnionType.Test
{
    [TestClass]
    public class BooleanMaxMinValuesTest
    {
        [TestMethod]
        public void Boolean()
        {
            Assert.AreEqual(true, BooleanMaxMinValues.Value.MaxValue);
            Assert.AreEqual(false, BooleanMaxMinValues.Value.MinValue);
        }
        [TestMethod]
        public void Double_ToNumeric()
        {
            var v = BooleanMaxMinValues.Numeric;
            Assert.AreEqual(1, (int)v.MaxValue);
            Assert.AreEqual(0, (int)v.MinValue);
        }
        [TestMethod]
        public void Double_Box()
        {
            var v = (ITypeMaxMinValues)BooleanMaxMinValues.Value;
            Assert.AreEqual(true, (bool)v.MaxValue!);
            Assert.AreEqual(false, (bool)v.MinValue!);
        }
        [TestMethod]
        public void EqualsHashCodeString()
        {
            Assert.AreEqual(BooleanMaxMinValues.Value.GetHashCode(), BooleanMaxMinValues.Value.GetHashCode());
            Assert.AreNotEqual(BooleanMaxMinValues.Value.GetHashCode(), NumericMaxMinValues.UInt.GetHashCode());
            Assert.AreEqual(BooleanMaxMinValues.Value.ToString(), BooleanMaxMinValues.Value.ToString());
            Assert.AreNotEqual(BooleanMaxMinValues.Value.ToString(), NumericMaxMinValues.UInt.ToString());
            Assert.IsFalse(BooleanMaxMinValues.Value.Equals(NumericMaxMinValues.UInt));
            Assert.IsTrue(BooleanMaxMinValues.Value.Equals(BooleanMaxMinValues.Value));
            Assert.IsFalse(BooleanMaxMinValues.Value.Equals(null));
            Assert.IsTrue(BooleanMaxMinValues.Value == BooleanMaxMinValues.Value);
            Assert.IsFalse(BooleanMaxMinValues.Value != BooleanMaxMinValues.Value);
        }
    }
}
