using System;
using System.Configuration;

namespace AlgorithmComparisonEngine
{
    public class Configuration
    {
        public static readonly Func<string, bool> settingStatus = settingName => ConfigurationManager.AppSettings.Get(settingName) == "true";

        public Configuration()
        {
            ConfigurationMenu();
        }

        private void ConfigurationMenu()
        {
            bool userExit = false;

            do
            {
                Interact.ApplicationInfo();
                Console.Clear();

                Interact.WriteText(ConsoleColor.DarkRed, "CONFIGURATION MENU");

                ShowSettingStatus(settingStatus("AscendingOrder"));
                Interact.WriteText(ConsoleColor.Green, "  1. Ascending sorting order");

                ShowSettingStatus(settingStatus("AdditionalInfo"));
                Interact.WriteText(ConsoleColor.Green, "  2. Show additional informations about alghoritms");

                ShowSettingStatus(settingStatus("ShowSortedData"));
                Interact.WriteText(ConsoleColor.Green, "  3. Show sorted data");

                ShowSettingStatus(settingStatus("ShowOriginalData"));
                Interact.WriteText(ConsoleColor.Green, "  4. Show original data");

                ShowSettingStatus(settingStatus("CompareAfterEveryUse"));
                Interact.WriteText(ConsoleColor.Green, "  5. Compare alghoritms after every use");

                Interact.WriteText(ConsoleColor.Green, "  6. Return");

                switch (Interact.TakeUserOutput(6))
                {
                    case 1:
                        ChangeSettingStatus("AscendingOrder");
                        break;
                    case 2:
                        ChangeSettingStatus("AdditionalInfo");
                        break;
                    case 3:
                        ChangeSettingStatus("ShowSortedData");
                        break;
                    case 4:
                        ChangeSettingStatus("ShowOriginalData");
                        break;
                    case 5:
                        ChangeSettingStatus("CompareAfterEveryUse");
                        break;
                    case 6:
                        userExit = true;
                        break;
                }
            } while (!userExit);
        }

        // It shows the status of the options for the user on the right side of the console, if enabled - GREEN if disabled - RED
        private void ShowSettingStatus(bool settingStatus)
        {
            Console.CursorLeft = Console.BufferWidth - 4;

            if (settingStatus)
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

        // Changes the state of options in the app.config file.
        private void ChangeSettingStatus(string settingName)
        {
            if (ConfigurationManager.AppSettings.Get(settingName) == "true")
            {
                ConfigurationManager.AppSettings.Set(settingName, "false");
            }
            else
            {
                ConfigurationManager.AppSettings.Set(settingName, "true");
            }
        }

    }
}
