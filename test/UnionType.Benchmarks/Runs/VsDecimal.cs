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
            var c = new decimal[Count];
            for (int i = 0; i < Count; i++)
            {
                c[i] = i;
            }
        }

        [Benchmark]
        public void Union()
        {
            var c = new UnionValue[Count];
            for (int i = 0; i < Count; i++)
            {
                c[i] = new UnionValue { Decimal = i };
            }
        }
    }
}
