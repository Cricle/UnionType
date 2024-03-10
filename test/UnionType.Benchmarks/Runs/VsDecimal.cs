using BenchmarkDotNet.Attributes;

namespace UnionType.Benchmarks.Runs
{
    [MemoryDiagnoser]
    public class VsDecimal
    {
        [Params(500, 5_000_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public void Decimal()
        {
            var v = new List<decimal>();
            for (int i = -Count; i < 0; i++)
            {
                v.Add(new decimal(i));
            }
        }

        [Benchmark]
        public void Union()
        {
            var v = new List<UnionValue>();
            for (int i = -Count; i < 0; i++)
            {
                v.Add(UnionValue.FromAsDecimal(i));
            }
        }
        [Benchmark]
        public void Dynamic()
        {
            var v = new List<dynamic>();
            for (int i = -Count; i < 0; i++)
            {
                v.Add(i);
            }
        }
        [Benchmark]
        public void Box()
        {
            var v = new List<object>();
            for (int i = -Count; i < 0; i++)
            {
                v.Add((decimal)i);
            }
        }
    }

}
