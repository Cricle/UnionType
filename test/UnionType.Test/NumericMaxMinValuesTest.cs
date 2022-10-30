using System.Numerics;

namespace UnionType.Test
{
    [TestClass]
    public class NumericMaxMinValuesTest
    {
        [TestMethod]
        public void Numeric_Byte()
        {
            Assert.AreEqual(byte.MaxValue, (byte)NumericMaxMinValues.Byte.MaxValue);
            Assert.AreEqual(byte.MinValue, (byte)NumericMaxMinValues.Byte.MinValue);
        }
        [TestMethod]
        public void Numeric_Byte_Box()
        {
            Assert.AreEqual(byte.MaxValue, (BigInteger)((ITypeMaxMinValues)NumericMaxMinValues.Byte).MaxValue!);
            Assert.AreEqual(byte.MinValue, (BigInteger)((ITypeMaxMinValues)NumericMaxMinValues.Byte).MinValue!);
        }
        [TestMethod]
        public void Numeric_SByte()
        {
            Assert.AreEqual(sbyte.MaxValue, (sbyte)NumericMaxMinValues.SByte.MaxValue);
            Assert.AreEqual(sbyte.MinValue, (sbyte)NumericMaxMinValues.SByte.MinValue);
        }
        [TestMethod]
        public void Numeric_Char()
        {
            Assert.AreEqual(char.MaxValue, (int)NumericMaxMinValues.Char.MaxValue);
            Assert.AreEqual(char.MinValue, (int)NumericMaxMinValues.Char.MinValue);
        }
        [TestMethod]
        public void Numeric_Short()
        {
            Assert.AreEqual(short.MaxValue, (short)NumericMaxMinValues.Short.MaxValue);
            Assert.AreEqual(short.MinValue, (short)NumericMaxMinValues.Short.MinValue);
        }
        [TestMethod]
        public void Numeric_UShort()
        {
            Assert.AreEqual(ushort.MaxValue, (ushort)NumericMaxMinValues.UShort.MaxValue);
            Assert.AreEqual(ushort.MinValue, (ushort)NumericMaxMinValues.UShort.MinValue);
        }
        [TestMethod]
        public void Numeric_Int()
        {
            Assert.AreEqual(int.MaxValue, (int)NumericMaxMinValues.Int.MaxValue);
            Assert.AreEqual(int.MinValue, (int)NumericMaxMinValues.Int.MinValue);
        }
        [TestMethod]
        public void Numeric_UInt()
        {
            Assert.AreEqual(uint.MaxValue, (uint)NumericMaxMinValues.UInt.MaxValue);
            Assert.AreEqual(uint.MinValue, (uint)NumericMaxMinValues.UInt.MinValue);
        }
        [TestMethod]
        public void Numeric_Long()
        {
            Assert.AreEqual(long.MaxValue, (long)NumericMaxMinValues.Long.MaxValue);
            Assert.AreEqual(long.MinValue, (long)NumericMaxMinValues.Long.MinValue);
        }
        [TestMethod]
        public void Numeric_ULong()
        {
            Assert.AreEqual(ulong.MaxValue, (ulong)NumericMaxMinValues.ULong.MaxValue);
            Assert.AreEqual(ulong.MinValue, (ulong)NumericMaxMinValues.ULong.MinValue);
        }
        [TestMethod]
        public void EqualsHashCodeString()
        {
            Assert.AreEqual(NumericMaxMinValues.ULong.GetHashCode(), NumericMaxMinValues.ULong.GetHashCode());
            Assert.AreNotEqual(NumericMaxMinValues.Long.GetHashCode(), NumericMaxMinValues.ULong.GetHashCode());
            Assert.AreEqual(NumericMaxMinValues.Long.ToString(), NumericMaxMinValues.Long.ToString());
            Assert.AreNotEqual(NumericMaxMinValues.Long.ToString(), NumericMaxMinValues.ULong.ToString());
            Assert.IsFalse(NumericMaxMinValues.Long.Equals(NumericMaxMinValues.ULong));
            Assert.IsTrue(NumericMaxMinValues.Long.Equals(NumericMaxMinValues.Long));
            Assert.IsFalse(NumericMaxMinValues.Long.Equals(null));
            Assert.IsTrue(NumericMaxMinValues.Long == NumericMaxMinValues.Long);
            Assert.IsTrue(NumericMaxMinValues.Long != NumericMaxMinValues.ULong);
        }
        [TestMethod]
        public void Numeric_Pow()
        {
            var v = NumericMaxMinValues.Byte;
            v = v * 12;
            Assert.AreEqual(v.MaxValue, byte.MaxValue * 12);
            Assert.AreEqual(v.MinValue, byte.MinValue * 12);
        }
        [TestMethod]
        public void Numeric_Div()
        {
            var v = NumericMaxMinValues.Byte;
            v = v / 12;
            Assert.AreEqual(v.MaxValue, byte.MaxValue / 12);
            Assert.AreEqual(v.MinValue, byte.MinValue / 12);
        }
        [TestMethod]
        public void Numeric_Add()
        {
            var v = NumericMaxMinValues.Byte;
            v = v + 12;
            Assert.AreEqual(v.MaxValue, byte.MaxValue + 12);
            Assert.AreEqual(v.MinValue, byte.MinValue + 12);
        }
        [TestMethod]
        public void Numeric_Sub()
        {
            var v = NumericMaxMinValues.Byte;
            v = v - 12;
            Assert.AreEqual(v.MaxValue, byte.MaxValue - 12);
            Assert.AreEqual(v.MinValue, byte.MinValue - 12);
        }
        [TestMethod]
        public void Numeric_Mod()
        {
            var v = NumericMaxMinValues.Byte;
            v = v % 12;
            Assert.AreEqual(v.MaxValue, byte.MaxValue % 12);
            Assert.AreEqual(v.MinValue, byte.MinValue % 12);
        }
        [TestMethod]
        public void Numeric_Neg()
        {
            var v = NumericMaxMinValues.Byte;
            v = -v;
            Assert.AreEqual(v.MaxValue, -byte.MaxValue);
            Assert.AreEqual(v.MinValue, -byte.MinValue);
        }
        [TestMethod]
        public void Numeric_Positive()
        {
            var v = NumericMaxMinValues.Byte;
            v = +v;
            Assert.AreEqual(v.MaxValue, +byte.MaxValue);
            Assert.AreEqual(v.MinValue, +byte.MinValue);
        }
        [TestMethod]
        public void Numeric_And()
        {
            var v = NumericMaxMinValues.Byte;
            v = v & 12;
            Assert.AreEqual(v.MaxValue, byte.MaxValue & 12);
            Assert.AreEqual(v.MinValue, byte.MinValue & 12);
        }
        [TestMethod]
        public void Numeric_Or()
        {
            var v = NumericMaxMinValues.Byte;
            v = v | 12;
            Assert.AreEqual(v.MaxValue, byte.MaxValue | 12);
            Assert.AreEqual(v.MinValue, byte.MinValue | 12);
        }
        [TestMethod]
        public void Numeric_Xor()
        {
            var v = NumericMaxMinValues.Byte;
            v = v ^ 12;
            Assert.AreEqual(v.MaxValue, byte.MaxValue ^ 12);
            Assert.AreEqual(v.MinValue, byte.MinValue ^ 12);
        }
        [TestMethod]
        public void Numeric_IsIn()
        {
            var v = NumericMaxMinValues.Byte;
            Assert.IsTrue(v.IsIn(1));
            Assert.IsFalse(v.IsIn(8888));
        }
        [TestMethod]
        public void Numeric_IsIn_Zoom()
        {
            var v = NumericMaxMinValues.SByte;
            Assert.IsTrue(v.IsIn(1,new ValueIsInOptions<BigInteger> { Zoom= 12 }));
            Assert.IsTrue(v.IsIn(sbyte.MaxValue * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsTrue(v.IsIn(sbyte.MinValue * 12, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
            Assert.IsFalse(v.IsIn(sbyte.MinValue * 12 - 1, new ValueIsInOptions<BigInteger> { Zoom = 12 }));
        }
        [TestMethod]
        public void Numeric_IsIn_Close()
        {
            var v = NumericMaxMinValues.Byte;
            Assert.IsTrue(v.IsIn(byte.MinValue, new ValueIsInOptions<BigInteger> { MinNotEquals = false }));
            Assert.IsFalse(v.IsIn(byte.MinValue, new ValueIsInOptions<BigInteger> { MinNotEquals = true }));

            Assert.IsTrue(v.IsIn(byte.MaxValue, new ValueIsInOptions<BigInteger> { MaxNotEquals = false }));
            Assert.IsFalse(v.IsIn(byte.MaxValue, new ValueIsInOptions<BigInteger> { MaxNotEquals = true }));
        }
    }
}
