using System;
using System.Collections.Generic;

namespace AlgorithmComparisonEngine
{
    static class Records
    {
        public static int id = 1;
        record AlgorithmData(int id, string name, double time);
        static List<AlgorithmData> algorithmsData = new List<AlgorithmData>();

        public static void AddRecord(string name, double time)
        {
            algorithmsData.Add(new AlgorithmData(id, name, time));
            id++;
        }

        public static void RemoveRecords()
        {
            algorithmsData.Clear();
            id = 1;
        }


        public static void ShowRecords()
        {
                foreach (var record in algorithmsData)
                {
                    Interact.WriteText(ConsoleColor.Red, $" {record.id}. {record.name} execute time: {record.time}");
                }

                Interact.WriteText(ConsoleColor.Red, $"\n The fastest algorithm for this data is {algorithmsData[FastestAlgorithm()].name} !");
        }

        static int FastestAlgorithm()
        {
            double time = 0;
            int recordIndex = 1;


            foreach(var record in algorithmsData)
            {
                if(record.id == 1 || record.time < time)
                {
                    time = record.time;
                    recordIndex = record.id;
                }
            }

            return recordIndex - 1;
        }

    }
}
// porownywarka w innej klasie raczej.
// fastest alghorithm nie static ?
// id nie public ? właściwość
// powinno osobno porownywać rosnąco i malejąco