using System;

namespace AlgorithmComparisonEngine
{
    class Configuration
    {
        public Configuration()
        {
            ConfigurationMenu();
        }

        void ConfigurationMenu()
        {
            bool temp = false;
            bool userExit = false;

            do
            {
                Console.Clear();
                Interact.ProgramInformation();

                Interact.WriteText(ConsoleColor.DarkRed, "CONFIGURATION MENU");

                ViewOptionStatus(temp);
                Interact.WriteText(ConsoleColor.Green, "  1. Ascending sorting order");

                ViewOptionStatus(temp);
                Interact.WriteText(ConsoleColor.Green, "  2. Show additional information about alghoritms");

                ViewOptionStatus(temp);
                Interact.WriteText(ConsoleColor.Green, "  3. Show sorted data");

                ViewOptionStatus(temp);
                Interact.WriteText(ConsoleColor.Green, "  4. Show orginal data");

                ViewOptionStatus(temp);
                Interact.WriteText(ConsoleColor.Green, "  5. Compare alghoritms after every use");

                Interact.WriteText(ConsoleColor.Green, "  6. Return");

                switch (Interact.TakeUserOutput(6))
                {
                    case 1:
                        temp = !temp;
                        break;
                    case 2:
                        temp = !temp;
                        break;
                    case 3:
                        temp = !temp;
                        break;
                    case 4:
                        temp = !temp;
                        break;
                    case 5:
                        temp = !temp;
                        break;
                    case 6:
                        userExit = true;
                        break;
                }
            } while (!userExit);
        }
        void ViewOptionStatus(bool option)
        {
            Console.CursorLeft = Console.BufferWidth - 4;

            if (option)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("ON");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("OFF");
            }

            Console.CursorLeft = 0;
            Console.ResetColor();
        }
    }
}
