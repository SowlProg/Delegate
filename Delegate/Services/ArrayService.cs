using System;
using System.Collections.Generic;
using System.Linq;

using System;
using System.Linq;

namespace Project.Services
{
    public static class ArrayService
    {
        public static int[] GetEvenNumbers(int[] array) => array.Where(n => n % 2 == 0).ToArray();
        public static int[] GetOddNumbers(int[] array) => array.Where(n => n % 2 != 0).ToArray();

        public static int[] GetPrimeNumbers(int[] array) => array.Where(IsPrime).ToArray();

        public static int[] GetFibonacciNumbers(int[] array) => array.Where(IsFibonacci).ToArray();

        private static bool IsPrime(int n)
        {
            if (n <= 1) return false;
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(n); i += 2)
                if (n % i == 0) return false;
            return true;
        }

        private static bool IsFibonacci(int n)
        {
            int a = 0, b = 1;
            while (b < n)
            {
                int temp = a;
                a = b;
                b = temp + b;
            }
            return b == n;
        }
    }
}