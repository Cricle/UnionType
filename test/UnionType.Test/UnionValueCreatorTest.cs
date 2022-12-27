using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType.Test
{
    [TestClass]
    public class UnionValueCreatorTest
    {
        [TestMethod]
        public void FromTimeSpan()
        {
            FromAny(TimeSpan.FromSeconds(11));
        }
        [TestMethod]
        public void FromGuid()
        {
            FromAny(Guid.NewGuid());
        }
        [TestMethod]
        public void FromIntPtr()
        {
            FromAny(new IntPtr(123));
        }
        [TestMethod]
        public void FromBool()
        {
            FromAny(true);
        }
        [TestMethod]
        public void FromByte()
        {
            FromAny((byte)1);
        }
        [TestMethod]
        public void FromSByte()
        {
            FromAny((sbyte)1);
        }
        [TestMethod]
        public void FromChar()
        {
            FromAny((char)1);
        }
        [TestMethod]
        public void FromShort()
        {
            FromAny((short)1);
        }
        [TestMethod]
        public void FromUShort()
        {
            FromAny((ushort)1);
        }
        [TestMethod]
        public void FromInt()
        {
            FromAny((int)1);
        }
        [TestMethod]
        public void FromUInt()
        {
            FromAny((uint)1);
        }
        [TestMethod]
        public void FromLong()
        {
            FromAny((long)1);
        }
        [TestMethod]
        public void FromULong()
        {
            FromAny((ulong)1);
        }
        [TestMethod]
        public void FromFloat()
        {
            FromAny((float)1.123);
        }
        [TestMethod]
        public void FromDouble()
        {
            FromAny((double)1.123);
        }
        [TestMethod]
        public void FromDecimal()
        {
            FromAny((decimal)1.123);
        }
        [TestMethod]
        public void FromObject()
        {
            FromAny(new object());
        }
        [TestMethod]
        public void FromDBNULL()
        {
            FromAny(DBNull.Value);
        }
        [TestMethod]
        public void FromString()
        {
            FromAny("123123");
        }
        [TestMethod]
        public void FromDateTime()
        {
            FromAny(DateTime.Now);
        }
        private static void FromAny<T>(T raw)
        {
            var uv = UnionValueCreator<T>.Create(raw);
            Assert.AreEqual(raw, uv.Box());
        }
    }
}
