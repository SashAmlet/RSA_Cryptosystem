using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task3
    {
        // Метод для обчислення символу Лежандра
        public static int LegendreSymbol(int a, int p)
        {
            if (a % p == 0)
                return (a == 0) ? 0 : 1;

            int legendre = (int)Math.Pow(a, (p - 1) / 2) % p;
            return (legendre == 1) ? 1 : ((legendre == (p - 1)) ? -1 : 0);
        }
        // Метод для обчислення символу Якобі
        public static int JacobiSymbol(int a, int n)
        {
            if (n <= 0 || n % 2 == 0)
                throw new ArgumentException("Для символу Якобі n повинно бути непарним та додатнім.");

            // Шаг 1
            a = a % n;
            int t = 1;
            int r;

            // Шаг 3
            while (a != 0)
            {
                // Шаг 2
                while (a % 2 == 0)
                {
                    a /= 2;
                    r = n % 8;
                    if (r == 3 || r == 5)
                    {
                        t = -t;
                    }
                }

                // Шаг 4
                r = n;
                n = a;
                a = r;

                if (a % 4 == 3 && n % 4 == 3)
                {
                    t = -t;
                }

                a = a % n;
            }

            return (n == 1) ? t : 0;
        }


    }
}
