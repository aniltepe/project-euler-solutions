using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program59
    {
        static void Main(string[] args)
        {
            string s = File.ReadAllText(@"Z:\BELGELERIM\B5KUTKM\My Documents\Visual Studio 2017\Projects\ProjectEuler\ProjectEuler\p059_cipher.txt");
            s = s.Replace("\n", "");
            string[] nos = s.Split(',');
            List<string> words = File.ReadAllLines(@"Z:\BELGELERIM\B5KUTKM\My Documents\Visual Studio 2017\Projects\ProjectEuler\ProjectEuler\p059_words.txt").ToList();
            for (int i =0; i < words.Count; i++)
                if (words[i].Length <= 4)
                {
                    words.RemoveAt(i);
                    i--;
                }
            for (int a=97; a<123; a++)  //a:97 z:123 in ASCII table
            {
                for (int b = 97; b < 123; b++)
                {
                    for (int c = 97; c < 123; c++)
                    {
                        string newText = "";
                        for (int i = 0; i < nos.Length; i++)
                        {
                            if ((i + 1) % 3 == 0) s = Int2BaseTwo(c.ToString());
                            if ((i + 1) % 3 == 1) s = Int2BaseTwo(a.ToString());
                            if ((i + 1) % 3 == 2) s = Int2BaseTwo(b.ToString());
                            int decrypted = BaseTwo2Int(XOR(Int2BaseTwo(nos[i]), s));
                            newText += (char)decrypted;
                        }
                        for (int i=0; i<words.Count; i++)
                        {
                            if (newText.Contains(words[i]))
                            {
                                int asciiSum = 0;
                                Console.WriteLine(newText);
                                Console.WriteLine("\n" + words[i] + "   " + i.ToString());
                                for (int j = 0; j < newText.Length; j++)
                                    asciiSum += newText[j];
                                Console.WriteLine(asciiSum.ToString());
                                Console.ReadKey();
                            }
                        }
                    }
                }
            }
            
            Console.ReadKey();
        }
        public static string Int2BaseTwo(string s)
        {
            string rtn = "";
            int n = Convert.ToInt32(s);
            while(n!=0)
            {
                rtn = (n % 2).ToString() + rtn;
                n = n / 2;
            }
            return rtn;
        }
        public static int BaseTwo2Int(string s)
        {
            int n = 0;
            for (int i=0; i<s.Length; i++)
                n += (int)(Convert.ToInt32(s[s.Length - 1 - i].ToString()) * Math.Pow(2, i));
            return n;
        }
        public static string XOR(string first, string second)
        {
            string s = "";
            int diff = first.Length - second.Length;
            if (diff > 0)
                for (int i = 0; i < diff; i++)
                    second = "0" + second;
            else
                for (int i = 0; i < diff * -1; i++)
                    first = "0" + first;
            for (int i=0; i<first.Length; i++)
            {
                if (first[i] == second[i])
                    s += "0";
                else
                    s += "1";
            }
            return s;
                
        }
    }
}
