using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program65
    {
        static void Main(string[] args)
        {
            // e'nin 100. yakınsağının kaçıncı üçlüde olduğunu bul, kesirli sayıyı bul, rakamlarını topla
            List<int> convergentSeries = new List<int>();
            convergentSeries.Add(2);
            for (int i = 1; i < 100; i++)
            {
                if (i%3 == 0)
                {
                    convergentSeries.Add(1);
                    convergentSeries.Add(i / 3 * 2);
                    convergentSeries.Add(1);
                }
            }
            List<int> numerator = new List<int>() { 1 };
            List<int> denominator = new List<int>() { 1 };
            //List<int> operand = new List<int>() { 6, 6 };
            for (int i = 98; i >= 0; i--)
            {
                List<int> operand = IntegerToList(convergentSeries[i]);
                numerator = Add(Multiply(operand, denominator), numerator);
                if (i != 0)
                {
                    List<int> temp = new List<int>(denominator);
                    denominator = numerator;
                    numerator = temp;
                }                
            }
            int numeratorSum = 0;
            for (int i = 0; i < numerator.Count; i++)
            {
                numeratorSum += numerator[i];
            }
            Console.WriteLine(numeratorSum.ToString());

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
        public static List<int> IntegerToList(int n)
        {
            List<int> rtnList = new List<int>();
            string s = n.ToString();
            for (int i = 0; i < s.Length; i++)
                rtnList.Add(Convert.ToInt32(s[i].ToString()));
            return rtnList;
        }
    }
}
