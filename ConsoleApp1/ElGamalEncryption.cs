using System;
using System.Collections.Generic;
using System.Numerics;

namespace ConsoleApp1
{

    public class ElGamalEncryption
    {
        private static Random random = new Random();
        public (BigInteger, BigInteger, BigInteger) publicKey { get; private set; } // (h, q, g)
        private int privateKey { get; set;} // a

        public ElGamalEncryption((BigInteger, BigInteger, BigInteger) pubKey)
        {
            publicKey = pubKey;
        }
        public ElGamalEncryption(BigInteger q) 
        {
            BigInteger g = random.Next(2, q > int.MaxValue ? int.MaxValue : (int)q);

            int a = GenerateKey(q);

            BigInteger h = BigInteger.Pow(g, a);
            publicKey = (h, q, g);
            privateKey = a;
        }

        public (BigInteger, BigInteger) ToEncrypt(BigInteger msg)
        {
            int k = GenerateKey(publicKey.Item2);
            BigInteger s = BigInteger.Pow(publicKey.Item1, k);
            BigInteger p = BigInteger.Pow(publicKey.Item3, k);

            BigInteger encryptedMsg = msg * s;

            return (encryptedMsg, p);
        }

        public BigInteger ToDecrypt((BigInteger, BigInteger) encryptedMsg)// (msg, p)
        {
            BigInteger h = BigInteger.Pow(encryptedMsg.Item2, privateKey);

            BigInteger decryptedMsg = encryptedMsg.Item1 / h;

            return decryptedMsg;
        }

        static int GenerateKey(BigInteger q)
        {
            int key;
            do
            {
                key = random.Next(2, q > int.MaxValue ? int.MaxValue : (int)q);
            } while (RSAcryptosystem.FindGCD(key, q) != 1);

            return key;
        }

    }
}