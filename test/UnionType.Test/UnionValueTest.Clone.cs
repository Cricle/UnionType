namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public void Clone()
        {
            var a = new UnionValue { Int = 123 };
            var b = a.Clone();
            Assert.AreEqual(a.Int, b.Int);
            Assert.AreEqual(a.TypeCode, b.TypeCode);
        }
        [TestMethod]
        public void CloneObject()
        {
            var a = new UnionValue { Int = 123 };
            var b = (UnionValue)((ICloneable)a).Clone();
            Assert.AreEqual(a.Int, b.Int);
            Assert.AreEqual(a.TypeCode, b.TypeCode);
        }
    }
}
