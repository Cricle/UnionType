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
        [Params(500, 100_000)]
        public int Count { get; set; }

        public VsDecimal()
        {
            values1 = new List<decimal>(0);
            values2 = new List<UnionValue>(0);
            values3 = new List<object>(0);
        }

        private List<decimal> values1 = new List<decimal>(0);
        private List<UnionValue> values2 = new List<UnionValue>(0);
        private List<object> values3 = new List<object>(0);

        [Benchmark(Baseline = true)]
        public void Decimal()
        {
            for (int i = 0; i < Count; i++)
            {
                values1.Add(i);
            }
            for (int i = 0; i < Count; i++)
            {
                _=values1[i];
            }
            values1.Clear();
        }

        [Benchmark]
        public void Union()
        {
            for (int i = 0; i < Count; i++)
            {
                values2.Add(new UnionValue { Decimal = i });
            }
            for (int i = 0; i < Count; i++)
            {
                _ = values2[i].Decimal;
            }
            values2.Clear();
        }
        [Benchmark]
        public void Box()
        {
            for (int i = 0; i < Count; i++)
            {
                values3.Add((decimal)i);
            }
            for (int i = 0; i < Count; i++)
            {
                _ = (decimal)values3[i];
            }
            values3.Clear();
        }
    }
}
