namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public void Comparer_Self()
        {
            var uv = new UnionValue { Int = 123 };
            Assert.AreEqual(0, uv.CompareTo(uv));
        }
        [TestMethod]
        public void Comparer_Raw()
        {
            var uv = new UnionValue { Int = 123 };
            Assert.AreEqual(0, uv.CompareTo(123));
            Assert.AreEqual(1, uv.CompareTo(1));
            Assert.AreEqual(-1, uv.CompareTo(124));
        }
        [TestMethod]
        public void Comparer_Not_Equals_Type()
        {
            var uv = new UnionValue();
            uv.Object=(new object());
            Assert.ThrowsException<NotSupportedException>(() => uv.CompareTo(123));
        }
    }
}
