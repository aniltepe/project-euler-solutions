using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program62Alt
    {
        static void Main(string[] args)
        {
            int i = 1;
            while (true)
            {
                List<double> cubePerms = new List<double>();
                double n = i * i * i;
                List<double> l = GetPermutations(n);
                for (int j = 0; j < l.Count; j++)
                {
                    if (IsCube(l[j]))
                        cubePerms.Add(l[j]);
                }
                if (cubePerms.Count > 5)
                {
                    for (int j = 0; j < 5; j++)
                        Console.WriteLine(cubePerms[j].ToString());
                    Console.ReadKey();
                }
                if (i%10 == 0)
                {
                    Console.WriteLine(i.ToString());
                }
                i++;
            }
        }
        public static bool IsCube(double n)
        {
            double a = 1.0 / 3;
            double b = Convert.ToDouble(Math.Pow(Convert.ToDouble(n), a));
            b = Math.Round(b);
            if (b * b * b == n) return true;
            else return false;
        }
        public static List<double> GetPermutations(double n)
        {
            List<double> returnList = new List<double>();
            List<string> l = new List<string>();
            string s = n.ToString();
            for (int i=0; i<s.Length; i++)
            {
                l.Add(s[i].ToString());
            }

            List<List<string>> inner = InnerPermutation(l);
            for (int i=0; i<inner.Count; i++)
            {
                returnList.Add(StrList2double(inner[i]));
            }
            List<double> newList = new List<double>();
            for (int i = 0; i < returnList.Count; i++)
            {
                bool isProper = true;
                if (n.ToString().Length != returnList[i].ToString().Length)
                    isProper = false;
                if (isProper && !newList.Contains(returnList[i]))
                    newList.Add(returnList[i]);
            }
            return newList;
        }

        public static List<List<string>> InnerPermutation(List<string> l)
        {
            List<List<string>> retList = new List<List<string>>();
            if (l.Count == 2)
            {
                retList.Add(l);
                retList.Add(new List<string>() { l[1], l[0] });
                return retList;
            }
            else
            {
                for (int i=0; i<l.Count; i++)
                {
                    List<List<string>> perms = InnerPermutation(l.GetRange(1, l.Count - 1));
                    for (int j=0;j<perms.Count; j++)
                    {
                        List<string> temp = new List<string>(perms[j]);
                        temp.Insert(0, l[0]);
                        retList.Add(temp);
                    }
                    l.Add(l[0]);
                    l.RemoveRange(0, 1);
                }                
            }
            return retList;
        }

        public static double StrList2double(List<string> l)
        {
            string s = "";
            for( int i=0; i<l.Count; i++)
            {
                s += l[i];
            }
            return Convert.ToDouble(s);
        }
    }
}
