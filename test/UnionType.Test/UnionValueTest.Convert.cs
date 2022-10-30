namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public void GetTypeCode()
        {
            var uv = new UnionValue { Int = 312 };
            Assert.AreEqual(System.TypeCode.Int32, uv.GetTypeCode());
        }
        [TestMethod]
        public void ToBoolean()
        {
            var uv = new UnionValue { Boolean = true };
            Assert.AreEqual(true, uv.ToBoolean(null));

            uv = new UnionValue { String = "true" };
            Assert.AreEqual(true, uv.ToBoolean(null));
        }
        [TestMethod]
        public void ToChar()
        {
            var uv = new UnionValue { Char = '1' };
            Assert.AreEqual('1', uv.ToChar(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual('1', uv.ToChar(null));
        }
        [TestMethod]
        public void ToDateTime()
        {
            var now = DateTime.Now;
            var uv = new UnionValue { DateTime = now };
            Assert.AreEqual(now, uv.ToDateTime(null));

            uv = new UnionValue { String = now.ToString("yyyy-MM-dd HH:mm:ss.fffffff") };
            Assert.AreEqual(now, uv.ToDateTime(null));
        }
        [TestMethod]
        public void ToDecimal()
        {
            var uv = new UnionValue { Decimal = 1 };
            Assert.AreEqual(1m, uv.ToDecimal(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual(1m, uv.ToDecimal(null));
        }
        [TestMethod]
        public void ToByte()
        {
            var uv = new UnionValue { Byte = 1 };
            Assert.AreEqual((byte)1, uv.ToByte(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual((byte)1, uv.ToByte(null));
        }
        [TestMethod]
        public void ToDouble()
        {
            var uv = new UnionValue { Double = 1 };
            Assert.AreEqual(1d, uv.ToDouble(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual(1d, uv.ToDouble(null));
        }
        [TestMethod]
        public void ToInt16()
        {
            var uv = new UnionValue { Short = 1 };
            Assert.AreEqual((short)1, uv.ToInt16(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual((short)1, uv.ToInt16(null));
        }
        [TestMethod]
        public void ToInt32()
        {
            var uv = new UnionValue { Int = 1 };
            Assert.AreEqual(1, uv.ToInt32(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual(1, uv.ToInt32(null));
        }
        [TestMethod]
        public void ToInt64()
        {
            var uv = new UnionValue { Long = 1 };
            Assert.AreEqual(1, uv.ToInt64(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual(1, uv.ToInt64(null));
        }
        [TestMethod]
        public void ToSByte()
        {
            var uv = new UnionValue { SByte = 1 };
            Assert.AreEqual((sbyte)1, uv.ToSByte(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual((sbyte)1, uv.ToSByte(null));
        }
        [TestMethod]
        public void ToSingle()
        {
            var uv = new UnionValue { Float = 1 };
            Assert.AreEqual(1, uv.ToSingle(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual(1, uv.ToSingle(null));
        }
        [TestMethod]
        public void ToString_Uv()
        {
            var uv = new UnionValue { Int = 1 };
            Assert.AreEqual("1", uv.ToString(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual("1", uv.ToString(null));
        }
        [TestMethod]
        public void ToUInt16()
        {
            var uv = new UnionValue { UShort = 1 };
            Assert.AreEqual((ushort)1, uv.ToUInt16(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual((ushort)1, uv.ToUInt16(null));
        }
        [TestMethod]
        public void ToUInt32()
        {
            var uv = new UnionValue { UInt = 1 };
            Assert.AreEqual((uint)1, uv.ToUInt32(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual((uint)1, uv.ToUInt32(null));
        }
        [TestMethod]
        public void ToUInt64()
        {
            var uv = new UnionValue { ULong = 1 };
            Assert.AreEqual((ulong)1, uv.ToUInt64(null));

            uv = new UnionValue { String = "1" };
            Assert.AreEqual((ulong)1, uv.ToUInt64(null));
        }
        [TestMethod]
        public void Formatter()
        {
            var uv = new UnionValue { Int = 123 };
            Assert.AreEqual(123.ToString("X"), uv.ToString("X", null));
        }
        [TestMethod]
        public void ToType()
        {
            var uv = new UnionValue { ULong = 1 };
            Assert.AreEqual((double)1, uv.ToType(typeof(double), null));
        }
    }
}
