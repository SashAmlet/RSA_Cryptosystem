using ConsoleApp1;
using System.Numerics;
using System.Threading.Tasks;


namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        #region Task1
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 1)]
        [TestCase(12, ExpectedResult = 4)]
        [TestCase(15, ExpectedResult = 8)]
        [TestCase(17, ExpectedResult = 16)]
        [TestCase(58, ExpectedResult = 28)]
        [TestCase(79, ExpectedResult = 78)]
        [TestCase(100, ExpectedResult = 40)]
        public int EulerPhiTest(int n)
        {
            return Task1.EulerPhi(n);
        }

        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = -1)]
        [TestCase(4, ExpectedResult = 0)]
        [TestCase(7, ExpectedResult = -1)]
        [TestCase(15, ExpectedResult = 1)]
        [TestCase(26, ExpectedResult = 1)]
        [TestCase(37, ExpectedResult = -1)]
        [TestCase(48, ExpectedResult = 0)]
        public int MoebiusMuTest(int n)
        {
            return Task1.MoebiusMu(n);
        }

        [TestCase(4, 6, ExpectedResult = 12)]
        [TestCase(5, 7, 10, ExpectedResult = 70)]
        [TestCase(3, 8, 12, 15, ExpectedResult = 120)]
        public int FindLCM(params int[] numbers)
        {
            return Task1.FindLCM(numbers);
        }
        #endregion

        #region Task2
        [TestCase(2, 3, ExpectedResult = 98)]
        [TestCase(2, 3, 2, ExpectedResult = 23)]
        [TestCase(2, 3, 6, ExpectedResult = 83)]
        public long Solve_ReturnsCorrectResult(params long[] a)
        {
            long[] m = { 3, 5, 7 }; // Adjust moduli as needed
            return Task2.ChineseRemainderTheorem_Solve(a, m);
        }
        #endregion

        #region Task3
        [TestCase(0, 3, ExpectedResult = 0)]
        [TestCase(1, 7, ExpectedResult = 1)]
        [TestCase(3, 5, ExpectedResult = -1)]
        [TestCase(7, 11, ExpectedResult = -1)]
        [TestCase(4, 11, ExpectedResult = 1)]
        public int LegendreSymbol_Test(int a, int p)
        {
            return Task3.LegendreSymbol(a, p);
        }

        [TestCase(16, 17, ExpectedResult = 1)]
        [TestCase(2, 11, ExpectedResult = -1)]
        [TestCase(5, 15, ExpectedResult = 0)]
        [TestCase(2, 17, ExpectedResult = 1)]
        [TestCase(14, 15, ExpectedResult = -1)]
        public int JacobiSymbol_Test(int a, int n)
        {
            return Task3.JacobiSymbol(a, n);
        }

        #endregion

        #region Task4
        [Test]
        public void PollardsRho_Test1()
        {
            int n = 12;
            Assert.That(0, Is.EqualTo(n % Task4.RhoPollard(n)));
        }
        [Test]
        public void PollardsRho_Test2()
        {
            int n = 187;
            Assert.That(0, Is.EqualTo(n % Task4.RhoPollard(n)));
        }
        [Test]
        public void PollardsRho_Test3()
        {
            int n = 5959;
            Assert.That(0, Is.EqualTo(n % Task4.RhoPollard(n)));
        }
        [Test]
        public void PollardsRho_Test4()
        {
            int n = 123456789;
            Assert.That(0, Is.EqualTo(n % Task4.RhoPollard(n)));
        }
        [Test]
        public void PollardsRho_Test5()
        {
            int n = 987654321;
            Assert.That(0, Is.EqualTo(n % Task4.RhoPollard(n)));
        }
        #endregion

        #region Task5
        [TestCase(2UL, 8UL, 11UL, ExpectedResult = 3UL)] // 2^3 = 8 mod 11
        [TestCase(5UL, 3UL, 23UL, ExpectedResult = 16UL)]
        [TestCase(438UL, 17UL, 509UL, ExpectedResult = 28UL)]
        public ulong BabyStepGiantStep_Test(ulong g, ulong h, ulong p)
        {
            return Task5.BabyStepGiantStep(g, h, p);
        }
        #endregion

        #region Task6
        [Test]
        public void CipollaSquareRoot_Test1()
        {
            long c = 15L, p = 17L;
            Assert.That(Math.Pow(Task6.CipollaSqrt(c, p), 2) % p, Is.EqualTo(c % p)); //(x^2) % p = c % p
        }
        [Test]
        public void CipollaSquareRoot_Test2()
        {
            long c = 8L, p = 17L;
            Assert.That(Math.Pow(Task6.CipollaSqrt(c, p), 2) % p, Is.EqualTo(c % p)); 
        }
        #endregion;

        #region Task7
        [TestCase("4244638087073", 10, ExpectedResult = true)]
        [TestCase("6790566624859", 10, ExpectedResult = true)]
        [TestCase("7294429081243", 10, ExpectedResult = true)]
        [TestCase("22806868983211", 10, ExpectedResult = true)]
        [TestCase("27280753292489", 10, ExpectedResult = true)]
        [TestCase("20245864076357", 10, ExpectedResult = true)]
        [TestCase("25986928002641", 10, ExpectedResult = true)]
        public bool MiillerTest_Test(string nStr, int k)
        {
            BigInteger n = BigInteger.Parse(nStr);
            return Task7.isPrime(n, k);
        }
        #endregion;

        #region Task8
        [TestCase("10235", ExpectedResult = "10235")]
        [TestCase("123456", ExpectedResult = "123456")]
        [TestCase("99999", ExpectedResult = "99999")]
        [TestCase("4244638087073", ExpectedResult = "4244638087073")]
        [TestCase("6790566624859", ExpectedResult = "6790566624859")]
        [TestCase("7294429081243", ExpectedResult = "7294429081243")]
        [TestCase("22806868983211", ExpectedResult = "22806868983211")]
        [TestCase("27280753292489", ExpectedResult = "27280753292489")]
        public string RSA_Test(string sentStr)
        {
            BigInteger sent = BigInteger.Parse(sentStr);
            BigInteger p = 499, q = 631;

            RSAcryptosystem Bob = new(p, q), Alice = new(Bob.publicKey);
            BigInteger encode = Alice.ToEncode(sent);
            BigInteger decode = Bob.ToDecode(encode);
            return decode.ToString();
        }
        #endregion
    }
}