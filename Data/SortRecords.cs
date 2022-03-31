using System;
using System.Threading;
using System.Collections.Generic;

namespace AlgorithmComparisonEngine.Data
{
    // In this class the program stores a set of records, each record represents one use of the sort algorithm.
    static class SortRecords
    {
        private static int Id { get; set; } = 1;
        private record AlgorithmData(int Id, string AlghoritmName, double ExecuteTime);

        private readonly static List<AlgorithmData> algorithmsData = new List<AlgorithmData>();

        public static void AddRecord(string alghoritmName, double executeTime)
        {
            algorithmsData.Add(new AlgorithmData(Id++, alghoritmName, executeTime));
        }

        public static void RemoveRecords()
        {
            algorithmsData.Clear();
            Id = 1;
        }

        public static void ShowRecords()
        {
            if (Id > 1)
            {
                foreach (var record in algorithmsData)
                {
                    Interact.WriteText(ConsoleColor.Red, $" {record.Id}. {record.AlghoritmName} execute time: {record.ExecuteTime}");
                }

                Interact.WriteText(ConsoleColor.Red, $"\n The fastest algorithm for this data is {algorithmsData[FastestAlgorithm()].AlghoritmName} !");
                Interact.WriteText(ConsoleColor.Green, " Press any button to continue");
                Console.ReadLine();
            }
            else
            {
                Interact.WriteText(ConsoleColor.Red, "No data to compare, use some alghoritms and try again.");
                Thread.Sleep(2000);
            }
        }

        private static int FastestAlgorithm()
        {
            int bestRecordIndex = 1;
            double bestExecuteTime = 0;

            foreach (var record in algorithmsData)
            {
                if(record.Id == 1 || record.ExecuteTime < bestExecuteTime)
                {
                    bestExecuteTime = record.ExecuteTime;
                    bestRecordIndex = record.Id;
                }
            }

            return bestRecordIndex - 1;
        }

    }
}