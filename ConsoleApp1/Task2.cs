using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task2
    {
        // Метод для знаходження оберненого за модулем числа (розширений алгоритм Евкліда) x*a = 1 (mod m)
        public static long ModInverse(long a, long m)
        {
            long m0 = m;
            long y = 0, x = 1;

            if (m == 1)
                return 0;

            while (a > 1)
            {
                long q = a / m;
                long t = m;

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

        // Метод для знаходження розв'язку системи лінійних порівнянь за модулем
        public static long ChineseRemainderTheorem_Solve(long[] a, long[] m)
        {
            int k = a.Length;

            // Перевірка, чи всі модулі попарно взаємно прості
            for (int i = 0; i < k; i++)
            {
                for (int j = i + 1; j < k; j++)
                {
                    if (gcd(m[i], m[j]) != 1)
                        throw new ArgumentException("Модулі повинні бути попарно взаємно простими.");
                }
            }

            // Обчислення M - добутку всіх модулів
            long M = 1;
            foreach (long mi in m)
            {
                M *= mi;
            }

            // Обчислення Mi - добутку всіх модулів, крім поточного
            long[] Mi = new long[k];
            for (int i = 0; i < k; i++)
            {
                Mi[i] = M / m[i];
            }

            // Обчислення yi - оберненого за модулем числа до Mi
            long[] yi = new long[k];
            for (int i = 0; i < k; i++)
            {
                yi[i] = ModInverse(Mi[i], m[i]);
            }

            // Обчислення x - розв'язку системи
            long x = 0;
            for (int i = 0; i < k; i++)
            {
                x += a[i] * Mi[i] * yi[i];
            }

            // x - розв'язок системи за модулем M
            return x % M;
        }

        // Метод для обчислення найбільшого спільного дільника
        private static long gcd(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
