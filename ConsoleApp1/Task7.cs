using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task7
    {
        // Utility function to do modular 
        // exponentiation. It returns (x^y) % p
        static BigInteger power(BigInteger x, BigInteger y, BigInteger p)
        {

            BigInteger res = 1; // Initialize result

            // Update x if it is more than 
            // or equal to p
            x = x % p;

            while (y > 0)
            {

                // If y is odd, multiply x with result
                if ((y & 1) == 1)
                    res = (res * x) % p;

                // y must be even now
                y = y >> 1; // y = y/2
                x = (x * x) % p;
            }

            return res;
        }

        // This function is called for all k trials. 
        // It returns false if n is composite and 
        // returns true if n is probably prime.
        // d is an odd number such that d*2<sup>r</sup>
        // = n-1 for some r >= 1
        static bool miillerTest(BigInteger d, BigInteger n)
        {

            // Pick a random number in [2..n-2]
            // Corner cases make sure that n > 4
            Random r = new Random();
            BigInteger a = 2 + r.Next() % (n - 4);

            // Compute a^d % n
            BigInteger x = power(a, d, n);

            if (x == 1 || x == n - 1)
                return true;

            // Keep squaring x while one of the
            // following doesn't happen
            // (i) d does not reach n-1
            // (ii) (x^2) % n is not 1
            // (iii) (x^2) % n is not n-1
            while (d != n - 1)
            {
                x = (x * x) % n;
                d *= 2;

                if (x == 1)
                    return false;
                if (x == n - 1)
                    return true;
            }

            // Return composite
            return false;
        }

        // It returns false if n is composite 
        // and returns true if n is probably 
        // prime. k is an input parameter that 
        // determines accuracy level. Higher 
        // value of k indicates more accuracy.
        public static bool isPrime(BigInteger n, int k)
        {

            // Corner cases
            if (n <= 1 || n == 4)
                return false;
            if (n <= 3)
                return true;

            // Find r such that n = 2^d * r + 1 
            // for some r >= 1
            BigInteger d = n - 1;

            while (d % 2 == 0)
                d /= 2;

            // Iterate given number of 'k' times
            for (int i = 0; i < k; i++)
                if (miillerTest(d, n) == false)
                    return false;

            return true;
        }
    }
}
