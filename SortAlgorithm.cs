﻿using System;
using System.Diagnostics;

namespace AlgorithmComparisonEngine
{
    abstract class SortAlgorithm
    {
        protected string name;
        protected string information;
        protected int temp;
        protected int count = 1;
        protected double sortTime;
        protected bool sorted;
        protected bool ascending;
        protected static Stopwatch stopWatch = new Stopwatch();
        
        public abstract void StartSort(int[] arrayToSort);

        protected void InputData(int[] arrayToWrite)
        {
            sortTime = stopWatch.Elapsed.TotalMilliseconds;
            Interact.WriteText(ConsoleColor.Red, $" Posortowano w {sortTime} milisekund. Użyty Algorytm: {name}");
            SaveData();
            if (ShowData("sorted"))
            {
                Interact.WriteText(ConsoleColor.Red, " Posortowana tablica:");
                foreach (int i in arrayToWrite)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                if (ShowData("original"))
                {
                    DataStorage.PrintOrginalData();
                }
            }
        }

        protected bool ShowData(string dataType)
        {
            Interact.WriteText(ConsoleColor.Green, $"Do you want to see {dataType} data ?\n  1. Yes \n  2. No");
            return Interact.TakeUserOutput(2) == 1 ? true : false;
        }

        protected void SaveData()
        {
            Records.AddRecord(name, sortTime);
        }
    }

    class BubbleSort : SortAlgorithm
    {
        public BubbleSort(bool sortOrder)
        {
            name = "Bubble Sort";
            information = "Informations";
            ascending = sortOrder;
            StartSort(DataStorage.TakeData());
        }

        public override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();
            while (!sorted)
            {
                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    count++;
                    if (ascending)
                    {
                        if (arrayToSort[i] > arrayToSort[i + 1])
                        {
                            count = 1;
                            temp = arrayToSort[i + 1];
                            arrayToSort[i + 1] = arrayToSort[i];
                            arrayToSort[i] = temp;
                        }
                    }
                    else
                    {
                        if (arrayToSort[i] < arrayToSort[i + 1])
                        {
                            count = 1;
                            temp = arrayToSort[i + 1];
                            arrayToSort[i + 1] = arrayToSort[i];
                            arrayToSort[i] = temp;
                        }
                    }

                    if (count == arrayToSort.Length - 1)
                    {
                        count = 1;
                        sorted = true;
                    }
                }
            }
            sorted = false;
            stopWatch.Stop();
            InputData(arrayToSort);
        }
    }

    class InsertSort : SortAlgorithm
    {
        public InsertSort(bool sortOrder)
        {
            name = "Insert Sort";
            information = "Informations";
            ascending = sortOrder;
            StartSort(DataStorage.TakeData());
        }
        public override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();
            int singleValue;
            for (int i = 1; i < arrayToSort.Length; i++)
            {
                temp = i;
                singleValue = arrayToSort[i];
                while (i != 0)
                {
                    if (ascending)
                    {
                        if (arrayToSort[i] < arrayToSort[i - 1])
                        {
                            arrayToSort[i] = arrayToSort[i - 1];
                            arrayToSort[i - 1] = singleValue;
                            i--;
                        }
                        else break;
                    }
                    else
                    {
                        if (arrayToSort[i] > arrayToSort[i - 1])
                        {
                            arrayToSort[i] = arrayToSort[i - 1];
                            arrayToSort[i - 1] = singleValue;
                            i--;
                        }
                        else break;
                    }

                }
                i = temp;
            }
            stopWatch.Stop();
            InputData(arrayToSort);
        }

    }
}
// TODO
// Zrobić w klasie bazowej konstuktor zamiast w klasach pochodnych
// poszukac sposobu na zmienienie operatora > w zależności od tego jak ma byc sortowane
// poprawic ShowData. zła nazwa i sposób działania
// ascending = enum ?