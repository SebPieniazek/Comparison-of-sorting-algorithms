using System;
using System.Diagnostics;
using AlgorithmComparisonEngine.Data;

namespace AlgorithmComparisonEngine
{
    abstract class SortAlgorithmBase
    {
        protected Stopwatch stopWatch;

        protected string alghoritmName;
        protected string alghoritmInformation;
        protected bool ascending;

        public SortAlgorithmBase()
        {
            stopWatch = new Stopwatch();

            ascending = Configuration.settingStatus("AscendingOrder");
        }

        protected abstract void StartSort(int[] arrayToSort);

        // It uses ref to swap value types without returning anything.
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

        private void SaveAlghoritmData(double executeTime)
        {
            SortRecords.AddRecord(alghoritmName, executeTime);
        }

        private void PrintInformation()
        {
            if (Configuration.settingStatus("AdditionalInfo"))
            {
                Console.WriteLine();
                Interact.WriteText(ConsoleColor.Green, alghoritmInformation);
            }
        }

        private void PrintDataSet(int[] arrayToPrint)
        {
            if (Configuration.settingStatus("ShowSortedData"))
            {
                Interact.WriteText(ConsoleColor.Red, " Sorted array:");
                foreach (int i in arrayToPrint)
                {
                    Console.Write(i + " ");
                }

                Console.WriteLine();

                if (Configuration.settingStatus("ShowOriginalData"))
                {
                    DataStorage.PrintOriginalData();
                }
            }
        }
    }

}