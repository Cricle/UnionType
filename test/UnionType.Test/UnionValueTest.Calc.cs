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
        public void Bigger()
        {
            var left = UnionValue.FromObject(123);
            Assert.IsTrue(left > 122);
            Assert.IsFalse(left > 124);
        }
        [TestMethod]
        public void BiggerOrEqualsThan()
        {
            var left = UnionValue.FromObject(123);
            Assert.IsTrue(left >= 122);
            Assert.IsFalse(left >= 124);
            Assert.IsTrue(left >= 123);
        }
        [TestMethod]
        public void Small()
        {
            var left = UnionValue.FromObject(123);
            Assert.IsFalse(left < 122);
            Assert.IsTrue(left < 124);
        }
        [TestMethod]
        public void SmallOrEqualsThan()
        {
            var left = UnionValue.FromObject(123);
            Assert.IsFalse(left <= 122);
            Assert.IsTrue(left <= 124);
            Assert.IsTrue(left <= 123);
        }

        [TestMethod]
        public void Bigger_Decimal()
        {
            var left = UnionValue.FromObject(123m);
            Assert.IsTrue(left > 122m);
            Assert.IsFalse(left > 124m);
        }
        [TestMethod]
        public void BiggerOrEqualsThan_Decimal()
        {
            var left = UnionValue.FromObject(123m);
            Assert.IsTrue(left >= 122m);
            Assert.IsFalse(left >= 124m);
            Assert.IsTrue(left >= 123m);
        }
        [TestMethod]
        public void Small_Decimal()
        {
            var left = UnionValue.FromObject(123m);
            Assert.IsFalse(left < 122m);
            Assert.IsTrue(left < 124m);
        }
        [TestMethod]
        public void SmallOrEqualsThan_Decimal()
        {
            var left = UnionValue.FromObject(123m);
            Assert.IsFalse(left <= 122m);
            Assert.IsTrue(left <= 124m);
            Assert.IsTrue(left <= 123m);
        }
        [TestMethod]
        public void Add()
        {
            var left = UnionValue.FromObject(123);
            var res = left + 456;
            Assert.AreEqual(579, res.ToInt32(null));
        }
        [TestMethod]
        public void Sub()
        {
            var left = UnionValue.FromObject(123);
            var res = left - 456;
            Assert.AreEqual(-333, res.ToInt32(null));
        }
        [TestMethod]
        public void Power()
        {
            var left = UnionValue.FromObject(123);
            var res = left * 456;
            Assert.AreEqual(123*456, res.ToInt32(null));
        }
        [TestMethod]
        public void Div()
        {
            var left = UnionValue.FromObject(456);
            var res = left / 123;
            Assert.AreEqual(456 / 123, res.ToInt32(null));
        }
        [TestMethod]
        public void Mod()
        {
            var left = UnionValue.FromObject(456);
            var res = left % 123;
            Assert.AreEqual(456 % 123, res.ToInt32(null));
        }

        [TestMethod]
        public void Add_Decimal()
        {
            var left = UnionValue.FromObject(123m);
            var res = left + 456;
            Assert.AreEqual(579m, res.ToDecimal(null));
        }
        [TestMethod]
        public void Sub_Decimal()
        {
            var left = UnionValue.FromObject(123m);
            var res = left - 456;
            Assert.AreEqual(-333m, res.ToDecimal(null));
        }
        [TestMethod]
        public void Power_Decimal()
        {
            var left = UnionValue.FromObject(123m);
            var res = left * 456;
            Assert.AreEqual(123m * 456, res.ToDecimal(null));
        }
        [TestMethod]
        public void Div_Decimal()
        {
            var left = UnionValue.FromObject(456m);
            var res = left / 123;
            Assert.AreEqual(456m / 123, res.ToDecimal(null));
        }
        [TestMethod]
        public void Mod_Decimal()
        {
            var left = UnionValue.FromObject(456m);
            var res = left % 123;
            Assert.AreEqual(456m % 123, res.ToDecimal(null));
        }
    }
}
