using System;
using System.Collections.Generic;

namespace AlgorithmComparisonEngine
{
    class Records
    {
        int id = 1;
        record AlgorithmData(int id, string name, double time);
        List<AlgorithmData> algorithmsData = new List<AlgorithmData>();

        void AddRecord(string name, double time)
        {
            algorithmsData.Add(new AlgorithmData(id, name, time));
            id++;
        }

        void RemoveRecords()
        {
            algorithmsData.Clear();
            id = 1;
        }

        void ShowRecords()
        {
            foreach(var record in algorithmsData)
            {
                Interact.WriteText(ConsoleColor.Red, $"{id}. {record.name} execute time: {record.time}");
            }

            Interact.WriteText(ConsoleColor.Red, $"\n The fastest algorithm for this data is {algorithmsData[FastestAlgorithm()].name} !");

        }

        int FastestAlgorithm()
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

            return recordIndex;
        }

    }
}
// porownywarka w innej klasie raczej.