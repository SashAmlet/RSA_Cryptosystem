using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Helper
    {
        // Перетворення слова латинського алфавіту в десяткову систему числення
        public static BigInteger LatinToDecimal(string latinWord)
        {
            if (string.IsNullOrEmpty(latinWord))
            {
                throw new ArgumentException("Input string is null or empty.");
            }

            BigInteger decimalValue = 0;
            foreach (char letter in latinWord.ToUpper())
            {
                if (letter < 'A' || letter > 'Z')
                {
                    throw new ArgumentException("Invalid character in the input string.");
                }

                decimalValue = decimalValue * 26 + (letter - 'A' + 1);
            }

            return decimalValue;
        }

        // Обернене перетворення з десяткової системи числення в слово латинського алфавіту
        public static string DecimalToLatin(BigInteger decimalValue)
        {
            if (decimalValue <= 0)
            {
                throw new ArgumentException("Input value must be a positive integer.");
            }

            string latinWord = "";
            while (decimalValue > 0)
            {
                int remainder = (int)((decimalValue - 1) % 26);
                char letter = (char)('A' + remainder);
                latinWord = letter + latinWord;
                decimalValue = (decimalValue - 1) / 26;
            }

            return latinWord;
        }
    }
}
