using System;
using System.Diagnostics;
using System.Configuration;
using AlgorithmComparisonEngine.Data;

namespace AlgorithmComparisonEngine
{
    abstract class SortAlgorithmBase
    {
        readonly Func<string, bool> settingStatus = settingName => ConfigurationManager.AppSettings.Get(settingName) == "true";
        protected Stopwatch stopWatch = new Stopwatch();

        protected string alghoritmName;
        protected string alghoritmInformation;
        protected bool ascending;

        public SortAlgorithmBase()
        {
            ascending = settingStatus("AscendingOrder");
        }

        protected abstract void StartSort(int[] arrayToSort);

        // It uses ref because there is posibility to use it in the future for value types.
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
            SortRecords.AddRecord(alghoritmName, executeTime);
        }

        void PrintInformation()
        {
            if (settingStatus("AdditionalInfo"))
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

}