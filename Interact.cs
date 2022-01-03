using System;

namespace AlgorithmComparisonEngine
{
    static class Interact
    {
        static public void ApplicationInfo()
        {
            WriteText(ConsoleColor.Red, "[Comparison of sorting algorithms] ver. 0.9 by Sebastian Pieniążek");
            Console.WriteLine();
        }

        static public void WriteText(ConsoleColor textColor, string text)
        {
            Console.ForegroundColor = textColor;

            Console.WriteLine(text);

            Console.ResetColor();
        }

        static public int TakeUserOutput(int maxChoice)
        {
            int userChoice = 1;
            bool goodChoice;

            do
            {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                    goodChoice = true;
                }
                catch (Exception)
                {
                    goodChoice = false;
                    WriteText(ConsoleColor.Red, " Enter the number of the selected option !");
                }
                
                if (goodChoice == true && (userChoice > maxChoice || userChoice < 1))
                {
                    WriteText(ConsoleColor.Red, " Enter the number of the selected option !");
                    goodChoice = false;
                }

            } while (!goodChoice);

            return userChoice;
        }
    }
}
