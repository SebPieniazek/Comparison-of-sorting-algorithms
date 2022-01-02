using System;
using System.Diagnostics;
using System.Configuration;

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
        readonly Func<string, bool> settingStatus = settingName => ConfigurationManager.AppSettings.Get(settingName) == "true";

        public SortAlgorithm()
        {
            ascending = settingStatus("AscendingOrder");
        }

        public abstract void StartSort(int[] arrayToSort);

        public void Swap(ref int first, ref int second)
        {
            temp = first;
            first = second;
            second = temp;
        }

        protected void InputData(int[] arrayToWrite)
        {
            sortTime = stopWatch.Elapsed.TotalMilliseconds;
            Interact.WriteText(ConsoleColor.Red, $" Posortowano w {sortTime} milisekund. Użyty Algorytm: {name}");
            SaveData();
            if (settingStatus("ShowSortedData"))
            {
                Interact.WriteText(ConsoleColor.Red, " Posortowana tablica:");
                foreach (int i in arrayToWrite)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                if (settingStatus("ShowOriginalData"))
                {
                    DataStorage.PrintOrginalData();
                }
            }
        }

        protected void SaveData()
        {
            Records.AddRecord(name, sortTime);
        }
    }

    class BubbleSort : SortAlgorithm
    {
        public BubbleSort()
        {
            name = "Bubble Sort";
            information = "Informations";
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
        public InsertSort()
        {
            name = "Insert Sort";
            information = "Informations";
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

    class SelectionSort : SortAlgorithm
    {
        public SelectionSort()
        {
            name = "Selection Sort";
            information = "Informations";
            StartSort(DataStorage.TakeData());
        }

        public override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();

            int min = 0;
            int index = 0;
            int temp = 0;


            for (int i = 0; i < arrayToSort.Length; i++)
            {
                min = arrayToSort[i];
                for (int j = i; j < arrayToSort.Length; j++)
                {
                    if (ascending)
                    {
                        if (min >= arrayToSort[j])
                        {
                            min = arrayToSort[j];
                            index = j;
                        }
                    }
                    else
                    {
                        if (min <= arrayToSort[j])
                        {
                            min = arrayToSort[j];
                            index = j;
                        }
                    }
                }
                temp = arrayToSort[i];
                arrayToSort[i] = min;
                arrayToSort[index] = temp;
            }

            stopWatch.Stop();
            InputData(arrayToSort);
        }
    }

    class QuickSort : SortAlgorithm
    {
        public QuickSort()
        {
            name = "Quick Sort";
            information = "Informations";
            StartSort(DataStorage.TakeData());
        }

        public override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSortMethod(0, arrayToSort.Length, ref arrayToSort);

            stopWatch.Stop();
            InputData(arrayToSort);
        }

        void QuickSortMethod(int lowestElement, int HighestElement, ref int[] tab)
        {
            int min = lowestElement;
            int max = HighestElement - 1;
            int size = HighestElement - lowestElement;

            if (size > 1)
            {
                int compareElement = tab[max];

                while (min < max)
                {
                    while (tab[max] > compareElement && max > min)
                    {
                        max--;
                    }
                    while (tab[min] < compareElement && min <= max)
                    {
                        min++;
                    }
                    if (min < max)
                    {
                        Swap(ref tab[min], ref tab[max]);
                        min++;
                    }
                }
                QuickSortMethod(lowestElement, min, ref tab);
                QuickSortMethod(max, HighestElement, ref tab);
            }
        }
    }

    class MergeSort : SortAlgorithm
    {
        public MergeSort()
        {
            name = "Merge Sort";
            information = "Informations";
            StartSort(DataStorage.TakeData());
        }

        public override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();

            MergeSortMethod(0, arrayToSort.Length - 1, arrayToSort);

            stopWatch.Stop();
            InputData(arrayToSort);
        }

        void MergeSortMethod(int left, int right, int[] tab)
        {
            if (right - left > 1)
            {
                int divide = (left + right) / 2;
                MergeSortMethod(left, divide, tab);
                MergeSortMethod(divide + 1, right, tab);
                Merge(left, divide, right, tab);
            }
        }
        void Merge(int left, int mediana, int right, int[] tab)
        {
            int[] temp = new int[(mediana - left + 1) + (right - mediana + 1 + 1)];

            int index = 0;
            int startIndex = left;
            int secStartIndex = mediana + 1;

            while (startIndex <= mediana || secStartIndex <= right)
            {
                if (startIndex <= mediana && secStartIndex <= right)
                {
                    if (tab[startIndex] <= tab[secStartIndex])
                    {
                        temp[index++] = tab[startIndex++];
                    }
                    else
                    {
                        temp[index++] = tab[secStartIndex++];
                    }
                }
                else if (startIndex <= mediana && secStartIndex > right)
                {
                    temp[index++] = tab[startIndex++];
                }
                else if (startIndex > mediana && secStartIndex <= right)
                {
                    temp[index++] = tab[secStartIndex++];
                }
            }
            index = 0;
            for (startIndex = left; startIndex <= mediana; startIndex++)
            {
                tab[startIndex] = temp[index++];
            }
            for (secStartIndex = mediana + 1; secStartIndex <= right; secStartIndex++)
            {
                tab[secStartIndex] = temp[index++];
            }
        } //# dont works correctly
    }
}
// TODO
// poszukac sposobu na zmienienie operatora > w zależności od tego jak ma byc sortowane
// temp i count lokalnie a nie globalnie
// dodac wyswietlanie dodatkowych informacji
// StartSort zliczanie czasu i input zrobic w klasie bazowej a w pochodnych zrobić wysyłanie metody jako parametr ?