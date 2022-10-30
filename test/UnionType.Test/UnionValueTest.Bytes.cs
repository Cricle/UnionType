namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public void ToBytesAndConvertBack()
        {
            var a = 123;
            var bs = UnionValue.FromBytes(BitConverter.GetBytes(a));
            bs.UnionValueType = UnionValueType.Int32;
            Assert.AreEqual(a, bs.Int);
            var back = BitConverter.ToInt32(bs.ToBytes(), 0);
            Assert.AreEqual(a, back);
        }
        [TestMethod]
        public void ToBytesBySpan()
        {
            var uv = new UnionValue { Int = 123 };
            var buffer = new byte[sizeof(int)];
            uv.ToBytes(buffer.AsSpan());
            Assert.AreEqual(123, BitConverter.ToInt32(buffer, 0));
        }
    }
}
