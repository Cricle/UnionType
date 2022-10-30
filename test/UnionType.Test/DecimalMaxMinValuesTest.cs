using System.Numerics;

namespace UnionType.Test
{
    [TestClass]
    public class DecimalMaxMinValuesTest
    {
        [TestMethod]
        public void Decimal()
        {
            Assert.AreEqual(decimal.MaxValue, DecimalMaxMinValues.Value.MaxValue);
            Assert.AreEqual(decimal.MinValue, DecimalMaxMinValues.Value.MinValue);
        }
        [TestMethod]
        public void Decimal_ToDecimal()
        {
            var v = DecimalMaxMinValues.Value;
            Assert.AreEqual(decimal.MaxValue, (decimal)v.MaxValue);
            Assert.AreEqual(decimal.MinValue, (decimal)v.MinValue);
        }
        [TestMethod]
        public void Decimal_Box()
        {
            var v = (ITypeMaxMinValues)DecimalMaxMinValues.Value;
            Assert.AreEqual(decimal.MaxValue, (decimal)v.MaxValue!);
            Assert.AreEqual(decimal.MinValue, (decimal)v.MinValue!);
        }
        [TestMethod]
        public void EqualsHashCodeString()
        {
            Assert.AreEqual(DecimalMaxMinValues.Value.GetHashCode(), DecimalMaxMinValues.Value.GetHashCode());
            Assert.AreNotEqual(DecimalMaxMinValues.Value.GetHashCode(), NumericMaxMinValues.UInt.GetHashCode());
            Assert.AreEqual(DecimalMaxMinValues.Value.ToString(), DecimalMaxMinValues.Value.ToString());
            Assert.AreNotEqual(DecimalMaxMinValues.Value.ToString(), NumericMaxMinValues.UInt.ToString());
            Assert.IsFalse(DecimalMaxMinValues.Value.Equals(NumericMaxMinValues.UInt));
            Assert.IsTrue(DecimalMaxMinValues.Value.Equals(DecimalMaxMinValues.Value));
            Assert.IsFalse(DecimalMaxMinValues.Value.Equals(null));
            Assert.IsTrue(DecimalMaxMinValues.Value == DecimalMaxMinValues.Value);
            Assert.IsFalse(DecimalMaxMinValues.Value != DecimalMaxMinValues.Value);
        }
        [TestMethod]
        public void Decimal_IsIn()
        {
            var v = new DecimalMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10m));
            Assert.IsFalse(v.IsIn(101m));
        }
        [TestMethod]
        public void Decimal_IsIn_Zoom()
        {
            var v = new DecimalMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10*12, new ValueIsInOptions<decimal> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(100 * 12, new ValueIsInOptions<decimal> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(55 * 12, new ValueIsInOptions<decimal> { Zoom = 12 }));
            Assert.IsFalse(v.IsIn(10 * 12 - 1, new ValueIsInOptions<decimal> { Zoom = 12 }));
        }
        [TestMethod]
        public void Decimal_IsIn_Close()
        {
            var v = new DecimalMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10, new ValueIsInOptions<decimal> { MinNotEquals = false }));
            Assert.IsFalse(v.IsIn(10, new ValueIsInOptions<decimal> { MinNotEquals = true }));

            Assert.IsTrue(v.IsIn(100, new ValueIsInOptions<decimal> { MaxNotEquals = false }));
            Assert.IsFalse(v.IsIn(100, new ValueIsInOptions<decimal> { MaxNotEquals = true }));
        }
        [TestMethod]
        public void Decimal_BigInt_IsIn_Zoom()
        {
            var v = new DecimalMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10 * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(100 * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(55 * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsFalse(v.IsIn(10 * 12 - 1, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
        }
        [TestMethod]
        public void Decimal_BigInt_IsIn_Close()
        {
            var v = new DecimalMaxMinValues(10, 100);
            Assert.IsTrue(v.IsIn(10, new ValueIsInOptions<BigInteger> { MinNotEquals = false }));
            Assert.IsFalse(v.IsIn(10, new ValueIsInOptions<BigInteger> { MinNotEquals = true }));

            Assert.IsTrue(v.IsIn(100, new ValueIsInOptions<BigInteger> { MaxNotEquals = false }));
            Assert.IsFalse(v.IsIn(100, new ValueIsInOptions<BigInteger> { MaxNotEquals = true }));
        }
    }
}
