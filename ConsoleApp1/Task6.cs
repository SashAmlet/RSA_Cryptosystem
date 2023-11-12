using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task6
    {
        public static long ModularPow(long baseValue, long exp, long mod)
        {
            long result = 1;
            baseValue = baseValue % mod;
            while (exp > 0)
            {
                if (exp % 2 == 1)
                    result = (result * baseValue) % mod;
                exp = exp >> 1;
                baseValue = (baseValue * baseValue) % mod;
            }
            return result;
        }

        public class Complex
        {
            public long Real { get; set; }
            public long Imaginary { get; set; }

            public Complex(long real, long imaginary)
            {
                Real = real;
                Imaginary = imaginary;
            }
        }

        public static Complex Multiply(Complex a, Complex b, long p, long w)
        {
            long x = (a.Real * b.Real + a.Imaginary * b.Imaginary % p * w) % p;
            long y = (a.Real * b.Imaginary + a.Imaginary * b.Real) % p;
            return new Complex(x, y);
        }

        public static Complex Pow(Complex a, long n, long p, long w)
        {
            Complex result = new Complex(1, 0);
            while (n > 0)
            {
                if ((n & 1) == 1)
                {
                    result = Multiply(result, a, p, w);
                }
                a = Multiply(a, a, p, w);
                n >>= 1;
            }
            return result;
        }

        public static long CipollaSqrt(long n, long p)
        {
            if (ModularPow(n, (p - 1) / 2, p) != 1)
                return -1;  // no square root exists

            Random rand = new Random();
            long a;
            long w;
            while (true)
            {
                a = rand.Next() % p;
                w = (a * a - n + p) % p;
                if (ModularPow(w, (p - 1) / 2, p) == p - 1)
                    break;
            }

            Complex res = Pow(new Complex(a, 1), (p + 1) / 2, p, w);
            return res.Real;
        }

    }
}
