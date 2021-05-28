using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program57
    {
        static void Main(string[] args)
        {
            int count = 0;
            for (int i=0; i<999;i++)
            {
                BigInteger[] numNdenom = Expand(i);
                BigInteger num = numNdenom[0];
                BigInteger denom = numNdenom[1];
                BigInteger temp = num;
                num = denom;
                denom = temp;
                num+= denom;
                if (num.ToString().Length > denom.ToString().Length)
                    count++;
            }
            Console.WriteLine(count.ToString());
            Console.ReadKey();
        }
        public static BigInteger[] Expand(int n)
        {
            if (n==0)
            {
                return new BigInteger[] { new BigInteger(5), new BigInteger(2) };
            }
            else
            {
                BigInteger[] numNdenom = Expand(n - 1);
                BigInteger num = numNdenom[0];
                BigInteger denom = numNdenom[1];
                BigInteger temp = num;
                num = denom;
                denom = temp;
                num += BigInteger.Multiply(2, denom);
                return new BigInteger[] { num, denom };
            }
        }
    }
}
