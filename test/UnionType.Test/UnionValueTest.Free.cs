namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        class A
        {

        }
        class B { }
        [TestMethod]
        public void Free_WhenSwitch()
        {
            var uv = new UnionValue();
            var a = new A();
            var b = new B();

            var memStart = GC.GetTotalMemory(true);

            for (int i = 0; i < 100_000; i++)
            {
                if (i % 2 == 0)
                {
                    uv.Object = a;
                }
                else
                {
                    uv.Object = b;
                }
            }
            var memEnd = GC.GetTotalMemory(true);
            Console.WriteLine($"Up memory:{(memEnd - memStart) / 1024 / 1024.0:F5}MB");
        }
        [TestMethod]
        public void Free_With_String()
        {
            var uv = new UnionValue();
            uv.String = "123";
            uv.String = "456";
            Assert.AreEqual("456", uv.String);
        }
    }
}
