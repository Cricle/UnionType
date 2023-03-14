using BenchmarkDotNet.Attributes;
using System.Numerics;

namespace UnionType.Benchmarks.Runs
{
    [MemoryDiagnoser]
    public class Create
    {
        [Params(500, 5_000_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public void FromGeneric()
        {
            for (int i = 0; i < Count; i++)
            {
                UnionValueCreator<int>.Create(i);
            }
        }
        [Benchmark]
        public void FromDynamic()
        {
            for (int i = 0; i < Count; i++)
            {
                dynamic _ = i;
            }
        }
        [Benchmark]
        public void FromObject()
        {
            for (int i = 0; i < Count; i++)
            {
                _ = UnionValue.FromObject((object)i);
            }
        }
        [Benchmark]
        public void BigInteger()
        {
            for (int i = 0; i < Count; i++)
            {
                _ = new BigInteger(i);
            }
        }
    }

}
