using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program62
    {
        static void Main(string[] args)
        {
            List<List<int>> cubes = new List<List<int>>();
            List<List<List<int>>> allCubePerms = new List<List<List<int>>>();
            int i = 344;
            int wordLength = 8;
            while(true) {
                List<List<int>> cubePerms = new List<List<int>>();
                i++;
                if (i%100 == 0)
                {
                    Console.WriteLine(i);
                }
                if (i == 384 || i == 405)
                {
                    Console.WriteLine("test");
                }
                List<int> l = IntegerToList(i);
                List<int> curr = Multiply(l, Multiply(l, l));
                //string curr = n.ToString();
                if (curr.Count > wordLength)
                {
                    bool is5exist = false;
                    for (int k = 0; k < allCubePerms.Count; k++)
                    {
                        if (allCubePerms[k].Count == 5)
                        {
                            is5exist = true;
                            break;
                        }
                    }
                    if (is5exist)
                    {
                        break;
                    }
                    else
                    {
                        wordLength = curr.Count;
                    }

                }
                cubes.Add(curr);
                cubePerms.Add(curr);
                allCubePerms.Add(cubePerms);
                for (int j = 0; j < cubes.Count - 1; j++)
                {
                    List<int> prev = new List<int>(cubes[j]);
                    List<int> current = new List<int>(curr);
                    if (prev.Count != current.Count)
                    {
                        continue;
                    }
                    else // (prev.Length == curr.Length)
                    {
                        for (int x=0; x < prev.Count; x++)
                        {
                            bool isExist = false;
                            for (int y = 0; y < current.Count; y++)
                            {
                                if (prev[x] == current[y])
                                {
                                    isExist = true;
                                    prev.RemoveAt(x);
                                    current.RemoveAt(y);
                                    x--;
                                    if (prev.Count == 0 && current.Count == 0)
                                    {
                                        allCubePerms[j].Add(curr);
                                    }
                                    break;
                                }
                            }
                            if (!isExist)
                            {
                                break;
                            }
                        }
                    }

                }
            }
            for (int h = 0; h < allCubePerms.Count; h++)
            {
                if (allCubePerms[h].Count == 5)
                {
                    for (int k = 0; k < allCubePerms[h].Count; k++)
                    {
                        for (int l = 0; l < allCubePerms[h][k].Count; l++)
                        {
                            Console.Write(allCubePerms[h][k][l]);
                        }
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();
        }

        public static List<int> IntegerToList(int n)
        {
            List<int> rtnList = new List<int>();
            string s = n.ToString();
            for (int i = 0; i < s.Length; i++)
                rtnList.Add(Convert.ToInt32(s[i].ToString()));
            return rtnList;
        }
        public static List<int> Multiply(List<int> first, List<int> second)
        {
            List<int> rtnList = IntegerToList(0);
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
    }
}
