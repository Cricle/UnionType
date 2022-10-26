using System.Numerics;

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
        [TestMethod]
        public void Float_IsIn()
        {
            var v = new FloatMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10f));
            Assert.IsFalse(v.IsIn(101f));
        }
        [TestMethod]
        public void Float_IsIn_Zoom()
        {
            var v = new FloatMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10 * 12, new ValueIsInOptions<double> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(100 * 12, new ValueIsInOptions<double> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(55 * 12, new ValueIsInOptions<double> { Zoom = 12 }));
            Assert.IsFalse(v.IsIn(10 * 12 - 1, new ValueIsInOptions<double> { Zoom = 12 }));
        }
        [TestMethod]
        public void Float_IsIn_Close()
        {
            var v = new FloatMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10, new ValueIsInOptions<double> { MinNotEquals = false }));
            Assert.IsFalse(v.IsIn(10, new ValueIsInOptions<double> { MinNotEquals = true }));

            Assert.IsTrue(v.IsIn(100, new ValueIsInOptions<double> { MaxNotEquals = false }));
            Assert.IsFalse(v.IsIn(100, new ValueIsInOptions<double> { MaxNotEquals = true }));
        }
        [TestMethod]
        public void Float_BigInt_IsIn_Zoom()
        {
            var v = new FloatMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10 * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(100 * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(55 * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsFalse(v.IsIn(10 * 12 - 1, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
        }
        [TestMethod]
        public void Float_BigInt_IsIn_Close()
        {
            var v = new FloatMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10, new ValueIsInOptions<BigInteger> { MinNotEquals = false }));
            Assert.IsFalse(v.IsIn(10, new ValueIsInOptions<BigInteger> { MinNotEquals = true }));

            Assert.IsTrue(v.IsIn(100, new ValueIsInOptions<BigInteger> { MaxNotEquals = false }));
            Assert.IsFalse(v.IsIn(100, new ValueIsInOptions<BigInteger> { MaxNotEquals = true }));
        }
    }
}
