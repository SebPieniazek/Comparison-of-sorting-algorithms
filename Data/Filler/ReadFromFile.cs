using System;
using System.IO;

namespace AlgorithmComparisonEngine.Data.Filler
{
    class ReadFromFile : DataStorageFiller
    {
        public ReadFromFile()
        {
            AskUserForFile();
        }

        void AskUserForFile()
        {
            string filePath;
            string fileData = "";
            bool correctData = false;

            Interact.WriteText(ConsoleColor.Magenta, " How do you want to upload the data?\n  1. Insert file path \n  2. Insert file name(file should be in Project folder)");
            Interact.WriteText(ConsoleColor.DarkRed, "\n The maximum length of a single value is 10 digits !\n Compartment 2-10000\n A single value should be separated by ' ' space.");

            do
            {
                if (Interact.TakeUserOutput(2) == 1)
                {
                    filePath = TakeFilePathFromUser();
                }
                else
                {
                    filePath = TakeFileNameFromUser();
                }

                if (filePath != "false")
                {
                    fileData = File.ReadAllText(filePath);
                    correctData = IsDigitsOnly(fileData);

                    if (!correctData || fileData == "")
                    {
                        Interact.WriteText(ConsoleColor.Red, " File data contains letters or invalid special characters. Check file and try again.");
                    }
                }
            } while (!correctData || filePath == "false");

            ChangeStringToInt(fileData);
        }

        string TakeFilePathFromUser()
        {
            string filePath;

            Interact.WriteText(ConsoleColor.Red, @" Insert full path to the txt file. It should looks like C:\User\Destop\file.txt");
            filePath = Console.ReadLine();

            filePath = CheckFilePath(filePath);

            return filePath;
        }

        string TakeFileNameFromUser()
        {
            string fileName;
            string filePath = Environment.CurrentDirectory;

            // Get path to the project folder.
            filePath = Directory.GetParent(filePath).Parent.Parent.FullName;

            do
            {
                Interact.WriteText(ConsoleColor.Red, " Insert file name. It should be txt file !");
                fileName = Console.ReadLine();

                filePath += @$"\{fileName}";

                filePath = CheckFilePath(filePath);

            } while (filePath == "false");

            return filePath;
        }

        string CheckFilePath(string file)
        {
            if (!file.EndsWith(@".txt"))
            {
                file += @".txt";
            }

            if (!File.Exists(file))
            {
                Interact.WriteText(ConsoleColor.Red, " File doesn't exists or you input invalid file path ! Try again.");
                return "false";
            }

            return file;
        }

    }
}
