namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public void ToBytesAndConvertBack()
        {
            var a = 123;
            var bs = UnionValue.FromBytes(BitConverter.GetBytes(a));
            bs.@object = TypeInfo.Int32Info;
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
        [TestMethod]
        public void ToUsedBytes()
        {
            var bs = UnionValue.FromObject(123);
            var buffer = bs.ToUsedBytes();
            Assert.AreEqual(sizeof(int), buffer.Length);
            Assert.AreEqual(123, BitConverter.ToInt32(buffer,0));
        }
    }
}
