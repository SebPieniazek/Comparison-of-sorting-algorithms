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
                //DataStorageFiller dataStorageFiller = new DataStorageFiller();
                _ = new DataStorageFiller();
                bool repeat;
                bool ascending;

                do
                {
                    Interact.WriteText(ConsoleColor.Green, " Did date should be order ascending ? \n 1. Yes \n 2. No");
                    ascending = Interact.TakeUserOutput(2) == 1 ? true : false;

                    Interact.WriteText(ConsoleColor.Green, " Which algorithm you want to use ?");
                    Interact.WriteText(ConsoleColor.Green, "  1. Bubble sort");
                    Interact.WriteText(ConsoleColor.Green, "  2. Insert sort");

                    switch (Interact.TakeUserOutput(2))
                    {
                        case 1:
                            //SortAlgorithm bubbleSort = new BubbleSort(ascending);
                            _ = new BubbleSort(ascending);
                            break;
                        case 2:
                            //SortAlgorithm insertSort = new InsertSort(ascending);
                            _ = new InsertSort(ascending);
                            break;
                        default:
                            break;
                    }

                    Interact.WriteText(ConsoleColor.Green, " Do you want to choose another algorithm ? \n 1. Yes \n 2. No");
                    repeat = (Interact.TakeUserOutput(2) == 1) ? true : false;


                } while (repeat);


            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

        }
    }
        // TODO#
        // Nazewnictwo
        // w ifach dodać interact take user == 1
        // nie powinno sie zwracac exception i system exception - zbyt ogolne
        // zrobic żeby porównywało algorytmy

}
