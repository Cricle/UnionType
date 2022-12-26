using BenchmarkDotNet.Attributes;
using System.Numerics;
using System.Runtime.CompilerServices;

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
            for (int i = -Count; i < 0; i++)
            {
                _= new decimal(i);
            }
        }

        [Benchmark]
        public void Union()
        {
            for (int i = -Count; i < 0; i++)
            {
                UnionValue.FromAsDecimal(i);
            }
        }
        [Benchmark]
        public void Box()
        {
            for (int i = -Count; i < 0; i++)
            {
                _ =(object)(decimal)i;
            }
        }
        [Benchmark]
        public void BigInteger()
        {
            for (int i = -Count; i < 0; i++)
            {
                _ = new BigInteger(i);
            }
        }
    }
}
