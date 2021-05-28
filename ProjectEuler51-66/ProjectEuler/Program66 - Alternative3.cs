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
            for (int D = 61; D <= 61; D++)
            {
                if (D % 10 == 0)
                {
                    Console.WriteLine(D.ToString());
                }
                if (IsSquare(D))
                {
                    continue;
                }
                double x = 2;
                while (true)
                {
                    if (IsSquare((x - 1) * (x + 1) / D))
                    {
                        Entry newEntry = new Entry();
                        newEntry.x = x;
                        newEntry.d = D;
                        entryList.Add(newEntry);
                        lines.Add(newEntry.d.ToString() + " - " + newEntry.x.ToString());
                        break;
                    }
                    x++;
                }
            }
            //Entry max = new Entry();
            //max.x = new List<int>() { 0 };
            //for (int i = 0; i < entryList.Count; i++)
            //{
            //    if (IsSmaller(max.x, entryList[i].x))
            //    {
            //        max = entryList[i];
            //    }
            //}

            //Console.Write("Maximum x is: ");
            //max.x.ForEach(digit => Console.Write(digit.ToString()));
            //Console.WriteLine();
            //Console.WriteLine("D for maximum x is: " + max.d.ToString());
            Console.ReadKey();
        }

        public static bool IsSquare(int n)
        {
            return Math.Pow(Math.Round(Math.Pow(n, 1.0 / 2)), 2) == n;
        }

        public static List<int> SquareRoot(List<int> n)
        {
            
        }


        public static List<int> Square(List<int> n)
        {
            return Multiply(n, n);
        }

        public static bool IsEqual(List<int> first, List<int> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }
            for (int i = 0; i < first.Count; i++)
            {
                if (first[i] != second[i])
                {
                    return false;
                }
            }
            return true;
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

        public static List<int> Substract(List<int> first, List<int> second)
        {
            List<int> rtnList = new List<int>();
            int excess = 0;
            int diff = first.Count - second.Count;
            if (diff > 0)
                for (int i = 0; i < diff; i++)
                    second.Insert(0, 0);
            else
            {
                List<int> temp = new List<int>(first);
                first = second;
                second = temp;
                for (int i = 0; i < diff; i++)
                    second.Insert(0, 0);
            }
            int idx = 0;
            while (first[idx] == second[idx])
            {
                idx++;
            }
            if (first[idx] < second[idx])
            {
                List<int> temp = new List<int>(first);
                first = second;
                second = temp;
            }
            for (int i = first.Count - 1; i >= 0; i--)
            {
                if (first[i] < second[i])
                {
                    first[i] += 10;
                    if (first[i - 1] == 0)
                        first[i - 1] = 9;
                    else
                        first[i - 1]--;
                }
                int a = first[i] - second[i];
                rtnList.Insert(0, a);
            }
            for (int i = 0; i < rtnList.Count; i++)
            {
                if (rtnList[i] != 0)
                {
                    break;
                }
                rtnList.RemoveAt(i);
                i--;
            }
            return rtnList;
        }

        public static List<int> Multiply(List<int> first, List<int> second)
        {
            List<int> rtnList = new List<int>() { 0 };
            for (int i = second.Count - 1; i >= 0; i--)
            {
                List<int> intrnal = new List<int>();
                int excess = 0;
                for (int j = first.Count - 1; j >= 0; j--)
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
        public static List<int> IntegerToList(int n)
        {
            List<int> rtnList = new List<int>();
            string s = n.ToString();
            for (int i = 0; i < s.Length; i++)
                rtnList.Add(Convert.ToInt32(s[i].ToString()));
            return rtnList;
        }
    }
    class Entry
    {
        public List<int> x { get; set; }
        public List<int> y { get; set; }
        public int d { get; set; }
    }
}