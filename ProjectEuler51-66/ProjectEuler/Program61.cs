using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program61
    {
        static void Main(string[] args)
        {
            int i = 1;
            List<int> tri = new List<int>();
            List<int> sqr = new List<int>();
            List<int> pen = new List<int>();
            List<int> hex = new List<int>();
            List<int> hep = new List<int>();
            List<int> oct = new List<int>();
            while (true)
            {
                int tria = i * (i + 1) / 2;
                int sqre = i * i;
                int pent = i * (3 * i - 1) / 2;
                int hexa = i * (2 * i - 1);
                int hept = i * (5 * i - 3) / 2;
                int octa = i * (3 * i - 2);
                if (tria >= 1000 && tria < 10000 && tria.ToString()[2]!='0') tri.Add(tria);
                if (sqre >= 1000 && sqre < 10000 && sqre.ToString()[2] != '0') sqr.Add(sqre);
                if (pent >= 1000 && pent < 10000 && pent.ToString()[2] != '0') pen.Add(pent);
                if (hexa >= 1000 && hexa < 10000 && hexa.ToString()[2] != '0') hex.Add(hexa);
                if (hept >= 1000 && hept < 10000 && hept.ToString()[2] != '0') hep.Add(hept);
                if (octa >= 1000 && octa < 10000 && octa.ToString()[2] != '0') oct.Add(octa);
                if (tria >= 10000 && sqre >= 10000 && pent >= 10000 && hexa >= 10000 && hept >= 10000 && octa >= 10000) break;
                i++;
            }
            List<List<int>> list = new List<List<int>>() { tri, sqr, pen, hex, hep, oct };

            for(int a=0;a<6;a++)
            {
                for (int a1=0; a1<list[a].Count; a1++)
                {
                    for (int b = 0; b < 6; b++)
                    {
                        if (a == b) continue;
                        for (int b1=0;b1<list[b].Count; b1++)
                        {
                            if (list[a][a1].ToString()[2] != list[b][b1].ToString()[0] || list[a][a1].ToString()[3] != list[b][b1].ToString()[1]) continue;
                            for (int c = 0; c < 6; c++)
                            {
                                if (b == c || a == c) continue;
                                for (int c1=0;c1<list[c].Count; c1++)
                                {
                                    if (list[b][b1].ToString()[2] != list[c][c1].ToString()[0] || list[b][b1].ToString()[3] != list[c][c1].ToString()[1]) continue;
                                    for (int d = 0; d < 6; d++)
                                    {
                                        if (c == d || b == d || a == d) continue;
                                        for (int d1=0;d1<list[d].Count; d1++)
                                        {
                                            if (list[c][c1].ToString()[2] != list[d][d1].ToString()[0] || list[c][c1].ToString()[3] != list[d][d1].ToString()[1]) continue;
                                            for (int e = 0; e < 6; e++)
                                            {
                                                if (d == e || c==e || b==e || a==e) continue;
                                                for (int e1=0; e1<list[e].Count; e1++)
                                                {
                                                    if (list[d][d1].ToString()[2] != list[e][e1].ToString()[0] || list[d][d1].ToString()[3] != list[e][e1].ToString()[1]) continue;
                                                    for (int f = 0; f < 6; f++)
                                                    {
                                                        if (e == f || d==f || c == f || b == f || a == f) continue;
                                                        for (int f1=0; f1<list[f].Count; f1++)
                                                        {
                                                            if (list[e][e1].ToString()[2] != list[f][f1].ToString()[0] || list[e][e1].ToString()[3] != list[f][f1].ToString()[1]) continue;
                                                            if (list[f][f1].ToString()[2] != list[a][a1].ToString()[0] || list[f][f1].ToString()[3] != list[a][a1].ToString()[1]) continue;
                                                            else
                                                            {
                                                                int sum = list[a][a1] + list[b][b1] + list[c][c1] + list[d][d1] + list[e][e1] + list[f][f1];
                                                                Console.WriteLine(sum.ToString());
                                                                Console.ReadKey();
                                                            }
                                                        }
                                                    }
                                                }
                                                
                                            }
                                        }
                                        
                                    }
                                }
                                
                            }
                        }
                        
                    }
                }
                
            }
        }
    }
}
