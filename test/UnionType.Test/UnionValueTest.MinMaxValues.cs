using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public void GetMaxMinValues()
        {
            var val = new UnionValue { Int = 34 };
            var mmv = val.GetMaxMinValues();
            Assert.IsNotNull(mmv);
            Assert.AreEqual(int.MaxValue, (int)(BigInteger)mmv.MaxValue!);
        }
    }
}
