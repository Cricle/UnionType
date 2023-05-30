using BenchmarkDotNet.Attributes;

namespace UnionType.Benchmarks.Runs
{
    [MemoryDiagnoser]
    public class StoreObject
    {
        [Params(500, 1_000_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public void Normal()
        {
            var obj = new object[Count];
            for (int i = 0; i < Count; i++)
            {
                obj[i] = new object();
            }
        }
        [Benchmark]
        public void UnionObject()
        {
            var obj = new UnionValue[Count];
            for (int i = 0; i < Count; i++)
            {
                obj[i] = new UnionValue { Object = new object() };
            }
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].Dispose();
            }
        }
    }

}
