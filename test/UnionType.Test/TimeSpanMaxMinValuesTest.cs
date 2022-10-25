namespace UnionType.Test
{
    [TestClass]
    public class TimeSpanMaxMinValuesTest
    {
        [TestMethod]
        public void MaxMinTimeSpan()
        {
            Assert.AreEqual(TimeSpan.MaxValue, TimeSpanMaxMinValues.Value.MaxValue);
            Assert.AreEqual(TimeSpan.MinValue, TimeSpanMaxMinValues.Value.MinValue);
        }
        [TestMethod]
        public void TimeSpan_Box()
        {
            var v = (ITypeMaxMinValues)TimeSpanMaxMinValues.Value;
            Assert.AreEqual(TimeSpan.MaxValue, (TimeSpan)v.MaxValue!);
            Assert.AreEqual(TimeSpan.MinValue, (TimeSpan)v.MinValue!);
        }
    }
}
