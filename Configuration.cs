using System;
using System.Configuration;

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
            Func<string, bool> settingStatus = settingName => ConfigurationManager.AppSettings.Get(settingName) == "true";
            bool userExit = false;
            do
            {


                Console.Clear();
                Interact.ProgramInformation();

                Interact.WriteText(ConsoleColor.DarkRed, "CONFIGURATION MENU");

                ViewOptionStatus(settingStatus("AscendingOrder"));
                Interact.WriteText(ConsoleColor.Green, "  1. Ascending sorting order");

                ViewOptionStatus(settingStatus("AdditionalInfo"));
                Interact.WriteText(ConsoleColor.Green, "  2. Show additional information about alghoritms");

                ViewOptionStatus(settingStatus("ShowSortedData"));
                Interact.WriteText(ConsoleColor.Green, "  3. Show sorted data");

                ViewOptionStatus(settingStatus("ShowOriginalData"));
                Interact.WriteText(ConsoleColor.Green, "  4. Show orginal data");

                ViewOptionStatus(settingStatus("CompareAfterEveryUse"));
                Interact.WriteText(ConsoleColor.Green, "  5. Compare alghoritms after every use");

                Interact.WriteText(ConsoleColor.Green, "  6. Return");

                switch (Interact.TakeUserOutput(6))
                {
                    case 1:
                        ChangeSetting("AscendingOrder");
                        break;
                    case 2:
                        ChangeSetting("AdditionalInfo");
                        break;
                    case 3:
                        ChangeSetting("ShowSortedData");
                        break;
                    case 4:
                        ChangeSetting("ShowOriginalData");
                        break;
                    case 5:
                        ChangeSetting("CompareAfterEveryUse");
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

        void ChangeSetting(string name)
        {
            if (ConfigurationManager.AppSettings.Get(name) == "true")
                ConfigurationManager.AppSettings.Set(name, "false");
            else
                ConfigurationManager.AppSettings.Set(name, "true");
        }

    }
}
