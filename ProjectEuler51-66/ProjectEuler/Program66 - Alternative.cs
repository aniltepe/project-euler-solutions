using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program66
    {
        static void Main(string[] args)
        {
            List<Entry> entryList = new List<Entry>();
            for (BigInteger D = 61; D <= 61; D++)
            {
                if (D % 10 == 0)
                {
                    Console.WriteLine(D.ToString());
                }
                if (SquareRoot(D) != -1)
                {
                    continue;
                }
                BigInteger y = 1;
                while (true)
                {
                    BigInteger sqrY = Square(y);
                    BigInteger sqrX = BigInteger.Multiply(sqrY, D) + 1;
                    BigInteger rootX = SquareRoot(sqrX);
                    if (rootX != -1)
                    {
                        Entry newEntry = new Entry();
                        newEntry.x = rootX;
                        newEntry.d = D;
                        entryList.Add(newEntry);
                        break;
                    }
                    y++;
                }
            }
            Entry max = new Entry();
            max.x = 0;
            for (int i = 0; i < entryList.Count; i++)
            {
                if (entryList[i].x > max.x)
                {
                    max = entryList[i];
                }
            }

            Console.WriteLine("Maximum x is: " + max.x.ToString());
            Console.WriteLine("D for maximum x is: " + max.d.ToString());
            Console.ReadKey();
        }

        public static BigInteger SquareRoot(BigInteger n)
        {
            BigInteger remainder = n - BigInteger.Multiply(BigInteger.Divide(n, 10), 10);
            if (remainder != 1 && remainder != 4 && remainder != 5 && remainder != 6 && remainder != 9 && remainder != 0)
            {
                return new BigInteger(-1);
            }
            BigInteger root = new BigInteger(2);
            while (BigInteger.Pow(root, 2) < n)
            {
                BigInteger.Add(root, new BigInteger(1));
            }
            if (BigInteger.Pow(root, 2) == n)
            {
                return root;
            }
            else
            {
                return new BigInteger(-1);
            }
        }
        //public static BigInteger SquareRoot2(BigInteger n)
        //{
        //    BigInteger root = new BigInteger(1);
        //    while (BigInteger.Pow(root, 2) < n)
        //    {
        //        root++;
        //    }
        //    if (BigInteger.Pow(root, 2) == n)
        //    {
        //        return root;
        //    }
        //    else
        //    {
        //        root--;
                
        //        return root;
        //    }
        //}
        public static BigInteger Square(BigInteger n)
        {
            return BigInteger.Multiply(n, n);
        }
    }
    class Entry
    {
        public BigInteger x { get; set; }
        public BigInteger d { get; set; }
    }
}