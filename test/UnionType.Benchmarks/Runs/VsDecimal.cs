using BenchmarkDotNet.Attributes;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace UnionType.Benchmarks.Runs
{
    [MemoryDiagnoser]
    public class VsDecimal
    {
        [Params(5000, 5_000_000)]
        public int Count { get; set; }

        [Benchmark(Baseline = true)]
        public void Decimal()
        {
            var lst =new decimal[Count];
            for (int i = 0; i < Count; i++)
            {
                lst[i] = i;
            }
        }

        [Benchmark]
        public void Union()
        {
            var lst = new UnionValue[Count];
            for (int i = 0; i < Count; i++)
            {
                Unsafe.SkipInit(out UnionValue v);
                v.decimal_hi32 = (uint)i;
                v.unionValueType = UnionValueType.Decimal;
                lst[i] = v;
            }
        }
        [Benchmark]
        public void Box()
        {
            var lst = new object[Count];
            for (int i = 0; i < Count; i++)
            {
                lst[i]=(decimal)i;
            }
        }
        [Benchmark]
        public void BigInteger()
        {
            var lst = new BigInteger[Count];
            for (int i = 0; i < Count; i++)
            {
                lst[i] = i;
            }
        }
    }
}
