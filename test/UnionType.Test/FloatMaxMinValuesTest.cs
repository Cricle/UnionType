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
        [TestMethod]
        public void EqualsHashCodeString()
        {
            Assert.AreEqual(FloatMaxMinValues.Value.GetHashCode(), FloatMaxMinValues.Value.GetHashCode());
            Assert.AreNotEqual(FloatMaxMinValues.Value.GetHashCode(), NumericMaxMinValues.UInt.GetHashCode());
            Assert.AreEqual(FloatMaxMinValues.Value.ToString(), FloatMaxMinValues.Value.ToString());
            Assert.AreNotEqual(FloatMaxMinValues.Value.ToString(), NumericMaxMinValues.UInt.ToString());
            Assert.IsFalse(FloatMaxMinValues.Value.Equals(NumericMaxMinValues.UInt));
            Assert.IsTrue(FloatMaxMinValues.Value.Equals(FloatMaxMinValues.Value));
            Assert.IsFalse(FloatMaxMinValues.Value.Equals(null));
            Assert.IsTrue(FloatMaxMinValues.Value == FloatMaxMinValues.Value);
            Assert.IsFalse(FloatMaxMinValues.Value != FloatMaxMinValues.Value);
        }
    }
}
