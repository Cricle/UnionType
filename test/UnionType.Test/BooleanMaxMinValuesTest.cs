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
    }
}
