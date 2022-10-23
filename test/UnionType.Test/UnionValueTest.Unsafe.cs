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
        public unsafe void ToPointer()
        {
            var uv = new UnionValue { Int = 123 };
            var ptr= uv.ToPointer();
            var @int = *(int*)ptr;
            Assert.AreEqual(123, @int);
        }
    }
}
