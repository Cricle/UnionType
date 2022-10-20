using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public void Cast_Bool()
        {
            var a = false;
            UnionValue b = a;
            Assert.AreEqual(a, b.Boolean);
            a = b;
            Assert.AreEqual(a, b.Boolean);
        }
        [TestMethod]
        public void Cast_Byte()
        {
            byte a = 123;
            UnionValue b = a;
            Assert.AreEqual(a, b.Byte);
            a = b;
            Assert.AreEqual(a, b.Byte);
        }
        [TestMethod]
        public void Cast_SByte()
        {
            sbyte a = 123;
            UnionValue b = a;
            Assert.AreEqual(a, b.SByte);
            a = b;
            Assert.AreEqual(a, b.SByte);
        }
        [TestMethod]
        public void Cast_Char()
        {
            char a = '1';
            UnionValue b = a;
            Assert.AreEqual(a, b.Char);
            a = b;
            Assert.AreEqual(a, b.Char);
        }
        [TestMethod]
        public void Cast_Short()
        {
            short a = 12;
            UnionValue b = a;
            Assert.AreEqual(a, b.Short);
            a = b;
            Assert.AreEqual(a, b.Short);
        }
        [TestMethod]
        public void Cast_UShort()
        {
            ushort a = 12;
            UnionValue b = a;
            Assert.AreEqual(a, b.UShort);
            a = b;
            Assert.AreEqual(a, b.UShort);
        }
        [TestMethod]
        public void Cast_Int()
        {
            int a = 12;
            UnionValue b = a;
            Assert.AreEqual(a, b.Int);
            a = b;
            Assert.AreEqual(a, b.Int);
        }
        [TestMethod]
        public void Cast_UInt()
        {
            uint a = 12;
            UnionValue b = a;
            Assert.AreEqual(a, b.UInt);
            a = b;
            Assert.AreEqual(a, b.UInt);
        }
        [TestMethod]
        public void Cast_Long()
        {
            long a = 12;
            UnionValue b = a;
            Assert.AreEqual(a, b.Long);
            a = b;
            Assert.AreEqual(a, b.Long);
        }
        [TestMethod]
        public void Cast_ULong()
        {
            ulong a = 12;
            UnionValue b = a;
            Assert.AreEqual(a, b.ULong);
            a = b;
            Assert.AreEqual(a, b.ULong);
        }
        [TestMethod]
        public void Cast_String()
        {
            string a = "123";
            UnionValue b = a;
            Assert.AreEqual(a, b.String);
            a = b;
            Assert.AreEqual(a, b.String);
        }
        [TestMethod]
        public void Cast_DateTime()
        {
            DateTime a = DateTime.Now;
            UnionValue b = a;
            Assert.AreEqual(a, b.DateTime);
            a = b;
            Assert.AreEqual(a, b.DateTime);
        }
        [TestMethod]
        public void Cast_TimeSpan()
        {
            TimeSpan a = TimeSpan.FromSeconds(11);
            UnionValue b = a;
            Assert.AreEqual(a, b.TimeSpan);
            a = b;
            Assert.AreEqual(a, b.TimeSpan);
        }
        [TestMethod]
        public void Cast_IntPtr()
        {
            IntPtr a = new IntPtr(11);
            UnionValue b = a;
            Assert.AreEqual(a, b.IntPtr);
            a = b;
            Assert.AreEqual(a, b.IntPtr);
        }
        [TestMethod]
        public void Cast_Float()
        {
            float a = 12.2f;
            UnionValue b = a;
            Assert.AreEqual(a, b.Float);
            a = b;
            Assert.AreEqual(a, b.Float);
        }
        [TestMethod]
        public void Cast_Double()
        {
            double a = 12.2d;
            UnionValue b = a;
            Assert.AreEqual(a, b.Double);
            a = b;
            Assert.AreEqual(a, b.Double);
        }
        [TestMethod]
        public void Cast_Decimal()
        {
            decimal a = 12.2m;
            UnionValue b = a;
            Assert.AreEqual(a, b.Decimal);
            a = b;
            Assert.AreEqual(a, b.Decimal);
        }
        [TestMethod]
        public void Cast_DbNull()
        {
            DBNull a = DBNull.Value;
            UnionValue b = a;
            Assert.AreEqual( UnionValueType.DBNull, b.UnionValueType);
        }
    }
}
