using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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
            Assert.AreEqual((int)char.MaxValue, (int)NumericMaxMinValues.Char.MaxValue);
            Assert.AreEqual((int)char.MinValue, (int)NumericMaxMinValues.Char.MinValue);
        }
        [TestMethod]
        public void Numeric_Short()
        {
            Assert.AreEqual((short)short.MaxValue, (short)NumericMaxMinValues.Short.MaxValue);
            Assert.AreEqual((short)short.MinValue, (short)NumericMaxMinValues.Short.MinValue);
        }
        [TestMethod]
        public void Numeric_UShort()
        {
            Assert.AreEqual((ushort)ushort.MaxValue, (ushort)NumericMaxMinValues.UShort.MaxValue);
            Assert.AreEqual((ushort)ushort.MinValue, (ushort)NumericMaxMinValues.UShort.MinValue);
        }
        [TestMethod]
        public void Numeric_Int()
        {
            Assert.AreEqual((int)int.MaxValue, (int)NumericMaxMinValues.Int.MaxValue);
            Assert.AreEqual((int)int.MinValue, (int)NumericMaxMinValues.Int.MinValue);
        }
        [TestMethod]
        public void Numeric_UInt()
        {
            Assert.AreEqual((uint)uint.MaxValue, (uint)NumericMaxMinValues.UInt.MaxValue);
            Assert.AreEqual((uint)uint.MinValue, (uint)NumericMaxMinValues.UInt.MinValue);
        }
        [TestMethod]
        public void Numeric_Long()
        {
            Assert.AreEqual((long)long.MaxValue, (long)NumericMaxMinValues.Long.MaxValue);
            Assert.AreEqual((long)long.MinValue, (long)NumericMaxMinValues.Long.MinValue);
        }
        [TestMethod]
        public void Numeric_ULong()
        {
            Assert.AreEqual((ulong)ulong.MaxValue, (ulong)NumericMaxMinValues.ULong.MaxValue);
            Assert.AreEqual((ulong)ulong.MinValue, (ulong)NumericMaxMinValues.ULong.MinValue);
        }
    }
}
