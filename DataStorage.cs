using System;


namespace AlgorithmComparisonEngine
{
    // In this class the application stores user data. I make it static,
    // because i want to let the user work on a single, global dataset.

    static class DataStorage
    {
        static int[] dataStorage;
        public static bool dataStorageFilled = false;

        public static void SaveData(int[] takenData)
        {
            dataStorage = takenData;
            dataStorageFilled = true;
        }

        public static int[] TakeData()
        {
            return (int[])dataStorage.Clone();
        }

        public static void PrintOriginalData()
        {
            Interact.WriteText(ConsoleColor.Red, " Original Data:");

            foreach(int i in dataStorage)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

    }
}
