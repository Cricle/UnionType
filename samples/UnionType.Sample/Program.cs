namespace UnionType.Sample
{
    internal class Program
    {
        unsafe static void Main(string[] args)
        {
            Console.WriteLine("Decimal size:" + sizeof(decimal));
            Console.WriteLine("UnionValue size:" + sizeof(UnionValue));

            Console.WriteLine();

            var a = new UnionValue { Int = 123 };
            Console.WriteLine("Can be primary type:" + a);

            Console.WriteLine();

            var buffer = a.ToBytes();
            var v = BitConverter.ToInt32(buffer);
            Console.WriteLine("Can translate primary type by byte[]:" + v);

            Console.WriteLine();

            var it = 333.123;
            UnionValue itUv = it;
            Console.WriteLine("Can implicit cast(from):" + itUv);

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
            Console.WriteLine("Can from bytes:" + bsUv);
        }
    }

    public class Student
    {
        public int Id { get; set; }
    }
}