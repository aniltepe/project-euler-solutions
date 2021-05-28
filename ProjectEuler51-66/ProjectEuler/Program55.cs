using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program55
    {
        static void Main(string[] args)
        {
            int lychrelCount = 0;
            for (decimal i=0; i<10000; i++)
            {
                bool gonnaAdd = true;
                int count = 0;
                decimal sum = i;
                while(++count<51)
                {
                    if (IsPalindrome(sum + Reverse(sum)))
                    {
                        gonnaAdd = false;
                        break;
                    }
                    else sum += Reverse(sum);
                }
                if (gonnaAdd)
                    lychrelCount++;
            }
            Console.WriteLine(lychrelCount.ToString());
            Console.ReadKey();
        }        
        public static bool IsPalindrome(decimal n)
        {
            if (n == Reverse(n)) return true;
            else return false;
        }
        public static decimal Reverse(decimal n)
        {
            if (n == 0) return 0;
            string ns = "";
            string s = n.ToString();
            for (int i=0; i<s.Length; i++)
            {
                if (i == s.Length - 1 && s[i] == '0') continue;
                ns = s[i].ToString() + ns;
            }
            decimal nn = Convert.ToDecimal(ns);
            return nn;
        }
    }
}
