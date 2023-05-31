using BenchmarkDotNet.Attributes;

namespace UnionType.Benchmarks.Runs
{
    [MemoryDiagnoser]
    public class StoreObject
    {
        [Params(500, 1_000_000)]
        public int Count { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            UnionValue.ObjectWithType = false;
        }
        [Benchmark]
        public void UnionObject()
        {
            for (int i = 0; i < Count; i++)
            {
                new UnionValue { Object = new object() }.Dispose();
            }
        }
    }

}
