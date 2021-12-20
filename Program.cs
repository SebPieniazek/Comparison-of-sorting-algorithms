using System;
using System.Configuration;

namespace AlgorithmComparisonEngine
{

    class Program
    {
        static void Main()
        {
            do
            {
                Console.Clear();
                Interact.ProgramInformation();
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


            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }

        static void AlghoritmSelectionMenu()
        {
            bool repeat;
            bool returnToMenu = false;
            Func<string, bool> settingStatus = settingName => ConfigurationManager.AppSettings.Get(settingName) == "true";

            if(!DataStorage.dataStorageFilled)
            {
                _ = new DataStorageFiller(parentInstantion: true);
            }

            do
            {
                Console.Clear();
                Interact.WriteText(ConsoleColor.Green, " Which algorithm you want to use ?\n  1.Bubble sort\n  2. Insert sort\n  3. Inser new data\n  4. Return");

                switch (Interact.TakeUserOutput(3))
                {
                    case 1:
                        _ = new BubbleSort();
                        break;
                    case 2:
                        _ = new InsertSort();
                        break;
                    case 3:
                        _ = new DataStorageFiller();
                        break;
                    case 4:
                        returnToMenu = true;
                        break;
                    default:
                        break;
                }

                if (settingStatus("CompareAfterEveryUse"))
                {
                    Records.ShowRecords();
                }

                Interact.WriteText(ConsoleColor.Green, " Do you want to choose another algorithm ? \n 1. Yes \n 2. No");
                repeat = (Interact.TakeUserOutput(2) == 1) ? true : false;

            } while (repeat || returnToMenu);
            Console.Clear();
        }
    }
        // TODO#
        // Nazewnictwo
        // nie powinno sie zwracac exception i system exception - zbyt ogolne
        // nie stosuje sie do app.config
        // w glownej petli zmienic read key na nieskonczona pentle
}
