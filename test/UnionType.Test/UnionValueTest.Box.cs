namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        [DataRow(UnionValueType.Empty, null)]
        [DataRow(UnionValueType.Boolean, false)]
        [DataRow(UnionValueType.Char, (char)0)]
        [DataRow(UnionValueType.Int16, (short)0)]
        [DataRow(UnionValueType.UInt16, (ushort)0)]
        [DataRow(UnionValueType.Int32, 0)]
        [DataRow(UnionValueType.UInt32, (uint)0)]
        [DataRow(UnionValueType.Int64, (long)0)]
        [DataRow(UnionValueType.UInt64, (ulong)0)]
        [DataRow(UnionValueType.Single, (float)0)]
        [DataRow(UnionValueType.Double, (double)0)]
        public void Box_Primary(UnionValueType type, object val)
        {
            var uv = UnionValue.FromObject(val);
            Assert.AreEqual(uv.Box(), val);
        }
        [TestMethod]
        public void Box_DateTime()
        {
            var dt = DateTime.Now;
            var uv = new UnionValue { DateTime = dt };
            Assert.AreEqual(uv.Box(), dt);
        }
        [TestMethod]
        public void Box_TimeSpan()
        {
            var dt = TimeSpan.FromSeconds(2);
            var uv = new UnionValue { TimeSpan = dt };
            Assert.AreEqual(uv.Box(), dt);
        }
        [TestMethod]
        public void Box_Guid()
        {
            var dt = Guid.NewGuid();
            var uv = new UnionValue { Guid = dt };
            Assert.AreEqual(uv.Box(), dt);
        }
        [TestMethod]
        public void Box_DBNull()
        {
            var uv = new UnionValue { Object =DBNull.Value};
            Assert.AreEqual(uv.Box(), DBNull.Value);
        }
        [TestMethod]
        public void Box_Decimal()
        {
            var uv = new UnionValue { Decimal = 1 };
            Assert.AreEqual(uv.Box(), 1m);
        }
        [TestMethod]
        public void Box_Byte()
        {
            var uv = new UnionValue { Byte = 1 };
            Assert.AreEqual(uv.Box(), (byte)1);
        }
        [TestMethod]
        public void Box_SByte()
        {
            var uv = new UnionValue { SByte = 1 };
            Assert.AreEqual(uv.Box(), (sbyte)1);
        }
        [TestMethod]
        public void Box_IntPtr()
        {
            var ptr = new IntPtr(123);
            var uv = new UnionValue { IntPtr = ptr };
            Assert.AreEqual(uv.Box(), ptr);
        }
        [TestMethod]
        public void Box_Object()
        {
            var ptr = new Student();
            var uv = new UnionValue();
            uv.Object=(ptr);
            Assert.AreEqual(uv.Box(), ptr);
        }
        [TestMethod]
        public void Box_String()
        {
            var uv = new UnionValue { String = "123" };
            Assert.AreEqual(uv.Box(), "123");
        }
        class Student
        {

        }
    }
}
