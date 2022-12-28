using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace ConsoleApp9_1
{
    class Program
    {
        class Coordinates
        {
            public int i;
            public int j;
            public Coordinates(int _i, int _j)
            {
                i = _i;
                j = _j;
            }
        }
        class Item
        {
            public string name;
            public Coordinates coordinates;
            public Item(string _name, Coordinates _coordinates)
            {
                name = _name;
                coordinates = _coordinates;
            }
        }
        class Step
        {
            public string direction;
            public int count;
            public Step(string _direction, int _count)
            {
                direction = _direction;
                count = _count;
            }
        }

        static Item H = new Item("H", new Coordinates(0, 0));//Голова
        static Item T = new Item("T", new Coordinates(0, 0));//Хвост
        static HashSet<string> setCount = new HashSet<string>();

        #region Движение
        static void GoRight(int steps)
        {
            //Вправо
            for (int i = 0; i < steps; i++)
            {
                H.coordinates.j++;

                if (H.coordinates.j - T.coordinates.j == 2)
                {
                    T.coordinates.j++;
                    T.coordinates.i += H.coordinates.i - T.coordinates.i;
                    setCount.Add(T.coordinates.i.ToString() + "," + T.coordinates.j);
                }
            }
        }
        static void GoLeft(int steps)
        {
            //Влево
            for (int i = 0; i < steps; i++)
            {
                H.coordinates.j--;

                if (T.coordinates.j - H.coordinates.j == 2)
                {
                    T.coordinates.j--;
                    T.coordinates.i += H.coordinates.i - T.coordinates.i;
                    setCount.Add(T.coordinates.i.ToString() + "," + T.coordinates.j);
                }
            }
        }
        static void GoUp(int steps)
        {
            //Вверх
            for (int i = 0; i < steps; i++)
            {
                H.coordinates.i++;

                if (H.coordinates.i - T.coordinates.i == 2)
                {
                    T.coordinates.i++;
                    T.coordinates.j += H.coordinates.j - T.coordinates.j;
                    setCount.Add(T.coordinates.i.ToString() + "," + T.coordinates.j);
                }
            }
        }
        static void GoDown(int steps)
        {
            //Вниз
            for (int i = 0; i < steps; i++)
            {
                H.coordinates.i--;

                if (T.coordinates.i - H.coordinates.i == 2)
                {
                    T.coordinates.i--;
                    T.coordinates.j += H.coordinates.j - T.coordinates.j;
                    setCount.Add(T.coordinates.i.ToString() + "," + T.coordinates.j);
                }
            }
        }
        #endregion
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("input.txt");

            //Записываем все шаги в массив
            List<Step> steps = new List<Step>();
            for (int i = 0; i < input.Length; i++)
                steps.Add(new Step(input[i].Split(' ')[0], int.Parse(input[i].Split(' ')[1])));

            setCount.Add("0,0");
            for (int i = 0; i < steps.Count; i++)
            {
                switch (steps[i].direction)
                {
                    //Вправо
                    case "R":
                        GoRight(steps[i].count);
                        break;
                    //Вверх
                    case "U":
                        GoUp(steps[i].count);
                        break;
                    //Влево
                    case "L":
                        GoLeft(steps[i].count);
                        break;
                    //Вниз
                    case "D":
                        GoDown(steps[i].count);
                        break;
                }
            }

            Console.WriteLine("Количество шагов Т = {0}", setCount.Count);
        }
    }
}