namespace UnionType.Sample
{
    internal class Program
    {
        unsafe static void Main(string[] args)
        {
            var size = sizeof(UnionValue);
            Console.WriteLine(size);
            size = sizeof(decimal);
            Console.WriteLine(size);
            var a = new UnionValue { Int = 123 };
            var buffer = a.ToBytes();
            Console.WriteLine(a.ToString());
            var v = BitConverter.ToInt32(buffer);
            Console.WriteLine(v);
        }
    }
}