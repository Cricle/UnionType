using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        class A
        {
            public string? Name { get; set; }
        }
        struct B
        {
            public string? Name { get; set; }
        }
        [TestMethod]
        public void StoreObject()
        {
            var a = new A { Name = "123" };
            var val = new UnionValue();
            val.SetObject(a);
            var back = val.GetObject<A>();
            Assert.AreEqual(a.Name, back.Name);
            Assert.AreEqual(a.GetType().AssemblyQualifiedName, val.TypeNameString);
            Assert.AreEqual(a.GetType(), val.TypeNameType);
        }
        [TestMethod]
        public void StoreNull()
        {
            var val = new UnionValue();
            val.SetObject(null);
            Assert.AreEqual(IntPtr.Zero, val.IntPtr);
            Assert.AreEqual(UnionValueType.Empty, val.UnionValueType);
        }
        [TestMethod]
        public void StoreStruct()
        {
            var a = new B { Name = "123" };
            var val = new UnionValue();
            val.SetObject(a);
            var back = val.GetObject<B>();
            Assert.AreEqual(a.Name, back.Name);
            Assert.AreEqual(a.GetType().AssemblyQualifiedName, val.TypeNameString);
            Assert.AreEqual(a.GetType(), val.TypeNameType);
        }
    }
}
