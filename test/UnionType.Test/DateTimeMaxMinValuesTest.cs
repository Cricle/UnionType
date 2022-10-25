namespace UnionType.Test
{
    [TestClass]
    public class DateTimeMaxMinValuesTest
    {
        [TestMethod]
        public void MaxMinDateTime()
        {
            Assert.AreEqual(DateTime.MaxValue, DateTimeMaxMinValues.Value.MaxValue);
            Assert.AreEqual(DateTime.MinValue, DateTimeMaxMinValues.Value.MinValue);
        }
        [TestMethod]
        public void DateTime_Box()
        {
            var v = (ITypeMaxMinValues)DateTimeMaxMinValues.Value;
            Assert.AreEqual(DateTime.MaxValue, (DateTime)v.MaxValue!);
            Assert.AreEqual(DateTime.MinValue, (DateTime)v.MinValue!);
        }
        [TestMethod]
        public void EqualsHashCodeString()
        {
            Assert.AreEqual(DateTimeMaxMinValues.Value.GetHashCode(), DateTimeMaxMinValues.Value.GetHashCode());
            Assert.AreNotEqual(DateTimeMaxMinValues.Value.GetHashCode(), NumericMaxMinValues.UInt.GetHashCode());
            Assert.AreEqual(DateTimeMaxMinValues.Value.ToString(), DateTimeMaxMinValues.Value.ToString());
            Assert.AreNotEqual(DateTimeMaxMinValues.Value.ToString(), NumericMaxMinValues.UInt.ToString());
            Assert.IsFalse(DateTimeMaxMinValues.Value.Equals(NumericMaxMinValues.UInt));
            Assert.IsTrue(DateTimeMaxMinValues.Value.Equals(DateTimeMaxMinValues.Value));
            Assert.IsFalse(DateTimeMaxMinValues.Value.Equals(null));
            Assert.IsTrue(DateTimeMaxMinValues.Value == DateTimeMaxMinValues.Value);
            Assert.IsFalse(DateTimeMaxMinValues.Value != DateTimeMaxMinValues.Value);
        }
    }
}
