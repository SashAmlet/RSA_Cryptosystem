using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class RSAcryptosystem
    {
        private BigInteger p, q, phi, secretKey;
        public (BigInteger, BigInteger) publicKey { get; private set; } // (n, e)
        public RSAcryptosystem((BigInteger, BigInteger) pubKey)
        {
            publicKey = pubKey;
        }
        public RSAcryptosystem(BigInteger intputP, BigInteger intputQ)
        {
            if (!UpdateData(intputP, intputQ))
            {
                throw new Exception("p or q is not a prime number");
            }
        }

        public bool UpdateData(BigInteger intputP, BigInteger intputQ)
        {
            if (Task7.isPrime(intputP, 10) && Task7.isPrime(intputQ, 10))
            {
                BigInteger n, e;
                p = intputP;
                q = intputQ;
                n = p * q;
                phi = (p - 1) * (q - 1);

                Random r = new Random();
                do
                {
                    e = r.Next(2, phi > int.MaxValue ? int.MaxValue : (int)phi);
                } while (FindGCD(e, phi) != 1);

                publicKey = (n, e);
                secretKey = ModInverse(e, phi);

                return true;
            }
            return false;
        }

        public BigInteger ToEncrypt(BigInteger message)
        {
            return BigInteger.ModPow(message, publicKey.Item2, publicKey.Item1);
        }

        public BigInteger ToDecrypt(BigInteger encodedMessage)
        {
            return BigInteger.ModPow(encodedMessage, secretKey, publicKey.Item1);
        }

        public static BigInteger FindGCD(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        private BigInteger ModInverse(BigInteger a, BigInteger m)
        {
            BigInteger m0 = m;
            BigInteger y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                BigInteger q = a / m;
                BigInteger t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if (x < 0)
                x += m0;

            return x;
        }
    }
}
