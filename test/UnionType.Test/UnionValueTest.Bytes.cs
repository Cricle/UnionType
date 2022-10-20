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
        public void ToBytesAndConvertBack()
        {
            var a = 123;
            var bs = UnionValue.FromBytes(BitConverter.GetBytes(a));
            bs.UnionValueType = UnionValueType.Int32;
            Assert.AreEqual(a, bs.Int);
            var back = BitConverter.ToInt32(bs.ToBytes());
            Assert.AreEqual(a, back);
        }
    }
}
