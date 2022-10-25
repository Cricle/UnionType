using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType.Test
{
    [TestClass]
    public class FloatMaxMinValuesTest
    {
        [TestMethod]
        public void Float()
        {
            Assert.AreEqual(float.MaxValue, FloatMaxMinValues.Value.MaxValue);
            Assert.AreEqual(float.MinValue, FloatMaxMinValues.Value.MinValue);
        }
        [TestMethod]
        public void Float_ToNumeric()
        {
            var v = FloatMaxMinValues.Numeric;
            Assert.AreEqual(float.MaxValue, (float)v.MaxValue);
            Assert.AreEqual(float.MinValue, (float)v.MinValue);
        }
        [TestMethod]
        public void Float_Box()
        {
            var v = (ITypeMaxMinValues)FloatMaxMinValues.Value;
            Assert.AreEqual(float.MaxValue, (float)v.MaxValue!);
            Assert.AreEqual(float.MinValue, (float)v.MinValue!);
        }
    }
}
