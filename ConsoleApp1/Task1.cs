using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task1
    {
        #region Функція Ейлера
        public static int EulerPhi(int n)
        {
            int result = n; // Ініціалізуємо результат значенням n

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    while (n % i == 0)
                        n /= i;

                    result -= result / i;
                }
            }

            if (n > 1)
                result -= result / n;

            return result;
        }
        #endregion

        #region Функція Мьобіуса
        public static int MoebiusMu(int n)
        {
            if (n == 1)
                return 1;

            int count = 0;

            for (int i = 2; i <= n; i++)
            {
                if (n % i == 0)
                {
                    n /= i;
                    count++;

                    if (n % i == 0)
                        return 0; // n має квадрат простого множника
                }
            }

            return count % 2 == 0 ? 1 : -1;
        }
        #endregion

        #region Функція для знаходження найменшого спільного кратного для набору чисел
        // Функція для знаходження найменшого спільного кратного для двох чисел
        private static int FindLCM(int a, int b)
        {
            return a / FindGCD(a, b) * b;
        }

        // Функція для знаходження найбільшого спільного дільника для двох чисел
        private static int FindGCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        // Функція для знаходження найменшого спільного кратного для масиву чисел
        public static int FindLCM(params int[] numbers)
        {
            if (numbers.Length < 2)
                throw new ArgumentException("Потрібно щонайменше два числа для знаходження НСК.");

            int lcm = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                lcm = FindLCM(lcm, numbers[i]);
            }

            return lcm;
        }
        #endregion
    }
}
