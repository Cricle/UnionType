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
        [DataRow(0)]
        [DataRow(123)]
        [DataRow(-123)]
        public void FromInt(int value) 
        {
            var uv=UnionValue.FromAsDecimal(value);
            Assert.AreEqual(value, uv.Decimal);
        }
        [TestMethod]
        [DataRow(0U)]
        [DataRow(123U)]
        public void FromUInt(uint value)
        {
            var uv = UnionValue.FromAsDecimal(value);
            Assert.AreEqual(value, uv.Decimal);
        }
        [TestMethod]
        [DataRow(0L)]
        [DataRow(123L)]
        [DataRow(-123L)]
        public void FromLong(long value)
        {
            var uv = UnionValue.FromAsDecimal(value);
            Assert.AreEqual(value, uv.Decimal);
        }
        [TestMethod]
        [DataRow(0UL)]
        [DataRow(123UL)]
        public void FromULong(ulong value)
        {
            var uv = UnionValue.FromAsDecimal(value);
            Assert.AreEqual(value, uv.Decimal);
        }
    }
}
