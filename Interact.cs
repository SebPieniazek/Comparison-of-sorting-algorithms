using System;

namespace AlgorithmComparisonEngine
{
    static class Interact
    {
        static public void WriteText(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(text);

            Console.ResetColor();
        }

        static public int TakeUserOutput(int maxChoice)
        {
            int userChoice = 1;
            bool badChoice;
            do
            {
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                    badChoice = false;
                }
                catch (Exception _)
                {
                    badChoice = true;
                    WriteText(ConsoleColor.Red, " Put the number of the choosen option !");
                }
                
                if (badChoice == false && (userChoice > maxChoice || userChoice < 1))
                {
                    WriteText(ConsoleColor.Red, " Put the number of the choosen option !");
                    badChoice = true;
                }

            } while (badChoice);
            return userChoice;
        }

        static public void ProgramInformation()
        {
            WriteText(ConsoleColor.Red, "[Algorithm Comparison Engine] ver. 0.4 by Sebastian Pieniążek");
            Console.WriteLine();
        }

    }
}
