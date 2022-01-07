using System;
using System.Diagnostics;
using System.Configuration;

namespace AlgorithmComparisonEngine
{
    abstract class SortAlgorithm
    {
        readonly Func<string, bool> settingStatus = settingName => ConfigurationManager.AppSettings.Get(settingName) == "true";
        protected Stopwatch stopWatch = new Stopwatch();

        protected string alghoritmName;
        protected string alghoritmInformation;
        protected bool ascending;

        public SortAlgorithm()
        {
            ascending = settingStatus("AscendingOrder");
        }

        protected abstract void StartSort(int[] arrayToSort);

        protected void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        protected void PrintData(int[] arrayToPrint)
        {
            double executeTime = stopWatch.Elapsed.TotalMilliseconds;

            Interact.WriteText(ConsoleColor.Red, $" Sorted in {executeTime} miliseconds. Used Alghoritm: {alghoritmName}");

            SaveAlghoritmData(executeTime);

            PrintInformation();

            PrintDataSet(arrayToPrint);
        }

        void SaveAlghoritmData(double executeTime)
        {
            Records.AddRecord(alghoritmName, executeTime);
        }

        void PrintInformation()
        {
            if(settingStatus("AdditionalInfo"))
            {
                Console.WriteLine();
                Interact.WriteText(ConsoleColor.Green, alghoritmInformation);
            }
        }

        void PrintDataSet(int[] arrayToPrint)
        {
            if (settingStatus("ShowSortedData"))
            {
                Interact.WriteText(ConsoleColor.Red, " Sorted array:");
                foreach (int i in arrayToPrint)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();

                if (settingStatus("ShowOriginalData"))
                {
                    DataStorage.PrintOriginalData();
                }
            }
        }
    }

    class BubbleSort : SortAlgorithm
    {
        public BubbleSort()
        {
            alghoritmName = "Bubble Sort";
            alghoritmInformation = "Stable in-place Alghoritm\n" +
                                   "Space complexity:\n" +
                                   " O(1)\n" +
                                   "Time complexity:\n" +
                                   " Average - O(n^2)\n" +
                                   " Best - O(n)\n" +
                                   " Worst - O(n^2)\n" +
                                   "Best destiny for the algorithm:\n" +
                                   " Small data sets - This alghoritm is easy to implement\n";
            StartSort(DataStorage.TakeData());
        }

        protected override void StartSort(int[] arrayToSort)
        {
            bool swap;

            stopWatch.Reset();
            stopWatch.Start();
            do
            {
                swap = false;
                for (int i = 0; i < arrayToSort.Length - 1; i++)
                {
                    if (ascending)
                    {
                        if (arrayToSort[i] > arrayToSort[i + 1])
                        {
                            Swap(ref arrayToSort[i + 1], ref arrayToSort[i]);
                            swap = true;
                        }
                    }
                    else
                    {
                        if (arrayToSort[i] < arrayToSort[i + 1])
                        {
                            Swap(ref arrayToSort[i + 1], ref arrayToSort[i]);
                            swap = true;
                        }
                    }
                }
            } while (swap);
            stopWatch.Stop();
            PrintData(arrayToSort);
        }
    }

