using System.Numerics;

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
        [TestMethod]
        public void EqualsHashCodeString()
        {
            Assert.AreEqual(DoubleMaxMinValues.Value.GetHashCode(), DoubleMaxMinValues.Value.GetHashCode());
            Assert.AreNotEqual(DoubleMaxMinValues.Value.GetHashCode(), NumericMaxMinValues.UInt.GetHashCode());
            Assert.AreEqual(DoubleMaxMinValues.Value.ToString(), DoubleMaxMinValues.Value.ToString());
            Assert.AreNotEqual(DoubleMaxMinValues.Value.ToString(), NumericMaxMinValues.UInt.ToString());
            Assert.IsFalse(DoubleMaxMinValues.Value.Equals(NumericMaxMinValues.UInt));
            Assert.IsTrue(DoubleMaxMinValues.Value.Equals(DoubleMaxMinValues.Value));
            Assert.IsFalse(DoubleMaxMinValues.Value.Equals(null));
            Assert.IsTrue(DoubleMaxMinValues.Value == DoubleMaxMinValues.Value);
            Assert.IsFalse(DoubleMaxMinValues.Value != DoubleMaxMinValues.Value);
        }
        [TestMethod]
        public void Double_IsIn()
        {
            var v = new DoubleMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10d));
            Assert.IsFalse(v.IsIn(101d));
        }
        [TestMethod]
        public void Double_IsIn_Zoom()
        {
            var v = new DoubleMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10 * 12, new ValueIsInOptions<double> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(100 * 12, new ValueIsInOptions<double> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(55 * 12, new ValueIsInOptions<double> { Zoom = 12 }));
            Assert.IsFalse(v.IsIn(10 * 12 - 1, new ValueIsInOptions<double> { Zoom = 12 }));
        }
        [TestMethod]
        public void Double_IsIn_Close()
        {
            var v = new DoubleMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10, new ValueIsInOptions<double> { MinNotEquals = false }));
            Assert.IsFalse(v.IsIn(10, new ValueIsInOptions<double> { MinNotEquals = true }));

            Assert.IsTrue(v.IsIn(100, new ValueIsInOptions<double> { MaxNotEquals = false }));
            Assert.IsFalse(v.IsIn(100, new ValueIsInOptions<double> { MaxNotEquals = true }));
        }
        [TestMethod]
        public void Double_BigInt_IsIn_Zoom()
        {
            var v = new DoubleMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10 * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(100 * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(55 * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsFalse(v.IsIn(10 * 12 - 1, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
        }
        [TestMethod]
        public void Double_BigInt_IsIn_Close()
        {
            var v = new DoubleMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10, new ValueIsInOptions<BigInteger> { MinNotEquals = false }));
            Assert.IsFalse(v.IsIn(10, new ValueIsInOptions<BigInteger> { MinNotEquals = true }));

            Assert.IsTrue(v.IsIn(100, new ValueIsInOptions<BigInteger> { MaxNotEquals = false }));
            Assert.IsFalse(v.IsIn(100, new ValueIsInOptions<BigInteger> { MaxNotEquals = true }));
        }
    }
}
