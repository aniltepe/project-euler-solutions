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
                List<int> y = new List<int>() { 1 };
                while (true)
                {
                    List<int> sqrY = Square(y);
                    List<int> sqrX = Add(Multiply(sqrY, IntegerToList(D)), new List<int>() { 1 });
                    List<int> rootX = SquareRoot(sqrX);
                    if (!IsEqual(rootX, new List<int>()))
                    {
                        Entry newEntry = new Entry();
                        newEntry.x = rootX;
                        newEntry.d = D;
                        newEntry.y = y;
                        entryList.Add(newEntry);
                        newEntry.x.ForEach(d => Console.Write(d.ToString()));
                        Console.Write(" - " + newEntry.d.ToString());
                        Console.WriteLine();
                        break;
                    }
                    y = Add(y, new List<int>() { 1 });
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
            if (n[n.Count - 1] != 1 && n[n.Count - 1] != 4 && n[n.Count - 1] != 5 && n[n.Count - 1] != 6 && n[n.Count - 1] != 9 && !(n[n.Count - 2] == 0 && n[n.Count - 1] == 0))
            {
                return new List<int>();
            }
            List<int> initial = new List<int>() { 1 };
            if (n.Count > 2)
            {
                int multiplier = 1;
                if (n[0] >= 4 && n[0]<9)
                {
                    multiplier = 2;
                }
                else if (n[0] == 9)
                {
                    multiplier = 3;
                }
                bool isOdd = false;
                int limit = 0;
                if ((n.Count - 1) % 2 == 0)
                {
                    limit = (n.Count - 1) / 2;
                }
                else
                {
                    limit = (n.Count - 2) / 2;
                    isOdd = true;
                }
                for (int i = 0; i < limit; i++)
                {
                    initial.Add(0);
                }
                if (isOdd)
                {
                    initial[0] = 3;
                }
                if (multiplier > 1)
                {
                    initial = Multiply(initial, new List<int>() { multiplier });
                }
            }
            while (IsSmaller(Square(initial), n))
            {
               initial = Add(initial, new List<int>() { 1 });
            }
            if (IsEqual(Square(initial), n))
            {
                return initial;
            }
            else
            {
                return new List<int>();
            }
        }

        
        public static List<int> Square(List<int> n)
        {
            return Multiply(n, n);
        }

        public static bool IsSmaller(List<int> first, List<int> second)
        {
            if (first.Count < second.Count)
            {
                return true;
            }
            else if (first.Count > second.Count)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < first.Count; i++)
                {
                    if (first[i] < second[i])
                    {
                        return true;
                    }
                    else if (first[i] > second[i])
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            return false;
        }
        public static bool IsEqual(List<int> first, List<int> second)
        {
            if (first.Count != second.Count)
            {
                return false;
            }
            for (int i=0; i < first.Count; i++)
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