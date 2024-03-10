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
        public void BitsEmpty()
        {
            Assert.AreEqual(0, UnionValue.GetBitsSize(UnionValueType.Empty));
        }
        [TestMethod]
        [DataRow(UnionValueType.Object)]
        [DataRow(UnionValueType.String)]
        [DataRow(UnionValueType.DBNull)]
        [DataRow(UnionValueType.IntPtr)]
        public void BitsIntPtr(UnionValueType type)
        {
            Assert.AreEqual(16, UnionValue.GetBitsSize(type));
        }
        [TestMethod]
        public void BitsChar()
        {
            Assert.AreEqual(sizeof(char), UnionValue.GetBitsSize(UnionValueType.Char));
        }
        [TestMethod]
        public void BitsBool()
        {
            Assert.AreEqual(sizeof(bool), UnionValue.GetBitsSize(UnionValueType.Boolean));
        }
        [TestMethod]
        public void BitsByte()
        {
            Assert.AreEqual(sizeof(byte), UnionValue.GetBitsSize(UnionValueType.Byte));
        }
        [TestMethod]
        public void BitsSByte()
        {
            Assert.AreEqual(sizeof(sbyte), UnionValue.GetBitsSize(UnionValueType.SByte));
        }
        [TestMethod]
        public void BitsShort()
        {
            Assert.AreEqual(sizeof(short), UnionValue.GetBitsSize(UnionValueType.Int16));
        }
        [TestMethod]
        public void BitsUShort()
        {
            Assert.AreEqual(sizeof(ushort), UnionValue.GetBitsSize(UnionValueType.UInt16));
        }
        [TestMethod]
        public void BitsInt()
        {
            Assert.AreEqual(sizeof(int), UnionValue.GetBitsSize(UnionValueType.Int32));
        }
        [TestMethod]
        public void BitsUInt()
        {
            Assert.AreEqual(sizeof(uint), UnionValue.GetBitsSize(UnionValueType.UInt32));
        }
        [TestMethod]
        public void BitsLong()
        {
            Assert.AreEqual(sizeof(long), UnionValue.GetBitsSize(UnionValueType.Int64));
        }
        [TestMethod]
        public void BitsULong()
        {
            Assert.AreEqual(sizeof(ulong), UnionValue.GetBitsSize(UnionValueType.UInt64));
        }
        [TestMethod]
        public void BitsFloat()
        {
            Assert.AreEqual(sizeof(float), UnionValue.GetBitsSize(UnionValueType.Single));
        }
        [TestMethod]
        public void BitsDouble()
        {
            Assert.AreEqual(sizeof(double), UnionValue.GetBitsSize(UnionValueType.Double));
        }
        [TestMethod]
        public void BitsDecimal()
        {
            Assert.AreEqual(sizeof(decimal), UnionValue.GetBitsSize(UnionValueType.Decimal));
        }
        [TestMethod]
        public void BitsTimeSpan()
        {
            Assert.AreEqual(sizeof(long), UnionValue.GetBitsSize(UnionValueType.TimeSpan));
        }
        [TestMethod]
        public void BitsDateTime()
        {
            Assert.AreEqual(sizeof(long), UnionValue.GetBitsSize(UnionValueType.DateTime));
        }
        [TestMethod]
        public void BitsGuid()
        {
            Assert.AreEqual(16, UnionValue.GetBitsSize(UnionValueType.Guid));
        }
        [TestMethod]
        public void BitsNoSupport()
        {
            Assert.ThrowsException<NotSupportedException>(() => UnionValue.GetBitsSize((UnionValueType)byte.MaxValue));
        }
        [TestMethod]
        public void CleanNoUsed_HasBits()
        {
            var uv = new UnionValue { @long = long.MaxValue, @object = TypeInfo.Int32Info};
            uv.@int = 123;
            var act=UnionValue.CleanNoUsed(ref uv);
            Assert.AreEqual(17 - 1 - sizeof(int), act);
            Assert.AreEqual(123, uv.@long);
        }
        [TestMethod]
        public void CleanNoUsed_NoBits()
        {
            var uv = new UnionValue { Decimal=123};
            var act = UnionValue.CleanNoUsed(ref uv);
            Assert.AreEqual(0, act);
            Assert.AreEqual(123m, uv.Decimal);
        }
    }
}
