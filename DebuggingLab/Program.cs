using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebuggingLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());
            var result = GetMultipleOfEvenAndOdds(num);
            Console.WriteLine(result);
        }

        private static long GetMultipleOfEvenAndOdds(int num)
        {
            var sumEvens = GetSumOfEvenDigits(num);
            var sumOdds = GetSumOfOddDigits(num);
            return sumEvens * sumOdds;
        }

        static int GetSumOfEvenDigits(int num)
        {
            int sum = 0;
            num = Math.Abs(num);
            while (num > 0)
            {
                var digit = num % 10;
                if (digit % 2 == 0)
                {
                    sum = sum + digit;
                }

                num = num / 10;
            }
            return sum;
        }

        static int GetSumOfOddDigits(int num)
        {
            int sum = 0;
            num = Math.Abs(num);
            while (num > 0)
            {
                var digit = num % 10;
                if (digit % 2 != 0)
                {
                    sum = sum + digit;
                }
                
                num = num / 10;
            }
            return sum;
        }
    }
}
