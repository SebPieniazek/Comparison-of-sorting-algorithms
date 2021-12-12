﻿using System;
using System.Collections.Generic;

namespace AlgorithmComparisonEngine
{
    static class Records
    {
        public static int Id { get; set; } = 1;
        record AlgorithmData(int Id, string Name, double Time);
        static List<AlgorithmData> algorithmsData = new List<AlgorithmData>();

        public static void AddRecord(string name, double time)
        {
            algorithmsData.Add(new AlgorithmData(Id, name, time));
            Id++;
        }

        public static void RemoveRecords()
        {
            algorithmsData.Clear();
            Id = 1;
        }


        public static void ShowRecords()
        {
                foreach (var record in algorithmsData)
                {
                    Interact.WriteText(ConsoleColor.Red, $" {record.Id}. {record.Name} execute time: {record.Time}");
                }

                Interact.WriteText(ConsoleColor.Red, $"\n The fastest algorithm for this data is {algorithmsData[FastestAlgorithm()].Name} !");
        }

        static int FastestAlgorithm()
        {
            double time = 0;
            int recordIndex = 1;

            foreach(var record in algorithmsData)
            {
                if(record.Id == 1 || record.Time < time)
                {
                    time = record.Time;
                    recordIndex = record.Id;
                }
            }

            return recordIndex - 1;
        }

    }
}
// powinno osobno porownywać rosnąco i malejąco