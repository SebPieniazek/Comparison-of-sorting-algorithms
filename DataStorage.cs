using System;


namespace AlgorithmComparisonEngine
{
    static class DataStorage
    {
        static int[] dataStorage;

        public static void SaveData(int[] takenData)
        {
            dataStorage = takenData;
        }

        static int[] CopyData()
        {
            int[] copiedData;

            copiedData = (int[])dataStorage.Clone();

            return copiedData;
        }

        public static int[] TakeData()
        {
            return CopyData();
        }

        public static void PrintOrginalData()
        {
            Interact.WriteText(ConsoleColor.Red, " Orginal Data:");
            foreach(int i in dataStorage)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }


    }
}
