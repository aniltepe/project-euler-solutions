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
            List<string> lines = new List<string>();
            for (double D = 2; D <= 1000; D++ )
            {
                //if (D % 10 == 0)
                //{
                //    Console.WriteLine(D.ToString());
                //}
                if (IsSquare(D))
                {
                    continue;
                }
                double y = 1;
                while(true)
                {
                    double sqrY = Math.Pow(y, 2);
                    double sqrX = sqrY * D + 1;
                    if (IsSquare(sqrX))
                    {
                        Entry newEntry = new Entry();
                        newEntry.x = SquareRoot(sqrX);
                        newEntry.d = D;
                        newEntry.y = y;
                        entryList.Add(newEntry);
                        //Console.WriteLine(newEntry.d.ToString() + " - " + newEntry.x.ToString() + " " + newEntry.y.ToString());
                        lines.Add(newEntry.d.ToString() + " - " + newEntry.x.ToString() + " " + newEntry.y.ToString());
                        break;
                    }
                    y++;
                }
            }
            //Entry max = new Entry();
            //max.x = 0;
            //for (int i = 0; i < entryList.Count; i++)
            //{
            //    //Console.WriteLine(entryList[i].x.ToString() + " " + entryList[i].d.ToString() + " " + entryList[i].y.ToString());
            //    if (entryList[i].x > max.x)
            //    {
            //        max = entryList[i];
            //    }
            //}

            //Console.WriteLine("Maximum x is: " + max.x.ToString());
            //Console.WriteLine("D for maximum x is: " + max.d.ToString());
            //Console.ReadKey();
            System.IO.File.WriteAllLines(@"Z:\belgelerim\B5KUTKM\My Documents\Desktop\WriteLines.txt", lines.ToArray());
        }
        public static bool IsSquare(double n)
        {
            return Math.Pow(Math.Round(Math.Pow(n, 1.0 / 2)), 2) == n;
        }

        public static double SquareRoot(double n)
        {
            return Math.Round(Math.Pow(n, 1.0 / 2));
        }
    }
    class Entry
    {
        public double x { get; set; }
        public double y { get; set; }
        public double d { get; set; }
    }
}
