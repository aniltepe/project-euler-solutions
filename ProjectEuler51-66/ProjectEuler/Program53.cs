using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ProjectEuler
{
    class Program53
    {
        public static int count = 0;
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                for (int j=1; j<= i; j++)
                {
                    if (Combinatoric(i,j)>1000000)
                    {
                        count++;
                    }
                }
            }
            Console.WriteLine(count.ToString());
            Console.ReadKey();
            //Console.WriteLine(Combinatoric(23, 10).ToString());
        }
        public static BigInteger Combinatoric(int n, int r)
        {
            BigInteger numerator = Factorial(n, r);
            BigInteger denominator = Factorial(n - r);
            return BigInteger.Divide(numerator, denominator);
        }
        public static BigInteger Factorial(int n, int r=0)
        {
            BigInteger ret; 
            if (n!=r)
            {
                ret = BigInteger.Multiply(n, Factorial(n - 1, r));
                return ret;
            }
            else
            {
                return 1;
            }
        }
    }
}
