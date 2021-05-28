using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    class Program52
    {
        static void Main(string[] args)
        {
            int no = 1;
            while (true)
            {
                List<List<int>> allDigits = new List<List<int>>();
                foreach (int j in new int[] {1, 2, 3, 4, 5, 6})
                {
                    string s = Convert.ToString(no*j);
                    List<int> digits = new List<int>();
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (!digits.Contains(Convert.ToInt32(s[i])))
                        {
                            digits.Add(Convert.ToInt32(s[i]));
                        }
                    }
                    digits.Sort();
                    allDigits.Add(digits);
                }
                bool isSame = true;
                for (int i=0; i<allDigits.Count-1; i++)
                {
                    bool forBreak = false;
                    if (allDigits[i].Count == allDigits[i + 1].Count)
                    {
                        for (int j = 0; j < allDigits[i].Count; j++)
                        {
                            int v1 = allDigits[i][j];
                            int v2 = allDigits[i + 1][j];
                            if (v1 != v2)
                            {
                                isSame = false;
                                forBreak = true;
                                break;
                            }
                        }
                        if (forBreak)
                            break;
                    }
                    else
                    {
                        isSame = false;
                        break;
                    }
                }
                if (isSame)
                {
                    Console.WriteLine(no.ToString());
                    Console.ReadKey();
                }
                if (no%10000==0)
                    Console.WriteLine(no.ToString());
                no++; 
            }
        }
    }
}
