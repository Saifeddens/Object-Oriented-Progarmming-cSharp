using chessMat;

namespace DiagTest
{
    [TestClass]
    public class DiagTest
    {
        [TestMethod]
        public void Create()
        {
            Assert.ThrowsException<Chess.NegativeSizeException>(() => _ = new Chess(0));
            Chess a = new(1);
            Assert.AreEqual(a[0, 0], 0);
            Assert.AreEqual(a.Size, 1);

            Chess b = new(2);
            Assert.AreEqual(b.Size, 2);

            Chess c = new(5);
            for (int i=0;i<5;i++)
            {
                for (int j=0;j<5;j++)
                {
                    Assert.AreEqual(c[i,j], 0);
                }
            }
            Assert.AreEqual(c.Size, 5);
            Assert.ThrowsException<Chess.NegativeSizeException>(() => _ = new Chess(-1));
            Chess d = new Chess(1000);
            Assert.AreEqual(d.Size, 1000);
        }

        [TestMethod]
        public void Change()
        {
            Chess c=new(3);
            c[0,0]=1;
            c[1,1]=1;
            c[0,2]=1;
            c[2,2]=1;
            for(int i=0;i<3;i++){
                Assert.AreEqual(c[i, i], 1);
            }

            Assert.AreEqual(c[0, 1], 0);
            Assert.ThrowsException<Chess.ReferenceToNullPartException>(() => c[1, 0] = 3);
        }

        [TestMethod]
        public void Assignment()
        {
            Chess a = new Chess(3);
            a[0,0]=1;
            a[1,1]=2;
            a[2,2]=3;
            Chess b = new Chess(a);
            Chess c = new Chess(2);
            c=a;
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(c));
            b[0,0]=0;
            Assert.IsFalse(a.Equals(b));
            c[0,0]=0;
            Assert.IsTrue(a.Equals(b));
            a=b=c;
            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(a.Equals(c));
            a=a;
            Assert.IsTrue(a.Equals(a));
        }


        [TestMethod]
        public void Add()
        {
            Chess a = new(3);
            Chess b = new(3);
            Chess zero = new(3);
            Chess d = new(2);
            Chess c;

            a[0,0]=1;
            a[0,2]=2;
            a[1,1]=3;
            a[2,0]=4;
            a[2,2]=5;

            b[0,0]=10;
            b[0,2]=10;
            b[1,1]=10;
            b[2,0]=10;
            b[2,2]=10;
            c=a+b;
            Assert.AreEqual(c[0,0],11);
            Assert.AreEqual(c[1,1],13);
            Assert.IsTrue(a.Equals(a+zero));
            Assert.IsTrue(a.Equals(zero+a));
            Assert.IsTrue((a+b).Equals(b+a));
            Assert.IsTrue(((a+b)+c).Equals(a+(b+c)));

            Assert.ThrowsException<Chess.DifferentSizeException>(() =>a+d);
        }

        [TestMethod]
        public void Mul()
        {
            Chess a = new(3);
            Chess b = new(3);
            Chess d = new(2);
            Chess zero = new(3);
            Chess c;

            a[0,0]=1;
            a[1,1]=1;
            a[2,2]=1;

            b[0,0]=42;
            b[1,1]=0;
            b[2,2]=0;

            c=a*b;

            Assert.AreEqual(c[0, 0], 42);
            Assert.AreEqual(c[1, 1], 0);

            Assert.IsTrue(zero.Equals(a*zero));
            Assert.IsTrue(b.Equals(a*b));
            Assert.IsTrue((a*(b*c)).Equals((a*b)*c));
            Assert.IsTrue((b*c).Equals(c*b));

            Assert.ThrowsException<Chess.DifferentSizeException>(() => a * d);
        }

        [TestMethod]
        public void SetMatrix()
        {
            List<double> vec = new List<double>() {1,2,3,4,5};
            Chess a = new Chess(3);
            Chess b = new Chess(2);
            Assert.AreEqual(vec.Count, 5);
            Assert.AreEqual(a[0,0], 0);
            Assert.AreEqual(a[1,1], 0);
            Assert.AreEqual(a[2,2], 0);
            a.Set(vec);
            Assert.AreEqual(a[0,0], 1);
            Assert.AreEqual(a[1,1], 3);
            Assert.AreEqual(a[2,2], 5);

            Assert.ThrowsException<Chess.DifferentSizeException>(() => b.Set(vec));
            
        }
    }
}