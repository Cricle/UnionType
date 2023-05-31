using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public void GCHandlerType()
        {
            var obj = new object();
            var uv = new UnionValue();
            uv.SetObject(obj, GCHandleType.Normal);
            Assert.AreEqual(GCHandleType.Normal, uv.GCHandleType);
            obj = null;
            GC.Collect();
            var back = uv.GetObject();
            Assert.IsNotNull(back);
            uv.Dispose();
        }
        [TestMethod]
        public void GCHandlerType_Changed()
        {
            var obj = new object();
            var uv = new UnionValue();
            uv.GCHandleType = GCHandleType.Weak;
            uv.Object = obj;
            obj = null;
            GC.Collect();
            Assert.IsNull(uv.TypeGCHandler.Target);
            uv.Dispose();
        }
        [TestMethod]
        public void WithNoName_NotStoreTypeName()
        {
            UnionValue.ObjectWithType = false;
            Assert.IsFalse(UnionValue.ObjectWithType);
            var uv = new UnionValue();
            uv.Object = new object();
            Assert.IsTrue(uv.TypeName == IntPtr.Zero);
            uv.Dispose();
            UnionValue.ObjectWithType = true;
        }
    }
}
