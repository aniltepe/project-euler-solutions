using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program63
    {
        static void Main(string[] args)
        {
            int x = 1;
            List<List<int>> propers = new List<List<int>>();
            while (true)
            {
                bool whileBreak = false;
                List<int> y = new List<int>() { 1 };
                List<int> compareY = new List<int>(y);
                while (true)
                {
                    List<int> result = Power(y, x);
                    if (result.Count == x)
                    {
                        propers.Add(result);
                        Console.WriteLine("Count: " + propers.Count.ToString());
                    }
                    else if (result.Count > x)
                    {
                        break;
                    }
                    y = Add(y, new List<int>() { 1 });
                    if (y[0] == 1 && y[1] == 1)
                    {
                        whileBreak = true;
                        break;
                    }
                }
                if (whileBreak)
                {
                    break;
                }
                x++;
            }
            Console.WriteLine("END");
            Console.ReadKey();
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
        public static List<int> Power(List<int> number, int power)
        {
            List<int> rtnList = new List<int>() { 1 };
            for (int i = 0; i < power; i++)
            {
                rtnList = Multiply(rtnList, number);
            }
            return rtnList;
        }
    }
}
