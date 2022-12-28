using System;
using System.Collections.Generic;
using System.IO;

namespace adventofcode2022_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string>[] arr = new Stack<string>[9];

            for (int i = 0; i < arr.Length; i++)
                arr[i] = new Stack<string>();

            arr[0].Push("[Z]");
            arr[0].Push("[J]");
            arr[0].Push("[N]");
            arr[0].Push("[W]");
            arr[0].Push("[P]");
            arr[0].Push("[S]");

            arr[1].Push("[G]");
            arr[1].Push("[S]");
            arr[1].Push("[T]");

            arr[2].Push("[V]");
            arr[2].Push("[Q]");
            arr[2].Push("[R]");
            arr[2].Push("[L]");
            arr[2].Push("[H]");

            arr[3].Push("[V]");
            arr[3].Push("[S]");
            arr[3].Push("[T]");
            arr[3].Push("[D]");

            arr[4].Push("[Q]");
            arr[4].Push("[Z]");
            arr[4].Push("[T]");
            arr[4].Push("[D]");
            arr[4].Push("[B]");
            arr[4].Push("[M]");
            arr[4].Push("[J]");

            arr[5].Push("[M]");
            arr[5].Push("[W]");
            arr[5].Push("[T]");
            arr[5].Push("[J]");
            arr[5].Push("[D]");
            arr[5].Push("[C]");
            arr[5].Push("[Z]");
            arr[5].Push("[L]");

            arr[6].Push("[L]");
            arr[6].Push("[P]");
            arr[6].Push("[M]");
            arr[6].Push("[W]");
            arr[6].Push("[G]");
            arr[6].Push("[T]");
            arr[6].Push("[J]");

            arr[7].Push("[N]");
            arr[7].Push("[G]");
            arr[7].Push("[M]");
            arr[7].Push("[T]");
            arr[7].Push("[B]");
            arr[7].Push("[F]");
            arr[7].Push("[Q]");
            arr[7].Push("[H]");

            arr[8].Push("[R]");
            arr[8].Push("[D]");
            arr[8].Push("[G]");
            arr[8].Push("[C]");
            arr[8].Push("[P]");
            arr[8].Push("[B]");
            arr[8].Push("[Q]");
            arr[8].Push("[W]");

            string[] lines = File.ReadAllLines("input.txt");
            int count, from, to;
            for (int i = 10; i < lines.Length; i++)
            {
                lines[i] = lines[i].Replace("move ", " ");
                lines[i] = lines[i].Replace(" from ", " ");
                lines[i] = lines[i].Replace(" to ", " ");
                string[] str = lines[i].Trim().Split(' ');
                count = int.Parse(str[0]);
                from = int.Parse(str[1]) - 1;
                to = int.Parse(str[2]) - 1;

                for (int j = 0; j < count; j++)
                    arr[to].Push(arr[from].Pop());
            }
            string str1 = "";
            for (int i = 0; i < 9; i++)
            {
                str1 += arr[i].Pop();
            }

            Console.WriteLine(str1.Replace("[", "").Replace("]", ""));
        }
    }
}
