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
        public void Free_WhenSwitch()
        {
            var uv = new UnionValue();
            var a = new A();
            var b = new B();

            var memStart = GC.GetTotalMemory(true);

            for (int i = 0; i < 100_000; i++)
            {
                if (i%2==0)
                {
                    uv.Object = a;
                }
                else
                {
                    uv.Object = b;
                }
            }
            var memEnd = GC.GetTotalMemory(true);
            Console.WriteLine($"Up memory:{(memEnd-memStart)/1024/1024.0:F5}MB");
        }
    }
}
