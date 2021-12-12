using System;

namespace AlgorithmComparisonEngine
{

    class Program
    {
        static void Main()
        {
            Interact.WriteText(ConsoleColor.Red, "[Algorithm Comparison Engine] ver. 0.01 by Sebastian Pieniążek");
            do
            {
                _ = new DataStorageFiller();
                bool repeat;
                bool ascending;
                bool compare = false;

                do
                {
                    Interact.WriteText(ConsoleColor.Green, " Did date should be order ascending ? \n 1. Yes \n 2. No");
                    ascending = Interact.TakeUserOutput(2) == 1 ? true : false;

                    Interact.WriteText(ConsoleColor.Green, " Which algorithm you want to use ?\n  1.Bubble sort\n  2. Insert sort");

                    switch (Interact.TakeUserOutput(2))
                    {
                        case 1:
                            _ = new BubbleSort(ascending);
                            break;
                        case 2:
                            _ = new InsertSort(ascending);
                            break;
                        default:
                            break;
                    }

                    Interact.WriteText(ConsoleColor.Green, " Do you want to choose another algorithm ? \n 1. Yes \n 2. No");
                    repeat = (Interact.TakeUserOutput(2) == 1) ? true : false;

                    if (!compare)
                    {
                        Interact.WriteText(ConsoleColor.Green, " Do you want to compare them ? \n 1. Yes \n 2. No");
                        compare = (Interact.TakeUserOutput(2) == 1) ? true : false;
                    }
                    if(compare && Records.Id > 1)
                    {
                        Records.ShowRecords();
                    }

                } while (repeat);


            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
        // TODO#
        // Nazewnictwo
        // nie powinno sie zwracac exception i system exception - zbyt ogolne
        // dodać klasę Config która będzie konfigurowała to co chce widzieć użytkownik zamiast pytać co chwilę o wszystko.

}
