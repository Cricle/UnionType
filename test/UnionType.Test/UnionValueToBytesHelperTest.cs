using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnionType.Test
{
    [TestClass]
    public class UnionValueToBytesHelperTest
    {
        [TestMethod]
        public void ToBytesValue()
        {
            var helper = new UnionValueToBytesHelper(Encoding.UTF8);
            var uv = new UnionValue();
            uv.String = "123";
            var bs=helper.ToBytes(uv);
            Assert.IsNotNull(bs);
            uv = helper.ToValue(bs.ToArray());
            Assert.AreEqual("123",uv.String);
        }
        [TestMethod]
        public void ToBytesObject()
        {
            var opt = new JsonSerializerOptions();
            opt.Converters.Add(new UnionValueJsonConverter(new JsonUnionValueTransformer(opt)));
            var uv = new UnionValue();
            var stu = new Student
            {
                A = 123
            };
            stu.Value = new UnionValue();
            stu.Value = 123;
            uv.SetObject(stu);
            for (int i = 0; i < 10; i++)
            {
                var str = JsonSerializer.Serialize(uv, opt);
                var obj = JsonSerializer.Deserialize<UnionValue>(str, opt);
                var s = (Student)obj.Object;
                Assert.AreEqual(stu.A, s.A);
                Assert.AreEqual(stu.Value, s.Value);
            }
        }
        [TestMethod]
        public void ToBytesString()
        {
            var opt = new JsonSerializerOptions();
            opt.Converters.Add(new UnionValueJsonConverter(new JsonUnionValueTransformer(opt)));
            var uv = new UnionValue();
            var stu = new Student
            {
                A = 123
            };
            stu.Value = new UnionValue();
            stu.Value = "aaasssddd";
            uv.SetObject(stu);
            for (int i = 0; i < 10; i++)
            {
                var str = JsonSerializer.Serialize(uv, opt);
                var obj = JsonSerializer.Deserialize<UnionValue>(str, opt);
                var s = (Student)obj.Object;
                Assert.AreEqual(stu.A, s.A);
                Assert.AreEqual(stu.Value, s.Value);
            }
        }
        class Student
        {
            public int A { get; set; }

            public UnionValue Value { get; set; }
        }
    }
    class JsonUnionValueTransformer : IUnionValueTransformer
    {
        public JsonUnionValueTransformer(JsonSerializerOptions options)
        {
            Options = options;
        }

        public JsonSerializerOptions Options { get; }

        public object? BytesToObject(byte[] buffer,int startIndex,int count, Type type)
        {
           return JsonSerializer.Deserialize(buffer.AsSpan(startIndex,count), type,Options);
        }

        public byte[] ObjectToBytes(object value, Type type)
        {
            return JsonSerializer.SerializeToUtf8Bytes(value, type, Options);
        }
    }
    class UnionValueJsonConverter : JsonConverter<UnionValue>
    {
        public UnionValueJsonConverter(JsonUnionValueTransformer transformer)
        {
            Transformer = transformer;
        }

        public JsonUnionValueTransformer Transformer { get; }

        public override UnionValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var bs = reader.GetBytesFromBase64();
            return new UnionValueToBytesHelper(Encoding.UTF8, Transformer)
                .ToValue(bs);
        }

        public override void Write(Utf8JsonWriter writer, UnionValue value, JsonSerializerOptions options)
        {
            var helper = new UnionValueToBytesHelper(Encoding.UTF8, Transformer);
            writer.WriteBase64StringValue(helper.ToBytes(value).ToArray());
        }
    }
}
