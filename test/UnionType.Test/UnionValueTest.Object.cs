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
        [TestMethod]
        public void TypeNameIntPtrFree()
        {
            var a = new B { Name = "123" };
            var val = new UnionValue();
            for (int i = 0; i < 2; i++)
            {
                val.SetObject(a);
                var back = val.GetObject<B>();
                Assert.AreEqual(a.Name, back.Name);
                Assert.AreEqual(a.GetType().AssemblyQualifiedName, val.TypeNameString);
                Assert.AreEqual(a.GetType(), val.TypeNameType);
            }
        }
        [TestMethod]
        public void Null_ReturnNulls()
        {
            var val = new UnionValue();
            Assert.IsNull(val.TypeNameString);
            Assert.IsNull(val.TypeNameType);
        }
        [TestMethod]
        public void SetNull_WillZeroPtr()
        {
            var val = new UnionValue();
            val.TypeNameString = null;
            Assert.AreEqual(IntPtr.Zero, val.TypeName);
        }
        [TestMethod]
        public void TypeNameVisit()
        {
            var val = new UnionValue();
            val.TypeName = new IntPtr(123);
            Assert.AreEqual(new IntPtr(123), val.TypeName);
        }
        [TestMethod]
        public void SetEmptyObjectType_MustSetEmpty()
        {
            var val = new UnionValue();
            val.TypeNameType = null;
            Assert.IsNull(val.TypeNameString);
        }
    }
}
