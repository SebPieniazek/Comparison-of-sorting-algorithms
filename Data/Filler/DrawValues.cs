using System;

namespace AlgorithmComparisonEngine.Data.Filler
{
    class DrawValues : DataStorageFiller
    {
        public DrawValues()
        {
            int userOutput;

            do
            {
                Interact.WriteText(ConsoleColor.Magenta, " How much digits you want to draw ? (compartment 2-10000)");
                userOutput = Interact.TakeUserOutput(10000);
            }
            while (!checkMinOutput(userOutput));

            dataStorage = new int[userOutput];

            Draw();

            DataStorage.SaveData(dataStorage);
        }

        void Draw()
        {
            Random rnd = new Random();
            for (int i = 0; i < dataStorage.Length - 1; i++)
            {
                dataStorage[i] = rnd.Next(-10000, 10000);
            }
        }
    }
}
