using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program58
    {
        static void Main(string[] args)
        {
            int layer = 2;
            List<int> diagonals = new List<int>() { 1, 3, 5, 7, 9 };
            int primeCount = 3;
            while (true)
            {
                layer++;
                int length = 2 * layer - 1;
                for (int i = 0; i < 4; i++)
                {
                    int x = diagonals.Last() + length - 1;
                    diagonals.Add(x);
                    if (IsPrime(x))
                        primeCount++;
                }
                double percent = (double)(primeCount * 100) / (double)diagonals.Count;
                if (percent < 10)
                {
                    Console.WriteLine(length.ToString());
                    break;
                }
            }
            Console.ReadKey();
        }
        public static bool IsPrime(int a)
        {
            if (a == 1) return false;
            int c = (int)Math.Ceiling(Math.Sqrt(a));
            for (int i = 2; i <= c; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
