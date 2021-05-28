using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program60
    {
        static void Main(string[] args)
        {
            List<ulong> primes = new List<ulong>();
            for (ulong i=0; i<10000; i++)
            {
                if (IsPrime(i))
                    primes.Add(i);
            }
            ulong lowestSum = int.MaxValue;
            List<ulong> pairablePrimes = new List<ulong>();
            for (int i = 0; i < primes.Count; i++)
            {
                for (int j=i+1; j< primes.Count; j++)
                {
                    if (!IsPairablePrime(new List<ulong>() { primes[i], primes[j] })) {
                        continue;
                    }
                    for (int h=j+1; h<primes.Count; h++)
                    {
                        if (!IsPairablePrime(new List<ulong>() { primes[i], primes[j], primes[h] })) {
                            continue;
                        }
                        for (int g = h + 1; g < primes.Count; g++)
                        {
                            if (!IsPairablePrime(new List<ulong>() { primes[i], primes[j], primes[h], primes[g] })) {
                                continue;
                            }
                            for (int k = g + 1; k < primes.Count; k++)
                            {
                                if (!IsPairablePrime(new List<ulong>() { primes[i], primes[j], primes[h], primes[g], primes[k] }))
                                {
                                    continue;
                                }
                                else {
                                    ulong sum = 0;
                                    sum = primes[i] + primes[j] + primes[h] + primes[g] + primes[k];
                                    if (sum < lowestSum) lowestSum = sum;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(lowestSum.ToString());
            Console.ReadKey();
        }
        public static bool IsPrime(UInt64 a)
        {
            if (a == 1 || a == 0) return false;
            if (a == 2) return true;
            ulong c = (ulong)Math.Ceiling(Math.Sqrt(a));
            for (ulong i = 2; i <= c; i++)
            {
                if (a % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsPairablePrime(List<ulong> l)
        {
            bool isFit = true;
            for (int i=0; i<l.Count; i++)
            {
                bool forBreak = false;
                for (int j=0; j<l.Count; j++)
                {
                    if (i == j) continue;
                    string s = l[i].ToString() + l[j].ToString();
                    if (!IsPrime(Convert.ToUInt64(s)))
                    {
                        forBreak = true;
                        isFit = false;
                        break;
                    }
                }
                if (forBreak)
                    break;
            }
            return isFit;
        }
    }
}
