using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;

namespace UnionType.Sample
{
    internal class Program
    {
        static unsafe void Main(string[] args)
        {
            var num = new NumericMaxMinValues(sizeof(int), true);
            Console.WriteLine($"Min:{int.MinValue}  vs  {num.MinValue}");
            Console.WriteLine($"Max:{int.MaxValue}  vs  {num.MaxValue}");
            Console.WriteLine("Decimal size:" + sizeof(decimal));
            Console.WriteLine("UnionValue size:" + sizeof(UnionValue));

            Console.WriteLine();

            var a = new UnionValue { Int = 123 };
            Console.WriteLine("Can be primary type:" + a.ToString());

            Console.WriteLine();

            var buffer = a.ToBytes();
            var v = BitConverter.ToInt32(buffer);
            Console.WriteLine("Can translate primary type by byte[]:" + v);

            Console.WriteLine();

            var it = 333.123;
            UnionValue itUv = it;
            Console.WriteLine("Can implicit cast(from):" + itUv.ToString());

            Console.WriteLine();

            it = itUv;
            Console.WriteLine("Can implicit cast(to):" + it);

            Console.WriteLine();

            var stu = new Student { Id = 123 };
            var stuUv = new UnionValue();
            stuUv.SetObject(stu);
            var stuBack = stuUv.GetObject();
            Console.WriteLine("Can store instance:");
            Console.WriteLine("Origan hash:" + stu.GetHashCode());
            Console.WriteLine("Back hash  :" + stuBack.GetHashCode());

            Console.WriteLine();

            var bs = BitConverter.GetBytes(123.123d);
            var bsUv = UnionValue.FromBytes(bs);
            bsUv.UnionValueType = UnionValueType.Double;
            Console.WriteLine("Can from bytes:" + bsUv.ToString());

            Console.WriteLine();

            var uv = NumericMaxMinValues.Int * 1024;
            Console.WriteLine("Range:" + uv + " is in range:" + uv.IsIn(new BigInteger(int.MaxValue) * 10 + 1));

            Console.WriteLine();
            var sw = Stopwatch.GetTimestamp();
            var bg = new BigInteger(int.MaxValue);
            for (int i = 0; i < 1_000_000; i++)
            {
                uv.IsIn(bg);
            }
            Console.WriteLine("Comparer:10_000_000, elsp:" + new TimeSpan(Stopwatch.GetTimestamp() - sw));

            Console.WriteLine();
            sw = Stopwatch.GetTimestamp();
            var duvMax = (decimal)uv.MaxValue;
            var duvMin = (decimal)uv.MinValue;
            for (int i = 0; i < 1_000_000; i++)
            {
                _ = int.MaxValue >= duvMin && int.MaxValue <= duvMax;
            }
            Console.WriteLine("Raw Comparer:10_000_000, elsp:" + new TimeSpan(Stopwatch.GetTimestamp() - sw));
        }
    }

    public class Student
    {
        public int Id { get; set; }
    }
}