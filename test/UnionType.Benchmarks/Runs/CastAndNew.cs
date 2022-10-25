using BenchmarkDotNet.Attributes;

namespace UnionType.Benchmarks.Runs
{
    [MemoryDiagnoser]
    public class CastAndNew
    {
        private readonly decimal value = 123;
        [Params(100, 1_000_000)]
        public int Count { get; set; }

        [Benchmark]
        public void Cast()
        {
            for (int i = 0; i < Count; i++)
            {
                UnionValue _ = value;
            }
        }

        [Benchmark(Baseline = true)]
        public void New()
        {
            for (int i = 0; i < Count; i++)
            {
                var _ = new UnionValue { Decimal = i };
            }
        }
    }
}
