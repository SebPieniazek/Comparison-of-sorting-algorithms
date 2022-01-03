﻿using System;
using System.Configuration;

namespace AlgorithmComparisonEngine
{

    class Program
    {
        static readonly Func<string, bool> settingStatus = settingName => ConfigurationManager.AppSettings.Get(settingName) == "true";

        static void Main()
        {
            do
            {
                Console.Clear();

                Interact.ApplicationInfo();
                Interact.WriteText(ConsoleColor.DarkGreen, " 1. Select Alghoritm \n 2. Compare already used alghoritms \n 3. Configuration \n 4. Exit");

                switch (Interact.TakeUserOutput(4))
                {
                    case 1:
                        AlghoritmSelectionMenu();
                        break;
                    case 2:
                        Records.ShowRecords();
                        break;
                    case 3:
                        _ = new Configuration();
                        break;
                    case 4:
                        Environment.Exit(1);
                        break;
                }

            } while (true);

        }

        static void AlghoritmSelectionMenu()
        {
            bool repeat = true;

            if (!DataStorage.dataStorageFilled)
            {
                FillDataStorage();
            }

            do
            {
                Console.Clear();
                Interact.WriteText(ConsoleColor.Green, " Which algorithm you want to use ?\n  1. Bubble sort\n  2. Insert sort\n" +
                                                       "  3. Selection sort\n  4. Quick sort\n  5. Merge sort\n  6. Inser new data\n  7. Return");

                switch (Interact.TakeUserOutput(7))
                {
                    case 1:
                        _ = new BubbleSort();
                        break;
                    case 2:
                        _ = new InsertSort();
                        break;
                    case 3:
                        _ = new SelectionSort();
                        break;
                    case 4:
                        _ = new QuickSort();
                        break;
                    case 5:
                        _ = new MergeSort();
                        break;
                    case 6:
                        FillDataStorage();
                        Records.RemoveRecords();
                        break;
                    case 7:
                        repeat = false;
                        break;
                }

                if (settingStatus("CompareAfterEveryUse"))
                {
                    Records.ShowRecords();
                }

                if (repeat)
                {
                    Interact.WriteText(ConsoleColor.Green, " Do you want to select the next sorting alghoritm ? \n 1. Yes \n 2. No");
                    repeat = (Interact.TakeUserOutput(2) == 1);
                }

            } while (repeat);
        }

        static void FillDataStorage()
        {
            do
            {
                _ = new DataStorageFiller(parentInstantion: true);
            } while (!DataStorage.dataStorageFilled);
        }
    }
}
