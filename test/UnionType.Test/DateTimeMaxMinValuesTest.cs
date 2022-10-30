using System.Numerics;

namespace UnionType.Test
{
    [TestClass]
    public class DateTimeMaxMinValuesTest
    {
        [TestMethod]
        public void MaxMinDateTime()
        {
            Assert.AreEqual(DateTime.MaxValue, DateTimeMaxMinValues.Value.MaxValue);
            Assert.AreEqual(DateTime.MinValue, DateTimeMaxMinValues.Value.MinValue);
        }
        [TestMethod]
        public void DateTime_Box()
        {
            var v = (ITypeMaxMinValues)DateTimeMaxMinValues.Value;
            Assert.AreEqual(DateTime.MaxValue, (DateTime)v.MaxValue!);
            Assert.AreEqual(DateTime.MinValue, (DateTime)v.MinValue!);
        }
        [TestMethod]
        public void EqualsHashCodeString()
        {
            Assert.AreEqual(DateTimeMaxMinValues.Value.GetHashCode(), DateTimeMaxMinValues.Value.GetHashCode());
            Assert.AreNotEqual(DateTimeMaxMinValues.Value.GetHashCode(), NumericMaxMinValues.UInt.GetHashCode());
            Assert.AreEqual(DateTimeMaxMinValues.Value.ToString(), DateTimeMaxMinValues.Value.ToString());
            Assert.AreNotEqual(DateTimeMaxMinValues.Value.ToString(), NumericMaxMinValues.UInt.ToString());
            Assert.IsFalse(DateTimeMaxMinValues.Value.Equals(NumericMaxMinValues.UInt));
            Assert.IsTrue(DateTimeMaxMinValues.Value.Equals(DateTimeMaxMinValues.Value));
            Assert.IsFalse(DateTimeMaxMinValues.Value.Equals(null));
            Assert.IsTrue(DateTimeMaxMinValues.Value == DateTimeMaxMinValues.Value);
            Assert.IsFalse(DateTimeMaxMinValues.Value != DateTimeMaxMinValues.Value);
        }
        [TestMethod]
        public void IsIn_Bool()
        {
            var b = new DateTimeMaxMinValues(DateTime.Parse("2022-1-1"), DateTime.Parse("2023-1-1"));
            Assert.IsTrue(b.IsIn(DateTime.Parse("2022-1-1")));
            Assert.IsFalse(b.IsIn(DateTime.Parse("2023-1-2")));
        }
        [TestMethod]
        public void DateTime_BigInt_IsIn()
        {
            var v = BooleanMaxMinValues.Value;
            Assert.IsTrue(v.IsIn(1));
        }
        [TestMethod]
        public void DateTime_BigInt_IsIn_Zoom()
        {
            var v =new  DateTimeMaxMinValues(
                DateTime.Parse("2022-1-1"),
                DateTime.Parse("2023-1-1"));
            Assert.IsTrue(v.IsIn(
                new DateTime((long)(DateTime.Parse("2022-1-1").Ticks * 1.3)), new ValueIsInOptions<double> { Zoom = 1.3 }));
            Assert.IsTrue(v.IsIn(
                new DateTime((long)(DateTime.Parse("2023-1-1").Ticks * 1.3))
                , new ValueIsInOptions<double> { Zoom = 1.3 }));
        }
        [TestMethod]
        public void DateTime_BigInt_IsIn_Close()
        {
            var v = new DateTimeMaxMinValues(
                DateTime.Parse("2022-1-1"),
                DateTime.Parse("2023-1-1"));
            Assert.IsTrue(v.IsIn(DateTime.Parse("2022-1-1"), new ValueIsInOptions<double> { MinNotEquals = false }));
            Assert.IsFalse(v.IsIn(DateTime.Parse("2022-1-1"), new ValueIsInOptions<double> { MinNotEquals = true }));

            Assert.IsTrue(v.IsIn(DateTime.Parse("2023-1-1"), new ValueIsInOptions<double> { MaxNotEquals = false }));
            Assert.IsFalse(v.IsIn(DateTime.Parse("2023-1-1"), new ValueIsInOptions<double> { MaxNotEquals = true }));
        }
    }
}
