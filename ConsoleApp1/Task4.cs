using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task4
    {
        public static int RhoPollard(int N)
        {
            Random rnd = new Random();
            int x = rnd.Next(1, N - 1);
            int y = 1;
            int i = 0;
            int stage = 2;

            while (GCD(N, Math.Abs(x - y)) == 1)
            {
                if (i == stage)
                {
                    y = x;
                    stage = stage * 2;
                }

                x = (x * x + 1) % N;
                i = i + 1;
            }

            return GCD(N, Math.Abs(x - y));
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}
