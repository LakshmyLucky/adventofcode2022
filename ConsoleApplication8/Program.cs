using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        class Direct
        {
            public bool left;
            public bool right;
            public bool top;
            public bool bottom;
            public Direct(bool l, bool r, bool t, bool b)
            {
                left = l;
                right = r;
                top = t;
                bottom = b;
            }
        }
        class Item
        {
            public int num;
            public Direct dir;
            public Item(int n, Direct d)
            {
                num = n;
                dir = d;
            }
        }
        static List<List<Item>> GetArray(string[] input)
        {
            List<string> listInput = input.ToList();
            List<List<Item>> arrayList = new List<List<Item>>();

            for (int i = 0; i < listInput.Count; i++)
            {
                //Разбиваем строку поэлементно
                char[] chars = listInput[i].ToArray();
                List<Item> list = new List<Item>();

                for (int j = 0; j < chars.Length; j++)
                    //Все деревья видны со всех сторон
                    list.Add(new Item(int.Parse(chars[j].ToString()), 
                        new Direct(true, true, true, true)));

                arrayList.Add(list);
            }

            return arrayList;
        }

        static int CountTree(List<List<Item>> listTree)
        {
            int countEnd = 0, countInto = 0;

            countEnd = listTree.Count * 2 + (listTree[0].Count - 2) * 2;

            Console.WriteLine("countEnd = {0}", countEnd);
            //Перебираем строки
            for (int i = 0; i < listTree.Count; i++)
            {
                //Исключаем из рассмотрения первую и последнюю строки
                if (i > 0 && i < listTree.Count - 1)
                {
                    //Перебираем элементы строки
                    for (int j = 0; j < listTree.Count; j++)
                    {
                        List<Item> list = listTree[i];
                        if (j > 0 && j < list.Count - 1)
                        {
                            //Лево
                            for (int k = 0; k < j; k++)
                                if (list[k].num >= list[j].num)
                                {
                                    list[j].dir.left = false;
                                    k = j;
                                }
                            //Право
                            for (int k = j + 1; k < list.Count - 1; k++)
                                if (list[k].num >= list[j].num)
                                {
                                    list[j].dir.right = false;
                                    k = list.Count;
                                }
                        }
                    }
                }
            }

            //Перебираем столбцы
            int cols = listTree[0].Count;
            for (int j = 0; j < cols; j++)
            {
                //Исключаем из рассмотрения первый и последний столбец
                if (j > 0 && j < cols - 1)
                {
                    //Перебираем элементы столбца
                    for (int i = 0; i < listTree.Count; i++)
                    {
                        List<Item> list = listTree[j];
                        if (i > 0 && i < cols - 1)
                        {
                            //Верх
                            for (int k = 0; k < i; k++)
                                if (list[k].num >= list[i].num)
                                {
                                    list[i].dir.bottom = false;
                                    k = i;
                                }
                            //Низ
                            for (int k = i + 1; k < cols - 1; k++)
                                if (list[k].num >= list[i].num)
                                {
                                    list[i].dir.top = false;
                                    k = list.Count;
                                }
                        }
                    }
                    Console.WriteLine();
                }
            }

            return countInto;
        }
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input_test.txt");
            List<List<Item>> treeArray = GetArray(input);
            Console.WriteLine("countInto = {0}", CountTree(treeArray));

        }
    }
}
