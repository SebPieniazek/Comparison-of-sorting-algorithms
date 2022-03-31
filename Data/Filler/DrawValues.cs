using System;

namespace AlgorithmComparisonEngine.Data.Filler
{
    internal class DrawValues : DataStorageFiller
    {
        public DrawValues()
        {
            int userOutput;
            int maxDigits = 10000;

            do
            {
                Interact.WriteText(ConsoleColor.Magenta, " How much digits you want to draw ? (compartment 2-10000)");
                userOutput = Interact.TakeUserOutput(maxDigits);
            }
            while (!checkMinOutput(userOutput));

            dataStorage = new int[userOutput];

            Draw();

            DataStorage.SaveData(dataStorage);
        }

        private void Draw()
        {
            Random rnd = new Random();
            int minDigit = -10000;
            int maxDigit = 10000;

            for (int i = 0; i < dataStorage.Length - 1; i++)
            {
                dataStorage[i] = rnd.Next(minDigit, maxDigit);
            }
        }
    }
}
