using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.IO;

namespace ProjectEuler
{
    class Program54
    {
        public static string order = "2,3,4,5,6,7,8,9,10,11,12,13,14";
        public static int player1 = 0;
        public static int player2 = 0;
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"Z:\BELGELERIM\B5KUTKM\My Documents\Visual Studio 2017\Projects\ProjectEuler\ProjectEuler\p054_poker.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string[] cards = lines[i].Split(' ');
                string[][] p1cards = new string[5][];
                string[][] p2cards = new string[5][];
                for (int j = 0; j < cards.Length; j++)
                {
                    if (j < 5)
                    {
                        p1cards[j] = new string[2];
                        p1cards[j][0] = cards[j][0].ToString();
                        p1cards[j][1] = cards[j][1].ToString();
                    }
                    else
                    {
                        p2cards[j - 5] = new string[2];
                        p2cards[j - 5][0] = cards[j][0].ToString();
                        p2cards[j - 5][1] = cards[j][1].ToString();
                    }
                }
                FindWinner(p1cards, p2cards);
            }
            Console.WriteLine(player1.ToString());
            Console.WriteLine(player2.ToString());
            Console.ReadKey();
        }
        public static void FindWinner(string[][] p1, string[][] p2)
        {
            List<int> order1 = new List<int>();
            List<int> order2 = new List<int>();
            string ordr1 = "";
            string ordr2 = "";
            bool isSameSuit1 = true;
            bool isSameSuit2 = true;
            string firstSuit1 = "";
            string firstSuit2 = "";
            for (int i = 0; i < 5; i++)
            {
                if (i == 0) firstSuit1 = p1[i][1];
                else
                    if (p1[i][1] != firstSuit1) isSameSuit1 = false;
                if (i == 0) firstSuit2 = p2[i][1];
                else
                    if (p2[i][1] != firstSuit2) isSameSuit2 = false;
                if (p1[i][0] == "T")
                {
                    if (order1.Count == 0) order1.Add(10);
                    else
                    {
                        for (int j = 0; j < order1.Count; j++)
                        {
                            if (order1[j] < 10)
                            {
                                if (j == order1.Count - 1)
                                {
                                    order1.Add(10);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order1.Insert(j, 10);
                                break;
                            }
                        }
                    }
                }
                if (p1[i][0] == "J")
                {
                    if (order1.Count == 0) order1.Add(11);
                    else
                    {
                        for (int j = 0; j < order1.Count; j++)
                        {
                            if (order1[j] < 11)
                            {
                                if (j == order1.Count - 1)
                                {
                                    order1.Add(11);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order1.Insert(j, 11);
                                break;
                            }
                        }
                    }
                }
                if (p1[i][0] == "Q")
                {
                    if (order1.Count == 0) order1.Add(12);
                    else
                    {
                        for (int j = 0; j < order1.Count; j++)
                        {
                            if (order1[j] < 12)
                            {
                                if (j == order1.Count - 1)
                                {
                                    order1.Add(12);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order1.Insert(j, 12);
                                break;
                            }
                        }
                    }
                }
                if (p1[i][0] == "K")
                {
                    if (order1.Count == 0) order1.Add(13);
                    else
                    {
                        for (int j = 0; j < order1.Count; j++)
                        {
                            if (order1[j] < 13)
                            {
                                if (j == order1.Count - 1)
                                {
                                    order1.Add(13);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order1.Insert(j, 13);
                                break;
                            }
                        }
                    }
                }
                if (p1[i][0] == "A")
                {
                    if (order1.Count == 0) order1.Add(14);
                    else
                    {
                        for (int j = 0; j < order1.Count; j++)
                        {
                            if (order1[j] < 14)
                            {
                                if (j == order1.Count - 1)
                                {
                                    order1.Add(14);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order1.Insert(j, 14);
                                break;
                            }
                        }
                    }
                }
                if (p2[i][0] == "T")
                {

                    if (order2.Count == 0) order2.Add(10);
                    else
                    {
                        for (int j = 0; j < order2.Count; j++)
                        {
                            if (order2[j] < 10)
                            {
                                if (j == order2.Count - 1)
                                {
                                    order2.Add(10);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order2.Insert(j, 10);
                                break;
                            }
                        }
                    }
                }
                if (p2[i][0] == "J")
                {
                    if (order2.Count == 0) order2.Add(11);
                    else
                    {
                        for (int j = 0; j < order2.Count; j++)
                        {
                            if (order2[j] < 11)
                            {
                                if (j == order2.Count - 1)
                                {
                                    order2.Add(11);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order2.Insert(j, 11);
                                break;
                            }
                        }
                    }
                }
                if (p2[i][0] == "Q")
                {
                    if (order2.Count == 0) order2.Add(12);
                    else
                    {
                        for (int j = 0; j < order2.Count; j++)
                        {
                            if (order2[j] < 12)
                            {
                                if (j == order2.Count - 1)
                                {
                                    order2.Add(12);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order2.Insert(j, 12);
                                break;
                            }
                        }
                    }
                }
                if (p2[i][0] == "K")
                {
                    if (order2.Count == 0) order2.Add(13);
                    else
                    {
                        for (int j = 0; j < order2.Count; j++)
                        {
                            if (order2[j] < 13)
                            {
                                if (j == order2.Count - 1)
                                {
                                    order2.Add(13);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order2.Insert(j, 13);
                                break;
                            }
                        }
                    }
                }
                if (p2[i][0] == "A")
                {
                    if (order2.Count == 0) order2.Add(14);
                    else
                    {
                        for (int j = 0; j < order2.Count; j++)
                        {
                            if (order2[j] < 14)
                            {
                                if (j == order2.Count - 1)
                                {
                                    order2.Add(14);
                                    break;
                                }
                                else
                                    continue;
                            }
                            else
                            {
                                order2.Insert(j, 14);
                                break;
                            }
                        }
                    }
                }
                if (p1[i][0] != "T" && p1[i][0] != "J" && p1[i][0] != "Q" && p1[i][0] != "K" && p1[i][0] != "A")
                {
                    if (order1.Count == 0) order1.Add(Convert.ToInt32(p1[i][0]));
                    else
                    {
                        for (int j = 0; j < order1.Count; j++)
                        {
                            if (order1[j] < Convert.ToInt32(p1[i][0]))
                            {
                                if (j == order1.Count - 1)
                                {
                                    order1.Add(Convert.ToInt32(p1[i][0]));
                                    break;
                                }
                                else continue;
                            }
                            else
                            {
                                order1.Insert(j, Convert.ToInt32(p1[i][0]));
                                break;
                            }
                        }
                    }
                }
                if (p2[i][0] != "T" && p2[i][0] != "J" && p2[i][0] != "Q" && p2[i][0] != "K" && p2[i][0] != "A")
                {
                    if (order2.Count == 0) order2.Add(Convert.ToInt32(p2[i][0]));
                    else
                    {
                        for (int j = 0; j < order2.Count; j++)
                        {
                            if (order2[j] < Convert.ToInt32(p2[i][0]))
                            {
                                if (j == order2.Count - 1)
                                {
                                    order2.Add(Convert.ToInt32(p2[i][0]));
                                    break;
                                }
                                else continue;
                            }
                            else
                            {
                                order2.Insert(j, Convert.ToInt32(p2[i][0]));
                                break;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < order1.Count; i++)
            {
                ordr1 += order1[i].ToString();
                ordr1 += ",";
            }
            ordr1 = ordr1.TrimEnd(',');
            for (int i = 0; i < order2.Count; i++)
            {
                ordr2 += order2[i].ToString();
                ordr2 += ",";
            }
            ordr2 = ordr2.TrimEnd(',');
            if (isSameSuit1 && isSameSuit2)
            {
                int i1 = order.IndexOf(ordr1);
                int i2 = order.IndexOf(ordr2);
                if (i1 > i2) player1++;
                else if (i2 > i1) player2++;
                else
                {
                    for (int i = 1; i <= 5; i++)
                    {
                        if (order1[order1.Count - i] > order2[order2.Count - i])
                            player1++;
                        if (order1[order1.Count - i] < order2[order2.Count - i])
                            player2++;
                        continue;
                    }
                }
            }
            if (!isSameSuit1 && isSameSuit2)
            {
                //player1 full house ya da four of a kind yapmadıysa player2 kazanır
                List<int> temp = new List<int>(order1);
                for (int i = 0; i < temp.Count; i++)
                {
                    int item = temp[i];
                    temp.Remove(item);
                    if (!temp.Contains(item))
                        temp.Insert(i, item);
                }
                if (temp.Count == 2)
                    player1++;
                else
                    player2++;
            }
            if (isSameSuit1 && !isSameSuit2)
            {
                //player2 full house ya da four of a kind yapmadıysa player1 kazanır
                List<int> temp = new List<int>(order2);
                for (int i = 0; i < temp.Count; i++)
                {
                    int item = temp[i];
                    temp.Remove(item);
                    if (!temp.Contains(item))
                        temp.Insert(i, item);
                }
                if (temp.Count == 2)
                    player2++;
                else
                    player1++;
            }
            if (!isSameSuit1 && !isSameSuit2)
            {
                int count1 = 0;
                int max1 = 0;
                for (int i = 0; i < order1.Count; i++)
                {
                    int c = 1;
                    for (int j = 0; j < order1.Count; j++)
                    {
                        if (i == j) continue;
                        if (order1[i] == order1[j]) c++;
                    }
                    if (c > count1) { count1 = c; max1 = order1[i]; }
                    if (c == count1 && order1[i] > max1) max1 = order1[i];
                }
                int count2 = 0;
                int max2 = 0;
                for (int i = 0; i < order2.Count; i++)
                {
                    int c = 1;
                    for (int j = 0; j < order2.Count; j++)
                    {
                        if (i == j) continue;
                        if (order2[i] == order2[j]) c++;
                    }
                    if (c > count2) { count2 = c; max2 = order2[i]; }
                    if (c == count2 && order2[i] > max2) max2 = order2[i];
                }
                if (count1 > count2)
                {
                    if (order.IndexOf(ordr2) > 0)
                    {
                        if (count1 == 3)
                        {
                            List<int> temp1 = new List<int>(order1);
                            while (temp1.Contains(max1)) temp1.Remove(max1);
                            int _count1 = 0;
                            int _max1 = 0;
                            for (int i = 0; i < temp1.Count; i++)
                            {
                                int c = 1;
                                for (int j = 0; j < temp1.Count; j++)
                                {
                                    if (i == j) continue;
                                    if (temp1[i] == temp1[j]) c++;
                                }
                                if (c > _count1) { _count1 = c; _max1 = temp1[i]; }
                                if (c == _count1 && temp1[i] > _max1) _max1 = temp1[i];
                            }
                            if (_count1 == 2) player1++;
                            else player2++;
                        }
                        else
                        {
                            player2++;
                        }
                    }
                    else player1++;
                }
                else if (count2 > count1)
                {
                    if (order.IndexOf(ordr1) > 0)
                    {
                        if (count2 == 3)
                        {
                            List<int> temp2 = new List<int>(order2);
                            while (temp2.Contains(max2)) temp2.Remove(max2);
                            int _count2 = 0;
                            int _max2 = 0;
                            for (int i = 0; i < temp2.Count; i++)
                            {
                                int c = 1;
                                for (int j = 0; j < temp2.Count; j++)
                                {
                                    if (i == j) continue;
                                    if (temp2[i] == temp2[j]) c++;
                                }
                                if (c > _count2) { _count2 = c; _max2 = temp2[i]; }
                                if (c == _count2 && temp2[i] > _max2) _max2 = temp2[i];
                            }
                            if (_count2 == 2) player2++;
                            else player1++;
                        }
                        else
                        {
                            player1++;
                        }
                    }
                    else player2++;
                }
                else
                {
                    if (count1 == 4 || count1 == 3)
                    {
                        if (max1 > max2) player1++;
                        else if (max2 > max1) player2++;
                    }
                    else if (count1 == 1)
                    {
                        int i1 = order.IndexOf(ordr1);
                        int i2 = order.IndexOf(ordr2);
                        if (i1 > i2) player1++;
                        else if (i2 > i1) player2++;
                        else
                        {
                            if (max1 > max2) player1++;
                            else if (max2 > max1) player2++;
                            else
                            {
                                for (int i = 2; i <= 5; i++)
                                {
                                    if (order1[order1.Count - i] > order2[order2.Count - i])
                                        player1++;
                                    if (order1[order1.Count - i] < order2[order2.Count - i])
                                        player2++;
                                    continue;
                                }
                            }
                        }
                    }
                    else
                    {
                        List<int> temp1 = new List<int>(order1);
                        List<int> temp2 = new List<int>(order2);
                        while (temp1.Contains(max1)) temp1.Remove(max1);
                        while (temp2.Contains(max2)) temp2.Remove(max2);
                        int _count1 = 0;
                        int _max1 = 0;
                        for (int i = 0; i < temp1.Count; i++)
                        {
                            int c = 1;
                            for (int j = 0; j < temp1.Count; j++)
                            {
                                if (i == j) continue;
                                if (temp1[i] == temp1[j]) c++;
                            }
                            if (c > _count1) { _count1 = c; _max1 = temp1[i]; }
                            if (c == _count1 && temp1[i] > _max1) _max1 = temp1[i];
                        }
                        int _count2 = 0;
                        int _max2 = 0;
                        for (int i = 0; i < temp2.Count; i++)
                        {
                            int c = 1;
                            for (int j = 0; j < temp2.Count; j++)
                            {
                                if (i == j) continue;
                                if (temp2[i] == temp2[j]) c++;
                            }
                            if (c > _count2) { _count2 = c; _max2 = temp2[i]; }
                            if (c == _count2 && temp2[i] > _max2) _max2 = temp2[i];
                        }
                        if (_count1 > _count2) player1++;
                        else if (_count2 > _count1) player2++;
                        else
                        {
                            if (_count1 == 2)
                            {
                                if (_max1 > _max2) player1++;
                                else if (_max2 > _max1) player2++;
                                else
                                {
                                    List<int> _temp1 = new List<int>(temp1);
                                    List<int> _temp2 = new List<int>(temp2);
                                    while (_temp1.Contains(_max1)) _temp1.Remove(_max1);
                                    while (_temp2.Contains(_max2)) _temp2.Remove(_max2);
                                    if (_temp1[0] > _temp2[0]) player1++;
                                    else if (_temp2[0] > _temp1[0]) player2++;
                                }
                            }
                            else if (_count1 == 1)
                            {
                                if (max1 > max2) player1++;
                                else if (max2 > max1) player2++;
                                else
                                {
                                    if (_max1 > _max2) player1++;
                                    else if (_max2 > _max1) player2++;
                                    else
                                    {
                                        for (int i = 4; i <= 5; i++)
                                        {
                                            if (order1[order1.Count - i] > order2[order2.Count - i])
                                                player1++;
                                            if (order1[order1.Count - i] < order2[order2.Count - i])
                                                player2++;
                                            continue;
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
