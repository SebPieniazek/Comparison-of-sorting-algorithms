using System;

namespace AlgorithmComparisonEngine.Data.Filler
{
    class TypeValues : DataStorageFiller
    {
        public TypeValues()
        {
            ChangeStringToInt(AskUserForDigits());
        }

        string AskUserForDigits()
        {
            string userOutput;
            bool goodOutput;

            do
            {
                Interact.WriteText(ConsoleColor.DarkRed, " The maximum length of a single value is 10 digits.;"// int = int32 = 32 bits = -2 147 483 648 to 2 147 483 647.
                                                        + "\n Compartment 2-10000."
                                                        + "\n A single value should be separated by ' ' space.");
                Interact.WriteText(ConsoleColor.Magenta, " Insert your date here:");

                goodOutput = IsDigitsOnly(userOutput = Console.ReadLine());
                if (!goodOutput)
                {
                    Interact.WriteText(ConsoleColor.Red, " Insert digits only !");
                }

            } while (!goodOutput);

            return userOutput;
        }
    }
}
