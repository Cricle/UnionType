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
        public void ToString_Empty()
        {
            Assert.AreEqual("(null)", new UnionValue().ToString());
        }
        [TestMethod]
        public void ToString_IntPtr()
        {
            var ptr = new IntPtr(123);
            Assert.AreEqual(ptr.ToString(), new UnionValue { IntPtr= ptr }.ToString());
        }
        [TestMethod]
        public void ToString_DbNull()
        {
            var ptr = DBNull.Value;
            Assert.AreEqual(ptr.ToString(), new UnionValue { UnionValueType= UnionValueType.DBNull}.ToString());
        }
        [TestMethod]
        public void ToString_DateTime()
        {
            var ptr = DateTime.Now;
            Assert.AreEqual(ptr.ToString(), new UnionValue { DateTime = ptr }.ToString());
        }
        [TestMethod]
        public void ToString_TimeSpan()
        {
            var ptr = TimeSpan.FromSeconds(123);
            Assert.AreEqual(ptr.ToString(), new UnionValue { TimeSpan = ptr }.ToString());
        }
        [TestMethod]
        public void ToString_String()
        {
            var ptr = "stra";
            Assert.AreEqual(ptr.ToString(), new UnionValue { String = ptr }.ToString());
        }
        [TestMethod]
        public void ToString_Char()
        {
            var ptr ='a';
            Assert.AreEqual(ptr.ToString(), new UnionValue { Char = ptr }.ToString());
        }
        [TestMethod]
        public void ToString_Single()
        {
            var ptr = 123.33f;
            Assert.AreEqual(ptr.ToString(), new UnionValue { Float = ptr }.ToString());
        }
        [TestMethod]
        public void ToString_Double()
        {
            var ptr = 123.33d;
            Assert.AreEqual(ptr.ToString(), new UnionValue { Double = ptr }.ToString());
        }
        [TestMethod]
        public void ToString_Decimal()
        {
            var ptr = 123.33m;
            Assert.AreEqual(ptr.ToString(), new UnionValue { Decimal = ptr }.ToString());
        }
    }
}
