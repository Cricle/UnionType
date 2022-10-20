using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionType.Benchmarks.Runs
{
    [MemoryDiagnoser]
    public class VsDecimal
    {
        [Params(100, 1_000_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public void Decimal()
        {
            var c = new List<decimal>();
            for (int i = 0; i < Count; i++)
            {
                c.Add(i);
            }
        }

        [Benchmark]
        public void Union()
        {
            var c = new List<UnionValue>();
            for (int i = 0; i < Count; i++)
            {
                c.Add(new UnionValue { Decimal = i });
            }
        }
    }
}
