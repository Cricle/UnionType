using BenchmarkDotNet.Attributes;

namespace UnionType.Benchmarks.Runs
{
    [MemoryDiagnoser]
    public class StoreObject
    {
        [Params(500, 1_000_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public void Raw()
        {
            for (int i = 0; i < Count; i++)
            {
                _ = new object();
            }
        }
        [Benchmark]
        public void UnionObject()
        {
            for (int i = 0; i < Count; i++)
            {
                new UnionValue { Object = new object() };
            }
        }
    }

}
