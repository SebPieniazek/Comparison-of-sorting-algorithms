using System;
using System.Configuration;
using System.Collections.Specialized;

namespace AlgorithmComparisonEngine
{

    class Program
    {
        static void Main()
        {
            Interact.ProgramInformation();
            do
            {
                _ = new Configuration();
                _ = new DataStorageFiller();
                bool repeat;
                Func<string, bool> settingStatus = settingName => ConfigurationManager.AppSettings.Get(settingName) == "true";

                do
                {
                    Interact.WriteText(ConsoleColor.Green, " Which algorithm you want to use ?\n  1.Bubble sort\n  2. Insert sort");

                    switch (Interact.TakeUserOutput(2))
                    {
                        case 1:
                            _ = new BubbleSort();
                            break;
                        case 2:
                            _ = new InsertSort();
                            break;
                        default:
                            break;
                    }

                    if (settingStatus("CompareAfterEveryUse") && Records.Id > 1)
                    {
                        Records.ShowRecords();
                    }

                    Interact.WriteText(ConsoleColor.Green, " Do you want to choose another algorithm ? \n 1. Yes \n 2. No");
                    repeat = (Interact.TakeUserOutput(2) == 1) ? true : false;

                } while (repeat);


            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
        // TODO#
        // Nazewnictwo
        // nie powinno sie zwracac exception i system exception - zbyt ogolne
        // dodać klasę Config która będzie konfigurowała to co chce widzieć użytkownik zamiast pytać co chwilę o wszystko.

}
