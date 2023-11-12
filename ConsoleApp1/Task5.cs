using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task5
    {
        static bool IsPrime(ulong number)
        {
            if (number <= 1)
                return false;
            for (ulong i = 2; i * i <= number; ++i)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        static ulong ModularPow(ulong baseNum, ulong exp, ulong mod)
        {
            ulong result = 1;
            while (exp > 0)
            {
                if ((exp & 1) == 1)
                    result = (result * baseNum) % mod;
                baseNum = (baseNum * baseNum) % mod;
                exp >>= 1;
            }
            return result;
        }

        public static ulong BabyStepGiantStep(ulong g, ulong h, ulong p)
        {
            ulong m = (ulong)Math.Sqrt(p) + 1;
            Dictionary<ulong, ulong> valueMap = new Dictionary<ulong, ulong>();

            if (!IsPrime(p))
                throw new ArgumentException("Перше число має бути простим.");

            // "малий крок"
            for (ulong j = 0; j < m; ++j)
            {
                ulong value = ModularPow(g, j, p);
                valueMap[value] = j;
            }

            // обчислюємо g^(-m) mod p
            ulong coeff = ModularPow(g, p - 1 - m, p);

            ulong curr = h;
            // "великий крок"
            for (ulong i = 0; i < m; ++i)
            {
                if (valueMap.ContainsKey(curr))
                    return i * m + valueMap[curr];
                else
                    curr = (curr * coeff) % p;
            }

            // якщо дискретний логарифм не знайдений
            return ulong.MaxValue; // або можна повернути -1, якщо більше підходить для вашого випадку
        }

    }
}
