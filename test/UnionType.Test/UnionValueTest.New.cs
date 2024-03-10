namespace UnionType.Test
{
    [TestClass]
    public partial class UnionValueTest
    {
        [TestMethod]
        public void NewEmpty()
        {
            var v = new UnionValue();
            Assert.AreEqual(UnionValueType.Empty, v.UnionValueType);
        }
        [TestMethod]
        public void NewBool()
        {
            var v = new UnionValue { Boolean = true };
            Assert.AreEqual(UnionValueType.Boolean, v.UnionValueType);
            Assert.AreEqual(true, v.Boolean);
        }
        [TestMethod]
        public void NewByte()
        {
            var v = new UnionValue { Byte = 12 };
            Assert.AreEqual(UnionValueType.Byte, v.UnionValueType);
            Assert.AreEqual((byte)12, v.Byte);
        }
        [TestMethod]
        public void NewSByte()
        {
            var v = new UnionValue { SByte = 12 };
            Assert.AreEqual(UnionValueType.SByte, v.UnionValueType);
            Assert.AreEqual((sbyte)12, v.SByte);
        }
        [TestMethod]
        public void NewChar()
        {
            var v = new UnionValue { Char = (char)12 };
            Assert.AreEqual(UnionValueType.Char, v.UnionValueType);
            Assert.AreEqual((char)12, v.Char);
        }
        [TestMethod]
        public void NewShort()
        {
            var v = new UnionValue { Short = 12 };
            Assert.AreEqual(UnionValueType.Int16, v.UnionValueType);
            Assert.AreEqual((short)12, v.Short);
        }
        [TestMethod]
        public void NewUShort()
        {
            var v = new UnionValue { UShort = 12 };
            Assert.AreEqual(UnionValueType.UInt16, v.UnionValueType);
            Assert.AreEqual((ushort)12, v.UShort);
        }
        [TestMethod]
        public void NewInt()
        {
            var v = new UnionValue { Int = 12 };
            Assert.AreEqual(UnionValueType.Int32, v.UnionValueType);
            Assert.AreEqual(12, v.Int);
        }
        [TestMethod]
        public void NewUInt()
        {
            var v = new UnionValue { UInt = 12 };
            Assert.AreEqual(UnionValueType.UInt32, v.UnionValueType);
            Assert.AreEqual((uint)12, v.UInt);
        }
        [TestMethod]
        public void NewLong()
        {
            var v = new UnionValue { Long = 12 };
            Assert.AreEqual(UnionValueType.Int64, v.UnionValueType);
            Assert.AreEqual(12, v.Long);
        }
        [TestMethod]
        public void NewULong()
        {
            var v = new UnionValue { ULong = 12 };
            Assert.AreEqual(UnionValueType.UInt64, v.UnionValueType);
            Assert.AreEqual((ulong)12, v.ULong);
        }
        [TestMethod]
        public void NewFloat()
        {
            var v = new UnionValue { Float = 12.3f };
            Assert.AreEqual(UnionValueType.Single, v.UnionValueType);
            Assert.AreEqual((float)12.3f, v.Float);
        }
        [TestMethod]
        public void NewDouble()
        {
            var v = new UnionValue { Double = 12.33d };
            Assert.AreEqual(UnionValueType.Double, v.UnionValueType);
            Assert.AreEqual((double)12.33, v.Double);
        }
        [TestMethod]
        public void NewDecimal()
        {
            var v = new UnionValue { Decimal = 12.33m };
            Assert.AreEqual(UnionValueType.Decimal, v.UnionValueType);
            Assert.AreEqual(12.33m, v.Decimal);
        }
        [TestMethod]
        public void NewGuid()
        {
            var gid = Guid.NewGuid();
            var v = new UnionValue { Guid = gid };
            Assert.AreEqual(UnionValueType.Guid, v.UnionValueType);
            Assert.AreEqual(gid, v.Guid);
        }
        [TestMethod]
        public void NewDateTime()
        {
            var now = DateTime.Now;
            var v = new UnionValue { DateTime = now };
            Assert.AreEqual(UnionValueType.DateTime, v.UnionValueType);
            Assert.AreEqual(now, v.DateTime);
        }
        [TestMethod]
        public void NewIntPtr()
        {
            var intptr = new IntPtr(1011);
            var v = new UnionValue { IntPtr = intptr };
            Assert.AreEqual(UnionValueType.IntPtr, v.UnionValueType);
            Assert.AreEqual(intptr, v.IntPtr);
        }
        [TestMethod]
        public void NewString()
        {
            var str = "aasda";
            var v = new UnionValue { String = str };
            Assert.AreEqual(UnionValueType.String, v.UnionValueType);
            Assert.AreEqual(str, v.String);
        }
        [TestMethod]
        public void NewStringNull()
        {
            var v = new UnionValue { String = null };
            Assert.AreEqual(UnionValueType.Empty, v.UnionValueType);
            Assert.IsNull(v.String);
        }
        [TestMethod]
        public void NewTimeSpan()
        {
            var ts = TimeSpan.FromHours(12);
            var v = new UnionValue { TimeSpan = ts };
            Assert.AreEqual(UnionValueType.TimeSpan, v.UnionValueType);
            Assert.AreEqual(ts, v.TimeSpan);
        }
        [TestMethod]
        public void TypeCode()
        {
            var v = new UnionValue { Int = 22 };
            Assert.AreEqual(UnionValueType.Int32, v.UnionValueType);
            v.UnionValueType= UnionValueType.Empty;
            Assert.AreEqual(UnionValueType.Empty, v.UnionValueType);
        }
        [TestMethod]
        public void Empty()
        {
            var v = UnionValue.Empty;
            Assert.IsTrue(v.ToBytes().All(x => x == 0));
        }
    }
}
