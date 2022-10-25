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
    }
}
