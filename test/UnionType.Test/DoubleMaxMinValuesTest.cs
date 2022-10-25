using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType.Test
{
    [TestClass]
    public class DoubleMaxMinValuesTest
    {
        [TestMethod]
        public void Double()
        {
            Assert.AreEqual(double.MaxValue, DoubleMaxMinValues.Value.MaxValue);
            Assert.AreEqual(double.MinValue, DoubleMaxMinValues.Value.MinValue);
        }
        [TestMethod]
        public void Double_ToNumeric()
        {
            var v = DoubleMaxMinValues.Numeric;
            Assert.AreEqual(double.MaxValue, (double)v.MaxValue);
            Assert.AreEqual(double.MinValue, (double)v.MinValue);
        }
        [TestMethod]
        public void Double_Box()
        {
            var v = (ITypeMaxMinValues)DoubleMaxMinValues.Value;
            Assert.AreEqual(double.MaxValue, (double)v.MaxValue!);
            Assert.AreEqual(double.MinValue, (double)v.MinValue!);
        }
    }
}