    class InsertSort : SortAlgorithm
    {
        public InsertSort()
        {
            alghoritmName = "Insert Sort";
            alghoritmInformation = "Stable in-place Alghoritm\n" +
                                   "Space complexity:\n" +
                                   " O(1)\n" +
                                   "Time complexity:\n" +
                                   " Average - O(n^2)\n" +
                                   " Best - O(n)\n" +
                                   " Worst - O(n^2)\n" +
                                   "Best destiny for the algorithm:\n" +
                                   " Small data sets - This alghoritm is easy to implement\n";
            StartSort(DataStorage.TakeData());
        }
        protected override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();
            int singleValue;
            int temp;
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
            PrintData(arrayToSort);
        }

    }

    class SelectionSort : SortAlgorithm
    {
        public SelectionSort()
        {
            alghoritmName = "Selection Sort";
            alghoritmInformation = "In-Stable in-place Alghoritm\n" +
                                   "Space complexity:\n" +
                                   " O(1)\n" +
                                   "Time complexity:\n" +
                                   " Average - O(n^2)\n" +
                                   " Best - O(n^2)\n" +
                                   " Worst - O(n^2)\n" +
                                   "Best destiny for the algorithm:\n" +
                                   " Small data sets - This alghoritm is easy to implement, but it has the worst time complexity\n";
            StartSort(DataStorage.TakeData());
        }

        protected override void StartSort(int[] arrayToSort)
        {
            int min;
            int index = 0;

            stopWatch.Reset();
            stopWatch.Start();

            for (int i = 0; i < arrayToSort.Length; i++)
            {
                min = arrayToSort[i];
                for (int j = i; j < arrayToSort.Length; j++)
                {
                    if (ascending)
                    {
                        if (min > arrayToSort[j])
                        {
                            min = arrayToSort[j];
                            index = j;
                        }
                    }
                    else
                    {
                        if (min < arrayToSort[j])
                        {
                            min = arrayToSort[j];
                            index = j;
                        }
                    }
                }
                Swap(ref arrayToSort[i], ref arrayToSort[index]);
            }

            stopWatch.Stop();
            PrintData(arrayToSort);
        }
    }

    class QuickSort : SortAlgorithm
    {
        public QuickSort()
        {
            alghoritmName = "Quick Sort";
            alghoritmInformation = "In-Stable in-place Alghoritm - Uses divide-and-conquern alghoritm\n" +
                                   "Space complexity:\n" +
                                   " O(n) or O(log n) - Depends on implementation\n" +
                                   "Time complexity:\n" +
                                   " Average - O(n log n)\n" +
                                   " Best - O(n log n)\n" +
                                   " Worst - O(n^2)\n" +
                                   "Best destiny for the algorithm:\n" +
                                   " Medium/Large data sets - This alghoritm uses recursion and it's moderately difficult to implement.\n It's one of the best sort alghoritms and is used in many libraries\n";
            StartSort(DataStorage.TakeData());
        }

        protected override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();

            QuickSortMethod(0, arrayToSort.Length, arrayToSort);

            stopWatch.Stop();
            PrintData(arrayToSort);
        }

        void QuickSortMethod(int lowestElement, int highestElement, int[] tab)
        {
            int min = lowestElement;
            int max = highestElement - 1;
            int size = highestElement - lowestElement;

            if (size > 1)
            {
                int comparentElement = tab[max];

                if (ascending)
                {
                    while (min < max)
                    {
                        while (tab[max] > comparentElement && max > min)
                        {
                            max--;
                        }
                        while (tab[min] < comparentElement && min <= max)
                        {
                            min++;
                        }
                        if (min < max)
                        {
                            Swap(ref tab[min], ref tab[max]);
                            min++;
                        }
                    }
                    QuickSortMethod(lowestElement, min, tab);
                    QuickSortMethod(max, highestElement, tab);
                }
                else
                {
                    while (min < max)
                    {
                        while (tab[max] < comparentElement && max > min)
                        {
                            max--;
                        }
                        while (tab[min] > comparentElement && min <= max)
                        {
                            min++;
                        }
                        if (min < max)
                        {
                            Swap(ref tab[min], ref tab[max]);
                            min++;
                        }
                    }
                    QuickSortMethod(lowestElement, min, tab);
                    QuickSortMethod(max, highestElement, tab);
                }
            }
        }
    }

    class MergeSort : SortAlgorithm
    {
        public MergeSort()
        {
            alghoritmName = "Merge Sort";
            alghoritmInformation = "Stable(in most implementations) non-in-place Alghoritm - Uses divide-and-conquern alghoritm\n" +
                                   "Space complexity:\n" +
                                   " O(n)\n" +
                                   "Time complexity:\n" +
                                   " Average - O(n log n)\n" +
                                   " Best - O(n log n)\n" +
                                   " Worst - O(n log n)\n" +
                                   "Best destiny for the algorithm:\n" +
                                   " Medium/Large data sets - This alghoritm uses recursion and it's moderately difficult to implement.\n";
            StartSort(DataStorage.TakeData());
        }

        protected override void StartSort(int[] arrayToSort)
        {
            stopWatch.Reset();
            stopWatch.Start();

            MergeSortMethod(0, arrayToSort.Length - 1, arrayToSort);

            stopWatch.Stop();
            PrintData(arrayToSort);
        }

        void MergeSortMethod(int leftPoint, int rightPoint, int[] tab)
        {
            if (rightPoint - leftPoint > 0)
            {
                int middlePoint = (leftPoint + rightPoint) / 2;
                MergeSortMethod(leftPoint, middlePoint, tab);
                MergeSortMethod(middlePoint + 1, rightPoint, tab);
                Merge(leftPoint, middlePoint, rightPoint, tab);
            }
        }
        void Merge(int leftPoint, int middlePoint, int rightPoint, int[] tab) // ugly code, needs to be refactored
        {
            int[] temp = new int[(middlePoint - leftPoint + 1) + (rightPoint - middlePoint + 1 + 1)];

            int index = 0;
            int startIndex = leftPoint;
            int secondStartIndex = middlePoint + 1;

            while (startIndex <= middlePoint || secondStartIndex <= rightPoint)
            {
                if (startIndex <= middlePoint && secondStartIndex <= rightPoint)
                {
                    if (ascending)
                    {
                        if (tab[startIndex] <= tab[secondStartIndex])
                        {
                            temp[index++] = tab[startIndex++];
                        }
                        else
                        {
                            temp[index++] = tab[secondStartIndex++];
                        }
                    }
                    else
                    {
                        if (tab[startIndex] >= tab[secondStartIndex])
                        {
                            temp[index++] = tab[startIndex++];
                        }
                        else
                        {
                            temp[index++] = tab[secondStartIndex++];
                        }
                    }
                }
                else if (startIndex <= middlePoint && secondStartIndex > rightPoint)
                {
                    temp[index++] = tab[startIndex++];
                }
                else if (startIndex > middlePoint && secondStartIndex <= rightPoint)
                {
                    temp[index++] = tab[secondStartIndex++];
                }
            }
            index = 0;
            for (startIndex = leftPoint; startIndex <= middlePoint; startIndex++)
            {
                tab[startIndex] = temp[index++];
            }
            for (secondStartIndex = middlePoint + 1; secondStartIndex <= rightPoint; secondStartIndex++)
            {
                tab[secondStartIndex] = temp[index++];
            }
        }
    }
}// #TODO
 // - The DRY rules were broken, need to be fixed.