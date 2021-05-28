using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program64
    {
        static void Main(string[] args)
        {
            int oddPeriodCount = 0;
            for (int i = 2; i <= 10000; i++)
            {
                if (IsSquare(i))
                {
                    continue;
                }
                int closestSquare = i-1;
                while (!IsSquare(closestSquare))
                {
                    closestSquare--;
                }
                List<StepObject> sol = new List<StepObject>();
                List<List<StepObject>> solAlternates = new List<List<StepObject>>();
                solAlternates.Add(sol);
                StepObject obj = new StepObject();
                obj.a = Convert.ToInt32(Math.Round(Math.Pow(closestSquare, 1.0 / 2)));
                obj.denominator = 1;
                obj.negative = -1 * obj.a;
                sol.Add(obj);
                int trueIndex = -1;
                while (true)
                {
                    bool outerWhileBreak = false;
                    for (int j = 0; j < solAlternates.Count; j++)
                    {
                        bool forBreak = false;
                        StepObject prev = solAlternates[j][solAlternates[j].Count - 1];
                        int tempNegative = prev.negative * -1;
                        StepObject newObj = new StepObject();
                        newObj.denominator = (i - Convert.ToInt32(Math.Pow(prev.negative, 2))) / prev.denominator; 
                        int x = 1;
                        while (true)
                        {
                            if (x * newObj.denominator <= tempNegative)
                            {
                                x++;
                                continue;
                            }
                            else
                            {
                                if (x * newObj.denominator - tempNegative > sol[0].a)
                                {
                                    break;
                                }
                                if (newObj.negative == int.MinValue)
                                {
                                    newObj.negative = (x * newObj.denominator - tempNegative) * -1;
                                    newObj.a = x;
                                    solAlternates[j].Add(newObj);
                                    x++;
                                }
                                else
                                {
                                    List<StepObject> steps = new List<StepObject>();
                                    for (int h = 0; h < solAlternates[j].Count - 1; h++)
                                    {
                                        steps.Add(solAlternates[j][h]);
                                    }
                                    StepObject so = new StepObject();
                                    so.denominator = newObj.denominator;
                                    so.a = x;
                                    so.negative = (x * newObj.denominator - tempNegative) * -1;
                                    steps.Add(so);
                                    solAlternates.Add(steps);
                                    x++;
                                    j++;
                                }
                                if (solAlternates[j][solAlternates[j].Count - 1].a == solAlternates[j][0].a * 2 && solAlternates[j][solAlternates[j].Count - 1].negative == solAlternates[j][0].negative)
                                {
                                    trueIndex = j;
                                    forBreak = true;
                                    outerWhileBreak = true;
                                    break;
                                }
                            }
                        }
                        if (forBreak)
                        {
                            break;
                        }
                    }
                    if (outerWhileBreak)
                    {
                        break;
                    }
                }
                string prompt = i.ToString() + ": [";
                for (int j = 0; j < solAlternates[trueIndex].Count; j++)
                {
                    if (j == 0)
                    {
                        prompt += solAlternates[trueIndex][j].a.ToString() + ";(";
                        continue;
                    }
                    prompt += solAlternates[trueIndex][j].a.ToString() + ",";
                    if (j == solAlternates[trueIndex].Count - 1)
                    {
                        prompt = prompt.Remove(prompt.Length - 1, 1);
                        prompt += ")], period=";
                    }
                }
                int cou = solAlternates[trueIndex].Count - 1;
                prompt += cou.ToString();
                if (cou % 2 == 1)
                {
                    oddPeriodCount++;
                }
                Console.WriteLine(prompt);
            }
            Console.WriteLine("total odd count: " + oddPeriodCount.ToString());
            Console.ReadKey();
        }   
        public static bool IsSquare(int n)
        {
            return Math.Pow(Math.Round(Math.Pow(n, 1.0 / 2)), 2) == n;
        } 
    }
    class StepObject
    {
        public int negative = int.MinValue;
        public int denominator { get; set; }
        public int a { get; set; }
    }
}
