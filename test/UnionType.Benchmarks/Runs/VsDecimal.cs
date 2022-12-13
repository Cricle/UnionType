using BenchmarkDotNet.Attributes;

namespace UnionType.Benchmarks.Runs
{
    [MemoryDiagnoser]
    public class VsDecimal
    {
        [Params(500, 100_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public void Decimal()
        {
            for (int i = 0; i < Count; i++)
            {
                var a = (decimal)i;
            }
        }

        [Benchmark]
        public void Union()
        {
            for (int i = 0; i < Count; i++)
            {
                new UnionValue { @decimal = i, unionValueType = UnionValueType.Decimal };
            }
        }
        [Benchmark]
        public void Box()
        {
            for (int i = 0; i < Count; i++)
            {
                var a = (object)(decimal)i;
            }
        }
    }
}
