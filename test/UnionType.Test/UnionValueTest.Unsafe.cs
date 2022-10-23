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
        [TestMethod]
        public unsafe void ToPointer_Write()
        {
            var uv = new UnionValue { Int = 123 };
            int* ptr = (int*)uv.ToPointer();
            *ptr = 456;
            Assert.AreEqual(456, uv.Int);
        }
        [TestMethod]
        public unsafe void AsSpan()
        {
            var uv = new UnionValue { Int = 123 };
            var ptr = uv.AsSpan();
            var back = UnionValue.FromBytes(ptr);
            Assert.IsTrue(uv.ToBytes().SequenceEqual(back.ToBytes()));
        }
    }
}
