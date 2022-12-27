using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow(false)]
        [DataRow((sbyte)1)]
        [DataRow((byte)1)]
        [DataRow((char)1)]
        [DataRow((short)1)]
        [DataRow((ushort)1)]
        [DataRow((int)1)]
        [DataRow((uint)1)]
        [DataRow((long)1)]
        [DataRow((ulong)1)]
        [DataRow((float)1.123)]
        [DataRow((double)1.123)]
        [DataRow("testtest")]
        public void FromObject_Box(object input)
        {
            var uv = UnionValue.FromObject(input);
            Assert.AreEqual(Convert.GetTypeCode(input), uv.GetTypeCode());
            Assert.AreEqual(input, uv.Box());
        }
        [TestMethod]
        public void FromObject_DateTime()
        {
            var dt = DateTime.Now;
            var uv = UnionValue.FromObject(dt);
            Assert.AreEqual(Convert.GetTypeCode(dt), uv.TypeCode);
            Assert.AreEqual(dt, uv.Box());
        }
        [TestMethod]
        public void FromObject_Decimal()
        {
            var dt = 123.1523m;
            var uv = UnionValue.FromObject(dt);
            Assert.AreEqual(Convert.GetTypeCode(dt), uv.TypeCode);
            Assert.AreEqual(dt, uv.Box());
        }
        [TestMethod]
        public void FromObject_TimeSpan()
        {
            var dt = TimeSpan.FromSeconds(123);
            var uv = UnionValue.FromObject(dt);
            Assert.AreEqual(UnionValueType.TimeSpan, uv.UnionValueType);
            Assert.AreEqual(dt, uv.Box());
        }
        [TestMethod]
        public void FromObject_Guid()
        {
            var dt = Guid.NewGuid();
            var uv = UnionValue.FromObject(dt);
            Assert.AreEqual(UnionValueType.Guid, uv.UnionValueType);
            Assert.AreEqual(dt, uv.Box());
        }
        [TestMethod]
        public void FromObject_IntPtr()
        {
            var dt = new IntPtr(123);
            var uv = UnionValue.FromObject(dt);
            Assert.AreEqual(UnionValueType.IntPtr, uv.UnionValueType);
            Assert.AreEqual(dt, uv.Box());
        }
        [TestMethod]
        public void FromObject_Object()
        {
            var dt = new object();
            var uv = UnionValue.FromObject(dt);
            Assert.AreEqual(UnionValueType.Object, uv.UnionValueType);
            Assert.AreEqual(dt, uv.Box());
        }
        [TestMethod]
        public void FromObject_DBNull()
        {
            var dt = DBNull.Value;
            var uv = UnionValue.FromObject(dt);
            Assert.AreEqual(UnionValueType.DBNull, uv.UnionValueType);
            Assert.AreEqual(dt, uv.Box());
        }
        [TestMethod]
        public void FromObject_Generic()
        {
            var uv = UnionValue.FromObject(123);
            Assert.AreEqual(123, uv.Box());
        }
    }
}
