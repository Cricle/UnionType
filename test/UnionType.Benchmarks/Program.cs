using BenchmarkDotNet.Running;

namespace UnionType.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run();
        }
    }
}