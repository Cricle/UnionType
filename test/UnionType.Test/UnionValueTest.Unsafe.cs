using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public unsafe void Size()
        {
            Assert.AreEqual(Unsafe.SizeOf<UnionValue>(), UnionValue.Size);
            Debug.WriteLine(UnionValue.Size);
        }
        [TestMethod]
        public unsafe void ToPointer()
        {
            var uv = new UnionValue { Int = 123 };
            var ptr = uv.ToPointer();
            var @int = *(int*)ptr;
            Assert.AreEqual(123, @int);
        }
        [TestMethod]
        public unsafe void ToPointer_Unmanage()
        {
            var uv = new UnionValue { Int = 123 };
            var ptr = uv.ToPointer<int>();
            var @int = *ptr;
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
        [TestMethod]
        public unsafe void AsSpan_Unmanager()
        {
            var uv = new UnionValue { Int = 123 };
            var ptr = uv.AsSpan<int>();
            Assert.AreEqual(123, ptr[0]);
        }
        [TestMethod]
        public unsafe void GetRef()
        {
            var uv = new UnionValue { Int = 123 };
            ref byte @ref = ref uv.GetReference();
            ref int data =ref Unsafe.AsRef<int>(Unsafe.AsPointer(ref @ref));
            Assert.AreEqual(123, data);
        }
        [TestMethod]
        public unsafe void GetRef_Any()
        {
            var uv = new UnionValue { Int = 123 };
            ref int @ref =ref uv.GetReference<int>();
            @ref = 456;
            Assert.AreEqual(456, uv.Int);
        }
    }
}
