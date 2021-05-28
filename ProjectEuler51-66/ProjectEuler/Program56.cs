using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program56
    {
        static void Main(string[] args)
        {
            int max = 0;
            int a = -1, b = -1;
            for (int i=0; i<100; i++)
            {
                for (int j=0;j<100; j++)
                {
                    List<int> res = IntegerToList(1);
                    for (int h=0; h<j; h++)
                    {
                        res = Multiply(res, IntegerToList(i));
                    }
                    int sum = 0;
                    for (int h=0; h<res.Count; h++)
                    {
                        sum += res[h];
                    }
                    if (sum > max)
                    {
                        max = sum;
                        a = i;
                        b = j;
                    }
                }
            }
            Console.WriteLine(max.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(a.ToString());
            Console.ReadKey();
        }
        public static List<int> Multiply(List<int> first, List<int> second)
        {
            List<int> rtnList = IntegerToList(0);
            for (int i=second.Count-1; i>=0; i--)
            {
                List<int> intrnal = new List<int>();
                int excess = 0;
                for (int j=first.Count-1; j>=0; j--)
                {
                    int a = second[i] * first[j] + excess;
                    intrnal.Insert(0, a % 10);
                    excess = a / 10;
                    if (j == 0 && excess != 0)
                        intrnal.Insert(0, excess);
                }
                for (int j = 0; j < second.Count - 1 - i; j++)
                    intrnal.Add(0);
                rtnList = Add(rtnList, intrnal);
            }
            return rtnList;
        }
        public static List<int> Add(List<int> first, List<int> second)
        {
            List<int> rtnList = new List<int>();
            int excess = 0;
            int diff = first.Count - second.Count;
            if (diff > 0)
                for (int i = 0; i < diff; i++)
                    second.Insert(0, 0);
            else
                for (int i = 0; i < diff * -1; i++)
                    first.Insert(0, 0);
            for (int i = first.Count - 1; i >= 0; i--)
            {
                int a = first[i] + second[i] + excess;
                rtnList.Insert(0, a % 10);
                excess = a / 10;
                if (i == 0 && excess != 0)
                    rtnList.Insert(0, excess);
            }
            return rtnList;
        }
        public static List<int> IntegerToList(int n)
        {
            List<int> rtnList = new List<int>();
            string s = n.ToString();
            for (int i=0; i<s.Length; i++)
                rtnList.Add(Convert.ToInt32(s[i].ToString()));
            return rtnList;
        }
    }
}
