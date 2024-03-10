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
            var info= TypeInfo.GetTypeInfo(type);
            Assert.IsTrue(new UnionValue { @object = info }.IsFraction());
        }
        [TestMethod]
        [DataRow(UnionValueType.DateTime)]
        [DataRow(UnionValueType.Int16)]
        [DataRow(UnionValueType.Empty)]
        public void Equals_False(UnionValueType type)
        {
            var info = TypeInfo.GetTypeInfo(type);
            Assert.IsFalse(new UnionValue { @object = info }.IsFraction());
        }
    }
}
