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
    }
}
