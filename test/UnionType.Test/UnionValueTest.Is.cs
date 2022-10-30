namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        [DataRow(UnionValueType.Single)]
        [DataRow(UnionValueType.Double)]
        [DataRow(UnionValueType.Decimal)]
        public void Equals_True(UnionValueType type)
        {
            Assert.IsTrue(new UnionValue { UnionValueType = type }.IsFraction());
        }
        [TestMethod]
        [DataRow(UnionValueType.DateTime)]
        [DataRow(UnionValueType.Int16)]
        [DataRow(UnionValueType.Empty)]
        public void Equals_False(UnionValueType type)
        {
            Assert.IsFalse(new UnionValue { UnionValueType = type }.IsFraction());
        }
    }
}
