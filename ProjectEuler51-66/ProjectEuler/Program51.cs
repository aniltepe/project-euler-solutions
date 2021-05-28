using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Program51
    {
        static void Main(string[] args)
        {
            int no = 0;
            while (true)
            {
                List<List<List<int>>> set = new List<List<List<int>>>();
                string s = Convert.ToString(no);
                for (int i = 1; i < s.Length; i++)  //alt küme grubu sayısı
                {
                    List<List<int>> subsets = new List<List<int>>();
                    if (i == 1)
                    {
                        for (int j = 0; j < s.Length; j++)
                        {
                            List<int> subset = new List<int>();
                            subset.Add(j);
                            subsets.Add(subset);
                        }
                    }
                    else
                    {
                        List<List<int>> last = set.Last();
                        for (int j = 0; j < last.Count; j++)
                        {
                            int maxInSubset = last[j].Max();
                            for (int h = maxInSubset + 1; h < s.Length; h++)
                            {
                                List<int> subset = new List<int>(last[j]);
                                subset.Add(h);
                                subsets.Add(subset);
                            }
                        }
                    }
                    set.Add(subsets);
                }
                List<List<int>> serialSubsets = SerializeSubsets(set);
                for (int i=0; i<serialSubsets.Count; i++)
                {
                    List<int> family = new List<int>();
                    List<int> number = new List<int>();
                    for (int j=0;j<s.Length; j++)
                    {
                        number.Add(Convert.ToInt32(s[j].ToString()));
                    }
                    if (number[number.Count-1]==0 && serialSubsets[i].Contains(s.Length-1))
                    {
                        break;
                    }
                    for (int j=0; j<10; j++)
                    {
                        if (j == 0 && serialSubsets[i].Contains(0))
                            continue;
                        for (int h=0; h<serialSubsets[i].Count; h++)
                        {
                            number[serialSubsets[i][h]] = j;
                        }
                        family.Add(NumberFromList(number));
                    }
                    int count = 0;
                    for (int m = 0; m < family.Count; m++)
                    {
                        if (!IsPrime(family[m]))
                        {
                            count++;
                        }
                        if (count==3)
                        {
                            break;
                        }
                    }
                    if (family.Count - count == 8)
                    {
                        for (int m = 0; m < family.Count; m++)
                        {
                            Console.WriteLine(family[m].ToString());
                        }
                        Console.ReadKey();
                    }
                }
                if (no%10000==0)
                    Console.WriteLine(no.ToString());
                no++;
            }
        }
        public static bool IsPrime(int a)
        {
            if (a == 1) return false;
            int c= (int)Math.Ceiling(Math.Sqrt(a));
            for (int i=2; i<=c; i++)
            {
                if (a%i==0)
                {
                    return false;
                }
            }
            return true;
        }
        public static List<List<int>> SerializeSubsets(List<List<List<int>>> l)
        {
            List<List<int>> returnList = new List<List<int>>();
            for (int i=0; i<l.Count; i++)
            {
                for (int j=0; j<l[i].Count; j++)
                {
                    returnList.Add(l[i][j]);
                }
            }
            return returnList;
        }
        public static int NumberFromList(List<int> l)
        {
            string s = "";
            for (int i=0; i<l.Count; i++)
            {
                s += Convert.ToString(l[i]);
            }
            return Convert.ToInt32(s);
        }
    }
}
