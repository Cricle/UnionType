namespace UnionType.Test
{
    public partial class UnionValueTest
    {
        [TestMethod]
        public void Equals()
        {
            var a = new UnionValue { Int = 123 };
            var b = new UnionValue { Short = 123 };
            var c = new UnionValue { Decimal = 123 };
            var d = new UnionValue { Int = 123 };
            var e = new UnionValue { Int = 22 };

            Assert.IsFalse(a == b);
            Assert.IsFalse(a == c);
            Assert.IsTrue(a == d);
            Assert.IsFalse(a == e);

            Assert.IsFalse(a.Equals((object)b));
            Assert.IsFalse(a.Equals((object)c));
            Assert.IsTrue(a.Equals((object)d));
            Assert.IsFalse(a.Equals((object)e));

            Assert.IsTrue(a != b);
            Assert.IsTrue(a != c);
            Assert.IsFalse(a != d);
            Assert.IsTrue(a != e);
        }
        [TestMethod]
        public void HashCodes()
        {
            var a = new UnionValue { Int = 123 };
            var b = new UnionValue { Short = 123 };
            var c = new UnionValue { Decimal = 123 };
            var d = new UnionValue { Int = 123 };
            var e = new UnionValue { Int = 22 };

            Assert.IsFalse(a.GetHashCode() == b.GetHashCode());
            Assert.IsFalse(a.GetHashCode() == c.GetHashCode());
            Assert.IsTrue(a.GetHashCode() == d.GetHashCode());
            Assert.IsFalse(a.GetHashCode() == e.GetHashCode());
        }
        [TestMethod]
        public void AsString()
        {
            var a = new UnionValue { Int = 123 };
            var b = new UnionValue { Short = 123 };
            var c = new UnionValue { Decimal = 123 };
            var d = new UnionValue { Int = 123 };
            var e = new UnionValue { Int = 22 };

            Assert.IsTrue(a.ToString() == b.ToString());
            Assert.IsTrue(a.ToString() == c.ToString());
            Assert.IsTrue(a.ToString() == d.ToString());
            Assert.IsFalse(a.ToString() == e.ToString());
        }
        [TestMethod]
        public void EqualsOthrerTypes()
        {
            Assert.IsFalse(new UnionValue().Equals(1));
        }
        [TestMethod]
        public void EqualsAnyNull()
        {
            var nullA = new UnionValue { Object = null };
            var valueB = new UnionValue { Object = new object() };
            Assert.IsFalse(nullA.Equals(valueB));
            Assert.IsFalse(valueB.Equals(nullA));
        }
        [TestMethod]
        public void EqualsAllNull()
        {
            var nullA = new UnionValue { Object = null };
            var nullB = new UnionValue { Object =null };
            Assert.IsTrue(nullA.Equals(nullB));
        }
        [TestMethod]
        public void StringEquals()
        {
            var v1 = new UnionValue();
            v1.String = "123";
            var v2 = new UnionValue();
            v2.String = "123";

            Assert.AreEqual(v1, v2);

            v2.String = "345";

            Assert.AreNotEqual(v1, v2);
        }
        [TestMethod]
        public void StringHashCode()
        {
            var v1 = new UnionValue();
            v1.String = "123";

            Assert.AreEqual(v1.String.GetHashCode(),v1.GetHashCode());
        }
        [TestMethod]
        public void ObjectEquals()
        {
            var v1 = new UnionValue();
            v1.Object=(123);
            var v2 = new UnionValue();
            v2.Object=(123);

            Assert.AreEqual(v1, v2);

            v2.Object=(456);

            Assert.AreNotEqual(v1, v2);
        }
        [TestMethod]
        public void ObjectEqualsNulls()
        {
            var v1 = new UnionValue();
            v1.Object=(null);
            var v2 = new UnionValue();
            v2.Object=(null);

            Assert.AreEqual(v1, v2);
        }
        [TestMethod]
        public void ObjectNotEqualsAnyNull()
        {
            var v1 = new UnionValue();
            v1.Object=(123);
            var v2 = new UnionValue();
            v2.Object=null;

            Assert.AreNotEqual(v1, v2);
        }
        [TestMethod]
        public void ObjectHashCode()
        {
            var v1 = new UnionValue();
            v1.Object=(123);

            Assert.AreEqual(v1.Object.GetHashCode(), v1.GetHashCode());
        }
    }
}
